// See https://aka.ms/new-console-template for more information


using NetMonitor.wrapper;



namespace NetMonitor;

static class MainClass{
    
    public static void Main(string[] args)
    {
        
        
        
        // User user = new User("admin", "admin@example", "admin123");
        // Console.WriteLine(user.toString());
        // string json = JsonSerializer.Serialize<User>(user);
        // Console.WriteLine(json);
        PcapWrapper pcapWrapper = new PcapWrapper();
        pcapWrapper.GetDevices();
    }
    
}