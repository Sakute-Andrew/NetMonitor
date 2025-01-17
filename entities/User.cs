
using System.Text.RegularExpressions;

namespace NetMonitor.entities;

public class User
{
    public String name { get; set; }
    public String email { get; set; }
    public String password { get; set; }
    public Role? role { get; set; }

    public readonly string filePath = @"Data\\users.json";

    public User(String name, String email, String password, Role? role)
    {
        this.name = name;
        this.email = email;
        this.password = password;
        this.role = role;
    }

    public User()
    {
        
    }
    
    public string isCorrectPassword(string password)
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
        if (!Regex.IsMatch(password, @"^[a-zA-Z0-9_@!#$%&'*+\-/=?^^{|}~]+$"))
        {
            errors.Add("Помилка: лише латинські символи, цифри та символи _ або @.");
        }
        if (errors.Count > 0)
        {
            throw new ArgumentException(string.Join(Environment.NewLine, errors));
        }
        return password;
    }

    public string isCorrectEmail(string email)
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

    public string isCorrectUsername(string username)
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
        return username;
    }
    
    public string serializeToJson()
    {
        return "{\n" +
               "\"name\": \"" + name + "\",\n" +
               "\"email\": \"" + email + "\",\n" +
               "\"password\": \"" + password + "\",\n" +
               "\"role\": \"" + role + "\",\n" +
               "},";
    }

    public List<User> deserializeFromJson(string json)
    {
        List<User> users = new List<User>();
        string[] lines = json.Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);

        User currentUser = null;
        foreach (var line in lines)
        {
            string trimmed = line.Trim();
            if (trimmed.StartsWith("{"))
            {
                currentUser = new User();
            }
            else if (trimmed.StartsWith("}"))
            {
                if (currentUser != null)
                {
                    users.Add(currentUser);
                }
            }
            else if (currentUser != null)
            {
                string[] keyValue = trimmed.Split(new[] { ':' }, 2, StringSplitOptions.RemoveEmptyEntries);
                if (keyValue.Length == 2)
                {
                    string key = keyValue[0].Trim(' ', '"');
                    string value = keyValue[1].Trim(' ', '"', ',');

                    switch (key)
                    {
                        case "name":
                            currentUser.name = value;
                            break;
                        case "email":
                            currentUser.email = value;
                            break;
                        case "password":
                            currentUser.password = value;
                            break;
                        case "role":
                            currentUser.role = role;
                            break;
                    }
                }
            }
        }
        return users;
    }
    
}