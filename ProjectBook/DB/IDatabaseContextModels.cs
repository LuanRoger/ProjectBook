using Microsoft.EntityFrameworkCore;
using ProjectBook.Model;

namespace ProjectBook.DB;

public interface IDatabaseContextModels
{
    public DbSet<AluguelModel> aluguelContext { get; }
    public DbSet<ClienteModel> clienteContext { get; }
    public DbSet<LivroModel> livrosContext { get; }
    public DbSet<UsuarioModel> usuarioContext { get; }
}