using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjectBook.DB.SqlServerExpress;
using ProjectBook.Managers;
using ProjectBook.Managers.Configuration;
using ProjectBook.Model;
using ProjectBook.Properties;

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
            await AppManager.DownloadFonts();
            AppConfigurationManager.LoadConfig();

            PrivateFontCollection privateFont = new();
            privateFont.AddFontFile(Consts.FONT_MONTSERRAT_EXTRABOLD);
            privateFont.AddFontFile(Consts.FONT_MONTSERRAT_EXTRALIGHT);

            label1.Font = new(privateFont.Families[0], 20, FontStyle.Bold);
            label2.Font = new(privateFont.Families[1], 7, FontStyle.Regular);
            
            lblStatusCarregamento.Text = Resources.VerificandoConexao_SplashScreen;
            
            if (DatabaseManager.VerificarConexao() == false)
            {
                DialogResult dialogResult = MessageBox.Show(Resources.ErrorConectarDb, Resources.Error_MessageBox, MessageBoxButtons.YesNo,
                    MessageBoxIcon.Error);
                
                if(dialogResult == DialogResult.Yes)
                {
                    DatabaseManager.OpenConfigurationSafeMode();
                    return;   
                }

                Environment.Exit(1);
            }

            lblStatusCarregamento.Text = Resources.VerificacoesSeguranca_SplashScreen;

            AppManager.LoadUser();
            if (!Verificadores.VerificarUsuarioLogado())
            {
                UsuarioLogado();
                return;
            }

            AppManager.UpdateUserInfo();

            lblStatusCarregamento.Text = Resources.Carregando_SplashScreen;

            List<Task> inicializeTasks = new()
            {
                AtualizarAtrasso(),
                Task.Delay(Consts.SPLASH_SCREEN_LOADTIME)
            };

            await Task.WhenAll(inicializeTasks.ToArray());

            Close();
        }

        private void UsuarioLogado()
        {
            if (Application.OpenForms.Count < 2)
            {
                Login login = new();
                login.ShowDialog();
            }
            else AppManager.ReiniciarPrograma();
        }

        private async Task AtualizarAtrasso()
        {
            lblStatusCarregamento.Text = Resources.AtualizandoBancoDados_SpashScreen;
            
            foreach (AluguelModel data in await AluguelDb.PegarLivrosAlugados())
            {
                DateTime hoje = DateTime.Now.Date;
                DateTime devolucao = data.dataDevolucao;
                if (Convert.ToInt32((hoje - devolucao).Days) >= 0)
                    AluguelDb.AtualizarStatusAtrasado(data.alugadoPor);
            }
        }
    }
}
