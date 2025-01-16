namespace NetMonitor.repo;

public interface RepoService
{
    void addData(string data, string pathValue);
    void removeData(string data,  string pathValue);
    string readData(string pathValue);
    
    
    
    
}