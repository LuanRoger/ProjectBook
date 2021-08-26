using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectBook.Livros;
using ProjectBook.Managers.Configuration;
using ProjectBook.Tipos;

namespace ProjectBook.DB.SqlServerExpress
{
    public class DatabaseManager : DbContext
    {
        //TODO - All thread safe, instance for each operation
        private static DatabaseManager _databaseManagers {get; set;}
        public static DatabaseManager databaseManager
        {
            get
            {
                _databaseManagers ??= new();
                return _databaseManagers;
            }
        }
        public static void DisposeSingletons() => _databaseManagers.Dispose();

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
        
        public static bool VerificarConexao() => databaseManager.Database.CanConnect();
        
        public static Task MigrateDb() => databaseManager.Database.MigrateAsync();
        
        public static async Task CreateDb()
        {
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
