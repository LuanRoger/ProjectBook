using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

namespace ProjectBook.DB.SqlServerExpress
{
    internal class Db
    {
        internal readonly SqlConnection connection = 
            new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString);

        public string DbStatus() => connection.State.ToString();
        #region Modificar conexão
        public void AbrirConexaoDb()
        {
            try { connection.Open(); }
            catch(Exception e)
            {
                DialogResult dialogResult = MessageBox.Show($"Não foi possivel conectar-se a base de dados: {e.Message}. Deseja abrir a configurações?", "Error",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Error);

                if (dialogResult == DialogResult.Yes)
                {
                    Configuracoes configuracoes = new Configuracoes();
                    configuracoes.Show();
                }
                else Application.Exit();
            }

        }
        public void FechaConecxaoDb() => connection.Close();
        #endregion
    }
}
