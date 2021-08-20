using System.Collections.Generic;
using ProjectBook.Livros;
using System.Linq;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.Bibliography;
using Microsoft.EntityFrameworkCore;

namespace ProjectBook.DB.SqlServerExpress
{
    public static class ClienteDb
    {
        public static void CadastrarCliente(ClienteModel cliente)
        {
            DatabaseManager.databaseManager.clienteModel.Add(cliente);
            DatabaseManager.databaseManager.SaveChanges();
        }
        
        #region Deletar
        public static void DeletarClienteId(int id)
        {
            DatabaseManager.databaseManager.clienteModel.Remove(new() {id = id});
            DatabaseManager.databaseManager.SaveChanges();
        }
        public static void DeletarClienteNome(string nome)
        {
            DatabaseManager.databaseManager.clienteModel.Remove(new() {nomeCompleto = nome});
            DatabaseManager.databaseManager.SaveChanges();
        }
        #endregion
        
        #region Buscar
        public static async Task<List<ClienteModel>> VerTodosClientes() =>
            await DatabaseManager.databaseManager.clienteModel.ToListAsync();
        public static async Task<ClienteModel> BuscarClienteId(int id) =>
            await DatabaseManager.databaseManager.clienteModel.FindAsync(id);
        public static async Task<List<ClienteModel>> BuscarClienteNome(string nomeCompleto) =>
            await DatabaseManager.databaseManager.clienteModel.Where(cliente => cliente.nomeCompleto.Contains(nomeCompleto))
                .ToListAsync();
        #endregion
        
        #region Atualizar
        public static async void AtualizarClienteId(int id, ClienteModel cliente)
        {
            ClienteModel clienteModel = await BuscarClienteId(id);
            
            clienteModel = cliente;
            
            await DatabaseManager.databaseManager.SaveChangesAsync();
            DatabaseManager.DisposeInstance();
        }
        #endregion
    }
}
