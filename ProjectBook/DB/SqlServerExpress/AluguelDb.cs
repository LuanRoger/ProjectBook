using ProjectBook.Livros;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ProjectBook.DB.SqlServerExpress
{
    class AluguelDb : Db
    {
        public void CadastrarAluguel(Aluguel aluguel)
        {
            SqlCommand command = new SqlCommand {Connection = connection};
            #region Parâmetros
            command.Parameters.AddWithValue("@titulo", aluguel.titulo);
            command.Parameters.AddWithValue("@autor", aluguel.autor);
            command.Parameters.AddWithValue("@alugadoPor", aluguel.alugadoPor);
            command.Parameters.AddWithValue("@dataEntrega", aluguel.dataEntrega);
            command.Parameters.AddWithValue("@dataRecebimento", aluguel.dataRecebimento);
            command.Parameters.AddWithValue("@status", aluguel.status);
            #endregion
            try
            {
                command.CommandText = "INSERT INTO Aluguel(Titulo, Autor, [Alugado por], [Data da entrega], [Data do recebimento], Status) " +
                "VALUES(@titulo, @autor, @alugadoPor, @dataEntrega, @dataRecebimento, @status)";
                command.ExecuteNonQuery();
                command.Dispose();

                MessageBox.Show("Aluguel registrado com sucesso", "Concluido",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException e) { MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        public DataTable VerTodosAluguel()
        {
            SqlDataAdapter adapter;
            DataTable table = new DataTable();
            try
            {
                adapter = new SqlDataAdapter("SELECT * FROM Aluguel", connection);
                adapter.Fill(table);
            }
            catch (SqlException e) { MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }

            return table;
        }

        #region Deletar
        public void DeletarAluguelTitulo(string titulo)
        {
            SqlCommand command = new SqlCommand {Connection = connection};

            try
            {
                command.CommandText = $"DELETE FROM Aluguel WHERE Titulo = \'{titulo}\'";
                command.ExecuteNonQuery();
                command.Dispose();

                MessageBox.Show("Livro deletado com sucesso", "Concluido",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException e) { MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        public void DeletarAluguelCliente(string nomeCliente)
        {
            SqlCommand command = new SqlCommand {Connection = connection}; 

            try
            {
                command.CommandText = $"DELETE FROM Aluguel WHERE [Alugado por] = \'{nomeCliente}\'";
                command.ExecuteNonQuery();
                command.Dispose();

                MessageBox.Show("Livro deletado com sucesso", "Concluido",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException e) { MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        #endregion

        #region Buscar
        public DataTable BuscarAluguelLivro(string titulo)
        {
            SqlDataAdapter adapter;
            DataTable table = new DataTable();
            try
            {
                adapter = new SqlDataAdapter($"SELECT * FROM Aluguel WHERE Titulo LIKE \'%{titulo}%\'", connection);
                adapter.Fill(table);
            }
            catch (SqlException e) { MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }

            return table;
        }
        public DataTable BuscarAluguelCliente(string nomeCliente)
        {
            SqlDataAdapter adapter;
            DataTable table = new DataTable();
            try
            {
                adapter = new SqlDataAdapter($"SELECT * FROM Aluguel WHERE [Alugado por] LIKE \'%{nomeCliente}%\'", connection);
                adapter.Fill(table);
            }
            catch (SqlException e) { MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }

            return table;
        }
        #endregion

        #region Atualizar
        public void AtualizarAluguelTitulo(Aluguel aluguel, string titulo)
        {
            SqlCommand command = new SqlCommand {Connection = connection};
            #region Parâmetros
            command.Parameters.AddWithValue("@titulo", aluguel.titulo);
            command.Parameters.AddWithValue("@autor", aluguel.autor);
            command.Parameters.AddWithValue("@alugadoPor", aluguel.alugadoPor);
            command.Parameters.AddWithValue("@dataEntrega", aluguel.dataEntrega);
            command.Parameters.AddWithValue("@dataRecebimento", aluguel.dataRecebimento);
            command.Parameters.AddWithValue("@status", aluguel.status);
            #endregion
            try
            {
                command.CommandText = "UPDATE Livros SET Titulo = @titulo, Autor = @autor, [Alugado por] = @alugadoPor," +
                    $" [Data de entrega] = @dataEntrega, [Data do recebimento] = @dataRecebimento, Status = @status WHERE Titulo = \'{titulo}\'";
                command.ExecuteNonQuery();
                command.Dispose();

                MessageBox.Show("Informações atualizadas", "Concluido", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException e) { MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        public void AtualizarAluguelNomeCliente(Aluguel aluguel, string nomeCliente)
        {
            SqlCommand command = new SqlCommand {Connection = connection};
            #region Parâmetros
            command.Parameters.AddWithValue("@titulo", aluguel.titulo);
            command.Parameters.AddWithValue("@autor", aluguel.autor);
            command.Parameters.AddWithValue("@alugadoPor", aluguel.alugadoPor);
            command.Parameters.AddWithValue("@dataEntrega", aluguel.dataEntrega);
            command.Parameters.AddWithValue("@dataRecebimento", aluguel.dataRecebimento);
            command.Parameters.AddWithValue("@status", aluguel.status);
            #endregion
            try
            {
                command.CommandText = "UPDATE Aluguel SET Titulo = @titulo, Autor = @autor, [Alugado por] = @alugadoPor," +
                    $" [Data da entrega] = @dataEntrega, [Data do recebimento] = @dataRecebimento, Status = @status WHERE [Alugado por] = \'{nomeCliente}\'";
                command.ExecuteNonQuery();
                command.Dispose();

                MessageBox.Show("Informações atualizadas", "Concluido", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException e) { MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        #endregion
    }
}
