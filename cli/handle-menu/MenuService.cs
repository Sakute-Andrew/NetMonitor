using NetMonitor.service;

namespace NetMonitor.cli.handle_menu;

public class MenuService
{
    private AuthService authService;

    public MenuService()
    {
        authService = new AuthServiceImpl();
    }
    public void handleMenu(int menuChoice)
    {
        switch (menuChoice)
        {
            case 1:
                authorization();
                break;
            case 2:
                registration();
                break;
            case 3:
                info();
                break;
            case 4:
                break;
        }
        
    }

    private void authorization()
    {
        
        
    }

    private void registration()
    {
        
    }

    private void info()
    {
        
    }

    private void printInfo()
    {
        
    }
    

    private string[] getInfo()
    {
        string username = Console.ReadLine();
        Console.WriteLine("Enter your email:");
        string email = Console.ReadLine();
        Console.WriteLine("Enter your password:");
        string password = Console.ReadLine();
        
        return new string[] { username, email, password };
    }
}