namespace ProjectBook.Livros
{
    public class UsuarioModel
    {
        public string usuario { get; set; }
        public string senha { get; set; }
        public string tipo { get; set; }
        
        public UsuarioModel(string usuario, string senha, string tipo)
        {
            this.usuario = usuario;
            this.senha = senha;
            this.tipo = tipo;
        }
    }
}