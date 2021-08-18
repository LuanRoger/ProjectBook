using System.Collections.Generic;
using ProjectBook.Livros;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using ProjectBook.Properties;
using ProjectBook.AppInsight;

namespace ProjectBook.DB.SqlServerExpress
{
    class ClienteDb
    {
        public void CadastrarCliente(ClienteModel cliente)
        {
            DatabaseManager.databaseManager.clienteModel.Add(cliente);
            DatabaseManager.databaseManager.SaveChanges();
        }
        
        #region Deletar
        public void DeletarClienteId(int id)
        {
            DatabaseManager.databaseManager.clienteModel.Remove(new() {id = id});
            DatabaseManager.databaseManager.SaveChanges();
        }
        public void DeletarClienteNome(string nome)
        {
            DatabaseManager.databaseManager.clienteModel.Remove(new() {nomeCompleto = nome});
            DatabaseManager.databaseManager.SaveChanges();
        }
        #endregion
        
        #region Buscar
        public async Task<List<ClienteModel>> VerTodosClientes() =>
            await DatabaseManager.databaseManager.clienteModel.ToListAsync();
        public async Task<ClienteModel> BuscarClienteId(int id) =>
            await DatabaseManager.databaseManager.clienteModel.FindAsync(id);
        public async Task<List<ClienteModel>> BuscarClienteNome(string nomeCompleto) =>
            await DatabaseManager.databaseManager.clienteModel.Where(cliente => cliente.nomeCompleto.Contains(nomeCompleto))
                .ToListAsync();
        #endregion
        
        #region Atualizar
        public async void AtualizarClienteId(int id, ClienteModel cliente)
        {
            ClienteModel clienteModel = await BuscarClienteId(id);
            
            clienteModel = cliente;
            
            await DatabaseManager.databaseManager.SaveChangesAsync();
            DatabaseManager.DisposeInstance();
        }
        #endregion
    }
}
