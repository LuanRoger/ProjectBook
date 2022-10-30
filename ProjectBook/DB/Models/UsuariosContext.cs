using Microsoft.EntityFrameworkCore;
using ProjectBook.Model;
using ProjectBook.Model.Enums;

namespace ProjectBook.DB.Models
{
    public class UsuariosContext : ICrudContext<UsuarioModel>
    {
        public IDatabaseContextModels contextModels { get; set; }

        public UsuariosContext(IDatabaseContextModels contextModels)
        {
            this.contextModels = contextModels;
        }

        public void Create(UsuarioModel model)
        {
            contextModels.usuarioContext.Add(model);
        }

        #region Deletar
        public void DeleteById(int id)
        {
            LivroModel livroModel = contextModels.livrosContext.Find(id);
            if (livroModel == null) return;
        
            contextModels.livrosContext.Remove(livroModel);
        }
        #endregion

        #region Read
        public UsuarioModel ReadById(int id)
        {
            return contextModels.usuarioContext.Find(id);
        }

        public List<UsuarioModel> ReadAll()
        {
            return contextModels.usuarioContext.ToList();
        }

        public async Task<List<UsuarioModel>> ReadAllAsync()
        {
            return await contextModels.usuarioContext.ToListAsync();
        }
        #region Search
        public async Task<List<UsuarioModel>> SearchUsuarioNome(string userName)
        {
            return await contextModels.usuarioContext
                .Where(usuario => usuario.usuario.Contains(userName))
                .ToListAsync();
        }
            
        public async Task<List<UsuarioModel>> GetAllAdms()
        {
            return await contextModels.usuarioContext
                .Where(usuairo => usuairo.tipo.Equals(TipoUsuario.ADM))
                .ToListAsync();
        }
            
        public async Task<List<UsuarioModel>> GetAllUsu()
        {
            return await contextModels.usuarioContext
                .Where(usuairo => usuairo.tipo.Equals(TipoUsuario.USU))
                .ToListAsync();
        }
            
        #endregion
        #endregion

        #region Atualizar
        public void UpdateById(int id, UsuarioModel newValue)
        {
            UsuarioModel usuarioModel = contextModels.usuarioContext.Find(id);
            if(usuarioModel is null) return;
            
            usuarioModel.usuario = newValue.usuario;
            usuarioModel.senha = newValue.senha;
            usuarioModel.tipo = newValue.tipo;
        }
        #endregion

        #region Login
        public UsuarioModel LoginUserName(string userName, string password)
        {
            return contextModels.usuarioContext
                .FirstOrDefault(usuario => usuario.usuario.Equals(userName) && 
                                           usuario.senha.Equals(password));   
        }
        public UsuarioModel LoginId(int id, string senha)
        {
            return contextModels.usuarioContext
                            .FirstOrDefault(usuario => usuario.id.Equals(id) &&
                                               usuario.senha.Equals(senha));
        }
            
        #endregion
        
        public TipoUsuario CheckUserTypeById(int id)
        {
            return contextModels.usuarioContext.Find(id)!.tipo;
        }
        public TipoUsuario CheckUserTypeByUsername(string userName)
        {
            return contextModels.usuarioContext
                            .First(usuario => usuario.usuario.Equals(userName)).tipo;
        }
    }
}