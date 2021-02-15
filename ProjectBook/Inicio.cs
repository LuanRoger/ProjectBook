﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.Threading;
using ProjectBook.DB.SqlServerExpress;
using ProjectBook.Properties;

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
            mnuArBuscaRapida.Click += (sender, e) =>
            {
                PesquisaRapida pesquisaRapida = new PesquisaRapida();
                pesquisaRapida.Show();
            };
        }
        #endregion

        private async void Inicio_Activated(object sender, EventArgs e)
        {
            //Carregar informações
            livrosDb.AbrirConexaoDb();
            if (livrosDb.DbStatus() != "Open") return;

            List<Task<int>> quantidade = new List<Task<int>>
            {
                Task.Run(() => livrosDb.VerTodosLivros().Rows.Count),
                Task.Run(() => clienteDb.VerTodosClientes().Rows.Count),
                Task.Run(() => aluguelDb.VerTodosAluguel().Rows.Count)
            };

            int[] resultado = await Task.WhenAll(quantidade);

            lblLivrosCadastrados.Text = resultado[0].ToString();
            lblClientesCadastrados.Text = resultado[1].ToString();
            lblAlugueisRegistrados.Text = resultado[2].ToString();

            livrosDb.FechaConecxaoDb();
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
    }
}
