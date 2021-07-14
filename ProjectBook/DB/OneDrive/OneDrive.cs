using System;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using ProjectBook.GUI;
using ProjectBook.Properties;

namespace ProjectBook.DB.OneDrive
{
    public static class OneDrive
    {
        private static readonly string pastaAplicacaoOneDrive = 
            Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\OneDrive\ProjectBook";

        public static void MigrarOneDrive()
        {
            try
            {
                if (Directory.Exists(pastaAplicacaoOneDrive))
                {
                    DialogResult dialogResult = MessageBox.Show(Resources.existePastaOneDrive,
                        Resources.MessageBoxInformacao, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (dialogResult == DialogResult.No)
                    {
                        AppConfigurationManager.dbPadrao = Tipos.TipoDatabase.SqlServerLocalDb;
                        AppConfigurationManager.SqlConnectionString =
                            $@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = {AppConfigurationManager.pastaDb}; Integrated Security = True";

                        AppManager.ReiniciarPrograma();
                        return;
                    }

                    Directory.Delete(pastaAplicacaoOneDrive);
                }

                Directory.Move(Directory
                    .GetParent(AppConfigurationManager.pastaDb).ToString(), pastaAplicacaoOneDrive);

                //Pegar o novo diretorio do banco de dados
                string diretorioDbOneDrive = Directory
                    .GetFiles(pastaAplicacaoOneDrive, "*.mdf", SearchOption.TopDirectoryOnly)
                    .First();

                //Criar nova string de conexão
                AppConfigurationManager.SqlConnectionString =
                    $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={diretorioDbOneDrive};Integrated Security=True";

                AppConfigurationManager.pastaDb = pastaAplicacaoOneDrive;
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
