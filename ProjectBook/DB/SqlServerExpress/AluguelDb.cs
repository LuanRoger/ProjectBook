using ProjectBook.Livros;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using ProjectBook.Properties.Languages;

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

                MessageBox.Show(Strings.aluguel_registrado_com_sucesso, Strings.concluido_MessageBox,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException e) { MessageBox.Show(e.Message, Strings.error_MessageBox, MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        public DataTable VerTodosAluguel()
        {
            DataTable table = new DataTable();
            try
            {
                AbrirConexaoDb();
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Aluguel", connection);
                FechaConecxaoDb();

                adapter.Fill(table);
            }
            catch (SqlException e) { MessageBox.Show(e.Message, Strings.error_MessageBox, MessageBoxButtons.OK, MessageBoxIcon.Error); }

            return table;
        }

        #region Deletar
        public void DeletarAluguelTitulo(string titulo)
        {
            SqlCommand command = new SqlCommand {Connection = connection};

            try
            {
                command.CommandText = $"DELETE FROM Aluguel WHERE Titulo = \'{titulo}\'";
                AbrirConexaoDb();
                command.ExecuteNonQuery();
                FechaConecxaoDb();

                command.Dispose();

                MessageBox.Show(Strings.livro_deletado_com_sucesso, Strings.concluido_MessageBox,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException e) { MessageBox.Show(e.Message, Strings.error_MessageBox, MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        public void DeletarAluguelCliente(string nomeCliente)
        {
            SqlCommand command = new SqlCommand {Connection = connection}; 

            try
            {
                command.CommandText = $"DELETE FROM Aluguel WHERE [Alugado por] = \'{nomeCliente}\'";
                AbrirConexaoDb();
                command.ExecuteNonQuery();
                FechaConecxaoDb();
                command.Dispose();

                MessageBox.Show(Strings.livro_deletado_com_sucesso, Strings.concluido_MessageBox,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException e) { MessageBox.Show(e.Message, Strings.error_MessageBox, MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        #endregion

        #region Buscar
        public DataTable BuscarAluguelLivro(string titulo)
        {
            DataTable table = new DataTable();
            try
            {
                AbrirConexaoDb();
                SqlDataAdapter adapter = new SqlDataAdapter($"SELECT * FROM Aluguel WHERE Titulo LIKE \'%{titulo}%\'", connection);
                FechaConecxaoDb();

                adapter.Fill(table);
            }
            catch (SqlException e) { MessageBox.Show(e.Message, Strings.error_MessageBox, MessageBoxButtons.OK, MessageBoxIcon.Error); }

            return table;
        }
        public DataTable BuscarAluguelCliente(string nomeCliente)
        {
            DataTable table = new DataTable();
            try
            {
                AbrirConexaoDb();
                SqlDataAdapter adapter = new SqlDataAdapter($"SELECT * FROM Aluguel WHERE [Alugado por] LIKE \'%{nomeCliente}%\'", connection);
                FechaConecxaoDb();

                adapter.Fill(table);
            }
            catch (SqlException e) { MessageBox.Show(e.Message, Strings.error_MessageBox, MessageBoxButtons.OK, MessageBoxIcon.Error); }

            return table;
        }
        public DataTable PegarLivrosAlugados()
        {
            DataTable table = new DataTable();
            try
            {
                AbrirConexaoDb();
                SqlDataAdapter adapter = new SqlDataAdapter($"SELECT * FROM Aluguel WHERE Status = \'{Tipos.StatusAluguel.Alugado}\'", connection);
                FechaConecxaoDb();

                adapter.Fill(table);
            }
            catch (SqlException e) { MessageBox.Show(e.Message, Strings.error_MessageBox, MessageBoxButtons.OK, MessageBoxIcon.Error); }

            return table;
        }

        public DataTable PegarLivroDevolvido()
        {
            DataTable table = new DataTable();
            try
            {
                AbrirConexaoDb();
                SqlDataAdapter adapter = new SqlDataAdapter($"SELECT * FROM Aluguel WHERE Status = \'{Tipos.StatusAluguel.Devolvido}\'", connection);
                FechaConecxaoDb();

                adapter.Fill(table);
            }
            catch (SqlException e) { MessageBox.Show(e.Message, Strings.error_MessageBox, MessageBoxButtons.OK, MessageBoxIcon.Error); }

            return table;
        }

        public DataTable PegarLivroAtrassado()
        {
            DataTable table = new DataTable();
            try
            {
                AbrirConexaoDb();
                SqlDataAdapter adapter = new SqlDataAdapter($"SELECT * FROM Aluguel WHERE Status = \'{Tipos.StatusAluguel.Atrasado}\'", connection);
                FechaConecxaoDb();

                adapter.Fill(table);
            }
            catch (SqlException e) { MessageBox.Show(e.Message, Strings.error_MessageBox, MessageBoxButtons.OK, MessageBoxIcon.Error); }

            return table;
        }
        #endregion

        #region Atualizar
        public void AtualizarAluguelNomeCliente(Aluguel aluguel, string nomeCliente, string nomeLivro)
        {
            SqlCommand command = new SqlCommand {Connection = connection};
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

                MessageBox.Show(Strings.informações_atualizadas, Strings.concluido_MessageBox, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException e) { MessageBox.Show(e.Message, Strings.error_MessageBox, MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        public void AtualizarStatusAtrasado(string alugadoPor)
        {
            SqlCommand command = new SqlCommand {Connection = connection};
            command.CommandText = $"UPDATE Aluguel SET Status = \'{Tipos.StatusAluguel.Atrasado}\' WHERE [Alugado por] = \'{alugadoPor}\'";

            AbrirConexaoDb();
            command.ExecuteNonQuery();
            FechaConecxaoDb();

            command.Dispose();
        }
        #endregion
    }
}
