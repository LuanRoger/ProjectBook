using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using ProjectBook.AppInsight;
using ProjectBook.Livros;
using ProjectBook.Properties;

namespace ProjectBook.DB.SqlServerExpress
{
    class UsuarioDb : Db
    {
        public void CadastrarUsuario(Usuario usuario)
        {
            SqlCommand command = new() { Connection = connection};
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

                MessageBox.Show(Resources.UsuarioRegistrado, Resources.concluido_MessageBox,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException e) { MessageBox.Show(e.Message, Resources.MessageBoxError, MessageBoxButtons.OK, MessageBoxIcon.Error); 
                AppInsightMetrics.SendError(e); }
        }
        public void DeletarUsuarioId(string id)
        {
            SqlCommand command = new() { Connection = connection };
            try
            {
                command.CommandText = $"DELETE FROM Usuarios WHERE ID = {id}";

                AbrirConexaoDb();
                command.ExecuteNonQuery();
                FechaConecxaoDb();

                command.Dispose();

                MessageBox.Show(Resources.UsuarioDeletado, Resources.concluido_MessageBox,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException e){ MessageBox.Show(e.Message, Resources.ErrorConectarDb, MessageBoxButtons.OK, MessageBoxIcon.Error); 
                AppInsightMetrics.SendError(e); }
        }
        public void AtualizarUsuarioId(string id, Usuario usuario)
        {
            SqlCommand command = new() { Connection = connection};
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
            catch (SqlException e) { MessageBox.Show(e.Message, Resources.MessageBoxError, MessageBoxButtons.OK, MessageBoxIcon.Error); 
                AppInsightMetrics.SendError(e);}
        }

        #region Login
        public DataTable LoginUsuario(string usuario, string senha)
        {
            DataTable dataTable = new();
            try
            {
                AbrirConexaoDb();
                SqlDataAdapter adapter = new($"SELECT * FROM Usuarios WHERE Usuario = \'{usuario}\' AND Senha = \'{senha}\'", connection);
                FechaConecxaoDb();
                adapter.Fill(dataTable);
            }
            catch (SqlException e) { MessageBox.Show(e.Message, Resources.MessageBoxError, MessageBoxButtons.OK, MessageBoxIcon.Error); 
                AppInsightMetrics.SendError(e); }

            return dataTable;
        }
        public DataTable LoginCodigo(string id, string senha)
        {
            DataTable dataTable = new();
            try
            {
                AbrirConexaoDb();
                SqlDataAdapter adapter = new($"SELECT * FROM Usuarios WHERE ID = \'{id}\' AND Senha = \'{senha}\'", connection);
                FechaConecxaoDb();
                adapter.Fill(dataTable);
            }
            catch (SqlException e){ MessageBox.Show(e.Message, Resources.MessageBoxError, MessageBoxButtons.OK, MessageBoxIcon.Error); 
                AppInsightMetrics.SendError(e); }

            return dataTable;
        }
        #endregion

        public DataTable ReceberTipoUsuario(string usuario)
        {
            DataTable dataTable = new();
            try
            {
                AbrirConexaoDb();
                SqlDataAdapter adapter = new($"SELECT Tipo FROM Usuarios WHERE Usuario = '{usuario}'", connection);
                FechaConecxaoDb();
                adapter.Fill(dataTable);
            }
            catch (Exception e){ MessageBox.Show(e.Message, Resources.MessageBoxError, MessageBoxButtons.OK, MessageBoxIcon.Error); 
                AppInsightMetrics.SendError(e);}

            return dataTable;
        }
        #region Buscar
        public DataTable BuscarUsuarioId(string id)
        {
            DataTable table = new();

            try
            {
                AbrirConexaoDb();
                SqlDataAdapter adapter = new($"SELECT * FROM Usuarios WHERE ID = {id}", connection);
                FechaConecxaoDb();
                adapter.Fill(table);
            }
            catch (SqlException e) { MessageBox.Show(e.Message, Resources.MessageBoxError, MessageBoxButtons.OK, MessageBoxIcon.Error); 
                AppInsightMetrics.SendError(e); }

            return table;
        }
        public DataTable BuscarUsuarioNome(string nomeUsuario)
        {
            DataTable table = new();
            try
            {
                AbrirConexaoDb();
                SqlDataAdapter adapter = new($"SELECT * FROM Usuarios WHERE Usuario = \'{nomeUsuario}\'", connection);
                FechaConecxaoDb();
                adapter.Fill(table);
            }
            catch (SqlException e) { MessageBox.Show(e.Message, Resources.MessageBoxError, MessageBoxButtons.OK, MessageBoxIcon.Error); 
                AppInsightMetrics.SendError(e); }

            return table;
        }
        public DataTable PesquisarUsuarioNome(string nomeUsuario)
        {
            DataTable table = new();
            try
            {
                AbrirConexaoDb();
                SqlDataAdapter adapter = new($"SELECT * FROM Usuarios WHERE Usuario LIKE \'%{nomeUsuario}%\'", connection);
                FechaConecxaoDb();
                adapter.Fill(table);
            }
            catch (SqlException e) { MessageBox.Show(e.Message, Resources.MessageBoxError, MessageBoxButtons.OK, MessageBoxIcon.Error); 
                AppInsightMetrics.SendError(e); }

            return table;
        }
        public DataTable VerAdm()
        {
            DataTable table = new();
            try
            {
                AbrirConexaoDb();
                SqlDataAdapter adapter = new($"SELECT * FROM Usuarios WHERE Tipo = \'{Tipos.TipoUsuário.ADM}\'", connection);
                FechaConecxaoDb();
                adapter.Fill(table);
            }
            catch (SqlException e) { MessageBox.Show(e.Message, Resources.MessageBoxError, MessageBoxButtons.OK, MessageBoxIcon.Error); 
                AppInsightMetrics.SendError(e); }

            return table;
        }
        public DataTable VerUsu()
        {
            DataTable table = new();
            try
            {
                AbrirConexaoDb();
                SqlDataAdapter adapter = new($"SELECT * FROM Usuarios WHERE Tipo = \'{Tipos.TipoUsuário.USU}\'", connection);
                FechaConecxaoDb();
                adapter.Fill(table);
            }
            catch (SqlException e) { MessageBox.Show(e.Message, Resources.MessageBoxError, MessageBoxButtons.OK, MessageBoxIcon.Error); 
                AppInsightMetrics.SendError(e); }

            return table;
        }
        #endregion
    }
}