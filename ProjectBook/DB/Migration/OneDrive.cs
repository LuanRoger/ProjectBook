using System;
using System.Collections.Generic;
using System.Linq;
using ProjectBook.GUI;
using System.IO;
using System.Windows.Forms;
using ProjectBook.Properties.Languages;
using System.Configuration;

namespace ProjectBook.DB.Migration
{
    static class OneDrive
    {
        public readonly static string _oneDriveFolder = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) +
                                                        @"\OneDrive\ProjectBook";

        public static void MigrarOneDrive()
        {
            try
            {
                if (Directory.Exists(_oneDriveFolder))
                {
                    DialogResult dialogResult = MessageBox.Show(Strings.ExistePastaOneDrive,
                        Strings.MessageBoxInformacao, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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
                    .GetParent(ConfigurationManager.AppSettings["pastaDb"]).ToString(), _oneDriveFolder);

                //Pegar o novo diretorio do banco de dados
                string diretorioDbOneDrive = Directory
                    .GetFiles(_oneDriveFolder, "*.*", SearchOption.AllDirectories)
                    .First(mdf => mdf.Contains(".mdf"));

                //Criar nova string de conexão
                Configuracoes.config.ConnectionStrings.ConnectionStrings["SqlConnectionString"].ConnectionString =
                    $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={diretorioDbOneDrive};Integrated Security=True";

                Configuracoes.config.AppSettings.Settings["pastaDb"].Value = _oneDriveFolder;
                Configuracoes.config.Save();
                ConfigurationManager.RefreshSection("connectionStrings");
            }
            catch (Exception e)
            {
                MessageBox.Show(
                    string.Format(Strings.ErrorMigrarOneDrive, e.Message),
                    Strings.MessageBoxError, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
