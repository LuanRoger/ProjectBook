using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
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

            //Sincronização OneDrive
            if (ConfigurationManager.AppSettings["dbPadrao"] == "onedrive" &&
                ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString == "")
            {
                lblStatusCarregamento.Text = "Migrando banco para o OneDrive...";
                string pastaAplicacaoOneDrive = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) +
                                                @"\OneDrive\ProjectBook";
                try
                {
                    //Mover pasta o OneDrive
                    Directory.Move(Directory
                        .GetParent(ConfigurationManager.AppSettings["pastaDb"]).ToString(), pastaAplicacaoOneDrive);

                    //Pegar o novo diretorio do banco de dados
                    string diretorioDbOneDrive = Directory
                        .GetFiles(pastaAplicacaoOneDrive, "*.*", SearchOption.AllDirectories)
                        .First(mdf => mdf.Contains(".mdf"));

                    //Criar novo string de conexão
                    Configuracoes.config.ConnectionStrings.ConnectionStrings["SqlConnectionString"]
                            .ConnectionString =
                        $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={diretorioDbOneDrive};Integrated Security=True";

                    Configuracoes.config.AppSettings.Settings["pastaDb"].Value = pastaAplicacaoOneDrive;
                    Configuracoes.config.Save();
                    ConfigurationManager.RefreshSection("connectionStrings");
                }
                catch (Exception e) { MessageBox.Show($"Ocorreu um error: {e.Message}. Volte as configurações e crie uma novo string de conexão.", 
                    Resources.error_MessageBox, MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }

            //Atualizar Status do aluguel
            lblStatusCarregamento.Text = Resources.atualizando_banco_de_dados_splashscreen;
            AtualizarAtrasso();

            //Verificar se existe usuário logado
            lblStatusCarregamento.Text = Resources.realizando_verificações_de_segurança_splashscreen;
            UsuarioLogado();
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
            aluguelDb.AbrirConexaoDb();
            foreach (DataRow data in aluguelDb.PegarLivrosAlugados().Rows)
            {
                DateTime hoje = DateTime.Now.Date;
                DateTime devolucao = (DateTime)data[4];
                if (Convert.ToInt32((hoje - devolucao).Days) >= 0)
                   aluguelDb.AtualizarStatusAtrasado(data[2].ToString());
            }
            aluguelDb.FechaConecxaoDb();
        }
    }
}
