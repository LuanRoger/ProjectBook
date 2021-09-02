using System.Collections.Generic;
using ProjectBook.Livros;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ProjectBook.DB.SqlServerExpress
{
    public static class ClienteDb
    {
        public static void CadastrarCliente(ClienteModel cliente)
        {
            using DatabaseManager databaseManager = new();
            
            databaseManager.clienteModel.Add(cliente);
            databaseManager.SaveChanges();
        }
        
        #region Deletar
        public static void DeletarClienteId(int id)
        {
            using DatabaseManager databaseManager = new();
            
            databaseManager.clienteModel.Remove(new() {id = id});
            databaseManager.SaveChanges();
        }
        public static void DeletarClienteNome(string nome)
        {
            using DatabaseManager databaseManager = new();
            
            databaseManager.clienteModel.Remove(databaseManager.clienteModel
                .Where(cliente => cliente.nomeCompleto == nome)
                .ToList()
                .First());
            databaseManager.SaveChanges();
        }
        #endregion
        
        #region Buscar
        public static async Task<List<ClienteModel>> VerTodosClientes()
        {
            await using DatabaseManager databaseManager = new();
            
            return await databaseManager.clienteModel.ToListAsync();
        }
            
        public static async Task<ClienteModel> BuscarClienteId(int id)
        {
            await using DatabaseManager databaseManager = new();
            
            return await databaseManager.clienteModel.FindAsync(id);
        }
            
        public static async Task<List<ClienteModel>> BuscarClienteNome(string nomeCompleto)
        {
            await using DatabaseManager databaseManager = new();
            
            return await databaseManager.clienteModel.Where(cliente => cliente.nomeCompleto.Contains(nomeCompleto))
                            .ToListAsync();
        }
            
        #endregion
        
        #region Atualizar
        public static async void AtualizarClienteId(int id, ClienteModel cliente)
        {
            await using DatabaseManager databaseManager = new();
            
            ClienteModel clienteModel = await databaseManager.clienteModel.FindAsync(id);
            
            clienteModel.nomeCompleto = cliente.nomeCompleto;
            clienteModel.endereco = cliente.endereco;
            clienteModel.cidade = cliente.cidade;
            clienteModel.estado = cliente.estado;
            clienteModel.cep = cliente.cep;
            clienteModel.telefone1 = cliente.telefone1;
            clienteModel.telefone2 = cliente.telefone2;
            clienteModel.email = cliente.email;

            databaseManager.SaveChanges();
        }
        #endregion
    }
}
