using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using ProjectBook.Livros;
using ProjectBook.DB.SqlServerExpress;

namespace ProjectBook
{
    class Verificadores
    {
        public static bool VerificarCamposLivros(Livro livro)
        {
            bool error = false;
            if (livro.titulo.Length == 0 || livro.autor.Length == 0 || livro.editora.Length == 0 || livro.edicao.Length == 0
                || livro.genero.Length == 0 || livro.isbn.Length == 0) error = true;
            return error;
        }
        public static bool VerificarCamposAluguel(Aluguel aluguel)
        {
            bool error = false;
            if (aluguel.titulo.Length == 0 || aluguel.autor.Length == 0 || aluguel.alugadoPor.Length == 0) error = true;
            return error;
        }
        public static bool VerificarCamposCliente(Cliente cliente)
        {
            bool error = false;
            if (cliente.nomeCompleto.Length == 0 || cliente.cidade.Length == 0 || cliente.estado.Length == 0 || cliente.telefone1.Length == 0) 
                error = true;
            return error;
        }
        public static bool VerificarCamposUsuario(Usuario usuario)
        {
            bool error = false;
            if (usuario.usuario.Length == 0 || usuario.senha.Length == 0 || usuario.tipo.Length == 0) 
                error = true;
            return error;
        }
        public static bool VerificarDataTable(DataTable table)
        {
            bool error = false;
            if (table.Rows.Count == 0) error = true;
            return error;
        }

        #region Verificar strings
        public static bool VerificarStrings(string valor1)
        {
            bool error = false;
            if (String.IsNullOrEmpty(valor1)) { error = true; }
            return error;
        }
        public static bool VerificarStrings(string valor1, string valor2)
        {
            bool error = false;
            if (String.IsNullOrEmpty(valor1) || String.IsNullOrEmpty(valor2)) { error = true; }
            return error;
        }
        public static bool VerificarStrings(string valor1, string valor2, string valor3)
        {
            bool error = false;
            if (String.IsNullOrEmpty(valor1) || String.IsNullOrEmpty(valor2) || String.IsNullOrEmpty(valor3)) { error = true; }
            return error;
        }
        #endregion
    }
}
