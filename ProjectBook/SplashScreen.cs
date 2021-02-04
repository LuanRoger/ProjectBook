using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjectBook.DB.SqlServerExpress;
using ProjectBook.Properties;

namespace ProjectBook
{
    public partial class SplashScreen : Form
    {
        private LivrosDb livrosDb = new LivrosDb();
        private AluguelDb aluguelDb = new AluguelDb();

        public SplashScreen()
        {
            InitializeComponent();

            PrivateFontCollection privateFont = new PrivateFontCollection();
            privateFont.AddFontFile(Application.StartupPath + @"font\\Montserrat-ExtraBold.ttf");
            privateFont.AddFontFile(Application.StartupPath + @"font\\Montserrat-ExtraLight.ttf");
            label1.Font = new Font(privateFont.Families[0], 20, FontStyle.Bold);
            label2.Font = new Font(privateFont.Families[1], 7, FontStyle.Regular);

            livrosDb.AbrirConexaoDb();
            if (livrosDb.DbStatus() == "Open")
            {
                //Atualizar Status do aluguel
                lblStatusCarregamento.Text = Resources.atualizando_banco_de_dados_splashscreen;
                AtualizarAtrasso();

                //Verificar se existe usuário logado
                lblStatusCarregamento.Text = Resources.realizando_verificações_de_segurança_splashscreen;
                UsuarioLogado();
            }
            livrosDb.FechaConecxaoDb();
        }
        private void UsuarioLogado()
        {
            if (String.IsNullOrEmpty(ConfigurationManager.AppSettings["usuarioLogado"]))
            {
                if (Application.OpenForms.Count < 2)
                {
                    Login login = new Login();
                    login.BringToFront();
                    login.Show();
                }
            }
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
