using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DocumentFormat.OpenXml.Drawing.Charts;
using Microsoft.EntityFrameworkCore;
using ProjectBook.AppInsight;
using ProjectBook.Livros;
using ProjectBook.Properties;
using ProjectBook.Tipos;
using DataTable = System.Data.DataTable;

namespace ProjectBook.DB.SqlServerExpress
{
    public class UsuarioDb
    {
        public void CadastrarUsuario(UsuarioModel usuario)
        {
           DatabaseManager.databaseManager.usuarioModel.Add(usuario);
           DatabaseManager.databaseManager.SaveChanges();
        }

        #region Deletar
        public void DeletarUsuarioId(int id)
        {
            DatabaseManager.databaseManager.usuarioModel.Remove(new() {id = id});
            DatabaseManager.databaseManager.SaveChanges();
        }
        #endregion
        
        #region Buscar
        public async Task<UsuarioModel> BuscarUsuarioId(int id) =>
            await DatabaseManager.databaseManager.usuarioModel.FindAsync(id);
        public async Task<List<UsuarioModel>> BuscarUsuarioNome(string nomeUsuario) => 
            await DatabaseManager.databaseManager.usuarioModel.Where(usuario => usuario.usuario.Contains(nomeUsuario))
                .ToListAsync();
        public async Task<List<UsuarioModel>> PegarTodosAdm() =>
            await DatabaseManager.databaseManager.usuarioModel
                    .Where(usuairo => usuairo.tipo.Equals(TipoUsuario.ADM.ToString()))
                    .ToListAsync();
        public async Task<List<UsuarioModel>> PegarTodosUsu() =>
            await DatabaseManager.databaseManager.usuarioModel
                .Where(usuairo => usuairo.tipo.Equals(TipoUsuario.ADM.ToString()))
                .ToListAsync();
        #endregion
        
        public async void AtualizarUsuarioId(int id, UsuarioModel usuario)
        {
            UsuarioModel usuarioModel = await BuscarUsuarioId(id);
            
            usuarioModel = usuario;
            
            await DatabaseManager.databaseManager.SaveChangesAsync();
            DatabaseManager.DisposeInstance();
        }

        #region Login
        public UsuarioModel LoginUsuario(string nomeUsuario, string senha) =>
            DatabaseManager.databaseManager.usuarioModel
                .Single(usuario => usuario.usuario.Equals(nomeUsuario) &&
                                   usuario.senha.Equals(senha));
        public UsuarioModel LoginCodigo(int id, string senha) =>
            DatabaseManager.databaseManager.usuarioModel
                .Single(usuario => usuario.id.Equals(id) &&
                                   usuario.senha.Equals(senha));
        #endregion

        public TipoUsuario VerTipoUsuario(string nomeUsuario) =>
            DatabaseManager.databaseManager.usuarioModel
                .Single(usuario => usuario.usuario.Equals(nomeUsuario)).tipo;
    }
}