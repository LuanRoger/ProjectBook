using System;
using System.Linq;
using System.Windows.Forms;
using ProjectBook.AppInsight;
using ProjectBook.DB.SqlServerExpress;
using ProjectBook.Model;
using ProjectBook.Properties;
using ProjectBook.Tipos;

namespace ProjectBook.GUI
{
    public partial class EditarAluguel : Form
    {
        private AluguelModel infoAluguelAntigo;
        private LivroModel infoLivro = new();
        private ClienteModel infoCliente = new();

        public EditarAluguel()
        {
            InitializeComponent();

            btnVerTodosAlugueis.Click += async delegate
            {
                ListaPesquisa<AluguelModel> listaPesquisa = new(await AluguelDb.VerTodosAluguel());
                listaPesquisa.Show();
            };
            btnVerTodosLivros.Click += async delegate
            {
                ListaPesquisa<LivroModel> listaPesquisa = new(await LivrosDb.VerTodosLivros());
                listaPesquisa.Show();
            };
            btnVerTodosClientes.Click += async delegate
            {
                ListaPesquisa<ClienteModel> listaPesquisa = new(await ClienteDb.VerTodosClientes());
                listaPesquisa.Show();
            };
            Load += (_, _) => AppInsightMetrics.TrackForm("EditarAluguel");
        }

        #region CheckedChanged & Sugestões
        private async void rabBuscarNomeCliente_CheckedChanged(object sender, EventArgs e)
        {
            AutoCompleteStringCollection aluguelSugestao = new();
            
            foreach (AluguelModel aluguel in await AluguelDb.VerTodosAluguel()) 
                aluguelSugestao.Add($"{aluguel.alugadoPor} - {aluguel.titulo}");
            
            txtBuscarAluguel.AutoCompleteCustomSource = aluguelSugestao;
        }
        private async void rabBuscarTituloLivro_CheckedChanged(object sender, EventArgs e)
        {
            AutoCompleteStringCollection aluguelSugestao = new();
            foreach (AluguelModel aluguel in await AluguelDb.VerTodosAluguel()) 
                aluguelSugestao.Add($"{aluguel.titulo} - {aluguel.alugadoPor}");
            
            txtBuscarAluguel.AutoCompleteCustomSource = aluguelSugestao;
        }

        private void rabBuscarNovoLivroCodigo_CheckedChanged(object sender, EventArgs e) =>
            txtMudarLivroAluguel.AutoCompleteMode = AutoCompleteMode.None;

        private async void rabBuscarNovoLivroTitulo_CheckedChanged(object sender, EventArgs e)
        {
            AutoCompleteStringCollection livrosSugestao = new();
            txtMudarLivroAluguel.AutoCompleteMode = AutoCompleteMode.Suggest;

            foreach (LivroModel livro in await LivrosDb.VerTodosLivros()) 
                livrosSugestao.Add(livro.titulo);
            
            txtMudarLivroAluguel.AutoCompleteCustomSource = livrosSugestao;
        }
        private async void rabBuscarNovoLivroAutor_CheckedChanged(object sender, EventArgs e)
        {
            AutoCompleteStringCollection livrosSugestao = new();
            txtMudarLivroAluguel.AutoCompleteMode = AutoCompleteMode.Suggest;

            foreach (LivroModel livro in await LivrosDb.VerTodosLivros()) 
                livrosSugestao.Add(livro.autor);
            
            txtMudarLivroAluguel.AutoCompleteCustomSource = livrosSugestao;
        }

        private void rabBuscarNovoClienteCodigo_CheckedChanged(object sender, EventArgs e) =>
            txtMudarClienteAluguel.AutoCompleteMode = AutoCompleteMode.None;

        private async void rabBuscarNovoClienteNome_CheckedChanged(object sender, EventArgs e)
        {
            AutoCompleteStringCollection clienteSugestao = new();
            txtMudarClienteAluguel.AutoCompleteMode = AutoCompleteMode.Suggest;

            foreach (ClienteModel cliente in await ClienteDb.VerTodosClientes()) 
                clienteSugestao.Add(cliente.nomeCompleto);
            
            txtMudarClienteAluguel.AutoCompleteCustomSource = clienteSugestao;
        }
        #endregion

