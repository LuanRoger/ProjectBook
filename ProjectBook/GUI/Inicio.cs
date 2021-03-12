using System;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjectBook.DB.SqlServerExpress;
using ProjectBook.Properties;

namespace ProjectBook.GUI
{
    public partial class Inicio : Form
    {
        private LivrosDb livrosDb = new LivrosDb();
        private AluguelDb aluguelDb = new AluguelDb();
        private ClienteDb clienteDb = new ClienteDb();

        public Inicio()
        {
            InitializeComponent();

            lblNomeUsuario.Text = ConfigurationManager.AppSettings["usuarioLogado"];

            #region MenuClick
            mnuNovoLivro.Click += (sender, e) =>
            {
                CadastroLivro cadastroLivro = new CadastroLivro();
                cadastroLivro.Show();
            };

            mnuEditarLivro.Click += (sender, e) => 
            {
                EditarLivro editarLivro = new EditarLivro();
                editarLivro.Show();
            };

            mnuCadastrarAluguel.Click += (sender, e) =>
            {
                CadastrarAluguel cadastrarAluguel = new CadastrarAluguel();
                cadastrarAluguel.Show();
            };
            mnuEditarAluguel.Click += (sender, e) =>
            {
                EditarAluguel editarAluguel = new EditarAluguel();
                editarAluguel.Show();
            };

            mnuCadastrarCliente.Click += (sender, e) =>
            {
                CadastrarClientes cadastrarClientes = new CadastrarClientes();
                cadastrarClientes.Show();
            };
            mnuEditarClientes.Click += (sender, e) =>
            {
                EditarCliente editarCliente = new EditarCliente();
                editarCliente.Show();
            };

            mnuUsuario.Visible = ConfigurationManager.AppSettings["tipoUsuario"] == "ADM";
            mnuUsuario.Click += (sender, e) =>
            {
                GerenciarUsuario gerenciarUsuario = new GerenciarUsuario();
                gerenciarUsuario.Show();
            };
            
            mnuExcluirLivro.Click += (sender, e) =>
            {
                Excluir excluir = new Excluir();
                excluir.Show();
            };
            mnuExcluirCliente.Click += (sender, e) =>
            {
                ExcluirCliente excluirCliente = new ExcluirCliente();
                excluirCliente.Show();
            };
            mnuExcluirAluguel.Click += (sender, e) =>
            {
                ExcluirAluguel excluirAluguel = new ExcluirAluguel();
                excluirAluguel.Show();
            };

            mnuTodosLivros.Click += (sender, e) =>
            {
                ListaPesquisa listaPesquisa = new ListaPesquisa(livrosDb.VerTodosLivros());
                listaPesquisa.Show();
            };
            mnuPesquisaSeletiva.Click += (sender, e) =>
            {
                PesquisaSeletiva pesquisaSeletiva = new PesquisaSeletiva();
                pesquisaSeletiva.Show();
            };
            mnuLivrosAlugados.Click += (sender, e) => 
            {
                ListaPesquisa listaPesquisa = new ListaPesquisa(aluguelDb.VerTodosAluguel());
                listaPesquisa.Show();
            };
            mnuPesquisarAluguel.Click += (sender, e) =>
            {
                PesquisarAluguel pesquisarAluguel = new PesquisarAluguel();
                pesquisarAluguel.Show();
            };
            mnuTodosClientes.Click += (sender, e) =>
            {
                ListaPesquisa listaPesquisa = new ListaPesquisa(clienteDb.VerTodosClientes());
                listaPesquisa.Show();
            };
            mnuPesquisarCliente.Click += (sender, e) =>
            {
                PesquisarCliente pesquisarCliente = new PesquisarCliente();
                pesquisarCliente.Show();
            };

            mnuConfig.Click += (sender, e) => 
            {
                Configuracoes configuracoes = new Configuracoes();
                configuracoes.Show();
            };

            mnuSobre.Click += (sender, e) =>
            {
                MessageBox.Show("Project Book v" +
                                Assembly.GetExecutingAssembly().GetName().Version + 
                                "\n" + Resources.luanroger +
                                "\n" + Resources.license +
                                "\n" + Resources.uso_de_ícones_de_FAMFAMFAM__http___famfamfam_com,
                    Resources.sobre_MessageBox, MessageBoxButtons.OK, MessageBoxIcon.Information);
            };
            #endregion

            #region Acesso rápido
            mnuArCadastroLivro.Click += (sender, e) =>
            {
                CadastroLivro cadastroLivro = new CadastroLivro();
                cadastroLivro.Show();
            };
            mnuArCadastroCliente.Click += (sender, e) =>
            {
                CadastrarClientes cadastrarClientes = new CadastrarClientes();
                cadastrarClientes.Show();
            };
            mnuArCadastroAluguel.Click += (sender, e) =>
            {
                CadastrarAluguel cadastrarAluguel = new CadastrarAluguel();
                cadastrarAluguel.Show();
            };
            mnuArEditarLivro.Click += (sender, e) =>
            {
                EditarLivro editarLivro = new EditarLivro();
                editarLivro.Show();
            };
            mnuArEditarCliente.Click += (sender, e) =>
            {
                EditarCliente editarCliente = new EditarCliente();
                editarCliente.Show();
            };
            mnuArEditarAluguel.Click += (sender, e) =>
            {
                EditarAluguel editarAluguel = new EditarAluguel();
                editarAluguel.Show();
            };
            mnuArUsuario.Click += (sender, e) =>
            {
                GerenciarUsuario gerenciarUsuario = new GerenciarUsuario();
                gerenciarUsuario.Show();
            };
            mnuArBuscaRapida.Click += (sender, e) =>
            {
                PesquisaRapida pesquisaRapida = new PesquisaRapida();
                pesquisaRapida.Show();
            };
        }
        #endregion

