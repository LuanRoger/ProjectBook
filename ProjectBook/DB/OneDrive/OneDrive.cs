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
                    DialogResult dialogResult = MessageBox.Show(Resources.existePastaOneDrive,
                        Resources.MessageBoxInformacao, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (dialogResult == DialogResult.No)
                    {
                        AppConfigurationManager.databaseConfiguration.DbEngine = Tipos.TipoDatabase.SqlServerLocalDb;
                        AppConfigurationManager.databaseConfiguration.SqlConnectionString =
                            $@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = {AppConfigurationManager.databaseConfiguration.DbFolder}; Integrated Security = True";

                        AppManager.ReiniciarPrograma();
                        return;
                    }

                    Directory.Delete(Consts.PASTA_APLICACAO_ONEDRIVE);
                }

                Directory.Move(Directory
                    .GetParent(AppConfigurationManager.databaseConfiguration.DbFolder).ToString(), Consts.PASTA_APLICACAO_ONEDRIVE);

                //Pegar o novo diretorio do banco de dados
                string diretorioDbOneDrive = Directory
                    .GetFiles(Consts.PASTA_APLICACAO_ONEDRIVE, "*.mdf", SearchOption.TopDirectoryOnly)
                    .First();

                //Criar nova string de conexão
                AppConfigurationManager.databaseConfiguration.SqlConnectionString =
                    $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={diretorioDbOneDrive};Integrated Security=True";

                AppConfigurationManager.databaseConfiguration.DbFolder = Consts.PASTA_APLICACAO_ONEDRIVE;
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
