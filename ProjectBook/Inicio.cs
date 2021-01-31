using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.Threading;
using ProjectBook.DB.SqlServerExpress;

namespace ProjectBook
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

            mnuNovoCadastro.Click += (sender, e) =>
            {
                NovoCadastro novoCadastro = new NovoCadastro();
                novoCadastro.Show();
            };

            mnuEditarCadastro.Click += (sender, e) => 
            {
                EditarCadastro editarCadastro = new EditarCadastro();
                editarCadastro.Show();
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
                ListaLivros listaLivros = new ListaLivros(livrosDb.VerTodosLivros());
                listaLivros.Show();
            };
            mnuPesquisaSeletiva.Click += (sender, e) =>
            {
                PesquisaSeletiva pesquisaSeletiva = new PesquisaSeletiva();
                pesquisaSeletiva.Show();
            };
            mnuLivrosAlugados.Click += (sender, e) => 
            {
                ListaLivros listaLivros = new ListaLivros(aluguelDb.VerTodosAluguel());
                listaLivros.Show();
            };
            mnuPesquisarAluguel.Click += (sender, e) =>
            {
                PesquisarAluguel pesquisarAluguel = new PesquisarAluguel();
                pesquisarAluguel.Show();
            };
            mnuTodosClientes.Click += (sender, e) =>
            {
                ListaLivros listaLivros = new ListaLivros(clienteDb.VerTodosClientes());
                listaLivros.Show();
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
                MessageBox.Show(Properties.Resources.versao_MessageBox +
                                Assembly.GetExecutingAssembly().GetName().Version + 
                                "\n" + Properties.Resources.luanroger,
                    Properties.Resources.sobre_MessageBox, MessageBoxButtons.OK, MessageBoxIcon.Information);
            };
        }

        private async void Inicio_Activated(object sender, EventArgs e)
        {
            //Carregar informações
            livrosDb.AbrirConexaoDb();
            if (livrosDb.DbStatus() == "Open")
            {
                int quantidadeLivros = await Task.Run(() => livrosDb.VerTodosLivros().Rows.Count);
                lblLivrosCadastrados.Text = quantidadeLivros.ToString();
                livrosDb.FechaConecxaoDb();

                clienteDb.AbrirConexaoDb();
                int quantidadeCliente = await Task.Run(() => clienteDb.VerTodosClientes().Rows.Count);
                lblClientesCadastrados.Text = quantidadeCliente.ToString();
                clienteDb.FechaConecxaoDb();

                aluguelDb.AbrirConexaoDb();
                int quantidadeAluguel = await Task.Run(() => aluguelDb.VerTodosAluguel().Rows.Count);
                lblAlugueisRegistrados.Text = quantidadeAluguel.ToString();
                aluguelDb.FechaConecxaoDb();
            }
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
            this.ShowInTaskbar = false;
            this.Opacity = 0;

            SplashScreen splashScreen = new SplashScreen();
            splashScreen.Show();

            livrosDb.AbrirConexaoDb();
            if (!String.IsNullOrEmpty(ConfigurationManager.AppSettings["usuarioLogado"]) && livrosDb.DbStatus() == "Open")
            {
                await Task.Delay(3000); //Delay para ver a Splash Screen
                this.ShowInTaskbar = true;
                this.Opacity = 100;
                splashScreen.Close();
            }
            livrosDb.FechaConecxaoDb();
        }
    }
}
