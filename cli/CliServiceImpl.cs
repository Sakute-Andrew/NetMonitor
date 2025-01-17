using NetMonitor.cli.handle_menu;
using NotImplementedException = System.NotImplementedException;

namespace NetMonitor.cli;

public class CliServiceImpl : CliService
{
    
    private readonly string[] menu = new[]
    {
        "---                                      ---\n" +
        "============= Вiтаємо в NetMonitor ===========\n"+
        "              1.Авторизуватись \n" +
        "              2.Зареєструватись\n" +
        "              3.Iнформацiя\n" +
        "              4.Вихiд\n"+
        "--------------------------------------------"
    };
    
    private readonly string[] authorizedMenu = new[]
    {
        "---                                      ---\n" +
        "============= Ласкаво просимо в NetMonitor ============\n" +
        "                1. Переглянути доступнi мережевi пристрої\n" +
        "                2. Переглянути TcpDump\n" +
        "                3. Перевiрити швидкість мережi\n" +
        "                4. Довiдка\n"+
        "                5. Вихiд\n" +
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
                Console.WriteLine("Натиснiть Enter для продовження...");
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