        private async void btnBuscarEditarAluguel_Click(object sender, EventArgs e)
        {
            string[] buscarEditarAluguel = txtBuscarAluguel.Text.Split('-', 2, StringSplitOptions.TrimEntries);
            AluguelModel infoAluguel = new();

            if (Verificadores.VerificarStrings(txtBuscarAluguel.Text))
            {
                MessageBox.Show(Resources.PesquiseParaContinuar, Resources.Error_MessageBox,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (buscarEditarAluguel.Length == 1)
            {
                if (rabBuscarNomeCliente.Checked)
                    infoAluguel = (await AluguelDb.BuscarAluguelCliente(buscarEditarAluguel[0])).First();
                else if (rabBuscarTituloLivro.Checked)
                    infoAluguel = (await AluguelDb.BuscarAluguelLivro(buscarEditarAluguel[0])).First();
                
                infoLivro = (await LivrosDb.BuscarLivrosTitulo(infoAluguel.titulo)).First();
                infoCliente = (await ClienteDb.BuscarClienteNome(infoAluguel.alugadoPor)).First();
            }
            else
            {
                string titulo = rabBuscarTituloLivro.Checked ? buscarEditarAluguel[0] : buscarEditarAluguel[1];
                string nomeCliente = rabBuscarNomeCliente.Checked ? buscarEditarAluguel[0] : buscarEditarAluguel[2];

                infoAluguel = (await AluguelDb.BuscarAluguelLivroCliente(titulo, nomeCliente)).First();
                infoLivro = (await LivrosDb.BuscarLivrosTitulo(titulo)).First();
                infoCliente = (await ClienteDb.BuscarClienteNome(nomeCliente)).First();
            }

            if(Verificadores.VerificarCamposAluguel(infoAluguel))
            {
                MessageBox.Show(Resources.ClienteLivroNaoAlugados, Resources.Error_MessageBox,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            infoAluguelAntigo = infoAluguel;
            PreencherCamposAluguel(infoAluguel);
            PreencharCamposLivro(infoLivro);
            PreencherCamposCliente(infoCliente);
        }

        private async void btnBuscarNovoLivro_Click(object sender, EventArgs e)
        {
            string buscarLivro = txtMudarLivroAluguel.Text;

            if (Verificadores.VerificarStrings(buscarLivro) || infoAluguelAntigo == null)
            {
                MessageBox.Show(Resources.PesquiseParaContinuar, Resources.Error_MessageBox,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (rabBuscarNovoLivroCodigo.Checked) 
                infoLivro = await LivrosDb.BuscarLivrosId(int.Parse(buscarLivro));
            else if (rabBuscarNovoLivroTitulo.Checked) 
                infoLivro = (await LivrosDb.BuscarLivrosTitulo(buscarLivro)).First();
            else infoLivro = (await LivrosDb.BuscarLivrosAutor(buscarLivro)).First();

            if(Verificadores.VerificarCamposLivros(infoLivro))
            {
                MessageBox.Show(Resources.ClienteLivroNaoAlugados, Resources.Error_MessageBox,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            PreencharCamposLivro(infoLivro);
        }
        private async void btnBuscarNovoCliente_Click(object sender, EventArgs e)
        {
            string buscarCliete = txtMudarClienteAluguel.Text;

            if (Verificadores.VerificarStrings(buscarCliete) || infoAluguelAntigo == null)
            {
                MessageBox.Show(Resources.PesquiseParaContinuar, Resources.Error_MessageBox,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            infoCliente = rabBuscarNovoClienteCodigo.Checked ?
                await ClienteDb.BuscarClienteId(int.Parse(buscarCliete)) : 
                (await ClienteDb.BuscarClienteNome(buscarCliete)).First();

            if(Verificadores.VerificarCamposCliente(infoCliente))
            {
                MessageBox.Show(Resources.ClienteLivroNaoAlugados, Resources.Error_MessageBox,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            PreencherCamposCliente(infoCliente);
        }

        private void btnSalvarEditarAluguel_Click(object sender, EventArgs e)
        {
            AluguelModel aluguel = new()
            {
                titulo = txtNovoTituloLivroAluguel.Text,
                autor = txtNovoAutorAluguel.Text,
                alugadoPor = txtNovoClienteAluguel.Text,
                dataEntrega = dtpEditarDataEntrega.Value,
                dataDevolucao = dtpEditarDataRecebimento.Value,
                status = (StatusAluguel)cmbNovoStatus.SelectedIndex
            };

            if (Verificadores.VerificarCamposAluguel(aluguel) || infoAluguelAntigo == null)
            {
                MessageBox.Show(Resources.PesquiseParaContinuar, Resources.Error_MessageBox,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            AluguelDb.AtualizarAluguelNomeCliente(aluguel, infoAluguelAntigo.titulo,
                    infoAluguelAntigo.alugadoPor);
            
            MessageBox.Show(Resources.InformacoesAtualizadas_MessageBox, Resources.Concluido_MessageBox, MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            LimparCampos();
        }

        private void PreencherCamposAluguel(AluguelModel infoAluguel)
        {
            txtTituloLivroAluguel.Text = infoAluguel.titulo;
            txtAlugadoPorAluguel.Text = infoAluguel.alugadoPor;
            dtpEditarDataEntrega.Value = infoAluguel.dataEntrega;
            dtpEditarDataRecebimento.Value = infoAluguel.dataDevolucao;
            cmbNovoStatus.Text = infoAluguel.status.ToString();
        }
        private void PreencharCamposLivro(LivroModel infoLivro)
        {
            txtNovoTituloLivroAluguel.Text = infoLivro.titulo;
            txtNovoAutorAluguel.Text = infoLivro.autor;
            txtNovoEditoraLivro.Text = infoLivro.editora;
            txtNovoEdicaoLivro.Text = infoLivro.edicao;
        }
        private void PreencherCamposCliente(ClienteModel infoCliente)
        {
            txtNovoClienteAluguel.Text = infoCliente.nomeCompleto;
            txtNovoEnderecoAluguel.Text = infoCliente.endereco;
            txtNovoTelefoneAluguel.Text = infoCliente.telefone1;
            txtNovoEmailAluguel.Text = infoCliente.email;
        }

        private void btnLimparTxtAluguel_Click(object sender, EventArgs e) => LimparCampos();
        private void btnCancelarEditarAluguel_Click(object sender, EventArgs e) => Close();
        private void LimparCampos()
        {
            infoAluguelAntigo = null;

            txtTituloLivroAluguel.Clear();
            txtAlugadoPorAluguel.Clear();
            txtBuscarAluguel.Clear();
            txtMudarLivroAluguel.Clear();
            txtNovoTituloLivroAluguel.Clear();
            txtNovoAutorAluguel.Clear();
            txtNovoEditoraLivro.Clear();
            txtNovoEdicaoLivro.Clear();
            txtMudarClienteAluguel.Clear();
            txtNovoClienteAluguel.Clear();
            txtNovoEnderecoAluguel.Clear();
            txtNovoTelefoneAluguel.Clear();
            txtNovoEmailAluguel.Clear();
            cmbNovoStatus.Text = string.Empty;
        }
    }
}
