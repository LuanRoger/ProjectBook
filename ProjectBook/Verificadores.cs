using System;
using System.Data;
using ProjectBook.Livros;
using ProjectBook.DB.SqlServerExpress;

namespace ProjectBook
{
    class Verificadores
    {
        public static bool VerificarCamposLivros(Livro livro)
        {
            return livro.titulo.Length == 0 || livro.autor.Length == 0 || livro.editora.Length == 0 || livro.ano.Length == 0;
        }
        public static bool VerificarCamposAluguel(Aluguel aluguel)
        {
            return aluguel.titulo.Length == 0 || aluguel.autor.Length == 0 || aluguel.alugadoPor.Length == 0;
        }
        public static bool VerificarCamposCliente(Cliente cliente)
        {
            return cliente.nomeCompleto.Length == 0 || cliente.cidade.Length == 0 || cliente.estado.Length == 0 || cliente.telefone1.Length == 0;
        }
        public static bool VerificarCamposUsuario(Usuario usuario)
        {
            return usuario.usuario.Length == 0 || usuario.senha.Length == 0 || usuario.tipo.Length == 0;
        }
        public static bool VerificarDataTable(DataTable table)
        {
            return table.Rows.Count == 0;
        }
        public static bool VerificarIdLivro(int id)
        {
            LivrosDb livrosDb = new LivrosDb();

            livrosDb.AbrirConexaoDb();
            DataTable ids = livrosDb.BuscarLivrosId(id.ToString());
            livrosDb.FechaConecxaoDb();

            return ids.Rows.Count > 0;
        }

        #region Verificar strings
        public static bool VerificarStrings(string valor1) => String.IsNullOrEmpty(valor1);
        public static bool VerificarStrings(string valor1, string valor2) => String.IsNullOrEmpty(valor1) || String.IsNullOrEmpty(valor2);
        public static bool VerificarStrings(string valor1, string valor2, string valor3) => String.IsNullOrEmpty(valor1) || String.IsNullOrEmpty(valor2) || String.IsNullOrEmpty(valor3);
        #endregion
    }
}
