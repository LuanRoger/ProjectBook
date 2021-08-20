using System.Collections.Generic;
using ProjectBook.Livros;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectBook.Tipos;

namespace ProjectBook.DB.SqlServerExpress
{
    public static class AluguelDb
    {
        public static void CadastrarAluguel(AluguelModel aluguel)
        {
            DatabaseManager.databaseManager.aluguelModel.Add(aluguel);
            DatabaseManager.databaseManager.SaveChanges();
        }
        public static async Task<List<AluguelModel>> VerTodosAluguel() =>
            await DatabaseManager.databaseManager.aluguelModel.ToListAsync();

        #region Deletar
        public static void DeletarAluguelTitulo(string titulo)
        {
            DatabaseManager.databaseManager.aluguelModel.Remove(new() {titulo = titulo});
            DatabaseManager.databaseManager.SaveChanges();
        }
        public static void DeletarAluguelCliente(string nomeCliente)
        {
            DatabaseManager.databaseManager.aluguelModel.Remove(new() {alugadoPor = nomeCliente});
            DatabaseManager.databaseManager.SaveChanges();
        }
        public static void DeletarAluguelTituloLivro(string titulo, string nomeCliente)
        {
            DatabaseManager.databaseManager.aluguelModel.Remove(new() {titulo = titulo, alugadoPor = nomeCliente});
            DatabaseManager.databaseManager.SaveChanges();
        }
        #endregion

        #region Buscar
        public static async Task<List<AluguelModel>> BuscarAluguelLivro(string titulo) =>
            await DatabaseManager.databaseManager.aluguelModel.Where(aluguel => aluguel.titulo.Contains(titulo))
                .ToListAsync();
        public static async Task<List<AluguelModel>> BuscarAluguelCliente(string nomeCliente) =>
            await DatabaseManager.databaseManager.aluguelModel
                .Where(aluguel => aluguel.alugadoPor.Contains(nomeCliente))
                .ToListAsync();
        public static async Task<List<AluguelModel>> BuscarAluguelLivroCliente(string titulo, string nomeCliente) =>
            await DatabaseManager.databaseManager.aluguelModel.Where(aluguel => aluguel.titulo.Contains(titulo) && 
                aluguel.alugadoPor.Contains(nomeCliente))
                .ToListAsync();
        public static async Task<List<AluguelModel>> PegarLivrosAlugados() =>
            await DatabaseManager.databaseManager.aluguelModel
                .Where(aluguel => aluguel.status.Equals(StatusAluguel.Alugado.ToString()))
                .ToListAsync();

        public static async Task<List<AluguelModel>> PegarLivroDevolvido() =>
            await DatabaseManager.databaseManager.aluguelModel
                .Where(aluguel => aluguel.status.Equals(StatusAluguel.Devolvido.ToString()))
                .ToListAsync();

        public static async Task<List<AluguelModel>> PegarLivroAtrassado() =>
            await DatabaseManager.databaseManager.aluguelModel
                .Where(aluguel => aluguel.status.Equals(StatusAluguel.Atrasado.ToString()))
                .ToListAsync();
        #endregion

        #region Atualizar
        public static async void AtualizarAluguelNomeCliente(AluguelModel aluguel, string titulo, string nomeCliente)
        {
            var alugueis = await BuscarAluguelLivroCliente(titulo, nomeCliente);
            AluguelModel aluguelModel = alugueis.First();
            
            aluguelModel = aluguel;
            
            await DatabaseManager.databaseManager.SaveChangesAsync();
            DatabaseManager.DisposeInstance();
        }
        public static async void AtualizarStatusAtrasado(string alugadoPor)
        {
            var alugueis = await BuscarAluguelCliente(alugadoPor);
            AluguelModel aluguelModel = alugueis.First();
            
            aluguelModel.status = StatusAluguel.Atrasado;
            
            await DatabaseManager.databaseManager.SaveChangesAsync();
            DatabaseManager.DisposeInstance();
        }
        #endregion
    }
}
