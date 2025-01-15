namespace NetMonitor.entities;

public class User
{
    public String name { get; set; }
    public String email { get; set; }
    public String password { get; set; }
    public Role? role { get; set; }

    public User(String name, String email, String password)
    {
        this.name = name;
        this.email = email;
        this.password = password;
        this.role = role;
    }
    
    private string isCorrectPassword(string password)
    {
        List<string> errors = new();

        if (string.IsNullOrWhiteSpace(password))
        {
            errors.Add("Помилка: ви не вірно ввели значення логіну.");
        }
        if (password.Length < 2 || password.Length > 18)
        {
            errors.Add("Помилка: розмір логіна повинен бути від 2 до 18 символів.");
        }
        if (!password.All(c => char.IsLetterOrDigit(c) || c == '_' || c == '@'))
        {
            errors.Add("Помилка: лише латинські символи, цифри та символи _ або @.");
        }
        if (errors.Count > 0)
        {
            throw new ArgumentException(string.Join(Environment.NewLine, errors));
        }
        return password;
    }

    private string isCorrectEmail(string email)
    {
        List<string> errors = new();
        
        if (string.IsNullOrWhiteSpace(email))
        {
            errors.Add("Помилка: ви не вказали емейл.");
        }
        if (email.Length < 5 || email.Length > 50)
        {
            errors.Add("Помилка: емейл повинен бути довжиною від 5 до 50 символів.");
        }
        if (!(email.Contains('@') && email.Contains('.')))
        {
            errors.Add("Помилка: емейл має містити символи '@' та '.'.");
        }
        var emailParts = email.Split('@');
        if (emailParts.Length != 2 || string.IsNullOrWhiteSpace(emailParts[0]) || string.IsNullOrWhiteSpace(emailParts[1]))
        {
            errors.Add("Помилка: емейл має бути у форматі 'username@domain'.");
        }
        if (errors.Count > 0)
        {
            throw new ArgumentException(string.Join(Environment.NewLine, errors));
        }
        return email;
    }

    private string isCorrectUsername(string username)
    {
        List<string> errors = new();
        
        if (string.IsNullOrWhiteSpace(username))
        {
            errors.Add("Помилка: ви не вказали емейл.");
        }
        if (username.Length < 3 || username.Length > 20)
        {
            errors.Add("Помилка: емейл повинен бути довжиною від 5 до 50 символів.");
        }
        if (!(email.Contains('@') && email.Contains('.')))
        {
            errors.Add("Помилка: емейл має містити символи '@' та '.'.");
        }
        return username;
    }
    
    public string toString()
    {
        return $"User: {name}, {email}, {role}";
    }
    
}