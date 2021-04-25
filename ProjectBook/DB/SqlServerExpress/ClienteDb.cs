﻿using ProjectBook.Livros;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using ProjectBook.Properties;

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

<<<<<<< HEAD
                MessageBox.Show(Strings.ClienteRegistrado, Strings.MessageBoxConcluido,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException e) { MessageBox.Show(e.Message, Strings.MessageBoxError, MessageBoxButtons.OK, MessageBoxIcon.Error); }
=======
                MessageBox.Show(Resources.cliente_registrado_com_sucesso, Resources.concluido_MessageBox,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException e) { MessageBox.Show(e.Message, Resources.error_MessageBox, MessageBoxButtons.OK, MessageBoxIcon.Error); }
>>>>>>> parent of e20e8c2 (v0.5.4-beta)
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
<<<<<<< HEAD
            catch (SqlException e) { MessageBox.Show(e.Message, Strings.MessageBoxError, MessageBoxButtons.OK, MessageBoxIcon.Error); }
=======
            catch (SqlException e) { MessageBox.Show(e.Message, Resources.error_MessageBox, MessageBoxButtons.OK, MessageBoxIcon.Error); }
>>>>>>> parent of e20e8c2 (v0.5.4-beta)

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

<<<<<<< HEAD
                MessageBox.Show(Strings.ClienteDeletado, Strings.MessageBoxConcluido,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException e) { MessageBox.Show(e.Message, Strings.MessageBoxError, MessageBoxButtons.OK, MessageBoxIcon.Error); }
=======
                MessageBox.Show(Resources.cliente_deletado_com_sucesso, Resources.concluido_MessageBox,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException e) { MessageBox.Show(e.Message, Resources.error_MessageBox, MessageBoxButtons.OK, MessageBoxIcon.Error); }
>>>>>>> parent of e20e8c2 (v0.5.4-beta)
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

<<<<<<< HEAD
                MessageBox.Show(Strings.ClienteDeletado, Strings.MessageBoxConcluido,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException e) { MessageBox.Show(e.Message, Strings.MessageBoxError, MessageBoxButtons.OK, MessageBoxIcon.Error); }
=======
                MessageBox.Show(Resources.cliente_deletado_com_sucesso, Resources.concluido_MessageBox,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException e) { MessageBox.Show(e.Message, Resources.error_MessageBox, MessageBoxButtons.OK, MessageBoxIcon.Error); }
>>>>>>> parent of e20e8c2 (v0.5.4-beta)
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
<<<<<<< HEAD
            catch (SqlException e) { MessageBox.Show(e.Message, Strings.MessageBoxError, MessageBoxButtons.OK, MessageBoxIcon.Error); }
=======
            catch (SqlException e) { MessageBox.Show(e.Message, Resources.error_MessageBox, MessageBoxButtons.OK, MessageBoxIcon.Error); }
>>>>>>> parent of e20e8c2 (v0.5.4-beta)

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
<<<<<<< HEAD
            catch (SqlException e) { MessageBox.Show(e.Message, Strings.PreecherCampoBusca,
=======
            catch (SqlException e) { MessageBox.Show(e.Message, Resources.preencherCampoBusca_MessageBox,
>>>>>>> parent of e20e8c2 (v0.5.4-beta)
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

<<<<<<< HEAD
                MessageBox.Show(Strings.InformacoesAtualizadas, Strings.MessageBoxConcluido, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException e) { MessageBox.Show(e.Message, Strings.MessageBoxError, MessageBoxButtons.OK, MessageBoxIcon.Error); }
=======
                MessageBox.Show(Resources.informações_atualizadas, Resources.concluido_MessageBox, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException e) { MessageBox.Show(e.Message, Resources.error_MessageBox, MessageBoxButtons.OK, MessageBoxIcon.Error); }
>>>>>>> parent of e20e8c2 (v0.5.4-beta)
        }
        #endregion
    }
}
