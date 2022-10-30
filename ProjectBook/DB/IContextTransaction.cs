using ProjectBook.DB.Models;

namespace ProjectBook.DB;

public interface IContextTransaction
{
    public ICrudContext<T> StartTransaction<T>();
    public void EndTransaction();
    public Task EndTransactionAsync();
}