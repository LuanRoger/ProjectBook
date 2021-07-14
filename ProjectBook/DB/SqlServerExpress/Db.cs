using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;
using ProjectBook.Properties;
using System.Data;
using System.Diagnostics;
using ProjectBook.GUI;
using ProjectBook.AppInsight;

namespace ProjectBook.DB.SqlServerExpress
{
    abstract class Db
    {
        protected static readonly SqlConnection connection = 
            new(AppConfigurationManager.SqlConnectionString);

        /// <summary>
        /// Verifica a conexão entre o programa e o banco de dados
        /// </summary>
        /// <returns>Retorna <c>Open</c> ou <c>Close</c> string</returns>
        public ConnectionState DbStatus() => connection.State;

        #region Modificar conexão
        protected void AbrirConexaoDb()
        {
            try { connection.Open(); }
            catch(Exception e)
            {
                AppInsightMetrics.SendError(e);

                if (Application.OpenForms.Count < 2)
                {
                    DialogResult dialogResult = MessageBox.Show(
                        string.Format(Resources.ErrorConectarDb, e.Message),
                        Resources.MessageBoxError,
                        MessageBoxButtons.YesNo, MessageBoxIcon.Error);

                    if (dialogResult == DialogResult.Yes)
                    {
                        AppManager.GiveAdm();

                        Configuracoes configuracoes = new();
                        configuracoes.Closing += (_, _) => Environment.Exit(1);
                        configuracoes.Show();
                        configuracoes.BringToFront();
                    }
                    else Process.GetCurrentProcess().Kill();
                }
            }
        }
        protected void FechaConecxaoDb() => connection.Close();

        public bool VerificarConexaoDb()
        {
            AbrirConexaoDb();
            if (DbStatus() == ConnectionState.Open)
            {
                FechaConecxaoDb();
                return true;
            }
            return false;
        }
        #endregion
    }
}
