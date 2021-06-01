using System;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using ProjectBook.DB.SqlServerExpress;
using ProjectBook.Properties;
using ProjectBook.AppInsight;

namespace ProjectBook.GUI
{
    public partial class Inicio : Form
    {
        private LivrosDb livrosDb = new();
        private AluguelDb aluguelDb = new();
        private ClienteDb clienteDb = new();

        public Inicio()
        {
            InitializeComponent();

            lblNomeUsuario.Text = ConfigurationManager.AppSettings["usuarioLogado"];
            btnAccountError.Visible = lblNomeUsuario.Text == "admin";

            #region MenuClick
            mnuNovoLivro.Click += (sender, e) =>
            {
                CadastroLivro cadastroLivro = new();
                cadastroLivro.Show();

                AppInsightMetrics.TrackEvent("AbrirCadastroLivroMenu");
            };

            mnuEditarLivro.Click += (sender, e) => 
            {
                EditarLivro editarLivro = new();
                editarLivro.Show();

                AppInsightMetrics.TrackEvent("AbrirEditarLivroMenu");
            };

            mnuCadastrarAluguel.Click += (sender, e) =>
            {
                CadastrarAluguel cadastrarAluguel = new();
                cadastrarAluguel.Show();

                AppInsightMetrics.TrackEvent("AbrirCadastrarAluguelMenu");
            };
            mnuEditarAluguel.Click += (sender, e) =>
            {
                EditarAluguel editarAluguel = new();
                editarAluguel.Show();

                AppInsightMetrics.TrackEvent("AbrirEditarAluguelMenu");
            };

            mnuCadastrarCliente.Click += (sender, e) =>
            {
                CadastrarClientes cadastrarClientes = new();
                cadastrarClientes.Show();

                AppInsightMetrics.TrackEvent("AbrirCadastrarClienteMenu");
            };
            mnuEditarClientes.Click += (sender, e) =>
            {
                EditarCliente editarCliente = new();
                editarCliente.Show();

                AppInsightMetrics.TrackEvent("AbrirEditarClienteMenu");
            };

            mnuUsuario.Visible = ConfigurationManager.AppSettings["tipoUsuario"] == "ADM";
            mnuGerenciarUsuario.Click += (sender, e) =>
            {
                GerenciarUsuario gerenciarUsuario = new();
                gerenciarUsuario.Show();

                AppInsightMetrics.TrackEvent("AbrirGerenciarUsuariosMenu");
            };
            mnuPesquisarUsuarios.Click += (sender, e) =>
            {
                PesquisarUsuario pesquisarUsuario = new();
                pesquisarUsuario.Show();

                AppInsightMetrics.TrackEvent("AbrirPesquisarUsuarioMenu");
            };
            
            mnuExcluirLivro.Click += (sender, e) =>
            {
                ExcluirLivro excluir = new();
                excluir.Show();

                AppInsightMetrics.TrackEvent("AbrirExcluirLivroMenu");
            };
            mnuExcluirCliente.Click += (sender, e) =>
            {
                ExcluirCliente excluirCliente = new();
                excluirCliente.Show();

                AppInsightMetrics.TrackEvent("AbrirExcluirClienteMenu");
            };
            mnuExcluirAluguel.Click += (sender, e) =>
            {
                ExcluirAluguel excluirAluguel = new();
                excluirAluguel.Show();

                AppInsightMetrics.TrackEvent("AbrirExcluirAluguelMenu");
            };

            mnuTodosLivros.Click += (sender, e) =>
            {
                ListaPesquisa listaPesquisa = new(livrosDb.VerTodosLivros());
                listaPesquisa.Show();

                AppInsightMetrics.TrackEvent("AbrirVerTodosLivrosMenu");
            };
            mnuPesquisaSeletiva.Click += (sender, e) =>
            {
                PesquisarLivro pesquisarLivro = new();
                pesquisarLivro.Show();

                AppInsightMetrics.TrackEvent("AbrirPesquisarLivroMenu");
            };
            mnuLivrosAlugados.Click += (sender, e) => 
            {
                ListaPesquisa listaPesquisa = new(aluguelDb.VerTodosAluguel());
                listaPesquisa.Show();

                AppInsightMetrics.TrackEvent("AbrirVerTodosAlugueisMenu");
            };
            mnuPesquisarAluguel.Click += (sender, e) =>
            {
                PesquisarAluguel pesquisarAluguel = new();
                pesquisarAluguel.Show();

                AppInsightMetrics.TrackEvent("AbrirPesquisarAluguelMenu");
            };
            mnuTodosClientes.Click += (sender, e) =>
            {
                ListaPesquisa listaPesquisa = new(clienteDb.VerTodosClientes());
                listaPesquisa.Show();

                AppInsightMetrics.TrackEvent("AbrirVerTodosClientesMenu");
            };
            mnuPesquisarCliente.Click += (sender, e) =>
            {
                PesquisarCliente pesquisarCliente = new();
                pesquisarCliente.Show();

                AppInsightMetrics.TrackEvent("AbrirPesquisarClienteMenu");
            };

            mnuConfig.Click += (sender, e) => 
            {
                Configuracoes configuracoes = new();
                configuracoes.Show();

                AppInsightMetrics.TrackEvent("AbrirConfiguracoesMenu");
            };

            mnuSobre.Click += (sender, e) =>
            {
                MessageBox.Show("Project Book v" +
                                Assembly.GetExecutingAssembly().GetName().Version +
                                "\n" + Resources.TheCreator +
                                "\n" + Resources.Licensa +
                                "\n" + Resources.UrlProjeto +
                                "\n" + Resources.CreditosIcones,
                    Resources.sobre_MessageBox, MessageBoxButtons.OK, MessageBoxIcon.Information);
            };
            mnuProcurarAtualizacoes.Click += (sender, e) => AppManager.ProcurarAtualizacoes();
            #endregion

            #region Acesso rápido
            mnuArCadastroLivro.Click += (sender, e) =>
            {
                CadastroLivro cadastroLivro = new();
                cadastroLivro.Show();

                AppInsightMetrics.TrackEvent("AbrirCadastroLivroAr");
            };
            mnuArCadastroCliente.Click += (sender, e) =>
            {
                CadastrarClientes cadastrarClientes = new();
                cadastrarClientes.Show();

                AppInsightMetrics.TrackEvent("AbrirCadastroClienteAr");
            };
            mnuArCadastroAluguel.Click += (sender, e) =>
            {
                CadastrarAluguel cadastrarAluguel = new();
                cadastrarAluguel.Show();

                AppInsightMetrics.TrackEvent("AbrirCadastroAluguelAr");
            };
            mnuArEditarLivro.Click += (sender, e) =>
            {
                EditarLivro editarLivro = new();
                editarLivro.Show();

                AppInsightMetrics.TrackEvent("AbrirEditarLivroAr");
            };
            mnuArEditarCliente.Click += (sender, e) =>
            {
                EditarCliente editarCliente = new();
                editarCliente.Show();

                AppInsightMetrics.TrackEvent("AbrirEditarClienteAr");
            };
            mnuArEditarAluguel.Click += (sender, e) =>
            {
                EditarAluguel editarAluguel = new();
                editarAluguel.Show();

                AppInsightMetrics.TrackEvent("AbrirEditarAluguelAr");
            };
            mnuArUsuario.Click += (sender, e) =>
            {
                GerenciarUsuario gerenciarUsuario = new();
                gerenciarUsuario.Show();

                AppInsightMetrics.TrackEvent("AbrirGerenciarUsuarioAr");
            };
            mnuArBuscaRapida.Click += (sender, e) =>
            {
                PesquisaRapida pesquisaRapida = new();
                pesquisaRapida.Show();

                AppInsightMetrics.TrackEvent("AbrirPesquisaRapidaAr");
            };
            #endregion
        }

