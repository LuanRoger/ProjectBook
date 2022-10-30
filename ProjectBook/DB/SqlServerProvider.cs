using Microsoft.EntityFrameworkCore;

namespace ProjectBook.DB;

public class SqlServerProvider : ProviderContext
{
    public SqlServerProvider(string connectionString) : base(connectionString) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(connectionString);
    }
}