        private void Inicio_Activated(object sender, EventArgs e)
        {
            //Carregar informações
            livrosDb.AbrirConexaoDb();
            if (livrosDb.DbStatus() != "Open") return;
            livrosDb.FechaConecxaoDb();

            lblLivrosCadastrados.Text = livrosDb.VerTodosLivros().Rows.Count.ToString();
            lblClientesCadastrados.Text = clienteDb.VerTodosClientes().Rows.Count.ToString();
            lblAlugueisRegistrados.Text = aluguelDb.VerTodosAluguel().Rows.Count.ToString();
        }
        private void btnSairUsuario_Click(object sender, EventArgs e)
        {
            Configuracoes.config.AppSettings.Settings["usuarioLogado"].Value = "";
            Configuracoes.config.Save();

            Process.Start(Application.StartupPath + Assembly.GetExecutingAssembly().GetName().Name + ".exe");
            Process.GetCurrentProcess().Kill();
        }

        private async void Inicio_Load(object sender, EventArgs e)
        {
            //Deixar o form invisível enquanto a SplashScreen está carregando
            Opacity = 0;
            ShowInTaskbar = false;

            SplashScreen splashScreen = new SplashScreen();
            splashScreen.Show();

            livrosDb.AbrirConexaoDb();
            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["usuarioLogado"]) && livrosDb.DbStatus() == "Open")
            {
                await Task.Delay(3000); // Delay para ver a Splash Screen
                ShowInTaskbar = true;
                Opacity = 100;
                splashScreen.Close();
                livrosDb.FechaConecxaoDb();
            }

            //Deixar o lblNomeUsuario trasnparente para evitar que sobreponha a imagem de fundo
            lblNomeUsuario.BackColor = Color.Transparent;

            this.BringToFront();
        }

        private void Inicio_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F1:
                    PesquisaRapida pesquisaRapida = new PesquisaRapida();
                    pesquisaRapida.Show();
                    break;
                case Keys.F6: 
                    this.Close(); 
                    break;
                case Keys.F7:
                    btnSairUsuario.PerformClick();
                    break;
            }
        }

        private void Inicio_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show(Resources.deseja_realmente_sair_, Resources.informacao_MessageBox,
                MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

            e.Cancel = dialogResult != DialogResult.Yes;
        }
    }
}
