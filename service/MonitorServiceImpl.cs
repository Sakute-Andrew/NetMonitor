using NetMonitor.repo;
using SharpPcap;
using SharpPcap.LibPcap;
using SharpPcap.Statistics;

namespace NetMonitor.service;

public class MonitorServiceImpl : MonitorService
{
    private Version ver;
    private LibPcapLiveDeviceList devices;

    static ulong oldSec = 0;
    static ulong oldUsec = 0;
    
    

    public MonitorServiceImpl()
    {
        devices = LibPcapLiveDeviceList.Instance;
    }


    public void showDevices()
    {
        // If no devices were found print an error
        if (devices.Count < 1)
        {
            throw new Exception("Пристрої не знайдено");
        }

        Console.WriteLine("\nНа цьому комп'ютерi наявнi наступнi пристрої:");
        Console.WriteLine("----------------------------------------------------\n");

        string output = "";
        int i = 0;
        /* Scan the list printing every entry */
        foreach (var dev in devices)
        {
            Console.WriteLine("{0}) {1} {2}", i, dev.Name, dev.Description);
            i++;
        }
    }

    public void showPackageSpeed()
    {
        try
        {
        showDevices();
        
        Console.WriteLine();
        Console.Write("---- Будь ласка, оберiть пристрiй який бажаєте прослуховувати: ");
        int i = int.Parse(Console.ReadLine());
        
            var description = devices[i].Description;
        
        
        
        using var device = new StatisticsDevice(devices[i].Interface);

        device.OnPcapStatistics += device_OnPcapStatistics;

        // Open the device for capturing
        device.Open();

        // Handle TCP packets only
        device.Filter = "tcp";

        Console.WriteLine();
        Console.WriteLine("-- Отримую данi вiд \"{0}\", нажмiть будь яку клавiшу для зупинки...",
            device.Description);
        
        // Start the capturing process
        device.StartCapture();

        // Wait for 'Enter' from the user.
        Console.ReadLine();

        // Stop the capturing process
        device.StopCapture();

        // Print out the device statistics
        Console.WriteLine(device.Statistics.ToString());

        Console.WriteLine("Запис закiнчено, пристрiй вiдключено.");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Непередбачена помилка: {e.Message}");
            Console.WriteLine("Натиснiть Enter для продовження...");
            Console.ReadLine();
        }
    }

    public void showTcpIpTraffic()
    {
        try
        {
        showDevices();
        Console.WriteLine();
        Console.Write("---- Будь ласка, оберiть пристрiй який бажаєте прослуховувати: ");
        int i = int.Parse(Console.ReadLine());

        
            using var device = devices[i];
        
        

        //Register our handler function to the 'packet arrival' event
        device.OnPacketArrival += device_OnPacketArrival;

        // Open the device for capturing
        int readTimeoutMilliseconds = 1000;
        device.Open(DeviceModes.Promiscuous, readTimeoutMilliseconds);

        //tcpdump filter to capture only TCP/IP packets
        string filter = "ip and tcp";
        device.Filter = filter;

        Console.WriteLine();
        Console.WriteLine
        ("-- Наступний фiльтр tcpdump буде застосовано: \"{0}\"",
            filter);
        Console.WriteLine
        ("-- Прослуховую {0}, нажмiть 'Enter' для зупинки...",
            device.Description);
        
        // Start capture 'INFINTE' number of packets
        device.StartCapture();
        
        
        Console.ReadLine();
        Console.WriteLine("Прослуховування завершено, кiлькiсть з'єднань: " + device.Statistics.ReceivedPackets);
        device.StopCapture();
        }
        catch (Exception e)
        {
            Console.WriteLine($"Непередбачена помилка: {e.Message}");
            Console.WriteLine("Натиснiть Enter для продовження...");
            Console.ReadLine();
        }
    }

    private static void device_OnPcapStatistics(object sender, StatisticsEventArgs e)
    {
        // Calculate the delay in microseconds from the last sample.
        // This value is obtained from the timestamp that's associated with the sample.
        ulong delay = (e.Timeval.Seconds - oldSec) * 1000000 - oldUsec + e.Timeval.MicroSeconds;

        // Get the number of Bits per second
        ulong bps = ((ulong)e.ReceivedBytes * 8 * 1000000) / delay;

        // Get the number of Packets per second
        ulong pps = ((ulong)e.ReceivedPackets * 1000000) / delay;

        // Convert the timestamp to readable format
        var ts = e.Timeval.Date.ToLongTimeString();

        // Print Statistics
        Console.WriteLine("[Час - {0}]: Бiтiв: [{1}], Пакетiв: [{2}]", ts, bps, pps);

        //store current timestamp
        oldSec = e.Timeval.Seconds;
        oldUsec = e.Timeval.MicroSeconds;
    }

    private static void device_OnPacketArrival(object sender, PacketCapture e)
    {
        var time = e.Header.Timeval.Date;
        var len = e.Data.Length;
        var rawPacket = e.GetPacket();

        var packet = PacketDotNet.Packet.ParsePacket(rawPacket.LinkLayerType, rawPacket.Data);

        var tcpPacket = packet.Extract<PacketDotNet.TcpPacket>();
        if (tcpPacket != null)
        {
            var ipPacket = (PacketDotNet.IPPacket)tcpPacket.ParentPacket;
            System.Net.IPAddress srcIp = ipPacket.SourceAddress;
            System.Net.IPAddress dstIp = ipPacket.DestinationAddress;
            int srcPort = tcpPacket.SourcePort;
            int dstPort = tcpPacket.DestinationPort;

            
            Console.WriteLine("{0}:{1}:{2},{3} Byte={4} From {5}:{6} -> To {7}:{8}",
                time.Hour, time.Minute, time.Second, time.Millisecond, len,
                srcIp, srcPort, dstIp, dstPort);
        }
    }
}