using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using ProjectBook.Livros;

namespace ProjectBook.DB.SqlServerExpress
{
    class UsuarioDb : Db
    {
        public void CadastrarUsuario(Usuario usuario)
        {
            SqlCommand command = new SqlCommand {Connection = connection};
            #region Parâmetros
            command.Parameters.AddWithValue("@usuario", usuario.usuario);
            command.Parameters.AddWithValue("@senha", usuario.senha);
            command.Parameters.AddWithValue("@tipo", usuario.tipo);
            #endregion
            try
            {
                command.CommandText = "INSERT INTO Usuarios(Usuario, Senha, Tipo) " +
                                      "VALUES(@usuario, @senha, @tipo)";
                command.ExecuteNonQuery();
                command.Dispose();

                MessageBox.Show("Usuário registrado com sucesso", Properties.Resources.concluido_MessageBox,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException e) { MessageBox.Show(e.Message, Properties.Resources.error_MessageBox,
                MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        public void DeletarUsuarioId(string id)
        {
            SqlCommand command = new SqlCommand {Connection = connection};

            try
            {
                command.CommandText = $"DELETE FROM Usuarios WHERE ID = {id}";
                command.ExecuteNonQuery();
                command.Dispose();

                MessageBox.Show("Usuário deletado com sucesso", Properties.Resources.concluido_MessageBox,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message, Properties.Resources.error_MessageBox,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public DataTable LoginUsuario(string usuario, string senha)
        {
            SqlDataAdapter adapter;
            DataTable dataTable = new DataTable();
            
            try
            {
                adapter = new SqlDataAdapter($"SELECT * FROM Usuarios WHERE Usuario = \'{usuario}\' AND Senha = \'{senha}\'", connection);
                adapter.Fill(dataTable);
            }
            catch (SqlException e){ MessageBox.Show(e.Message, Properties.Resources.error_MessageBox,
                MessageBoxButtons.OK, MessageBoxIcon.Error); }

            return dataTable;
        }
        public void AtualizarUsuarioId(string id, Usuario usuario)
        {
            SqlCommand command = new SqlCommand {Connection = connection};
            #region Parâmetros
            command.Parameters.AddWithValue("@usuario", usuario.usuario);
            command.Parameters.AddWithValue("@senha", usuario.senha);
            command.Parameters.AddWithValue("@tipo", usuario.tipo);
            #endregion
            try
            {
                command.CommandText = $"UPDATE Usuarios SET Usuario = @usuario, Senha = @senha, Tipo = @tipo WHERE ID = {id}";
                command.ExecuteNonQuery();
                command.Dispose();

                MessageBox.Show("Informações atualizadas", Properties.Resources.concluido_MessageBox, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException e) { MessageBox.Show(e.Message, Properties.Resources.error_MessageBox,
                MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        #region Buscar
        public DataTable BuscarUsuarioId(string id)
        {
            SqlDataAdapter adapter;
            DataTable table = new DataTable();

            try
            {
                adapter = new SqlDataAdapter($"SELECT * FROM Usuarios WHERE ID = {id}", connection);
                adapter.Fill(table);
            }
            catch (SqlException e) { MessageBox.Show(e.Message, Properties.Resources.error_MessageBox, MessageBoxButtons.OK, MessageBoxIcon.Error); }

            return table;
        }
        #endregion
    }
}