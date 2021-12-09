using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectBook.Model;
using ProjectBook.Tipos;

namespace ProjectBook.DB.SqlServerExpress
{
    public static class UsuarioDb
    {
        public static void CadastrarUsuario(UsuarioModel usuario)
        {
            using DatabaseManager databaseManager = new();
            
           databaseManager.usuarioModel.Add(usuario);
           databaseManager.SaveChanges();
        }

        #region Deletar
        public static void DeletarUsuarioId(int id)
        {
            using DatabaseManager databaseManager = new();
            
            databaseManager.usuarioModel.Remove(new() {id = id});
            databaseManager.SaveChanges();
        }
        #endregion
        
        #region Buscar
        public static async Task<UsuarioModel> BuscarUsuarioId(int id)
        {
            await using DatabaseManager databaseManager = new();
            
            return await databaseManager.usuarioModel.FindAsync(id);
        }
            
        public static async Task<List<UsuarioModel>> BuscarUsuarioNome(string nomeUsuario)
        {
            await using DatabaseManager databaseManager = new();
            
            return await databaseManager.usuarioModel.Where(usuario => usuario.usuario.Contains(nomeUsuario))
                            .ToListAsync();
        }
            
        public static async Task<List<UsuarioModel>> PegarTodosAdm()
        {
            await using DatabaseManager databaseManager = new();
            
            return await databaseManager.usuarioModel
                                .Where(usuairo => usuairo.tipo.Equals(TipoUsuario.ADM))
                                .ToListAsync();
        }
            
        public static async Task<List<UsuarioModel>> PegarTodosUsu()
        {
            await using DatabaseManager databaseManager = new();
            
            return await databaseManager.usuarioModel
                            .Where(usuairo => usuairo.tipo.Equals(TipoUsuario.USU))
                            .ToListAsync();
        }
            
        #endregion

        #region Atualizar
        public static async void AtualizarUsuarioId(int id, UsuarioModel usuario)
        {
            await using DatabaseManager databaseManager = new();
            UsuarioModel usuarioModel = await databaseManager.usuarioModel.FindAsync(id);
            
            usuarioModel.usuario = usuario.usuario;
            usuarioModel.senha = usuario.senha;
            usuarioModel.tipo = usuario.tipo;

            databaseManager.SaveChanges();
        }
        #endregion

        #region Login
        public static UsuarioModel LoginUsuario(string nomeUsuario, string senha)
        {
            using DatabaseManager databaseManager = new();
            
            return databaseManager.usuarioModel.FirstOrDefault(usuario => usuario.usuario.Equals(nomeUsuario) &&
                                                                 usuario.senha.Equals(senha));   
        }
        public static UsuarioModel LoginCodigo(int id, string senha)
        {
            using DatabaseManager databaseManager = new();
            
            return databaseManager.usuarioModel
                            .SingleOrDefault(usuario => usuario.id.Equals(id) &&
                                               usuario.senha.Equals(senha));
        }
            
        #endregion

        public static TipoUsuario VerTipoUsuario(string nomeUsuario)
        {
            using DatabaseManager databaseManager = new();
            
            return databaseManager.usuarioModel
                            .First(usuario => usuario.usuario.Equals(nomeUsuario)).tipo;
        }
            
    }
}