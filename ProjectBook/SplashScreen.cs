﻿using System;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Drawing;
using System.Drawing.Text;
using ProjectBook.DB.Migration;
using System.Windows.Forms;
using ProjectBook.DB.SqlServerExpress;
using ProjectBook.GUI;
using ProjectBook.Properties;
using System.Threading.Tasks;

namespace ProjectBook
{
    public partial class SplashScreen : Form
    {
        private readonly string _fontMontserratExtraBold = Application.StartupPath + @"font\Montserrat-ExtraBold.ttf";
        private readonly string _fontMontserratExtraLight = Application.StartupPath + @"font\Montserrat-ExtraLight.ttf";

        private LivrosDb livrosDb = new();
        private AluguelDb aluguelDb = new();

        public SplashScreen()
        {
            InitializeComponent();

            AppManager.DownloadFonts();

            PrivateFontCollection privateFont = new();
            privateFont.AddFontFile(_fontMontserratExtraBold);
            privateFont.AddFontFile(_fontMontserratExtraLight);

            label1.Font = new Font(privateFont.Families[0], 20, FontStyle.Bold);
            label2.Font = new Font(privateFont.Families[1], 7, FontStyle.Regular);

            //Sincronização OneDrive
            if (ConfigurationManager.AppSettings["dbPadrao"] == "onedrive" &&
                ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString == "")
            {
                lblStatusCarregamento.Text = Resources.MigrandoOneDrive;
                OneDrive.MigrarOneDrive(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) +
                                                @"\OneDrive\ProjectBook");
            }

            if (!livrosDb.VerificarConexaoDb()) return;

            //Verificar se existe usuário logado
            lblStatusCarregamento.Text = Resources.realizando_verificações_de_segurança_splashscreen;
            if (string.IsNullOrEmpty(ConfigurationManager.AppSettings["usuarioLogado"]))
            {
                UsuarioLogado();
                return;
            }

            //Atualizar Status do aluguel
            lblStatusCarregamento.Text = Resources.AtualizandoBancoDadosSpashScreen;
            if (ConfigurationManager.AppSettings["atualizarStatusAluguel"] == "1") AtualizarAtrasso();

            //Procurar atualizazções
            lblStatusCarregamento.Text = Resources.ProcurandoAtualizacoesSplashScreen;
            AppManager.ProcurarAtualizacoes();

            Task.Run(async () =>
            {
                await Task.Delay(Consts.SPLASH_SCREEN_LOADTIME);
                Invoke((MethodInvoker)delegate { Close(); });
            });
        }
        private void UsuarioLogado()
        {
            if (Application.OpenForms.Count < 2)
            {
                Login login = new();
                login.BringToFront();
                login.Show();
            }
            else { /*Configurações aberta*/ }
        }
        private void AtualizarAtrasso()
        {
            foreach (DataRow data in aluguelDb.PegarLivrosAlugados().Rows)
            {
                DateTime hoje = DateTime.Now.Date;
                DateTime devolucao = (DateTime)data[4];
                if (Convert.ToInt32((hoje - devolucao).Days) >= 0)
                    aluguelDb.AtualizarStatusAtrasado(data[2].ToString());
            }
        }
    }
}
