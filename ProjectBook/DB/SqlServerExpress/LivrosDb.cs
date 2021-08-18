using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectBook.Livros;

namespace ProjectBook.DB.SqlServerExpress
{
    public class LivrosDb
    {
        public void AdicionarLivro(LivroModel livro)
        {
            DatabaseManager.databaseManager.livroModel.Add(livro);
            DatabaseManager.databaseManager.SaveChanges();
        }

        #region Deletar
        public void DeletarLivroId(int id)
        {
            DatabaseManager.databaseManager.livroModel.Remove(new() {id = id});
            DatabaseManager.databaseManager.SaveChanges();
        }
        public void DeletarLivroTitulo(string tituloLivro)
        {
            DatabaseManager.databaseManager.livroModel.Remove(new() {titulo = tituloLivro});
            DatabaseManager.databaseManager.SaveChanges();
        }
        #endregion

        #region Buscar
        public async Task<List<LivroModel>> VerTodosLivros() => 
            await DatabaseManager.databaseManager.livroModel.ToListAsync();

        public async Task<List<string>> PegarGeneros()
        {
            var livroModels = await VerTodosLivros();
            return livroModels.Select(livroModel => livroModel.genero).ToList();
        }
        
        public async Task<LivroModel> BuscarLivrosId(int id) => 
            await DatabaseManager.databaseManager.livroModel.FindAsync(id);
        public async Task<List<LivroModel>> BuscarLivrosTitulo(string titulo) =>
            await DatabaseManager.databaseManager.livroModel.Where(livro => livro.titulo.Contains(titulo))
                .ToListAsync();
        public async Task<List<LivroModel>> BuscarLivrosAutor(string autor) =>
            await DatabaseManager.databaseManager.livroModel.Where(livro => livro.autor.Contains(autor))
                .ToListAsync();
        public async Task<List<LivroModel>> BuscarLivrosGenero(string genero) =>
            await DatabaseManager.databaseManager.livroModel.Where(livro => livro.genero.Contains(genero))
                .ToListAsync();
        #endregion

        #region Atualizar
        public async void AtualizarViaId(int id, LivroModel livro)
        {
            LivroModel livroModel = await BuscarLivrosId(id);
            livroModel ??= livro;
            
            await DatabaseManager.databaseManager.SaveChangesAsync();
            DatabaseManager.DisposeInstance();
        }
        public async void AtualizarViaTitulo(string titulo, LivroModel livro)
        {
            var livroModels = await BuscarLivrosTitulo(titulo);
            LivroModel livroModel = livroModels.First();
            livroModel = livro;
            
            await DatabaseManager.databaseManager.SaveChangesAsync();
            DatabaseManager.DisposeInstance();
        }
        public async void AtualizarViaAutor(string autor, LivroModel livro)
        {
            var livroModels = await BuscarLivrosAutor(autor);
            LivroModel livroModel = livroModels.First();
            livroModel = livro;
            
            await DatabaseManager.databaseManager.SaveChangesAsync();
            DatabaseManager.DisposeInstance();
        }
        #endregion
    }
}
