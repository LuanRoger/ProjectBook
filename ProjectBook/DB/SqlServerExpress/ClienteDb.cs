using ProjectBook.Livros;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

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
                command.ExecuteNonQuery();
                command.Dispose();

                MessageBox.Show("Cliente registrado com sucesso", "Concluido",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException e) { MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        public DataTable VerTodosClientes()
        {
            SqlDataAdapter adapter;
            DataTable table = new DataTable();
            try
            {
                adapter = new SqlDataAdapter("SELECT * FROM Clientes", connection);
                adapter.Fill(table);
            }
            catch (SqlException e) { MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }

            return table;
        }

        public void DeletarClienteId(string id)
        {
            SqlCommand command = new SqlCommand {Connection = connection};

            try
            {
                command.CommandText = $"DELETE FROM Clientes WHERE ID = {id}";
                command.ExecuteNonQuery();
                command.Dispose();

                MessageBox.Show("Cliente deletado com sucesso", "Concluido",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException e) { MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        #region Buscar
        public DataTable BuscarClienteId(string id)
        {
            SqlDataAdapter adapter;
            DataTable table = new DataTable();

            try
            {
                adapter = new SqlDataAdapter($"SELECT * FROM Clientes WHERE ID = {id}", connection);
                adapter.Fill(table);
            }
            catch (SqlException e) { MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }

            return table;
        }
        public DataTable BuscarClienteNome(string nomeCompleto)
        {
            SqlDataAdapter adapter;
            DataTable table = new DataTable();

            try
            {
                adapter = new SqlDataAdapter($"SELECT * FROM Clientes WHERE [Nome completo] LIKE \'%{nomeCompleto}%\'", connection);
                adapter.Fill(table);
            }
            catch (SqlException e) { MessageBox.Show(e.Message, Properties.Resources.preencherCampos_MessageBox,
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
                command.ExecuteNonQuery();
                command.Dispose();

                MessageBox.Show("Informações atualizadas", "Concluido", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException e) { MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        #endregion
    }
}
