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
            using DatabaseManager databaseManager = new();
            
            databaseManager.livroModel.Add(livro);
            
            databaseManager.Database.OpenConnection();
            try
            {
                databaseManager.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Livros ON");
                databaseManager.SaveChanges();
                databaseManager.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Livros OFF");
            }
            finally
            {
                databaseManager.Database.CloseConnection();
            }
        }

        #region Deletar
        public static void DeletarLivroId(int id)
        {
            using DatabaseManager databaseManager = new();
            
            databaseManager.livroModel.Remove(new() {id = id});
            databaseManager.SaveChanges();
        }
        public static void DeletarLivroTitulo(string tituloLivro)
        {
            using DatabaseManager databaseManager = new();
            
            databaseManager.livroModel.Remove(databaseManager.livroModel
                .Where(livro => livro.titulo == tituloLivro)
                .ToList()
                .First());
            databaseManager.SaveChanges();
        }
        #endregion

        #region Buscar
        public static async Task<List<LivroModel>> VerTodosLivros()
        {
            await using DatabaseManager databaseManager = new();
            return await databaseManager.livroModel.ToListAsync();
        }
            

        public static async Task<List<string>> PegarGeneros()
        {
            var livroModels = await VerTodosLivros();
            return livroModels.Select(livroModel => livroModel.genero).ToList();
        }

        public static async Task<LivroModel> BuscarLivrosId(int id)
        {
            await using DatabaseManager databaseManager = new();
            
            return await databaseManager.livroModel.FindAsync(id);
        }
        public static async Task<List<LivroModel>> BuscarLivrosTitulo(string titulo)
        {
            await using DatabaseManager databaseManager = new();
            
            return await databaseManager.livroModel.Where(livro => livro.titulo.Contains(titulo))
                            .ToListAsync();
        }
            
        public static async Task<List<LivroModel>> BuscarLivrosAutor(string autor)
        {
            using DatabaseManager databaseManager = new();
            
            return await databaseManager.livroModel.Where(livro => livro.autor.Contains(autor))
                            .ToListAsync();
        }
            
        public static async Task<List<LivroModel>> BuscarLivrosGenero(string genero)
        {
            await using DatabaseManager databaseManager = new();
            
            return await databaseManager.livroModel.Where(livro => livro.genero.Contains(genero))
                            .ToListAsync();
        }
            
        #endregion

        #region Atualizar
        public static async void AtualizarViaId(int id, LivroModel livro)
        {
            await using DatabaseManager databaseManager = new();
            
            LivroModel livroModel = await databaseManager.livroModel.FindAsync(id);
            
            livroModel.id = livro.id;
            livroModel.titulo = livro.titulo;
            livroModel.autor = livro.autor;
            livroModel.editora = livro.editora;
            livroModel.edicao = livro.edicao;
            livroModel.ano = livro.ano;
            livroModel.genero = livro.genero;
            livroModel.isbn = livro.isbn;
            livroModel.dataCadastro = livro.dataCadastro;
            livroModel.observacoes = livro.observacoes;

            databaseManager.SaveChanges();
        }
        public static async void AtualizarViaTitulo(string titulo, LivroModel livro)
        {
            await using DatabaseManager databaseManager = new();
            
            LivroModel livroModel = (await databaseManager.livroModel
                .Where(model => model.titulo.Contains(titulo))
                .ToListAsync()).First();
            
            livroModel.id = livro.id;
            livroModel.titulo = livro.titulo;
            livroModel.autor = livro.autor;
            livroModel.editora = livro.editora;
            livroModel.edicao = livro.edicao;
            livroModel.ano = livro.ano;
            livroModel.genero = livro.genero;
            livroModel.isbn = livro.isbn;
            livroModel.dataCadastro = livro.dataCadastro;
            livroModel.observacoes = livro.observacoes;
            
            await databaseManager.SaveChangesAsync();
        }
        public static async void AtualizarViaAutor(string autor, LivroModel livro)
        {
            await using DatabaseManager databaseManager = new();
            
            LivroModel livroModel = (await databaseManager.livroModel.Where(model => model.autor.Contains(autor))
                .ToListAsync()).First();
            
            livroModel.id = livro.id;
            livroModel.titulo = livro.titulo;
            livroModel.autor = livro.autor;
            livroModel.editora = livro.editora;
            livroModel.edicao = livro.edicao;
            livroModel.ano = livro.ano;
            livroModel.genero = livro.genero;
            livroModel.isbn = livro.isbn;
            livroModel.dataCadastro = livro.dataCadastro;
            livroModel.observacoes = livro.observacoes;
            
            await databaseManager.SaveChangesAsync();
        }
        #endregion
    }
}
