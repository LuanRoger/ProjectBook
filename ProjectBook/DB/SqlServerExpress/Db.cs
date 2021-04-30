using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;
using ProjectBook.GUI;
using ProjectBook.Properties;
using System.Data;

namespace ProjectBook.DB.SqlServerExpress
{
    abstract class Db
    {
        protected static readonly SqlConnection connection = 
            new(ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString);
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
                if (Application.OpenForms.Count < 2)
                {
                    DialogResult dialogResult = MessageBox.Show(
                        string.Format(Resources.ErrorConectarDb, e.Message),
                        Resources.MessageBoxError,
                        MessageBoxButtons.YesNo, MessageBoxIcon.Error);

                    if (dialogResult == DialogResult.Yes)
                    {
                        // Fazer com que o tipo de usuario seja alterado para ADM para que possa editar a string de conexão
                        Configuracoes.config.AppSettings.Settings["tipoUsuario"].Value = Tipos.TipoUsuário.ADM.ToString();
                        Configuracoes.config.Save();
                        ConfigurationManager.RefreshSection("appSettings");

                        Configuracoes configuracoes = new();
                        configuracoes.Closing += delegate
                        {
                            //Evitar softlock
                            if (string.IsNullOrEmpty(ConfigurationManager.AppSettings["usuarioLogado"]) ||
                                string.IsNullOrEmpty(ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString))
                                Environment.Exit(1);
                        };
                        configuracoes.Show();
                        configuracoes.BringToFront();
                    }
                    else Environment.Exit(0);
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
            else return false;
        }
        #endregion
    }
}
