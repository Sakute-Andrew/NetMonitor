namespace NetMonitor.entities;

public class Device
{
    private char ipAddress { get; set; }
    private char macAddress { get; set; }
    private char Hostname { get; set; }
    private char Ports { get; set; }

    public Device(char ipAddress, char macAddress, char hostname, char Ports)
    {
        this.ipAddress = ipAddress;
        this.macAddress = macAddress;
        this.Hostname = Hostname;
        this.Ports = Ports;
    }
}