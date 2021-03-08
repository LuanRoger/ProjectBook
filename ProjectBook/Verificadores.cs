using System;
using System.Data;
using ProjectBook.Livros;
using ProjectBook.DB.SqlServerExpress;

namespace ProjectBook
{
    class Verificadores
    {
        /// <summary>
        /// Verificar todos os campos obrigatórios em <c>Livro</c>.
        /// </summary>
        /// <param name="livro"><c>Livro</c> que será analisado</param>.
        /// <returns>Retorna <c>error</c></returns>
        public static bool VerificarCamposLivros(Livro livro)
        {
            return livro.titulo.Length == 0 || livro.autor.Length == 0 || livro.editora.Length == 0 || livro.ano.Length == 0;
        }

        /// <summary>
        /// Verificar todos os campos obrigatórios em <c>Aluguel</c>.
        /// </summary>
        /// <param name="aluguel"><c>Aluguel</c> que será analisado</param>.
        /// <returns>Retorna <c>error</c></returns>
        public static bool VerificarCamposAluguel(Aluguel aluguel)
        {
            return aluguel.titulo.Length == 0 || aluguel.autor.Length == 0 || aluguel.alugadoPor.Length == 0;
        }

        /// <summary>
        /// Verificar todos os campos obrigatórios em <c>Cliente</c>.
        /// </summary>
        /// <param name="cliente"><c>Cliente</c> que será analisado</param>.
        /// <returns>Retorna <c>error</c></returns>
        public static bool VerificarCamposCliente(Cliente cliente)
        {
            return cliente.nomeCompleto.Length == 0 || cliente.cidade.Length == 0 || cliente.estado.Length == 0 || cliente.telefone1.Length == 0;
        }

        /// <summary>
        /// Verificar todos os campos obrigatórios em <c>Usuario</c>.
        /// </summary>
        /// <param name="usuario"><c>Usuario</c> que será analisado</param>.
        /// <returns>Retorna <c>error</c></returns>
        public static bool VerificarCamposUsuario(Usuario usuario)
        {
            return usuario.usuario.Length == 0 || usuario.senha.Length == 0 || usuario.tipo.Length == 0;
        }

        /// <summary>
        /// Verifica se uma <c>DataTable</c> está vazia.
        /// </summary>
        /// <param name="table"><c>DataTable</c> que será analisado</param>.
        /// <returns>Retorna <c>error</c></returns>
        public static bool VerificarDataTable(DataTable table)
        {
            return table.Rows.Count == 0;
        }

        /// <summary>
        /// Verifica se já existe um mesmo <c>id</c> cadastrado.
        /// </summary>
        /// <param name="id"><c>id</c> que será usado para procurar um igual</param>.
        /// <returns>Retorna <c>error</c></returns>
        public static bool VerificarIdLivro(int id)
        {
            LivrosDb livrosDb = new LivrosDb();

            DataTable ids = livrosDb.BuscarLivrosId(id.ToString());

            return ids.Rows.Count > 0;
        }

        #region Verificar strings
        /// <summary>
        /// Verifica se <c>string.IsNullOrEmpty(valor1)</c>
        /// </summary>
        /// <param name="valor1">Valor que será verificado</param>
        /// <returns>Retorna <c>error</c></returns>
        public static bool VerificarStrings(string valor1) => string.IsNullOrEmpty(valor1);
        public static bool VerificarStrings(string valor1, string valor2) => string.IsNullOrEmpty(valor1) || string.IsNullOrEmpty(valor2);
        public static bool VerificarStrings(string valor1, string valor2, string valor3) => string.IsNullOrEmpty(valor1) || string.IsNullOrEmpty(valor2) || string.IsNullOrEmpty(valor3);
        #endregion
    }
}
