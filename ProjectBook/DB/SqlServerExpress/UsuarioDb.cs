using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectBook.Livros;
using ProjectBook.Tipos;

namespace ProjectBook.DB.SqlServerExpress
{
    public static class UsuarioDb
    {
        public static void CadastrarUsuario(UsuarioModel usuario)
        {
           DatabaseManager.databaseManager.usuarioModel.Add(usuario);
           DatabaseManager.databaseManager.SaveChanges();
        }

        #region Deletar
        public static void DeletarUsuarioId(int id)
        {
            DatabaseManager.databaseManager.usuarioModel.Remove(new() {id = id});
            DatabaseManager.databaseManager.SaveChanges();
        }
        #endregion
        
        #region Buscar
        public static async Task<UsuarioModel> BuscarUsuarioId(int id) =>
            await DatabaseManager.databaseManager.usuarioModel.FindAsync(id);
        public static async Task<List<UsuarioModel>> BuscarUsuarioNome(string nomeUsuario) => 
            await DatabaseManager.databaseManager.usuarioModel.Where(usuario => usuario.usuario.Contains(nomeUsuario))
                .ToListAsync();
        public static async Task<List<UsuarioModel>> PegarTodosAdm() =>
            await DatabaseManager.databaseManager.usuarioModel
                    .Where(usuairo => usuairo.tipo.Equals(TipoUsuario.ADM.ToString()))
                    .ToListAsync();
        public static async Task<List<UsuarioModel>> PegarTodosUsu() =>
            await DatabaseManager.databaseManager.usuarioModel
                .Where(usuairo => usuairo.tipo.Equals(TipoUsuario.ADM.ToString()))
                .ToListAsync();
        #endregion
        
        public static async void AtualizarUsuarioId(int id, UsuarioModel usuario)
        {
            UsuarioModel usuarioModel = await BuscarUsuarioId(id);
            
            usuarioModel = usuario;
            
            await DatabaseManager.databaseManager.SaveChangesAsync();
            DatabaseManager.DisposeInstance();
        }

        #region Login
        public static UsuarioModel LoginUsuario(string nomeUsuario, string senha) =>
            DatabaseManager.databaseManager.usuarioModel
                .Single(usuario => usuario.usuario.Equals(nomeUsuario) &&
                                   usuario.senha.Equals(senha));
        public static UsuarioModel LoginCodigo(int id, string senha) =>
            DatabaseManager.databaseManager.usuarioModel
                .Single(usuario => usuario.id.Equals(id) &&
                                   usuario.senha.Equals(senha));
        #endregion

        public static TipoUsuario VerTipoUsuario(string nomeUsuario) =>
            DatabaseManager.databaseManager.usuarioModel
                .Single(usuario => usuario.usuario.Equals(nomeUsuario)).tipo;
    }
}