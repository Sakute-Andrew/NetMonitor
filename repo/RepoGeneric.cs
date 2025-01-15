namespace NetMonitor.repo;

public abstract class RepoGeneric<T> : RepoService<T>
{
    
    
    public void add(T entity)
    {
        throw new NotImplementedException();
    }

    public void update(T entity)
    {
        throw new NotImplementedException();
    }

    public void delete(T entity)
    {
        throw new NotImplementedException();
    }

    public List<T> getAll()
    {
        throw new NotImplementedException();
    }
}