using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using ProjectBook.Livros;
using ProjectBook.Properties;

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

                AbrirConexaoDb();
                command.ExecuteNonQuery();
                FechaConecxaoDb();

                command.Dispose();

                MessageBox.Show(Resources.usuário_registrado_com_sucesso, Resources.concluido_MessageBox,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException e) { MessageBox.Show(e.Message, Resources.error_MessageBox,
                MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        public void DeletarUsuarioId(string id)
        {
            SqlCommand command = new SqlCommand { Connection = connection };
            try
            {
                command.CommandText = $"DELETE FROM Usuarios WHERE ID = {id}";

                AbrirConexaoDb();
                command.ExecuteNonQuery();
                FechaConecxaoDb();

                command.Dispose();

                MessageBox.Show(Resources.usuário_deletado_com_sucesso, Resources.concluido_MessageBox,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message, Resources.error_MessageBox,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

                AbrirConexaoDb();
                command.ExecuteNonQuery();
                FechaConecxaoDb();

                command.Dispose();

                MessageBox.Show(Resources.informações_atualizadas, Resources.concluido_MessageBox, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException e) { MessageBox.Show(e.Message, Resources.error_MessageBox,
                MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        public DataTable LoginUsuario(string usuario, string senha)
        {
            DataTable dataTable = new DataTable();
            try
            {
                AbrirConexaoDb();
                SqlDataAdapter adapter = new SqlDataAdapter($"SELECT * FROM Usuarios WHERE Usuario = \'{usuario}\' AND Senha = \'{senha}\'", connection);
                FechaConecxaoDb();
                adapter.Fill(dataTable);
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message, Resources.error_MessageBox,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return dataTable;
        }
        public DataTable LoginCodigo(string id, string senha)
        {
            DataTable dataTable = new DataTable();
            try
            {
                AbrirConexaoDb();
                SqlDataAdapter adapter = new SqlDataAdapter($"SELECT * FROM Usuarios WHERE ID = \'{id}\' AND Senha = \'{senha}\'", connection);
                FechaConecxaoDb();
                adapter.Fill(dataTable);
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message, Resources.error_MessageBox,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return dataTable;
        }
        #region Buscar
        public DataTable BuscarUsuarioId(string id)
        {
            DataTable table = new DataTable();

            try
            {
                AbrirConexaoDb();
                SqlDataAdapter adapter = new SqlDataAdapter($"SELECT * FROM Usuarios WHERE ID = {id}", connection);
                FechaConecxaoDb();
                adapter.Fill(table);
            }
            catch (SqlException e) { MessageBox.Show(e.Message, Resources.error_MessageBox, MessageBoxButtons.OK, MessageBoxIcon.Error); }

            return table;
        }
        public DataTable BuscarUsuarioNome(string nomeUsuario)
        {
            DataTable table = new DataTable();
            try
            {
                AbrirConexaoDb();
                SqlDataAdapter adapter = new SqlDataAdapter($"SELECT * FROM Usuarios WHERE Usuario = \'{nomeUsuario}\'", connection);
                FechaConecxaoDb();
                adapter.Fill(table);
            }
            catch (SqlException e) { MessageBox.Show(e.Message, Resources.error_MessageBox, MessageBoxButtons.OK, MessageBoxIcon.Error); }

            return table;
        }
        public DataTable PesquisarUsuarioNome(string nomeUsuario)
        {
            DataTable table = new DataTable();
            try
            {
                AbrirConexaoDb();
                SqlDataAdapter adapter = new SqlDataAdapter($"SELECT * FROM Usuarios WHERE Usuario LIKE \'%{nomeUsuario}%\'", connection);
                FechaConecxaoDb();
                adapter.Fill(table);
            }
            catch (SqlException e) { MessageBox.Show(e.Message, Resources.error_MessageBox, MessageBoxButtons.OK, MessageBoxIcon.Error); }

            return table;
        }
        public DataTable VerAdm()
        {
            DataTable table = new DataTable();
            try
            {
                AbrirConexaoDb();
                SqlDataAdapter adapter = new SqlDataAdapter($"SELECT * FROM Usuarios WHERE Tipo = \'{Tipos.TipoUsuário.ADM}\'", connection);
                FechaConecxaoDb();
                adapter.Fill(table);
            }
            catch (SqlException e) { MessageBox.Show(e.Message, Resources.error_MessageBox, MessageBoxButtons.OK, MessageBoxIcon.Error); }

            return table;
        }
        public DataTable VerUsu()
        {
            DataTable table = new DataTable();
            try
            {
                AbrirConexaoDb();
                SqlDataAdapter adapter = new SqlDataAdapter($"SELECT * FROM Usuarios WHERE Tipo = \'{Tipos.TipoUsuário.USU}\'", connection);
                FechaConecxaoDb();
                adapter.Fill(table);
            }
            catch (SqlException e) { MessageBox.Show(e.Message, Resources.error_MessageBox, MessageBoxButtons.OK, MessageBoxIcon.Error); }

            return table;
        }
        #endregion
    }
}