// See https://aka.ms/new-console-template for more information

using System.Text.Json;
using NetMonitor.entities;
using NetMonitor.repo;
using NetMonitor.service;
using SharpPcap;

namespace NetMonitor;

static class MainClass{
    
    public static void Main(string[] args)
    {
        User user = new User("jopa", "jopa@example", "jopa123", Role.USER);
        
        string json = JsonSerializer.Serialize(user);
        string json2 = user.serializeToJson();
        Console.WriteLine(json);
        Console.WriteLine(json2);

        Serializer ser = new Serializer();
        
        // var devices = CaptureDeviceList.Instance;
        // foreach (var dev in devices)
        //     Console.WriteLine("{0}\n", dev.ToString());
        // MonitorService service = new MonitorServiceImpl();
        // service.showPackageSpeed();
    }
    
}