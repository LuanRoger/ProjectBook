using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using ProjectBook.Properties;
using ProjectBook.Managers;
using ProjectBook.Managers.Configuration;

namespace ProjectBook.DB.OneDrive
{
    public static class OneDrive
    {
        public static void MigrarOneDrive()
        {
            try
            {
                if (Directory.Exists(Consts.PASTA_APLICACAO_ONEDRIVE))
                {
                    DialogResult dialogResult = MessageBox.Show(Resources.ExistePastaOneDrive,
                        Resources.Informacao_MessageBox, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (dialogResult == DialogResult.No)
                    {
                        AppConfigurationManager.configuration.database.DbEngine = Tipos.TipoDatabase.SqlServerLocalDb;
                        AppConfigurationManager.configuration.database.SqlConnectionString =
                            $@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = {AppConfigurationManager.configuration.database.DbFolder}; Integrated Security = True";

                        AppManager.ReiniciarPrograma();
                        return;
                    }

                    Directory.Delete(Consts.PASTA_APLICACAO_ONEDRIVE);
                }

                Directory.Move(Directory
                    .GetParent(AppConfigurationManager.configuration.database.DbFolder).ToString(), Consts.PASTA_APLICACAO_ONEDRIVE);

                //Pegar o novo diretorio do banco de dados
                string diretorioDbOneDrive = Directory
                    .GetFiles(Consts.PASTA_APLICACAO_ONEDRIVE, "*.mdf", SearchOption.TopDirectoryOnly)
                    .First();

                //Criar nova string de conexão
                AppConfigurationManager.configuration.database.SqlConnectionString =
                    $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={diretorioDbOneDrive};Integrated Security=True";

                AppConfigurationManager.configuration.database.DbFolder = Consts.PASTA_APLICACAO_ONEDRIVE;
            }
            catch (Exception e)
            {
                MessageBox.Show(
                    string.Format(Resources.ErrorMigrarOneDrive, e.Message),
                    Resources.Error_MessageBox, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
