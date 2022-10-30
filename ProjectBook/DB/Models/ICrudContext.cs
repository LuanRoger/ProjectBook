namespace ProjectBook.DB.Models;

public interface ICrudContext<T>
{
    public IDatabaseContextModels contextModels { get; set; }
    
    public void Create(T model);
    
    public T ReadById(int id);
    public List<T> ReadAll();
    public Task<List<T>> ReadAllAsync();
    
    public void UpdateById(int id, T newValue);
    
    public void DeleteById(int id);
}