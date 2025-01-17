using NetMonitor.cli.handle_menu;
using NotImplementedException = System.NotImplementedException;

namespace NetMonitor.cli;

public class CliServiceImpl : CliService
{
    
    private readonly string[] menu = new[]
    {
        "---                                      ---\n" +
        "============= Вітаємо в NetMonitor ===========\n"+
        "              1.Авторизуватись \n" +
        "              2.Зареєструватись\n" +
        "              3.Інформація\n" +
        "              4.Вихід\n"+
        "--------------------------------------------"
    };
    
    private readonly string[] authorizedMenu = new[]
    {
        "---                                      ---\n" +
        "============= Ласкаво просимо в NetMonitor ============\n" +
        "                1. Вийти з облікового запису\n" +
        "                2. Переглянути доступні мережеві пристрої\n" +
        "                3. Переглянути TcpDump\n" +
        "                4. Перевірити швидкість мережі\n" +
        "                5.Довідка\n"+
        "                5. Вихід\n" +
        "---------------------------------------------------------"
    };

    
    public void initMenu()
    {
        Console.Clear();
        int programRun = 0;
        MenuService menuService = new MenuService();
        while (programRun != 4)
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
        Console.Clear();
        int programRun = 0;
        AuthorizedMenuService authorizedMenuService = new AuthorizedMenuService();
        while (programRun != 5)
        {
            Console.WriteLine(authorizedMenu.First());
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
            authorizedMenuService.handleMenu(programRun);
        }
        Environment.Exit(0);
    }
}