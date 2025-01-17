using System.Runtime.InteropServices.JavaScript;
using NetMonitor.entities;
using NetMonitor.hash;
using NetMonitor.repo;

namespace NetMonitor.service;

public class AuthServiceImpl : AuthService
{
    private Boolean isLoggedIn { get; set; }
    private RepoService repoService { get; set; }
    private User loggedUser { get; set; }

    public AuthServiceImpl()
    {
        isLoggedIn = false;
        repoService = new Serializer();
        loggedUser = new User();
    }

    private List<User> GetUsers()
    {
        List<User> users = new User().deserializeFromJson(repoService.readData((loggedUser.filePath)));
        return users;
    }

    public void Login(string username, string password)
    {
        // Десеріалізуємо список користувачів з JSON
        List<User> users = GetUsers();
    
        // Знаходимо користувача за email
        User user = users.FirstOrDefault(u => u.name == username);

        // Перевіряємо пароль
        if (user.password == Hash.HashCode(password))
        {
            loggedUser = user;
            isLoggedIn = true;
            Console.WriteLine("Ви успiшно увiйшли!");
        }
        else
        {
            isLoggedIn = false;
            Console.WriteLine("Неправильний пароль");
        }
    }


    public void Register(string email,string username, string password)
    {
        User user = new User();
        try
        {
            user.isCorrectEmail(email);
            user.isCorrectUsername(username);
            user.isCorrectPassword(password);
        }
        catch (Exception e)
        {
            Console.WriteLine($"Помилка: {e.Message}");
            Console.WriteLine("Натиснiть Enter для продовження...");
            Console.ReadLine();
            return;
        }
        
        
        List<User> users = GetUsers();
        if (users.Any(u => u.email == email))
        {
            Console.WriteLine("Користувач з таким iм'ям вже iснує");
            isLoggedIn = false;
            return;
        }
        user.password = Hash.HashCode(password);
        user.email = email;
        user.name = username;
        user.role = Role.USER;
        repoService.addData(user.serializeToJson(), user.filePath);
        isLoggedIn = true;
        Console.WriteLine("Нажмiть Enter щоб продовжити");
        Console.ReadLine();
        
    }

    public Boolean IsEmailExist(string email)
    {
        List<User> users = GetUsers();
        User user = users.FirstOrDefault(u => u.email == email);
        if (user == null)
        {
            return false;
        }

        return true;
    }

    public Boolean IsUsernameExist(string username)
    {
        List<User> users = GetUsers();
        User user = users.FirstOrDefault(u => u.name == username);
        if (user == null)
        {
            return false;
        }
        return true;
    }
    

    public void Logout()
    {
        isLoggedIn = false;
    }

    public bool IsLoggedIn()
    {
       return isLoggedIn;
    }
    
}