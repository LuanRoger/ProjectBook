using Microsoft.EntityFrameworkCore;
using ProjectBook.Livros;
using ProjectBook.Managers.Configuration;

namespace ProjectBook.DB.SqlServerExpress
{
    public class DatabaseManager : DbContext
    {
        // TODO - Locker
        private static DatabaseManager _databaseManager { get; set; }
        public static DatabaseManager databaseManager
        {
            get => _databaseManager ??= new();
        }
        public static void DisposeInstance() => _databaseManager.Dispose();
        
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
        
        public static bool VerificarConexao() => _databaseManager.Database.CanConnect();
    }
}
