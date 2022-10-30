using InfraDomain;
using Microsoft.EntityFrameworkCore;
using ProjectBook.DB.Models;
using ProjectBook.Model;
// ReSharper disable RedundantIfElseBlock

namespace ProjectBook.DB;

public abstract class ProviderContext : ProviderCore, IDatabaseContextModels, IContextTransaction
{
    public DbSet<AluguelModel> aluguelContext { get; set; }
    public DbSet<ClienteModel> clienteContext { get; set; }
    public DbSet<LivroModel> livrosContext { get; set; }
    public DbSet<UsuarioModel> usuarioContext { get; set; }

    protected ProviderContext(string connectionString) : base(connectionString) { }
    
    public virtual ICrudContext<T> StartTransaction<T>()
    {
        if(typeof(T) == typeof(AluguelModel)) return (ICrudContext<T>)new AluguelContext(this);
        else if(typeof(T) == typeof(ClienteModel)) return (ICrudContext<T>)new ClienteContext(this);
        else if(typeof(T) == typeof(LivroModel)) return (ICrudContext<T>)new LivrosContext(this);
        else if(typeof(T) == typeof(UsuarioModel)) return (ICrudContext<T>)new UsuariosContext(this);
        
        return null;
    }

    public void EndTransaction()
    {
        SaveChanges();
    }
    public async Task EndTransactionAsync()
    {
        await SaveChangesAsync();
    }
}