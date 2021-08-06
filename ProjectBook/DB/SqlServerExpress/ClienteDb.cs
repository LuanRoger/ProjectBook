using ProjectBook.Livros;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using ProjectBook.Properties;
using ProjectBook.AppInsight;

namespace ProjectBook.DB.SqlServerExpress
{
    class ClienteDb : Db
    {
        public void CadastrarCliente(ClienteModel cliente)
        {
            SqlCommand command = new() { Connection = connection};
            #region Parâmetros
            command.Parameters.AddWithValue("@nomeCompleto", cliente.nomeCompleto);
            command.Parameters.AddWithValue("@endereco", cliente.endereco);
            command.Parameters.AddWithValue("@cidade", cliente.cidade);
            command.Parameters.AddWithValue("@estado", cliente.estado);
            command.Parameters.AddWithValue("@cep", cliente.cep);
            command.Parameters.AddWithValue("@telefone1", cliente.telefone1);
            command.Parameters.AddWithValue("@telefone2", cliente.telefone2);
            command.Parameters.AddWithValue("@email", cliente.email);
            #endregion
            try
            {
                command.CommandText = "INSERT INTO Clientes([Nome completo], Endereco, Cidade, Estado, Cep, Telefone1, Telefone2, Email) " +
                "VALUES(@nomeCompleto, @endereco, @cidade, @estado, @cep, @telefone1, @telefone2, @email)";
                
                AbrirConexaoDb();
                command.ExecuteNonQuery();
                FechaConecxaoDb();

                command.Dispose();

                MessageBox.Show(Resources.ClienteRegistrado, Resources.Concluido_MessageBox,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException e) { MessageBox.Show(e.Message, Resources.Error_MessageBox, MessageBoxButtons.OK, MessageBoxIcon.Error); 
                AppInsightMetrics.SendError(e); }
        }
        public DataTable VerTodosClientes()
        {
            DataTable table = new();
            try
            {
                AbrirConexaoDb();
                SqlDataAdapter adapter = new("SELECT * FROM Clientes", connection);
                FechaConecxaoDb();

                adapter.Fill(table);
            }
            catch (SqlException e) { MessageBox.Show(e.Message, Resources.Error_MessageBox, MessageBoxButtons.OK, MessageBoxIcon.Error); 
                AppInsightMetrics.SendError(e); }

            return table;
        }

        #region Deletar
        public void DeletarClienteId(string id)
        {
            SqlCommand command = new() { Connection = connection};

            try
            {
                command.CommandText = $"DELETE FROM Clientes WHERE ID = {id}";
                AbrirConexaoDb();
                command.ExecuteNonQuery();
                FechaConecxaoDb();

                command.Dispose();

                MessageBox.Show(Resources.ClienteDeletado, Resources.ClienteDeletado,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException e) { MessageBox.Show(e.Message, Resources.Error_MessageBox, MessageBoxButtons.OK, MessageBoxIcon.Error); 
                AppInsightMetrics.SendError(e); }
        }
        public void DeletarClienteNome(string nome)
        {
            SqlCommand command = new() { Connection = connection};

            try
            {
                command.CommandText = $"DELETE FROM Clientes WHERE [Nome completo] LIKE \'%{nome}%\'";
                AbrirConexaoDb();
                command.ExecuteNonQuery();
                FechaConecxaoDb();
                command.Dispose();

                MessageBox.Show(Resources.ClienteDeletado, Resources.Concluido_MessageBox,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException e) { MessageBox.Show(e.Message, Resources.Error_MessageBox, MessageBoxButtons.OK, MessageBoxIcon.Error); 
                AppInsightMetrics.SendError(e); }
        }
        #endregion
        
        #region Buscar
        public DataTable BuscarClienteId(string id)
        {
            DataTable table = new();

            try
            {
                AbrirConexaoDb();
                SqlDataAdapter adapter = new($"SELECT * FROM Clientes WHERE ID = {id}", connection);
                FechaConecxaoDb();

                adapter.Fill(table);
            }
            catch (SqlException e) { MessageBox.Show(e.Message, Resources.Error_MessageBox, MessageBoxButtons.OK, MessageBoxIcon.Error); 
                AppInsightMetrics.SendError(e); }

            return table;
        }
        public DataTable BuscarClienteNome(string nomeCompleto)
        {
            DataTable table = new();

            try
            {
                AbrirConexaoDb();
                SqlDataAdapter adapter = new($"SELECT * FROM Clientes WHERE [Nome completo] LIKE \'%{nomeCompleto}%\'", connection);
                FechaConecxaoDb();

                adapter.Fill(table);
            }
            catch (SqlException e) { MessageBox.Show(e.Message, Resources.PesquiseParaContinuar, MessageBoxButtons.OK, MessageBoxIcon.Error); 
                AppInsightMetrics.SendError(e); }

            return table;
        }
        #endregion

        #region Atualizar
        public void AtualizarClienteId(string id, ClienteModel cliente)
        {
            SqlCommand command = new() { Connection = connection};
            #region Parâmetros
            command.Parameters.AddWithValue("@nomeCompleto", cliente.nomeCompleto);
            command.Parameters.AddWithValue("@endereco", cliente.endereco);
            command.Parameters.AddWithValue("@cidade", cliente.cidade);
            command.Parameters.AddWithValue("@estado", cliente.estado);
            command.Parameters.AddWithValue("@cep", cliente.cep);
            command.Parameters.AddWithValue("@telefone1", cliente.telefone1);
            command.Parameters.AddWithValue("@telefone2", cliente.telefone2);
            command.Parameters.AddWithValue("@email", cliente.email);
            #endregion
            try
            {
                command.CommandText = "UPDATE Clientes SET [Nome completo] = @nomeCompleto, Endereco = @endereco, Cidade = @cidade, Estado = @estado, Cep = @cep, Telefone1 = @telefone1," +
                    $" Telefone2 = @telefone2, Email = @email WHERE ID = {id}";

                AbrirConexaoDb();
                command.ExecuteNonQuery();
                FechaConecxaoDb();

                command.Dispose();

                MessageBox.Show(Resources.InformaçõesAtualizadas_MessageBox, Resources.Concluido_MessageBox, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException e) { MessageBox.Show(e.Message, Resources.Error_MessageBox, MessageBoxButtons.OK, MessageBoxIcon.Error); 
                AppInsightMetrics.SendError(e);}
        }
        #endregion
    }
}
