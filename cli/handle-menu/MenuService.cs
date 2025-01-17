using NetMonitor.service;

namespace NetMonitor.cli.handle_menu;

public class MenuService
{
    private AuthService authService;
    private CliService cliService;
    

    public MenuService()
    {
        authService = new AuthServiceImpl();
        cliService = new CliServiceImpl();
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
            
        }
        
    }

    private void authorization()
    {
        Console.WriteLine("Введіть ім'я: ");
        string username = Console.ReadLine();
        if (!authService.IsUsernameExist(username))
        {
            Console.WriteLine("Такого користувача не існує!");
            return;
        }
        
        Console.WriteLine("Введіть пароль: ");
        string password = Console.ReadLine();
        
        
        authService.Login(username, password);   
        if (authService.IsLoggedIn())
        {
            authMenu();
        }
    }

    private void registration()
    {
        string[] userInput = getInfo();
        authService.Register(userInput[0],userInput[1], userInput[2]);
        if (authService.IsLoggedIn())
        {
            authMenu();
        }
    }

    private void info()
    {
        
    }

    private void authMenu()
    {
        cliService.initAuthorisedMenu();
    }

    private string[] getInfo()
    {
        Console.WriteLine("Enter user name: ");
        string username = Console.ReadLine();
        Console.WriteLine("Enter your email:");
        string email = Console.ReadLine();
        Console.WriteLine("Enter your password:");
        string password = Console.ReadLine();
        
        return new string[] { email, username, password };
    }
}