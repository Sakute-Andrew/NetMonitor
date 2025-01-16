namespace NetMonitor.service;

public class AuthServiceImpl : AuthService
{
    private Boolean isLoggedIn { get; set; }

    public void Login(string username, string password)
    {
        throw new NotImplementedException();
    }

    public void Register(string username, string password)
    {
        throw new NotImplementedException();
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