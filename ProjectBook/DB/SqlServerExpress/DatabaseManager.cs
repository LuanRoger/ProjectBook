using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectBook.GUI;
using ProjectBook.Livros;
using ProjectBook.Managers;
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
        
        public static async Task<bool> VerificarConexao()
        {
            await using DatabaseManager databaseManager = new();
            
            return await databaseManager.Database.CanConnectAsync();
        }
        
        public static void OpenConfigurationSafeMode()
        {
            Configuracoes configuracoes = new(true);
            configuracoes.Show();
            configuracoes.BringToFront();
        }

        public static async Task CreateDb()
        {
            await using DatabaseManager databaseManager = new();
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
