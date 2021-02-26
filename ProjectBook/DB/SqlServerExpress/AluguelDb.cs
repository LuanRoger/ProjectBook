﻿using ProjectBook.Livros;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using ProjectBook.Properties;

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
            command.Parameters.AddWithValue("@dataSaida", aluguel.dataEntrega);
            command.Parameters.AddWithValue("@dataDevolucao", aluguel.dataRecebimento);
            command.Parameters.AddWithValue("@status", aluguel.status);
            #endregion
            try
            {
                command.CommandText = "INSERT INTO Aluguel(Titulo, Autor, [Alugado por], [Data de saida], [Data de devolução], Status) " +
                "VALUES(@titulo, @autor, @alugadoPor, @dataSaida, @dataDevolucao, @status)";
                command.ExecuteNonQuery();
                command.Dispose();

                MessageBox.Show(Resources.aluguel_registrado_com_sucesso, Resources.concluido_MessageBox,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException e) { MessageBox.Show(e.Message, Resources.error_MessageBox, MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        public DataTable VerTodosAluguel()
        {
            DataTable table = new DataTable();
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Aluguel", connection);
                adapter.Fill(table);
            }
            catch (SqlException e) { MessageBox.Show(e.Message, Resources.error_MessageBox, MessageBoxButtons.OK, MessageBoxIcon.Error); }

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

                MessageBox.Show(Resources.livro_deletado_com_sucesso, Resources.concluido_MessageBox,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException e) { MessageBox.Show(e.Message, Resources.error_MessageBox, MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        public void DeletarAluguelCliente(string nomeCliente)
        {
            SqlCommand command = new SqlCommand {Connection = connection}; 

            try
            {
                command.CommandText = $"DELETE FROM Aluguel WHERE [Alugado por] = \'{nomeCliente}\'";
                command.ExecuteNonQuery();
                command.Dispose();

                MessageBox.Show(Resources.livro_deletado_com_sucesso, Resources.concluido_MessageBox,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException e) { MessageBox.Show(e.Message, Resources.error_MessageBox, MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        #endregion

        #region Buscar
        public DataTable BuscarAluguelLivro(string titulo)
        {
            DataTable table = new DataTable();
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter($"SELECT * FROM Aluguel WHERE Titulo LIKE \'%{titulo}%\'", connection);
                adapter.Fill(table);
            }
            catch (SqlException e) { MessageBox.Show(e.Message, Resources.error_MessageBox, MessageBoxButtons.OK, MessageBoxIcon.Error); }

            return table;
        }
        public DataTable BuscarAluguelCliente(string nomeCliente)
        {
            DataTable table = new DataTable();
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter($"SELECT * FROM Aluguel WHERE [Alugado por] LIKE \'%{nomeCliente}%\'", connection);
                adapter.Fill(table);
            }
            catch (SqlException e) { MessageBox.Show(e.Message, Resources.error_MessageBox, MessageBoxButtons.OK, MessageBoxIcon.Error); }

            return table;
        }
        public DataTable PegarLivrosAlugados()
        {
            DataTable table = new DataTable();
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter($"SELECT * FROM Aluguel WHERE Status = \'{Tipos.StatusAluguel.Alugado}\'", connection);
                adapter.Fill(table);
            }
            catch (SqlException e) { MessageBox.Show(e.Message, Resources.error_MessageBox, MessageBoxButtons.OK, MessageBoxIcon.Error); }

            return table;
        }

        public DataTable PegarLivroDevolvido()
        {
            DataTable table = new DataTable();
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter($"SELECT * FROM Aluguel WHERE Status = \'{Tipos.StatusAluguel.Devolvido}\'", connection);
                adapter.Fill(table);
            }
            catch (SqlException e) { MessageBox.Show(e.Message, Resources.error_MessageBox, MessageBoxButtons.OK, MessageBoxIcon.Error); }

            return table;
        }

        public DataTable PegarLivroAtrassado()
        {
            DataTable table = new DataTable();
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter($"SELECT * FROM Aluguel WHERE Status = \'{Tipos.StatusAluguel.Atrssado}\'", connection);
                adapter.Fill(table);
            }
            catch (SqlException e) { MessageBox.Show(e.Message, Resources.error_MessageBox, MessageBoxButtons.OK, MessageBoxIcon.Error); }

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
            command.Parameters.AddWithValue("@dataSaida", aluguel.dataEntrega);
            command.Parameters.AddWithValue("@dataDevolucao", aluguel.dataRecebimento);
            command.Parameters.AddWithValue("@status", aluguel.status);
            #endregion
            try
            {
                command.CommandText = "UPDATE Livros SET Titulo = @titulo, Autor = @autor, [Alugado por] = @alugadoPor," +
                    $" [Data de saida] = @dataEntrega, [Data de devolução] = @dataRecebimento, Status = @status WHERE Titulo = \'{titulo}\'";
                command.ExecuteNonQuery();
                command.Dispose();

                MessageBox.Show(Resources.informações_atualizadas, Resources.concluido_MessageBox, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException e) { MessageBox.Show(e.Message, Resources.error_MessageBox, MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        public void AtualizarAluguelNomeCliente(Aluguel aluguel, string nomeCliente)
        {
            SqlCommand command = new SqlCommand {Connection = connection};
            #region Parâmetros
            command.Parameters.AddWithValue("@titulo", aluguel.titulo);
            command.Parameters.AddWithValue("@autor", aluguel.autor);
            command.Parameters.AddWithValue("@alugadoPor", aluguel.alugadoPor);
            command.Parameters.AddWithValue("@dataSaida", aluguel.dataEntrega);
            command.Parameters.AddWithValue("@dataDevolucao", aluguel.dataRecebimento);
            command.Parameters.AddWithValue("@status", aluguel.status);
            #endregion
            try
            {
                command.CommandText = "UPDATE Aluguel SET Titulo = @titulo, Autor = @autor, [Alugado por] = @alugadoPor," +
                    $" [Data de saida] = @dataSaida, [Data de devolução] = @dataDevolucao, Status = @status WHERE [Alugado por] = \'{nomeCliente}\'";
                command.ExecuteNonQuery();
                command.Dispose();

                MessageBox.Show(Resources.informações_atualizadas, Resources.concluido_MessageBox, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException e) { MessageBox.Show(e.Message, Resources.error_MessageBox, MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        public void AtualizarStatusAtrasado(string alugadoPor)
        {
            SqlCommand command = new SqlCommand {Connection = connection};
            command.CommandText = $"UPDATE Aluguel SET Status = \'{Tipos.StatusAluguel.Atrssado}\' WHERE [Alugado por] = \'{alugadoPor}\'";
            command.ExecuteNonQuery();
            command.Dispose();
        }
        #endregion
    }
}
