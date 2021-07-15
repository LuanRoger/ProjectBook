using ProjectBook.Livros;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using ProjectBook.Properties;
using ProjectBook.AppInsight;

namespace ProjectBook.DB.SqlServerExpress
{
    class AluguelDb : Db
    {
        public void CadastrarAluguel(AluguelModel aluguel)
        {
            SqlCommand command = new() { Connection = connection};
            #region Parâmetros
            command.Parameters.AddWithValue("@titulo", aluguel.titulo);
            command.Parameters.AddWithValue("@autor", aluguel.autor);
            command.Parameters.AddWithValue("@alugadoPor", aluguel.alugadoPor);
            command.Parameters.AddWithValue("@dataSaida", aluguel.dataEntrega);
            command.Parameters.AddWithValue("@dataDevolucao", aluguel.dataDevolucao);
            command.Parameters.AddWithValue("@status", aluguel.status);
            #endregion
            try
            {
                command.CommandText = "INSERT INTO Aluguel(Titulo, Autor, [Alugado por], [Data de saida], [Data de devolucao], Status) " +
                "VALUES(@titulo, @autor, @alugadoPor, @dataSaida, @dataDevolucao, @status)";

                AbrirConexaoDb();
                command.ExecuteNonQuery();
                FechaConecxaoDb();

                command.Dispose();

                MessageBox.Show(Resources.AluguelRegistrado, Resources.concluido_MessageBox,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException e) { MessageBox.Show(e.Message, Resources.MessageBoxError, MessageBoxButtons.OK, MessageBoxIcon.Error); 
                AppInsightMetrics.SendError(e); }
        }
        public DataTable VerTodosAluguel()
        {
            DataTable table = new();
            try
            {
                AbrirConexaoDb();
                SqlDataAdapter adapter = new("SELECT * FROM Aluguel", connection);
                FechaConecxaoDb();

                adapter.Fill(table);
            }
            catch (SqlException e) { MessageBox.Show(e.Message, Resources.MessageBoxError, MessageBoxButtons.OK, MessageBoxIcon.Error); 
                AppInsightMetrics.SendError(e); }


            return table;
        }

        #region Deletar
        public void DeletarAluguelTitulo(string titulo)
        {
            SqlCommand command = new() { Connection = connection};

            try
            {
                command.CommandText = $"DELETE FROM Aluguel WHERE Titulo = \'{titulo}\'";
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
        public void DeletarAluguelCliente(string nomeCliente)
        {
            SqlCommand command = new() { Connection = connection}; 

            try
            {
                command.CommandText = $"DELETE FROM Aluguel WHERE [Alugado por] = \'{nomeCliente}\'";
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
        public void DeletarAluguelTituloLivro(string titulo, string nomeCliente)
        {
            SqlCommand command = new() { Connection = connection}; 

            try
            {
                command.CommandText = $"DELETE FROM Aluguel WHERE [Titulo] LIKE \'%{titulo}%\' AND [Alugado por] LIKE \'%{nomeCliente}%\'";
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

        #region Buscar
        public DataTable BuscarAluguelLivro(string titulo)
        {
            DataTable table = new();
            try
            {
                AbrirConexaoDb();
                SqlDataAdapter adapter = new($"SELECT * FROM Aluguel WHERE Titulo LIKE \'%{titulo}%\'", connection);
                FechaConecxaoDb();

                adapter.Fill(table);
            }
            catch (SqlException e) { MessageBox.Show(e.Message, Resources.MessageBoxError, MessageBoxButtons.OK, MessageBoxIcon.Error); 
                AppInsightMetrics.SendError(e); }

            return table;
        }
        public DataTable BuscarAluguelCliente(string nomeCliente)
        {
            DataTable table = new();
            try
            {
                AbrirConexaoDb();
                SqlDataAdapter adapter = new($"SELECT * FROM Aluguel WHERE [Alugado por] LIKE \'%{nomeCliente}%\'", connection);
                FechaConecxaoDb();

                adapter.Fill(table);
            }
            catch (SqlException e) { MessageBox.Show(e.Message, Resources.MessageBoxError, MessageBoxButtons.OK, MessageBoxIcon.Error); 
                AppInsightMetrics.SendError(e); }

            return table;
        }
        public DataTable BuscarAluguelLivroCliente(string titulo, string nomeCliente)
        {
            DataTable table = new();
            try
            {
                AbrirConexaoDb();
                SqlDataAdapter adapter = new($"SELECT * FROM Aluguel WHERE [Titulo] LIKE \'%{titulo}%\' AND [Alugado por] LIKE \'%{nomeCliente}%\'", connection);
                FechaConecxaoDb();

                adapter.Fill(table);
            }
            catch (SqlException e) { MessageBox.Show(e.Message, Resources.MessageBoxError, MessageBoxButtons.OK, MessageBoxIcon.Error); 
                AppInsightMetrics.SendError(e); }

            return table;
        }
        public DataTable PegarLivrosAlugados()
        {
            DataTable table = new();
            try
            {
                AbrirConexaoDb();
                SqlDataAdapter adapter = new($"SELECT * FROM Aluguel WHERE Status = \'{Tipos.StatusAluguel.Alugado}\'", connection);
                FechaConecxaoDb();

                adapter.Fill(table);
            }
            catch (SqlException e) { MessageBox.Show(e.Message, Resources.MessageBoxError, MessageBoxButtons.OK, MessageBoxIcon.Error); 
                AppInsightMetrics.SendError(e); }

            return table;
        }

        public DataTable PegarLivroDevolvido()
        {
            DataTable table = new();
            try
            {
                AbrirConexaoDb();
                SqlDataAdapter adapter = new($"SELECT * FROM Aluguel WHERE Status = \'{Tipos.StatusAluguel.Devolvido}\'", connection);
                FechaConecxaoDb();

                adapter.Fill(table);
            }
            catch (SqlException e) { MessageBox.Show(e.Message, Resources.MessageBoxError, MessageBoxButtons.OK, MessageBoxIcon.Error); 
                AppInsightMetrics.SendError(e); }

            return table;
        }

        public DataTable PegarLivroAtrassado()
        {
            DataTable table = new();
            try
            {
                AbrirConexaoDb();
                SqlDataAdapter adapter = new($"SELECT * FROM Aluguel WHERE Status = \'{Tipos.StatusAluguel.Atrasado}\'", connection);
                FechaConecxaoDb();

                adapter.Fill(table);
            }
            catch (SqlException e) { MessageBox.Show(e.Message, Resources.MessageBoxError, MessageBoxButtons.OK, MessageBoxIcon.Error); 
                AppInsightMetrics.SendError(e); }

            return table;
        }
        #endregion

        #region Atualizar
        public void AtualizarAluguelNomeCliente(AluguelModel aluguel, string nomeCliente, string nomeLivro)
        {
            SqlCommand command = new() { Connection = connection};
            #region Parâmetros
            command.Parameters.AddWithValue("@titulo", aluguel.titulo);
            command.Parameters.AddWithValue("@autor", aluguel.autor);
            command.Parameters.AddWithValue("@alugadoPor", aluguel.alugadoPor);
            command.Parameters.AddWithValue("@dataSaida", aluguel.dataEntrega);
            command.Parameters.AddWithValue("@dataDevolucao", aluguel.dataDevolucao);
            command.Parameters.AddWithValue("@status", aluguel.status);
            #endregion
            try
            {
                command.CommandText = "UPDATE Aluguel SET Titulo = @titulo, Autor = @autor, [Alugado por] = @alugadoPor," +
                    $" [Data de saida] = @dataSaida, [Data de devolucao] = @dataDevolucao, Status = @status WHERE [Alugado por] = \'{nomeCliente}\' " +
                    $"AND Titulo = \'{nomeLivro}\'";

                AbrirConexaoDb();
                command.ExecuteNonQuery();
                FechaConecxaoDb();

                command.Dispose();

                MessageBox.Show(Resources.informações_atualizadas, Resources.concluido_MessageBox, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException e) { MessageBox.Show(e.Message, Resources.MessageBoxError, MessageBoxButtons.OK, MessageBoxIcon.Error); 
                AppInsightMetrics.SendError(e); }
        }
        public void AtualizarStatusAtrasado(string alugadoPor)
        {
            try
            {
                SqlCommand command = new() { Connection = connection };
                command.CommandText = $"UPDATE Aluguel SET Status = \'{Tipos.StatusAluguel.Atrasado}\' WHERE [Alugado por] = \'{alugadoPor}\'";

                AbrirConexaoDb();
                command.ExecuteNonQuery();
                FechaConecxaoDb();

                command.Dispose();
            }
            catch(SqlException e) { AppInsightMetrics.SendError(e); }
        }
        #endregion
    }
}
