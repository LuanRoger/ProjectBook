using ProjectBook.DB;

namespace ProjectBook.Controllers;

public class DatabaseController
{
    private ProviderContext? _providerContext { get; set; }
    
    public void SetProviderContext(ProviderContext providerContext)
    {
        _providerContext = providerContext;
    }
    
    public bool CanConnect() => _providerContext.CheckConnection();

    public IContextTransaction GetTransactionContext()
    {
        return _providerContext;
    }
    public async Task CreateDatabase()
    {
        await _providerContext.CreateDatabase();
    }
}