        private void btnAccountError_Click(object sender, EventArgs e) => new GerenciarUsuario().Show();
        private void btnSairUsuario_Click(object sender, EventArgs e)
        {
            Configuracoes.config.AppSettings.Settings["usuarioLogado"].Value = "";
            Configuracoes.config.AppSettings.Settings["idUsuario"].Value = "";
            Configuracoes.config.Save();

            AppInsightMetrics.TrackEvent("SairUsuario");

            Process.Start(Application.StartupPath + Assembly.GetExecutingAssembly().GetName().Name + ".exe");
            Process.GetCurrentProcess().Kill();
        }

        private void Inicio_ActivatedAsync(object sender, EventArgs e)
        {
            if (Opacity != 0)
            {
                lblLivrosCadastrados.Text = livrosDb.VerTodosLivros().Rows.Count.ToString();
                lblClientesCadastrados.Text = clienteDb.VerTodosClientes().Rows.Count.ToString();
                lblAlugueisRegistrados.Text = aluguelDb.VerTodosAluguel().Rows.Count.ToString();

                AppInsightMetrics.SendMetric("LivrosRegistrados", int.Parse(lblLivrosCadastrados.Text));
                AppInsightMetrics.SendMetric("ClientesCadastrados", int.Parse(lblClientesCadastrados.Text));
                AppInsightMetrics.SendMetric("AlugueisRegistrados", int.Parse(lblAlugueisRegistrados.Text));
            }

            GC.Collect();
        }
        private void Inicio_Load(object sender, EventArgs e)
        {
            //Deixar o Form invisível enquanto a SplashScreen está carregando
            Opacity = 0;
            ShowInTaskbar = false;

            SplashScreen splashScreen = new();
            splashScreen.Show();
            splashScreen.FormClosed += delegate
            {
                Opacity = 100;
                ShowInTaskbar = true;
                splashScreen.Dispose();
            };

            AppInsightMetrics.InicializarInsights();
            AppInsightMetrics.TrackForm("Inicio");

            lblNomeUsuario.BackColor = Color.Transparent;
            AppInsightMetrics.SendProcessInfo();
            BringToFront();
        }

        private void Inicio_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F1:
                    PesquisaRapida pesquisaRapida = new();
                    pesquisaRapida.Show();
                    AppInsightMetrics.TrackEvent("AbrirPesquisaRapidaAtalho");
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
            if(!e.Cancel) AppInsightMetrics.FlushTelemetry();
        }
    }
}
