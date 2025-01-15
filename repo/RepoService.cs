namespace NetMonitor.repo;

public interface RepoService<T>
{
    void add(T entity);
    
    void update(T entity);
    
    void delete(T entity);
    
    List<T> getAll();
    
}