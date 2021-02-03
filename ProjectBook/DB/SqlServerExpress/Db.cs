using System;
using System.ComponentModel;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ProjectBook.DB.SqlServerExpress
{
    internal abstract class Db
    {
        protected static readonly SqlConnection connection = 
            new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString);

        public string DbStatus() => connection.State.ToString();
        #region Modificar conexão
        public void AbrirConexaoDb()
        {
            try { connection.Open(); }
            catch(Exception e)
            {
                if (Application.OpenForms.Count < 2)
                {
                    DialogResult dialogResult = MessageBox.Show(
                        $"Não foi possivel conectar-se a base de dados: {e.Message}. Deseja abrir a configurações?",
                        Properties.Resources.error_MessageBox,
                        MessageBoxButtons.YesNo, MessageBoxIcon.Error);

                    if (dialogResult == DialogResult.Yes)
                    {
                        Configuracoes configuracoes = new Configuracoes();
                        configuracoes.Closing += delegate(object sender, CancelEventArgs args)
                        {
                            if (String.IsNullOrEmpty(ConfigurationManager.AppSettings["usuarioLogado"]) ||
                                String.IsNullOrEmpty(ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString))
                                Environment.Exit(0);
                        };
                        configuracoes.Show();
                    }
                    else Environment.Exit(0);
                }
            }

        }
        public void FechaConecxaoDb() => connection.Close();
        #endregion
    }
}
