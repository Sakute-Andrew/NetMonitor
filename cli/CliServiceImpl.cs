using NetMonitor.cli.handle_menu;
using NotImplementedException = System.NotImplementedException;

namespace NetMonitor.cli;

public class CliServiceImpl : CliService
{
    
    private readonly string[] menu = new[]
    {
        "Welcome to NetMonitor\n" +
        "1.Log in \n" +
        "2.Register\n" +
        "3.See info\n" +
        "4.Exit"
    };
    
    private readonly string[] authorizedMenu = new[]
    {
        "Welcome to NetMonitor\n" +
        "1.Log out \n" +
        "2.See available network devices\n" +
        "3.See TcpDump\n" +
        "4.See network speed\n" +
        "5.Exit"
    };
    
    public void initMenu()
    {
        int programRun = 0;
        MenuService menuService = new MenuService();
        while (programRun != 5)
        {
            Console.WriteLine(menu.First());
            try
            {
                programRun = Convert.ToInt32(Console.In.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine($"Непередбачена помилка: {e.Message}");
                Console.WriteLine("Натисніть Enter для продовження...");
                Console.ReadLine();
            }
            menuService.handleMenu(programRun);
        }
        Environment.Exit(0);
    }

    public void initAuthorisedMenu()
    {
        throw new NotImplementedException();
    }
}