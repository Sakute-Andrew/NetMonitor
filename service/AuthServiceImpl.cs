using NetMonitor.entities;
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

    public void Login(string email, string password)
    {
        // Десеріалізуємо список користувачів з JSON
        List<User> users = GetUsers();
    
        // Знаходимо користувача за email
        User user = users.FirstOrDefault(u => u.email == email);

        // Перевіряємо, чи знайдено користувача
        if (user == null)
        {
            isLoggedIn = false;
            Console.WriteLine("Такого користувача не існує");
            return;
        }

        // Перевіряємо пароль
        if (user.password == password)
        {
            loggedUser = user;
            isLoggedIn = true;
            Console.WriteLine("Ви успішно увійшли!");
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
        user.isCorrectEmail(email);
        user.isCorrectUsername(username);
        user.isCorrectPassword(password);
        
        List<User> users = GetUsers();
        if (users.Any(u => u.email == email))
        {
            Console.WriteLine("Користувача з таким ім'ям вже існує");
            isLoggedIn = false;
        }
        repoService.addData(user.serializeToJson(), user.email);
        
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