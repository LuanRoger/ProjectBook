using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectBook.Livros;

namespace ProjectBook.DB.SqlServerExpress
{
    public static class LivrosDb
    {
        public static void AdicionarLivro(LivroModel livro)
        {
            DatabaseManager.databaseManager.livroModel.Add(livro);
            DatabaseManager.databaseManager.SaveChanges();
        }

        #region Deletar
        public static void DeletarLivroId(int id)
        {
            DatabaseManager.databaseManager.livroModel.Remove(new() {id = id});
            DatabaseManager.databaseManager.SaveChanges();
        }
        public static void DeletarLivroTitulo(string tituloLivro)
        {
            DatabaseManager.databaseManager.livroModel.Remove(new() {titulo = tituloLivro});
            DatabaseManager.databaseManager.SaveChanges();
        }
        #endregion

        #region Buscar
        public static async Task<List<LivroModel>> VerTodosLivros() => 
            await DatabaseManager.databaseManager.livroModel.ToListAsync();

        public static async Task<List<string>> PegarGeneros()
        {
            var livroModels = await VerTodosLivros();
            return livroModels.Select(livroModel => livroModel.genero).ToList();
        }

        public static async Task<LivroModel> BuscarLivrosId(int id) => 
            await DatabaseManager.databaseManager.livroModel.SingleOrDefaultAsync(book => book.id == id);
        public static async Task<List<LivroModel>> BuscarLivrosTitulo(string titulo) =>
            await DatabaseManager.databaseManager.livroModel.Where(livro => livro.titulo.Contains(titulo))
                .ToListAsync();
        public static async Task<List<LivroModel>> BuscarLivrosAutor(string autor) =>
            await DatabaseManager.databaseManager.livroModel.Where(livro => livro.autor.Contains(autor))
                .ToListAsync();
        public static async Task<List<LivroModel>> BuscarLivrosGenero(string genero) =>
            await DatabaseManager.databaseManager.livroModel.Where(livro => livro.genero.Contains(genero))
                .ToListAsync();
        #endregion

        #region Atualizar
        public static async void AtualizarViaId(int id, LivroModel livro)
        {
            LivroModel livroModel = await BuscarLivrosId(id);
            livroModel ??= livro;
            
            await DatabaseManager.databaseManager.SaveChangesAsync();
        }
        public static async void AtualizarViaTitulo(string titulo, LivroModel livro)
        {
            var livroModels = await BuscarLivrosTitulo(titulo);
            LivroModel livroModel = livroModels.First();
            livroModel = livro;
            
            await DatabaseManager.databaseManager.SaveChangesAsync();
        }
        public static async void AtualizarViaAutor(string autor, LivroModel livro)
        {
            var livroModels = await BuscarLivrosAutor(autor);
            LivroModel livroModel = livroModels.First();
            livroModel = livro;
            
            await DatabaseManager.databaseManager.SaveChangesAsync();
        }
        #endregion
    }
}
