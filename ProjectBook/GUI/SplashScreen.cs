using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;
using ProjectBook.Controllers;
using ProjectBook.DB;
using ProjectBook.DB.Models;
using ProjectBook.Model;
using ProjectBook.Properties;
using ProjectBook.Services;

namespace ProjectBook.GUI
{
    public partial class SplashScreen : Form
    {
        public SplashScreen()
        {
            InitializeComponent();
        }
        private async void SplashScreen_Load(object sender, EventArgs e)
        {
            WebDownloadService webDownloadService = new();
            
            Task firstTasks = Task.WhenAll(new List<Task> 
            { 
                webDownloadService.DownloadFonts(), 
                Globals.configurationController.LoadConfig()
            });
            await firstTasks;

            PrivateFontCollection privateFont = new();
            privateFont.AddFontFile(Consts.FONT_MONTSERRAT_EXTRABOLD);
            privateFont.AddFontFile(Consts.FONT_MONTSERRAT_EXTRALIGHT);

            label1.Font = new(privateFont.Families[0], 20, FontStyle.Bold);
            label2.Font = new(privateFont.Families[1], 7, FontStyle.Regular);
            
            lblStatusCarregamento.Text = Resources.VerificandoConexao_SplashScreen;
            
            if (Globals.databaseController.CanConnect() == false)
            {
                DialogResult dialogResult = MessageBox.Show(Resources.ErrorConectarDb, Resources.Error_MessageBox, MessageBoxButtons.YesNo,
                    MessageBoxIcon.Error);
                
                if(dialogResult == DialogResult.Yes)
                {
                    Configuracoes configuracoes = new(safeMode: true);
                    configuracoes.Show();
                    configuracoes.BringToFront();
                    return;   
                }

                Environment.Exit(1);
            }

            lblStatusCarregamento.Text = Resources.VerificacoesSeguranca_SplashScreen;

            Globals.userSessionController.LoadUser();
            if (UserSessionController.isAnonymus)
            {
                LoginUser();
                return;
            }

            lblStatusCarregamento.Text = Resources.Carregando_SplashScreen;

            List<Task> inicializeTasks = new()
            {
                Globals.userSessionController.UpdateUserAccessType(),
                AtualizarAtrasso(),
                Task.Delay(Consts.SPLASH_SCREEN_LOADTIME)
            };

            await Task.WhenAll(inicializeTasks);

            Close();
        }

        private void LoginUser()
        {
            if (Application.OpenForms.Count < 2)
            {
                Login login = new();
                login.ShowDialog();
            }
            else AppController.RestartApplication();
        }

        private async Task AtualizarAtrasso()
        {
            lblStatusCarregamento.Text = Resources.AtualizandoBancoDados_SpashScreen;
            
            IContextTransaction transaction = Globals.databaseController.GetTransactionContext();
            AluguelContext aluguelTransaction = (AluguelContext)transaction.StartTransaction<AluguelModel>();
            await aluguelTransaction.UpdateStatusAtrasado();
            
            await transaction.EndTransactionAsync();
        }
    }
}
