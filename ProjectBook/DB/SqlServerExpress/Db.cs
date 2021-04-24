using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using ProjectBook.GUI;
using ProjectBook.Properties.Languages;

namespace ProjectBook.DB.SqlServerExpress
{
    internal abstract class Db
    {
        protected static readonly SqlConnection connection = 
            new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString);
        /// <summary>
        /// Verifica a conexão entre o programa e o banco de dados
        /// </summary>
        /// <returns>Retorna <c>Open</c> ou <c>Close</c> string</returns>
        public ConnectionState DbStatus() => connection.State;
        #region Modificar conexão
        public void AbrirConexaoDb()
        {
            try { connection.Open(); }
            catch(Exception e)
            {
                if (Application.OpenForms.Count < 2)
                {
                    DialogResult dialogResult = MessageBox.Show(
                        string.Format(Strings.ErrorConectarDb, e.Message),
                        Strings.MessageBoxError,
                        MessageBoxButtons.YesNo, MessageBoxIcon.Error);

                    if (dialogResult == DialogResult.Yes)
                    {
                        // Fazer com que o tipo de usuario seja alterado para ADM para que possa editar a string de conexão
                        Configuracoes.config.AppSettings.Settings["tipoUsuario"].Value = Tipos.TipoUsuário.ADM.ToString();
                        Configuracoes.config.Save();
                        ConfigurationManager.RefreshSection("appSettings");

                        Configuracoes configuracoes = new Configuracoes();
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
        public void FechaConecxaoDb() => connection.Close();
        #endregion
    }
}
