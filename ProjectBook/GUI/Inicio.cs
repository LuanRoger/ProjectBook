using System.Windows.Forms;
using ProjectBook.Properties;
using System.ComponentModel;
using ProjectBook.Controllers;
using ProjectBook.DB;
using ProjectBook.DB.Models;
using ProjectBook.Managers;
using ProjectBook.Model;
using ProjectBook.Model.Enums;
using ProjectBook.Services;

namespace ProjectBook.GUI
{
    public partial class Inicio : Form
    {
        private bool isVisible => Opacity != 0;
        
        public Inicio()
        {
            InitializeComponent();
        }

        private void btnAccountError_Click(object sender, EventArgs e) => new GerenciarUsuario().Show();
        private void btnSairUsuario_Click(object sender, EventArgs e)
        {
            UsuarioModel currentSessionUser = Globals.userSessionController.userCurrentSession;
            currentSessionUser.usuario = "";
            currentSessionUser.id = 0;

            AppController.RestartApplication();
        }

        private async void bgwInicioActivated_DoWork(object sender, DoWorkEventArgs e)
        {
            if (!isVisible) return;
            
            IContextTransaction transaction = Globals.databaseController.GetTransactionContext();
            ICrudContext<LivroModel> livrosContext = (LivrosContext)transaction.StartTransaction<LivroModel>();
            ICrudContext<ClienteModel> clienteContext = (ClienteContext)transaction.StartTransaction<ClienteModel>();
            ICrudContext<AluguelModel> aluguelContext = (AluguelContext)transaction.StartTransaction<AluguelModel>();
            
            lblLivrosCadastrados.Text = (await livrosContext.ReadAllAsync()).Count.ToString();
            lblClientesCadastrados.Text = (await clienteContext.ReadAllAsync()).Count.ToString();
            lblAlugueisRegistrados.Text = (await aluguelContext.ReadAllAsync()).Count.ToString();
        }
        private void Inicio_ActivatedAsync(object sender, EventArgs e)
        {
            if(!bgwInicioActivated.IsBusy) bgwInicioActivated.RunWorkerAsync();
        }
        private void Inicio_Load(object sender, EventArgs e)
        {
            #region MenuClick
            mnuNovoLivro.Click += (_, _) =>
            {
                CadastroLivro cadastroLivro = new();
                cadastroLivro.Show();
            };

            mnuEditarLivro.Click += (_, _) =>
            {
                EditarLivro editarLivro = new();
                editarLivro.Show();
            };

            mnuCadastrarAluguel.Click += (_, _) =>
            {
                CadastrarAluguel cadastrarAluguel = new();
                cadastrarAluguel.Show();
            };
            mnuEditarAluguel.Click += (_, _) =>
            {
                EditarAluguel editarAluguel = new();
                editarAluguel.Show();
            };

            mnuCadastrarCliente.Click += (_, _) =>
            {
                CadastrarClientes cadastrarClientes = new();
                cadastrarClientes.Show();
            };
            mnuEditarClientes.Click += (_, _) =>
            {
                EditarCliente editarCliente = new();
                editarCliente.Show();
            };

            mnuGerenciarUsuario.Click += (_, _) =>
            {
                GerenciarUsuario gerenciarUsuario = new();
                gerenciarUsuario.Show();
            };
            mnuPesquisarUsuarios.Click += (_, _) =>
            {
                PesquisarUsuario pesquisarUsuario = new();
                pesquisarUsuario.Show();
            };

            mnuExcluirLivro.Click += (_, _) =>
            {
                ExcluirLivro excluir = new();
                excluir.Show();
            };
            mnuExcluirCliente.Click += (_, _) =>
            {
                ExcluirCliente excluirCliente = new();
                excluirCliente.Show();
            };
            mnuExcluirAluguel.Click += (_, _) =>
            {
                ExcluirAluguel excluirAluguel = new();
                excluirAluguel.Show();
            };
            mnuExcluirUsuario.Click += (_, _) =>
            {
                ExcluirUsuario excluirUsuario = new();
                excluirUsuario.Show();
            };

            mnuTodosLivros.Click += async (_, _) =>
            {
                IContextTransaction transaction = Globals.databaseController.GetTransactionContext();
                ICrudContext<LivroModel> livrosContext = (LivrosContext)transaction.StartTransaction<LivroModel>();
                ListaPesquisa<LivroModel> listaPesquisa = new(await livrosContext.ReadAllAsync());
                listaPesquisa.Show();
            };
            mnuPesquisarLivro.Click += (_, _) =>
            {
                PesquisarLivro pesquisarLivro = new();
                pesquisarLivro.Show();
            };
            mnuTodosAlugueis.Click += async (_, _) =>
            {
                IContextTransaction transaction = Globals.databaseController.GetTransactionContext();
                ICrudContext<AluguelModel> aluguelContext = (AluguelContext)transaction.StartTransaction<AluguelModel>();
                ListaPesquisa<AluguelModel> listaPesquisa = new(await aluguelContext.ReadAllAsync());
                listaPesquisa.Show();
            };
            mnuPesquisarAluguel.Click += (_, _) =>
            {
                PesquisarAluguel pesquisarAluguel = new();
                pesquisarAluguel.Show();
            };
            mnuTodosClientes.Click += async (_, _) =>
            {
                IContextTransaction transaction = Globals.databaseController.GetTransactionContext();
                ICrudContext<ClienteModel> clienteContext = (ClienteContext)transaction.StartTransaction<ClienteModel>();
                ListaPesquisa<ClienteModel> listaPesquisa = new(await clienteContext.ReadAllAsync());
                listaPesquisa.Show();
            };
            mnuPesquisarCliente.Click += (_, _) =>
            {
                PesquisarCliente pesquisarCliente = new();
                pesquisarCliente.Show();
            };

            mnuConfig.Click += (_, _) =>
            {
                Configuracoes configuracoes = new();
                configuracoes.Show();
            };

            mnuSobre.Click += (_, _) =>
            {
                Sobre sobre = new();
                sobre.Show();
            };
            mnuProcurarAtualizacoes.Click += (_, _) => AppUpdateManager.StartUpdate();
                #endregion

            #region Acesso rápido
            mnuArCadastroLivro.Click += (_, _) =>
            {
                CadastroLivro cadastroLivro = new();
                cadastroLivro.Show();
            };
            mnuArCadastroCliente.Click += (_, _) =>
            {
                CadastrarClientes cadastrarClientes = new();
                cadastrarClientes.Show();
            };
            mnuArCadastroAluguel.Click += (_, _) =>
            {
                CadastrarAluguel cadastrarAluguel = new();
                cadastrarAluguel.Show();
            };
            mnuArEditarLivro.Click += (_, _) =>
            {
                EditarLivro editarLivro = new();
                editarLivro.Show();
            };
            mnuArEditarCliente.Click += (_, _) =>
            {
                EditarCliente editarCliente = new();
                editarCliente.Show();
            };
            mnuArEditarAluguel.Click += (_, _) =>
            {
                EditarAluguel editarAluguel = new();
                editarAluguel.Show();
            };
            mnuArUsuario.Click += (_, _) =>
            {
                GerenciarUsuario gerenciarUsuario = new();
                gerenciarUsuario.Show();
            };
            mnuArBuscaRapida.Click += (_, _) =>
            {
                PesquisaRapida pesquisaRapida = new();
                pesquisaRapida.Show();
            };
            #endregion
            
            Opacity = 0; 
            ShowInTaskbar = false;

            SplashScreen splashScreen = new();
            splashScreen.Show();
            splashScreen.FormClosed += delegate
            {
                Opacity = 1;
                ShowInTaskbar = true;
                
                UsuarioModel currentSessionUser = Globals.userSessionController.userCurrentSession;
                lblNomeUsuario.Text = currentSessionUser.usuario;
                btnAccountError.Visible = Verificadores.IsDefaultUser();
                if(currentSessionUser.tipo != TipoUsuario.ADM)
                {
                    mnuUsuario.Visible = false;
                    mnuArUsuario.Visible = false;
                    mnuExcluirUsuario.Visible = false;
                    tssUsuario.Visible = false;
                }

                BringToFront();
            };
        }

        private void Inicio_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F1:
                    PesquisaRapida pesquisaRapida = new();
                    pesquisaRapida.FormClosed += (_, _) => pesquisaRapida.Dispose();
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
            DialogResult dialogResult = MessageBox.Show(Resources.ConfirmarSair, Resources.Informacao_MessageBox,
                MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

            e.Cancel = dialogResult != DialogResult.Yes;
            if(!Globals.configurationController.configuration.login.keepConnected) IOAppService.DeleteUserInfoFile();
        }
    }
}
