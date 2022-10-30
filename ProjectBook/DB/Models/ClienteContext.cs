using Microsoft.EntityFrameworkCore;
using ProjectBook.Model;

namespace ProjectBook.DB.Models
{
    public class ClienteContext : ICrudContext<ClienteModel>
    {
        public IDatabaseContextModels contextModels { get; set; }

        public ClienteContext(IDatabaseContextModels contextModels)
        {
            this.contextModels = contextModels;
        }
        
        public void Create(ClienteModel model)
        {
            contextModels.clienteContext.Add(model);
        }
        
        #region Read
        public ClienteModel ReadById(int id)
        {
            return contextModels.clienteContext.Find(id);
        }

        public List<ClienteModel> ReadAll()
        {
            return contextModels.clienteContext.ToList();
        }

        public async Task<List<ClienteModel>> ReadAllAsync()
        {
            return await contextModels.clienteContext.ToListAsync();
        }
        #region Search
        public async Task<List<ClienteModel>> SearchClienteNome(string nomeCompleto)
        {
            return await contextModels.clienteContext
                .Where(cliente => cliente.nomeCompleto.Contains(nomeCompleto))
                .ToListAsync();
        }
        #endregion
        #endregion
        
        #region Delete
        public void DeleteById(int id)
        {
            ClienteModel clienteModel = contextModels.clienteContext.Find(id);
            if (clienteModel == null) return;
        
            contextModels.clienteContext.Remove(clienteModel);
        }
        public void DeleteByClienteNome(string clientName)
        {
            ClienteModel? clienteModel = contextModels.clienteContext
                .FirstOrDefault(cliente => cliente.nomeCompleto == clientName);
            if(clienteModel is null) return;
            
            contextModels.clienteContext.Remove(clienteModel);
        }
        #endregion

        #region Update
        public void UpdateById(int id, ClienteModel newValue)
        {
            ClienteModel clienteModel = contextModels.clienteContext.Find(id);
            if(clienteModel == null) return;
        
            clienteModel.nomeCompleto = newValue.nomeCompleto;
            clienteModel.endereco = newValue.endereco;
            clienteModel.cidade = newValue.cidade;
            clienteModel.estado = newValue.estado;
            clienteModel.cep = newValue.cep;
            clienteModel.dataNascimento = newValue.dataNascimento;
            clienteModel.profissao = newValue.profissao;
            clienteModel.empresa = newValue.empresa;
            clienteModel.telefone1 = newValue.telefone1;
            clienteModel.telefone2 = newValue.telefone2;
            clienteModel.email = newValue.email;
            clienteModel.observacoes = newValue.observacoes;
        }
        #endregion
    }
}
