﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;
using ProjectBook.Livros;
using ProjectBook.Properties;

namespace ProjectBook.DB.SqlServerExpress
{
    class LivrosDb : Db
    {
        public void AdicionarLivro(Livro livro)
        {
            SqlCommand command = new SqlCommand {Connection = connection};
            #region Parâmetros
            command.Parameters.AddWithValue("@id", livro.id);
            command.Parameters.AddWithValue("@titulo", livro.titulo);
            command.Parameters.AddWithValue("@autor", livro.autor);
            command.Parameters.AddWithValue("@editora", livro.editora);
            command.Parameters.AddWithValue("@edicao", livro.edicao);
            command.Parameters.AddWithValue("@ano", livro.ano);
            command.Parameters.AddWithValue("@genero", livro.genero);
            command.Parameters.AddWithValue("@isbn", livro.isbn);
            #endregion
            try
            {
                command.CommandText = "INSERT INTO Livros(ID, Titulo, Autor, Editora, Edicao, Ano, Genero, Isbn) " +
                "VALUES(@id, @titulo, @autor, @editora, @edicao, @ano, @genero, @isbn)";
                command.ExecuteNonQuery();
                command.Dispose();

                MessageBox.Show(Resources.livro_registrado_com_sucesso, Resources.concluido_MessageBox,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(SqlException e) { MessageBox.Show(e.Message, Resources.error_MessageBox, MessageBoxButtons.OK, MessageBoxIcon.Error);  }
        }

        #region Deletar
        public void DeletarLivroId(string id)
        {
            SqlCommand command = new SqlCommand {Connection = connection};

            try
            {
                command.CommandText = $"DELETE FROM Livros WHERE ID = {id}";
                command.ExecuteNonQuery();
                command.Dispose();

                MessageBox.Show(Resources.livro_deletado_com_sucesso, Resources.concluido_MessageBox,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException e) { MessageBox.Show(e.Message, Resources.error_MessageBox, MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        public void DeletarLivroTitulo(string tituloLivro)
        {
            SqlCommand command = new SqlCommand {Connection = connection};

            try
            {
                command.CommandText = $"DELETE FROM Livros WHERE Titulo LIKE \'%{tituloLivro}%\'";
                command.ExecuteNonQuery();
                command.Dispose();

                MessageBox.Show(Resources.livro_deletado_com_sucesso, Resources.concluido_MessageBox,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException e) { MessageBox.Show(e.Message, Resources.error_MessageBox, MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        #endregion
        
        public DataTable VerTodosLivros()
        {
            DataTable table = new DataTable();
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Livros", connection);
                adapter.Fill(table);
            }
            catch (SqlException e) { MessageBox.Show(e.Message, Resources.error_MessageBox,
                MessageBoxButtons.OK, MessageBoxIcon.Error); }
            
            return table;
        }

        public DataTable PegarGeneros()
        {
            DataTable table = new DataTable();
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT DISTINCT Genero FROM Livros", connection);
                adapter.Fill(table);
            }
            catch (SqlException e) { MessageBox.Show(e.Message, Resources.error_MessageBox,
                MessageBoxButtons.OK, MessageBoxIcon.Error); }

            return table;
        }

        #region Buscar
        public DataTable BuscarLivrosId(string id)
        {
            DataTable table = new DataTable();
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter($"SELECT * FROM Livros WHERE ID = ${id}", connection);
                adapter.Fill(table);
            }
            catch (SqlException e) { MessageBox.Show(e.Message, Resources.error_MessageBox, MessageBoxButtons.OK, MessageBoxIcon.Error); }

            return table;
        }
        public DataTable BuscarLivrosTitulo(string titulo)
        {
            DataTable table = new DataTable();
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter($"SELECT * FROM Livros WHERE Titulo LIKE \'%{titulo}%\'", connection);
                adapter.Fill(table);
            }
            catch (SqlException e) { MessageBox.Show(e.Message, Resources.error_MessageBox, MessageBoxButtons.OK, MessageBoxIcon.Error); }

            return table;
        }
        public DataTable BuscarLivrosAutor(string autor)
        {
            DataTable table = new DataTable();
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter($"SELECT * FROM Livros WHERE Autor LIKE \'%{autor}%\'", connection);
                adapter.Fill(table);
            }
            catch (SqlException e) { MessageBox.Show(e.Message, Resources.error_MessageBox, MessageBoxButtons.OK, MessageBoxIcon.Error); }

            return table;
        }
        #endregion

        #region Atualizar
        public void AtualizarViaId(string id, Livro livro)
        {
            SqlCommand command = new SqlCommand {Connection = connection};
            #region Parâmetros
            command.Parameters.AddWithValue("@titulo", livro.titulo);
            command.Parameters.AddWithValue("@autor", livro.autor);
            command.Parameters.AddWithValue("@editora", livro.editora);
            command.Parameters.AddWithValue("@edicao", livro.edicao);
            command.Parameters.AddWithValue("@ano", Convert.ToInt32(livro.ano));
            command.Parameters.AddWithValue("@genero", livro.genero);
            command.Parameters.AddWithValue("@isbn", livro.isbn);
            #endregion
            try
            {
                command.CommandText = "UPDATE Livros SET Titulo = @titulo, Autor = @autor, Editora = @editora," +
                    $" Edicao = @edicao, Ano = @ano, Genero = @genero, Isbn = @isbn WHERE ID = {id}";
                command.ExecuteNonQuery();
                command.Dispose();

                MessageBox.Show(Resources.informações_atualizadas, Resources.concluido_MessageBox, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException e) { MessageBox.Show(e.Message, Resources.error_MessageBox, MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        public void AtualizarViaTitulo(string titulo, Livro livro)
        {
            SqlCommand command = new SqlCommand {Connection = connection};
            #region Parâmetros
            command.Parameters.AddWithValue("@titulo", livro.titulo);
            command.Parameters.AddWithValue("@autor", livro.autor);
            command.Parameters.AddWithValue("@editora", livro.editora);
            command.Parameters.AddWithValue("@edicao", livro.edicao);
            command.Parameters.AddWithValue("@ano", Convert.ToInt32(livro.ano));
            command.Parameters.AddWithValue("@genero", livro.genero);
            command.Parameters.AddWithValue("@isbn", livro.isbn);
            #endregion
            try
            {
                command.CommandText = "UPDATE Livros SET Titulo = @titulo, Autor = @autor, Editora = @editora," +
                    $" Edicao = @edicao, Ano = @ano, Genero = @genero, Isbn = @isbn WHERE Titulo = \'{titulo}\'";
                command.ExecuteNonQuery();
                command.Dispose();

                MessageBox.Show(Resources.informações_atualizadas, Resources.concluido_MessageBox, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException e) { MessageBox.Show(e.Message, Resources.error_MessageBox, MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        public void AtualizarViaAutor(string autor, Livro livro)
        {
            SqlCommand command = new SqlCommand {Connection = connection};
            #region Parâmetros
            command.Parameters.AddWithValue("@titulo", livro.titulo);
            command.Parameters.AddWithValue("@autor", livro.autor);
            command.Parameters.AddWithValue("@editora", livro.editora);
            command.Parameters.AddWithValue("@edicao", livro.edicao);
            command.Parameters.AddWithValue("@ano", Convert.ToInt32(livro.ano));
            command.Parameters.AddWithValue("@genero", livro.genero);
            command.Parameters.AddWithValue("@isbn", livro.isbn);
            #endregion
            try
            {
                command.CommandText = "UPDATE Livros SET Titulo = @titulo, Autor = @autor, Editora = @editora," +
                    $" Edicao = @edicao, Ano = @ano, Genero = @genero, Isbn = @isbn WHERE Autor = \'{autor}\'";
                command.ExecuteNonQuery();
                command.Dispose();

                MessageBox.Show(Resources.informações_atualizadas, Resources.concluido_MessageBox, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException e) { MessageBox.Show(e.Message, Resources.error_MessageBox, MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        #endregion
    }
}
