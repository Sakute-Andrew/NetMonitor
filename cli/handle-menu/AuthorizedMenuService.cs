using NetMonitor.service;

namespace NetMonitor.cli.handle_menu;

public class AuthorizedMenuService
{
    public readonly string[] info = new[]
    {
        "Ласкаво просимо до NetMonitor!\n" +
        "Ця програма створена для монiторингу мережевого трафiку вашого пристрою.\n" +
        "Вона дозволяє:\n" +
        "  - Переглядати доступнi мережевi пристрої на комп'ютерi.\n" +
        "  - Відстежувати мережевий трафiк у режимi реального часу за допомогою tcpdump.\n" +
        "  - Аналізувати кількість i розмiр мережевих пакетiв.\n"
    };


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
                networkDevices();
                break;
            case 2:
                tcpDump();
                break;
            case 3:
                networkSpeed();
                break;
            case 4:
                infoPrint();
                break;
            
        }
        
    }

    public void logout()
    {
        return;
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

    public void infoPrint()
    {
        Console.WriteLine(info.FirstOrDefault());
    }
}