using System;
using System.Collections.Generic;
using System.Linq;
using ProjectBook.GUI;
using System.IO;
using System.Windows.Forms;
using ProjectBook.Properties;
using System.Configuration;

namespace ProjectBook.DB.Migration
{
    static class OneDrive
    {
        public static void MigrarOneDrive(string pastaAplicacaoOneDrive)
        {
            try
            {
                if (Directory.Exists(pastaAplicacaoOneDrive))
                {
                    DialogResult dialogResult = MessageBox.Show(Resources.existePastaOneDrive,
                        Resources.MessageBoxInformacao, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (dialogResult == DialogResult.No)
                    {
                        Configuracoes.config.AppSettings.Settings["dbPadrao"].Value = "sqlserverlocaldb";
                        Configuracoes.config.ConnectionStrings.ConnectionStrings["SqlConnectionString"].ConnectionString =
                            $@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename ={ConfigurationManager.AppSettings["pastaDb"]}; Integrated Security = True";
                        Configuracoes.config.Save();
                        ConfigurationManager.RefreshSection("appSettings");

                        AppManager.ReiniciarPrograma();
                        return;
                    }
                }

                Directory.Move(Directory
                    .GetParent(ConfigurationManager.AppSettings["pastaDb"]).ToString(), pastaAplicacaoOneDrive);

                //Pegar o novo diretorio do banco de dados
                string diretorioDbOneDrive = Directory
                    .GetFiles(pastaAplicacaoOneDrive, "*.*", SearchOption.AllDirectories)
                    .First(mdf => mdf.Contains(".mdf"));

                //Criar nova string de conexão
                Configuracoes.config.ConnectionStrings.ConnectionStrings["SqlConnectionString"].ConnectionString =
                    $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={diretorioDbOneDrive};Integrated Security=True";

                Configuracoes.config.AppSettings.Settings["pastaDb"].Value = pastaAplicacaoOneDrive;
                Configuracoes.config.Save();
                ConfigurationManager.RefreshSection("connectionStrings");
            }
            catch (Exception e)
            {
                MessageBox.Show(
                    string.Format(Resources.ErrorMigrarOneDrive, e.Message),
                    Resources.MessageBoxError, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
