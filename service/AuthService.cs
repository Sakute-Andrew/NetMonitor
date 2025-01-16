namespace NetMonitor.service;

public interface AuthService
{
    void Login(string username, string password);
    void Register(string email,string username, string password);
    void Logout();
    Boolean IsLoggedIn();
}