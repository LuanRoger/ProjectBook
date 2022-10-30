using Microsoft.EntityFrameworkCore;

namespace InfraDomain;

public abstract class ProviderCore : DbContext
{
    protected string connectionString { get; }

    protected ProviderCore(string connectionString)
    {
        this.connectionString = connectionString;
    }
    
    public virtual async Task CreateDatabase() => await Database.EnsureCreatedAsync();
    public virtual bool CheckConnection() => Database.CanConnect();
}