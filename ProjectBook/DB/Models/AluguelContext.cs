using Microsoft.EntityFrameworkCore;
using ProjectBook.Model;
using ProjectBook.Model.Enums;

namespace ProjectBook.DB.Models;

public class AluguelContext : ICrudContext<AluguelModel>
{
    public IDatabaseContextModels contextModels { get; set; }

    public AluguelContext(IDatabaseContextModels databaseContextModels)
    {
        contextModels = databaseContextModels;
    }
    
    public void Create(AluguelModel model)
    {
        contextModels.aluguelContext.Add(model);
    }

    #region Read
    public AluguelModel ReadById(int id)
    {
        return contextModels.aluguelContext.Find(id);
    }
    public List<AluguelModel> ReadAll()
    {
        return contextModels.aluguelContext.ToList();
    }
    public async Task<List<AluguelModel>> ReadAllAsync()
    {
        return await contextModels.aluguelContext.ToListAsync();
    }
    public async Task<List<AluguelModel>> ReadLivrosAlugados()
    {
        return await contextModels.aluguelContext
            .Where(aluguel => aluguel.status.Equals(StatusAluguel.Alugado))
            .ToListAsync();
    }
    public async Task<List<AluguelModel>> ReadLivroDevolvido()
    {
        return await contextModels.aluguelContext
            .Where(aluguel => aluguel.status.Equals(StatusAluguel.Devolvido))
            .ToListAsync();
    }
    public async Task<List<AluguelModel>> ReadLivroAtrassado()
    {
        return await contextModels.aluguelContext
            .Where(aluguel => aluguel.status.Equals(StatusAluguel.Atrasado))
            .ToListAsync();
    }

    #region Search
    public async Task<List<AluguelModel>> SearchAluguelLivro(string titulo)
    {
        return await contextModels.aluguelContext.Where(aluguel => aluguel.titulo.Contains(titulo))
            .ToListAsync();
    }
    public async Task<List<AluguelModel>> SearchAluguelCliente(string nomeCliente)
    {
        return await contextModels.aluguelContext
            .Where(aluguel => aluguel.alugadoPor.Contains(nomeCliente))
            .ToListAsync();
    }
            
    public async Task<List<AluguelModel>> SearchAluguelLivroCliente(string titulo, string nomeCliente)
    {
        return await contextModels.aluguelContext.Where(aluguel => aluguel.titulo.Contains(titulo) && 
                                                                   aluguel.alugadoPor.Contains(nomeCliente))
            .ToListAsync();
    }
    #endregion
    #endregion

    #region Update
    public void UpdateById(int id, AluguelModel newValue)
    {
        AluguelModel aluguelModel = contextModels.aluguelContext.Find(id);
        if(aluguelModel is null) return;
        
        aluguelModel.titulo = newValue.titulo;
        aluguelModel.autor = newValue.autor;
        aluguelModel.alugadoPor = newValue.alugadoPor;
        aluguelModel.dataEntrega = newValue.dataEntrega;
        aluguelModel.dataDevolucao = newValue.dataDevolucao;
        aluguelModel.status = newValue.status;
    }
    public void UpdateByNomeCliente(AluguelModel newValue, string titulo, string nomeCliente)
    {
            
        AluguelModel? aluguelModel = contextModels.aluguelContext
            .FirstOrDefault(model => model.titulo.Contains(titulo) &&
                                          model.alugadoPor.Contains(nomeCliente));
        if(aluguelModel is null) return;
        
        aluguelModel.titulo = newValue.titulo;
        aluguelModel.autor = newValue.autor;
        aluguelModel.alugadoPor = newValue.alugadoPor;
        aluguelModel.dataEntrega = newValue.dataEntrega;
        aluguelModel.dataDevolucao = newValue.dataDevolucao;
        aluguelModel.status = newValue.status;
    }
    public async Task UpdateStatusAtrasado()
    {
        foreach (AluguelModel aluguel in await ReadLivrosAlugados())
        {
            DateTime hoje = DateTime.Now.Date;
            DateTime devolucao = aluguel.dataDevolucao;
            
            //TODO: Do a better check
            if (Convert.ToInt32((hoje - devolucao).Days) < 0) continue;
            
            aluguel.status = StatusAluguel.Atrasado;
        }
    }
    #endregion

    #region Delete
    public void DeleteById(int id)
    {
        AluguelModel aluguelModel = contextModels.aluguelContext.Find(id);
        if (aluguelModel is null) return;
        
        contextModels.aluguelContext.Remove(aluguelModel);
    }
    public void DeleteAluguelTitulo(string titulo)
    {
        AluguelModel aluguelModel = contextModels.aluguelContext
            .FirstOrDefault(aluguel => aluguel.titulo == titulo);
        if(aluguelModel is null) return;

        contextModels.aluguelContext.Remove(aluguelModel);
    }
    public void DeleteAluguelCliente(string clientName)
    {
        AluguelModel aluguelModel = contextModels.aluguelContext
            .FirstOrDefault(aluguel => aluguel.alugadoPor == clientName);
        if(aluguelModel is null) return;

        contextModels.aluguelContext.Remove(aluguelModel);
    }
    public void DeleteAluguelTituloClient(string titulo, string clientName)
    {
        AluguelModel aluguelModel = contextModels.aluguelContext.FirstOrDefault(
            aluguel => aluguel.titulo == titulo && aluguel.alugadoPor == clientName);
        if(aluguelModel is null) return;
        
        contextModels.aluguelContext.Remove(aluguelModel);
    }
    #endregion
}