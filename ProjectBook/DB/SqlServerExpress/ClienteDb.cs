using ProjectBook.Livros;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using ProjectBook.Properties.Languages;

namespace ProjectBook.DB.SqlServerExpress
{
    class ClienteDb : Db
    {
        public void CadastrarCliente(Cliente cliente)
        {
            SqlCommand command = new SqlCommand {Connection = connection};
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

                MessageBox.Show(Strings.cliente_registrado_com_sucesso, Strings.concluido_MessageBox,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException e) { MessageBox.Show(e.Message, Strings.error_MessageBox, MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        public DataTable VerTodosClientes()
        {
            DataTable table = new DataTable();
            try
            {
                AbrirConexaoDb();
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Clientes", connection);
                FechaConecxaoDb();

                adapter.Fill(table);
            }
            catch (SqlException e) { MessageBox.Show(e.Message, Strings.error_MessageBox, MessageBoxButtons.OK, MessageBoxIcon.Error); }

            return table;
        }

        #region Deletar
        public void DeletarClienteId(string id)
        {
            SqlCommand command = new SqlCommand {Connection = connection};

            try
            {
                command.CommandText = $"DELETE FROM Clientes WHERE ID = {id}";
                AbrirConexaoDb();
                command.ExecuteNonQuery();
                FechaConecxaoDb();

                command.Dispose();

                MessageBox.Show(Strings.cliente_deletado_com_sucesso, Strings.concluido_MessageBox,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException e) { MessageBox.Show(e.Message, Strings.error_MessageBox, MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        public void DeletarClienteNome(string nome)
        {
            SqlCommand command = new SqlCommand {Connection = connection};

            try
            {
                command.CommandText = $"DELETE FROM Clientes WHERE [Nome completo] LIKE \'%{nome}%\'";
                AbrirConexaoDb();
                command.ExecuteNonQuery();
                FechaConecxaoDb();
                command.Dispose();

                MessageBox.Show(Strings.cliente_deletado_com_sucesso, Strings.concluido_MessageBox,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException e) { MessageBox.Show(e.Message, Strings.error_MessageBox, MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        #endregion
        
        #region Buscar
        public DataTable BuscarClienteId(string id)
        {
            DataTable table = new DataTable();

            try
            {
                AbrirConexaoDb();
                SqlDataAdapter adapter = new SqlDataAdapter($"SELECT * FROM Clientes WHERE ID = {id}", connection);
                FechaConecxaoDb();

                adapter.Fill(table);
            }
            catch (SqlException e) { MessageBox.Show(e.Message, Strings.error_MessageBox, MessageBoxButtons.OK, MessageBoxIcon.Error); }

            return table;
        }
        public DataTable BuscarClienteNome(string nomeCompleto)
        {
            DataTable table = new DataTable();

            try
            {
                AbrirConexaoDb();
                SqlDataAdapter adapter = new SqlDataAdapter($"SELECT * FROM Clientes WHERE [Nome completo] LIKE \'%{nomeCompleto}%\'", connection);
                FechaConecxaoDb();

                adapter.Fill(table);
            }
            catch (SqlException e) { MessageBox.Show(e.Message, Strings.preencherCampoBusca_MessageBox,
                MessageBoxButtons.OK, MessageBoxIcon.Error); }

            return table;
        }
        #endregion

        #region Atualizar
        public void AtualizarClienteId(string id, Cliente cliente)
        {
            SqlCommand command = new SqlCommand {Connection = connection};
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

                MessageBox.Show(Strings.informações_atualizadas, Strings.concluido_MessageBox, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException e) { MessageBox.Show(e.Message, Strings.error_MessageBox, MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        #endregion
    }
}
