﻿using System;
using System.Windows.Forms;
using ProjectBook.DB.SqlServerExpress;
using ProjectBook.Properties;
using ProjectBook.AppInsight;
using System.ComponentModel;
using ProjectBook.Tipos;
using ProjectBook.Managers;
using ProjectBook.Managers.Configuration;
using ProjectBook.Model;

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
            UserInfo.UserNowInstance.userName = "";
            UserInfo.UserNowInstance.idUsuario = 0;

            AppInsightMetrics.TrackEvent("SairUsuario");

            AppManager.ReiniciarPrograma();
        }

        private async void bgwInicioActivated_DoWork(object sender, DoWorkEventArgs e)
        {
            if (isVisible)
            {
                //TODO - Create a method to get only the count
                lblLivrosCadastrados.Text = (await LivrosDb.VerTodosLivros()).Count.ToString();
                lblClientesCadastrados.Text = (await ClienteDb.VerTodosClientes()).Count.ToString();
                lblAlugueisRegistrados.Text = (await AluguelDb.VerTodosAluguel()).Count.ToString();

                AppInsightMetrics.SendMetric("LivrosRegistrados", int.Parse(lblLivrosCadastrados.Text));
                AppInsightMetrics.SendMetric("ClientesCadastrados", int.Parse(lblClientesCadastrados.Text));
                AppInsightMetrics.SendMetric("AlugueisRegistrados", int.Parse(lblAlugueisRegistrados.Text));
            }

            GC.Collect();
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

                AppInsightMetrics.TrackEvent("AbrirCadastroLivroMenu");
            };

            mnuEditarLivro.Click += (_, _) =>
            {
                EditarLivro editarLivro = new();
                editarLivro.Show();

                AppInsightMetrics.TrackEvent("AbrirEditarLivroMenu");
            };

            mnuCadastrarAluguel.Click += (_, _) =>
            {
                CadastrarAluguel cadastrarAluguel = new();
                cadastrarAluguel.Show();

                AppInsightMetrics.TrackEvent("AbrirCadastrarAluguelMenu");
            };
            mnuEditarAluguel.Click += (_, _) =>
            {
                EditarAluguel editarAluguel = new();
                editarAluguel.Show();

                AppInsightMetrics.TrackEvent("AbrirEditarAluguelMenu");
            };

            mnuCadastrarCliente.Click += (_, _) =>
            {
                CadastrarClientes cadastrarClientes = new();
                cadastrarClientes.Show();

                AppInsightMetrics.TrackEvent("AbrirCadastrarClienteMenu");
            };
            mnuEditarClientes.Click += (_, _) =>
            {
                EditarCliente editarCliente = new();
                editarCliente.Show();

                AppInsightMetrics.TrackEvent("AbrirEditarClienteMenu");
            };

            mnuGerenciarUsuario.Click += (_, _) =>
            {
                GerenciarUsuario gerenciarUsuario = new();
                gerenciarUsuario.Show();

                AppInsightMetrics.TrackEvent("AbrirGerenciarUsuariosMenu");
            };
            mnuPesquisarUsuarios.Click += (_, _) =>
            {
                PesquisarUsuario pesquisarUsuario = new();
                pesquisarUsuario.Show();

                AppInsightMetrics.TrackEvent("AbrirPesquisarUsuarioMenu");
            };

            mnuExcluirLivro.Click += (_, _) =>
            {
                ExcluirLivro excluir = new();
                excluir.Show();

                AppInsightMetrics.TrackEvent("AbrirExcluirLivroMenu");
            };
            mnuExcluirCliente.Click += (_, _) =>
            {
                ExcluirCliente excluirCliente = new();
                excluirCliente.Show();

                AppInsightMetrics.TrackEvent("AbrirExcluirClienteMenu");
            };
            mnuExcluirAluguel.Click += (_, _) =>
            {
                ExcluirAluguel excluirAluguel = new();
                excluirAluguel.Show();

                AppInsightMetrics.TrackEvent("AbrirExcluirAluguelMenu");
            };
            mnuExcluirUsuario.Click += (_, _) =>
            {
                ExcluirUsuario excluirUsuario = new();
                excluirUsuario.Show();

                AppInsightMetrics.TrackEvent("AbrirExcluirUsuarioMenu");
            };

            mnuTodosLivros.Click += async (_, _) =>
            {
                ListaPesquisa<LivroModel> listaPesquisa = new(await LivrosDb.VerTodosLivros());
                listaPesquisa.Show();

                AppInsightMetrics.TrackEvent("AbrirVerTodosLivrosMenu");
            };
            mnuPesquisarLivro.Click += (_, _) =>
            {
                PesquisarLivro pesquisarLivro = new();
                pesquisarLivro.Show();

                AppInsightMetrics.TrackEvent("AbrirPesquisarLivroMenu");
            };
            mnuTodosAlugueis.Click += async (_, _) =>
            {
                ListaPesquisa<AluguelModel> listaPesquisa = new(await AluguelDb.VerTodosAluguel());
                listaPesquisa.Show();

                AppInsightMetrics.TrackEvent("AbrirVerTodosAlugueisMenu");
            };
            mnuPesquisarAluguel.Click += (_, _) =>
            {
                PesquisarAluguel pesquisarAluguel = new();
                pesquisarAluguel.Show();

                AppInsightMetrics.TrackEvent("AbrirPesquisarAluguelMenu");
            };
            mnuTodosClientes.Click += async (_, _) =>
            {
                ListaPesquisa<ClienteModel> listaPesquisa = new(await ClienteDb.VerTodosClientes());
                listaPesquisa.Show();

                AppInsightMetrics.TrackEvent("AbrirVerTodosClientesMenu");
            };
            mnuPesquisarCliente.Click += (_, _) =>
            {
                PesquisarCliente pesquisarCliente = new();
                pesquisarCliente.Show();

                AppInsightMetrics.TrackEvent("AbrirPesquisarClienteMenu");
            };

            mnuConfig.Click += (_, _) =>
            {
                Configuracoes configuracoes = new();
                configuracoes.Show();

                AppInsightMetrics.TrackEvent("AbrirConfiguracoesMenu");
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

                AppInsightMetrics.TrackEvent("AbrirCadastroLivroAr");
            };
            mnuArCadastroCliente.Click += (_, _) =>
            {
                CadastrarClientes cadastrarClientes = new();
                cadastrarClientes.Show();

                AppInsightMetrics.TrackEvent("AbrirCadastroClienteAr");
            };
            mnuArCadastroAluguel.Click += (_, _) =>
            {
                CadastrarAluguel cadastrarAluguel = new();
                cadastrarAluguel.Show();

                AppInsightMetrics.TrackEvent("AbrirCadastroAluguelAr");
            };
            mnuArEditarLivro.Click += (_, _) =>
            {
                EditarLivro editarLivro = new();
                editarLivro.Show();

                AppInsightMetrics.TrackEvent("AbrirEditarLivroAr");
            };
            mnuArEditarCliente.Click += (_, _) =>
            {
                EditarCliente editarCliente = new();
                editarCliente.Show();

                AppInsightMetrics.TrackEvent("AbrirEditarClienteAr");
            };
            mnuArEditarAluguel.Click += (_, _) =>
            {
                EditarAluguel editarAluguel = new();
                editarAluguel.Show();

                AppInsightMetrics.TrackEvent("AbrirEditarAluguelAr");
            };
            mnuArUsuario.Click += (_, _) =>
            {
                GerenciarUsuario gerenciarUsuario = new();
                gerenciarUsuario.Show();

                AppInsightMetrics.TrackEvent("AbrirGerenciarUsuarioAr");
            };
            mnuArBuscaRapida.Click += (_, _) =>
            {
                PesquisaRapida pesquisaRapida = new();
                pesquisaRapida.Show();

                AppInsightMetrics.TrackEvent("AbrirPesquisaRapidaAr");
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

                lblNomeUsuario.Text = UserInfo.UserNowInstance.userName;
                btnAccountError.Visible = Verificadores.IsDefaultUser();
                if(UserInfo.UserNowInstance.tipoUsuario != TipoUsuario.ADM)
                {
                    mnuUsuario.Visible = false;
                    mnuArUsuario.Visible = false;
                    mnuExcluirUsuario.Visible = false;
                    tssUsuario.Visible = false;
                }

                AppInsightMetrics.InicializarInsights();
                AppInsightMetrics.SendProcessInfo();
                AppInsightMetrics.TrackForm("Inicio");
                
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
            DialogResult dialogResult = MessageBox.Show(Resources.ConfirmarSair, Resources.Informacao_MessageBox,
                MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

            e.Cancel = dialogResult != DialogResult.Yes;
            if(!e.Cancel) AppInsightMetrics.FlushTelemetry();
            if(!AppConfigurationManager.configuration.login.keepConnected) UserInfo.DeleteUserFile();
        }
    }
}
