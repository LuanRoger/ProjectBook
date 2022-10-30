using Microsoft.EntityFrameworkCore;
using ProjectBook.Model;

namespace ProjectBook.DB.Models
{
    public class LivrosContext : ICrudContext<LivroModel>
    {
        public IDatabaseContextModels contextModels { get; set; }

        public LivrosContext(IDatabaseContextModels contextModels)
        {
            this.contextModels = contextModels;
        }
        
        public void Create(LivroModel model)
        {
            contextModels.livrosContext.Add(model);
        }

        #region Read
        public LivroModel ReadById(int id)
        {
            return contextModels.livrosContext.Find(id);
        }

        public List<LivroModel> ReadAll()
        {
            return contextModels.livrosContext.ToList();
        }

        public async Task<List<LivroModel>> ReadAllAsync()
        {
            return await contextModels.livrosContext.ToListAsync();
        }
        #region Search
        public async Task<List<string>> GetGenres()
        {
            return await contextModels.livrosContext.Select(livroModel => livroModel.genero).ToListAsync();
        }
        public async Task<List<LivroModel>> SearchLivrosTitulo(string titulo)
        {
            return await contextModels.livrosContext
                .Where(livro => livro.titulo.Contains(titulo))
                .ToListAsync();
        }
            
        public async Task<List<LivroModel>> SearchLivrosAutor(string autor)
        {
            return await contextModels.livrosContext
                .Where(livro => livro.autor.Contains(autor))
                .ToListAsync();
        }
            
        public async Task<List<LivroModel>> SearchLivrosGenero(string genero)
        {
            return await contextModels.livrosContext
                .Where(livro => livro.genero.Contains(genero))
                .ToListAsync();
        }
        #endregion
        #endregion
        
        #region Deletar
        public void DeleteById(int id)
        {
            LivroModel livroModel = contextModels.livrosContext.Find(id);
            if (livroModel == null) return;
        
            contextModels.livrosContext.Remove(livroModel);
        }
        public void DeleteLivroTitulo(string tituloLivro)
        {
            LivroModel livroModel = contextModels.livrosContext
                .FirstOrDefault(livro => livro.titulo == tituloLivro);
            if(livroModel is null) return;
            
            contextModels.livrosContext.Remove(livroModel);
        }
        #endregion

        #region Update
        public void UpdateById(int id, LivroModel newValue)
        {
            LivroModel livroModel = contextModels.livrosContext.Find(id);
            if(livroModel is null) return;
            
            livroModel.id = newValue.id;
            livroModel.titulo = newValue.titulo;
            livroModel.autor = newValue.autor;
            livroModel.editora = newValue.editora;
            livroModel.edicao = newValue.edicao;
            livroModel.ano = newValue.ano;
            livroModel.genero = newValue.genero;
            livroModel.isbn = newValue.isbn;
            livroModel.dataCadastro = newValue.dataCadastro;
            livroModel.observacoes = newValue.observacoes;
        }
        public void UpdateByTitulo(string titulo, LivroModel newValue)
        {
            LivroModel livroModel = contextModels.livrosContext
                .FirstOrDefault(model => model.titulo.Contains(titulo));
            if(livroModel is null) return;
            
            livroModel.id = newValue.id;
            livroModel.titulo = newValue.titulo;
            livroModel.autor = newValue.autor;
            livroModel.editora = newValue.editora;
            livroModel.edicao = newValue.edicao;
            livroModel.ano = newValue.ano;
            livroModel.genero = newValue.genero;
            livroModel.isbn = newValue.isbn;
            livroModel.dataCadastro = newValue.dataCadastro;
            livroModel.observacoes = newValue.observacoes;
        }
        public void UpdateByAutor(string autor, LivroModel newValue)
        {
            LivroModel livroModel = contextModels.livrosContext
                .FirstOrDefault(model => model.autor.Contains(autor));
            if(livroModel is null) return;
            
            livroModel.id = newValue.id;
            livroModel.titulo = newValue.titulo;
            livroModel.autor = newValue.autor;
            livroModel.editora = newValue.editora;
            livroModel.edicao = newValue.edicao;
            livroModel.ano = newValue.ano;
            livroModel.genero = newValue.genero;
            livroModel.isbn = newValue.isbn;
            livroModel.dataCadastro = newValue.dataCadastro;
            livroModel.observacoes = newValue.observacoes;
        }
        #endregion
    }
}
