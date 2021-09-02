using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectBook.Livros;
using ProjectBook.Managers.Configuration;
using ProjectBook.Tipos;

namespace ProjectBook.DB.SqlServerExpress
{
    public class DatabaseManager : DbContext
    {
        private readonly string connectionString =
            AppConfigurationManager.configuration.database.SqlConnectionString;

        public DbSet<LivroModel> livroModel { get; set; }
        public DbSet<ClienteModel> clienteModel { get; set; }
        public DbSet<AluguelModel> aluguelModel { get; set; }
        public DbSet<UsuarioModel> usuarioModel { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }
        
        public static bool VerificarConexao()
        {
            using DatabaseManager databaseManager = new();
            
            return databaseManager.Database.CanConnect();
        }

        public static async Task CreateDb()
        {
            using DatabaseManager databaseManager = new();
            await databaseManager.Database.EnsureCreatedAsync();
            
            UsuarioDb.CadastrarUsuario(new()
            {
                id = 0,
                usuario = "admin",
                senha = "admin",
                tipo = TipoUsuario.ADM
            });
        }
    }
}
