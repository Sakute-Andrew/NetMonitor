using NetMonitor.service;

namespace NetMonitor.cli.handle_menu;

public class AuthorizedMenuService
{
    
    
    private MonitorService? monitorService;

    public AuthorizedMenuService()
    {
        monitorService = new MonitorServiceImpl();
    }
    
    public void handleMenu(int menuChoice)
    {
        switch (menuChoice)
        {
            case 1:
                logout();
                break;
            case 2:
                networkDevices();
                break;
            case 3:
                tcpDump();
                break;
            case 4:
                networkSpeed();
                break;
            
        }
        
    }

    public void logout()
    {
        
    }

    public void networkDevices()
    {
        monitorService.showDevices();
    }

    public void tcpDump()
    {
        monitorService.showTcpIpTraffic();
    }

    public void networkSpeed()
    {
        monitorService.showPackageSpeed();
    }
}