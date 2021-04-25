using System;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using AutoUpdaterDotNET;
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
            mnuGerenciarUsuario.Click += (sender, e) =>
            {
                GerenciarUsuario gerenciarUsuario = new GerenciarUsuario();
                gerenciarUsuario.Show();
            };
            mnuPesquisarUsuarios.Click += (sender, e) =>
            {
                PesquisarUsuario pesquisarUsuario = new PesquisarUsuario();
                pesquisarUsuario.Show();
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
                                "\n" + Resources.TheCreator +
                                "\n" + Resources.Licensa +
                                "\n" + Resources.CreditosIcones,
                    Resources.sobre_MessageBox, MessageBoxButtons.OK, MessageBoxIcon.Information);
            };
            mnuProcurarAtualizacoes.Click += (sender, e) => AppManager.ProcurarAtualizacoes();
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

        private void Inicio_Load(object sender, EventArgs e)
        {
            //Deixar o Form invisível enquanto a SplashScreen está carregando
            Opacity = 0;
            ShowInTaskbar = false;

            SplashScreen splashScreen = new SplashScreen();
            splashScreen.Show();
            splashScreen.FormClosed += delegate
            {
                Opacity = 100;
                ShowInTaskbar = true;
            };

            //Deixar o lblNomeUsuario trasnparente para evitar que sobreponha a imagem de fundo
            lblNomeUsuario.BackColor = Color.Transparent;
            BringToFront();
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
                    Close(); 
                    break;
                case Keys.F7:
                    btnSairUsuario.PerformClick();
                    break;
            }
        }

        private void Inicio_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show(Resources.ConfirmarSair, Resources.MessageBoxInformacao,
                MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

            e.Cancel = dialogResult != DialogResult.Yes;
        }
    }
}
