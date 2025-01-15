using NetMonitor.service;

namespace NetMonitor.cli.handle_menu;

public class MenuService
{
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
                handling();
                break;
        }
        
    }

    private void authorization()
    {
        Console.WriteLine("Authorization\n Enter your username:");
        string username = Console.ReadLine();
        Console.WriteLine("Enter your email:");
        string email = Console.ReadLine();
        Console.WriteLine("Enter your password:");
        string password = Console.ReadLine();
        
    }

    private void registration()
    {
        
    }

    private void info()
    {
        
    }

    private void handling()
    {
        
    }

    private void getInfo()
    {
        string username = Console.ReadLine();
        Console.WriteLine("Enter your email:");
        string email = Console.ReadLine();
        Console.WriteLine("Enter your password:");
        string password = Console.ReadLine();
        
    }
}