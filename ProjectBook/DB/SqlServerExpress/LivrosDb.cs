using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;
using ProjectBook.Livros;
using ProjectBook.Properties;
using ProjectBook.AppInsight;

namespace ProjectBook.DB.SqlServerExpress
{
    class LivrosDb : Db
    {
        public void AdicionarLivro(Livro livro)
        {
            SqlCommand command = new() { Connection = connection};
            #region Parâmetros
            command.Parameters.AddWithValue("@id", livro.id);
            command.Parameters.AddWithValue("@titulo", livro.titulo);
            command.Parameters.AddWithValue("@autor", livro.autor);
            command.Parameters.AddWithValue("@editora", livro.editora);
            command.Parameters.AddWithValue("@edicao", livro.edicao);
            command.Parameters.AddWithValue("@ano", livro.ano);
            command.Parameters.AddWithValue("@genero", livro.genero);
            command.Parameters.AddWithValue("@isbn", livro.isbn);
            command.Parameters.AddWithValue("@dataCadastro", livro.dataCadastro);
            command.Parameters.AddWithValue("@observacoes", livro.observacoes);
            #endregion
            try
            {
                command.CommandText = "INSERT INTO Livros(ID, Titulo, Autor, Editora, Edicao, Ano, Genero, Isbn, DataCadastro, Observacoes) " +
                "VALUES(@id, @titulo, @autor, @editora, @edicao, @ano, @genero, @isbn, @dataCadastro, @observacoes)";

                AbrirConexaoDb();
                command.ExecuteNonQuery();
                FechaConecxaoDb();

                command.Dispose();

                MessageBox.Show(Resources.LivroRegistrado, Resources.concluido_MessageBox,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(SqlException e) { MessageBox.Show(e.Message, Resources.MessageBoxError, MessageBoxButtons.OK, MessageBoxIcon.Error); 
                AppInsightMetrics.SendError(e); }
        }

        #region Deletar
        public void DeletarLivroId(string id)
        {
            SqlCommand command = new() { Connection = connection};

            try
            {
                command.CommandText = $"DELETE FROM Livros WHERE ID = {id}";

                AbrirConexaoDb();
                command.ExecuteNonQuery();
                FechaConecxaoDb();

                command.Dispose();

                MessageBox.Show(Resources.LivroDeletado, Resources.concluido_MessageBox,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException e) { MessageBox.Show(e.Message, Resources.MessageBoxError, MessageBoxButtons.OK, MessageBoxIcon.Error); 
                AppInsightMetrics.SendError(e); }
        }
        public void DeletarLivroTitulo(string tituloLivro)
        {
            SqlCommand command = new() { Connection = connection};

            try
            {
                command.CommandText = $"DELETE FROM Livros WHERE Titulo LIKE \'%{tituloLivro}%\'";

                AbrirConexaoDb();
                command.ExecuteNonQuery();
                FechaConecxaoDb();

                command.Dispose();

                MessageBox.Show(Resources.LivroDeletado, Resources.concluido_MessageBox,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException e) { MessageBox.Show(e.Message, Resources.MessageBoxError, MessageBoxButtons.OK, MessageBoxIcon.Error); 
                AppInsightMetrics.SendError(e); }
        }
        #endregion
        
        public DataTable VerTodosLivros()
        {
            DataTable table = new();
            try
            {
                AbrirConexaoDb();
                SqlDataAdapter adapter = new("SELECT * FROM Livros", connection);
                FechaConecxaoDb();

                adapter.Fill(table);
            }
            catch (SqlException e) { MessageBox.Show(e.Message, Resources.MessageBoxError, MessageBoxButtons.OK, MessageBoxIcon.Error); 
                AppInsightMetrics.SendError(e); }
            
            return table;
        }

        public DataTable PegarGeneros()
        {
            DataTable table = new();
            try
            {
                AbrirConexaoDb();
                SqlDataAdapter adapter = new("SELECT DISTINCT Genero FROM Livros", connection);
                FechaConecxaoDb();

                adapter.Fill(table);
            }
            catch (SqlException e) { MessageBox.Show(e.Message, Resources.MessageBoxError, MessageBoxButtons.OK, MessageBoxIcon.Error); 
                AppInsightMetrics.SendError(e); }

            return table;
        }

        #region Buscar
        public DataTable BuscarLivrosId(string id)
        {
            DataTable table = new();
            try
            {
                AbrirConexaoDb();
                SqlDataAdapter adapter = new($"SELECT * FROM Livros WHERE ID = ${id}", connection);
                FechaConecxaoDb();
                adapter.Fill(table);
            }
            catch (SqlException e) { MessageBox.Show(e.Message, Resources.MessageBoxError, MessageBoxButtons.OK, MessageBoxIcon.Error); 
                AppInsightMetrics.SendError(e); }

            return table;
        }
        public DataTable BuscarLivrosTitulo(string titulo)
        {
            DataTable table = new();
            try
            {
                AbrirConexaoDb();
                SqlDataAdapter adapter = new($"SELECT * FROM Livros WHERE Titulo LIKE \'%{titulo}%\'", connection);
                FechaConecxaoDb();
                adapter.Fill(table);
            }
            catch (SqlException e) { MessageBox.Show(e.Message, Resources.MessageBoxError, MessageBoxButtons.OK, MessageBoxIcon.Error); 
                AppInsightMetrics.SendError(e);}

            return table;
        }
        public DataTable BuscarLivrosAutor(string autor)
        {
            DataTable table = new();
            try
            {
                AbrirConexaoDb();
                SqlDataAdapter adapter = new($"SELECT * FROM Livros WHERE Autor LIKE \'%{autor}%\'", connection);
                FechaConecxaoDb();

                adapter.Fill(table);
            }
            catch (SqlException e) { MessageBox.Show(e.Message, Resources.MessageBoxError, MessageBoxButtons.OK, MessageBoxIcon.Error); 
                AppInsightMetrics.SendError(e); }

            return table;
        }
        public DataTable BuscarLivrosGenero(string genero)
        {
            DataTable table = new();
            try
            {
                AbrirConexaoDb();
                SqlDataAdapter adapter = new($"SELECT * FROM Livros WHERE Genero = \'{genero}\'", connection);
                FechaConecxaoDb();

                adapter.Fill(table);
            }
            catch (SqlException e) { MessageBox.Show(e.Message, Resources.MessageBoxError, MessageBoxButtons.OK, MessageBoxIcon.Error); 
                AppInsightMetrics.SendError(e);}

            return table;
        }
        #endregion

        #region Atualizar
        public void AtualizarViaId(string id, Livro livro)
        {
            SqlCommand command = new() { Connection = connection};
            #region Parâmetros
            command.Parameters.AddWithValue("@titulo", livro.titulo);
            command.Parameters.AddWithValue("@autor", livro.autor);
            command.Parameters.AddWithValue("@editora", livro.editora);
            command.Parameters.AddWithValue("@edicao", livro.edicao);
            command.Parameters.AddWithValue("@ano", livro.ano);
            command.Parameters.AddWithValue("@genero", livro.genero);
            command.Parameters.AddWithValue("@isbn", livro.isbn);
            command.Parameters.AddWithValue("@observacoes", livro.observacoes);
            #endregion
            try
            {
                command.CommandText = "UPDATE Livros SET Titulo = @titulo, Autor = @autor, Editora = @editora," +
                    $" Edicao = @edicao, Ano = @ano, Genero = @genero, Isbn = @isbn," +
                    $" Observacoes = @observacoes WHERE ID = {id}";

                AbrirConexaoDb();
                command.ExecuteNonQuery();
                FechaConecxaoDb();

                command.Dispose();

                MessageBox.Show(Resources.informações_atualizadas, Resources.concluido_MessageBox, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException e) { MessageBox.Show(e.Message, Resources.MessageBoxError, MessageBoxButtons.OK, MessageBoxIcon.Error); 
                AppInsightMetrics.SendError(e); }
        }
        public void AtualizarViaTitulo(string titulo, Livro livro)
        {
            SqlCommand command = new() { Connection = connection};
            #region Parâmetros
            command.Parameters.AddWithValue("@titulo", livro.titulo);
            command.Parameters.AddWithValue("@autor", livro.autor);
            command.Parameters.AddWithValue("@editora", livro.editora);
            command.Parameters.AddWithValue("@edicao", livro.edicao);
            command.Parameters.AddWithValue("@ano", Convert.ToInt32(livro.ano));
            command.Parameters.AddWithValue("@genero", livro.genero);
            command.Parameters.AddWithValue("@isbn", livro.isbn);
            command.Parameters.AddWithValue("@observacoes", livro.observacoes);
            #endregion
            try
            {
                command.CommandText = "UPDATE Livros SET Titulo = @titulo, Autor = @autor, Editora = @editora," +
                    $" Edicao = @edicao, Ano = @ano, Genero = @genero, Isbn = @isbn," +
                    $" Observacoes = @observacoes WHERE Titulo = \'{titulo}\'";

                AbrirConexaoDb();
                command.ExecuteNonQuery();
                FechaConecxaoDb();

                command.Dispose();

                MessageBox.Show(Resources.informações_atualizadas, Resources.concluido_MessageBox, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException e) { MessageBox.Show(e.Message, Resources.MessageBoxError, MessageBoxButtons.OK, MessageBoxIcon.Error); 
                AppInsightMetrics.SendError(e); }
        }
        public void AtualizarViaAutor(string autor, Livro livro)
        {
            SqlCommand command = new() { Connection = connection};
            #region Parâmetros
            command.Parameters.AddWithValue("@titulo", livro.titulo);
            command.Parameters.AddWithValue("@autor", livro.autor);
            command.Parameters.AddWithValue("@editora", livro.editora);
            command.Parameters.AddWithValue("@edicao", livro.edicao);
            command.Parameters.AddWithValue("@ano", Convert.ToInt32(livro.ano));
            command.Parameters.AddWithValue("@genero", livro.genero);
            command.Parameters.AddWithValue("@isbn", livro.isbn);
            command.Parameters.AddWithValue("@observacoes", livro.observacoes);
            #endregion
            try
            {
                command.CommandText = "UPDATE Livros SET Titulo = @titulo, Autor = @autor, Editora = @editora," +
                    $" Edicao = @edicao, Ano = @ano, Genero = @genero, Isbn = @isbn," +
                    $" Observacoes = @observacoes WHERE Autor = \'{autor}\'";

                AbrirConexaoDb();
                command.ExecuteNonQuery();
                FechaConecxaoDb();

                command.Dispose();

                MessageBox.Show(Resources.informações_atualizadas, Resources.concluido_MessageBox, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException e) { MessageBox.Show(e.Message, Resources.MessageBoxError, MessageBoxButtons.OK, MessageBoxIcon.Error); 
                AppInsightMetrics.SendError(e); }
        }
        #endregion
    }
}
