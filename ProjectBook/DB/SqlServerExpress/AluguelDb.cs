using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectBook.Model;
using ProjectBook.Tipos;

namespace ProjectBook.DB.SqlServerExpress
{
    public static class AluguelDb
    {
        public static void CadastrarAluguel(AluguelModel aluguel)
        {
            using DatabaseManager databaseManager = new();
            
            databaseManager.aluguelModel.Add(aluguel);
            databaseManager.SaveChanges();
        }
        public static async Task<List<AluguelModel>> VerTodosAluguel()
        {
            await using DatabaseManager databaseManager = new();
            
            return await databaseManager.aluguelModel.ToListAsync();
        }
            

        #region Deletar
        public static void DeletarAluguelTitulo(string titulo)
        {
            using DatabaseManager databaseManager = new();
            
            databaseManager.aluguelModel.Remove(databaseManager.aluguelModel
                .Where(aluguel => aluguel.titulo == titulo)
                .ToList()
                .First());
            databaseManager.SaveChanges();
        }
        public static void DeletarAluguelCliente(string nomeCliente)
        {
            using DatabaseManager databaseManager = new();
            
            databaseManager.aluguelModel.Remove(databaseManager.aluguelModel
                .Where(aluguel => aluguel.alugadoPor == nomeCliente)
                .ToList()
                .First());
            databaseManager.SaveChanges();
        }
        public static void DeletarAluguelTituloLivro(string titulo, string nomeCliente)
        {
            using DatabaseManager databaseManager = new();
            
            databaseManager.aluguelModel.Remove(databaseManager.aluguelModel
                .Where(aluguel => aluguel.titulo == titulo && aluguel.alugadoPor == nomeCliente)
                .ToList()
                .First());
            databaseManager.SaveChanges();
        }
        #endregion

        #region Buscar
        public static async Task<List<AluguelModel>> BuscarAluguelLivro(string titulo)
        {
            await using DatabaseManager databaseManager = new();
            
            return await databaseManager.aluguelModel.Where(aluguel => aluguel.titulo.Contains(titulo))
                            .ToListAsync();
        }
            
        public static async Task<List<AluguelModel>> BuscarAluguelCliente(string nomeCliente)
        {
            using DatabaseManager databaseManager = new();
            
            return await databaseManager.aluguelModel
                            .Where(aluguel => aluguel.alugadoPor.Contains(nomeCliente))
                            .ToListAsync();
        }
            
        public static async Task<List<AluguelModel>> BuscarAluguelLivroCliente(string titulo, string nomeCliente)
        {
            await using DatabaseManager databaseManager = new();
            
            return await databaseManager.aluguelModel.Where(aluguel => aluguel.titulo.Contains(titulo) && 
                            aluguel.alugadoPor.Contains(nomeCliente))
                            .ToListAsync();
        }
            
        public static async Task<List<AluguelModel>> PegarLivrosAlugados()
        {
            await using DatabaseManager databaseManager = new();
            
            return await databaseManager.aluguelModel
                            .Where(aluguel => aluguel.status.Equals(StatusAluguel.Alugado))
                            .ToListAsync();
        }
            

        public static async Task<List<AluguelModel>> PegarLivroDevolvido()
        {
            await using DatabaseManager databaseManager = new();
            
            return await databaseManager.aluguelModel
                            .Where(aluguel => aluguel.status.Equals(StatusAluguel.Devolvido))
                            .ToListAsync();
        }
            

        public static async Task<List<AluguelModel>> PegarLivroAtrassado()
        {
            await using DatabaseManager databaseManager = new();
            
            return await databaseManager.aluguelModel
                            .Where(aluguel => aluguel.status.Equals(StatusAluguel.Atrasado))
                            .ToListAsync();
        }
            
        #endregion

        #region Atualizar
        public static async void AtualizarAluguelNomeCliente(AluguelModel aluguel, string titulo, string nomeCliente)
        {
            await using DatabaseManager databaseManager = new();
            
            AluguelModel aluguelModel = (await databaseManager.aluguelModel
                .Where(model => model.titulo.Contains(titulo) &&
                                  model.alugadoPor.Contains(nomeCliente))
                .ToListAsync())
                .First();

            aluguelModel.titulo = aluguel.titulo;
            aluguelModel.autor = aluguel.autor;
            aluguelModel.alugadoPor = aluguel.alugadoPor;
            aluguelModel.dataEntrega = aluguel.dataEntrega;
            aluguelModel.dataDevolucao = aluguel.dataDevolucao;
            aluguelModel.status = aluguel.status;

            databaseManager.SaveChanges();
        }
        public static async void AtualizarStatusAtrasado(string alugadoPor)
        {
            await using DatabaseManager databaseManager = new();
            
            AluguelModel aluguelModel = (await databaseManager.aluguelModel
                .Where(aluguel => aluguel.alugadoPor.Contains(alugadoPor))
                .ToListAsync()).First();

            aluguelModel.status = StatusAluguel.Atrasado;
            
            await databaseManager.SaveChangesAsync();
        }
        #endregion
    }
}
