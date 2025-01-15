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
        "3.Unregister\n" +
        "4.See preferences\n" +
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

    public void showTable()
    {
        throw new NotImplementedException();
    }

    public void showView()
    {
        throw new NotImplementedException();
    }
}