using System;
using System.Data;
using System.Windows.Forms;
using ProjectBook.DB.SqlServerExpress;
using ProjectBook.Livros;
using ProjectBook.Properties;

namespace ProjectBook.GUI
{
    public partial class EditarAluguel : Form
    {
        private AluguelDb aluguelDb = new();
        private LivrosDb livrosDb = new();
        private ClienteDb clienteDb = new();

        private DataTable infoAluguel = new();
        private DataTable infoLivro = new();
        private DataTable infoCliente = new();

        private string primeiroDono;
        private string primeiroLivro;
        public EditarAluguel()
        {
            InitializeComponent();

            btnVerTodosAlugueis.Click += (sender, args) =>
            {
                ListaPesquisa listaPesquisa = new ListaPesquisa(aluguelDb.VerTodosAluguel());
                listaPesquisa.Show();
            };
            btnVerTodosLivros.Click += (sender, args) =>
            {
                ListaPesquisa listaPesquisa = new ListaPesquisa(livrosDb.VerTodosLivros());
                listaPesquisa.Show();
            };
            btnVerTodosClientes.Click += (sender, args) =>
            {
                ListaPesquisa listaPesquisa = new ListaPesquisa(clienteDb.VerTodosClientes());
                listaPesquisa.Show();
            };
        }

        #region CheckedChanged & Sugestões
        private void rabBuscarNomeCliente_CheckedChanged(object sender, EventArgs e)
        {
            AutoCompleteStringCollection aluguelSugestao = new();
            foreach (DataRow aluguel in aluguelDb.VerTodosAluguel().Rows) aluguelSugestao.Add($"{aluguel[2]} - {aluguel[0]}"); // Cliente - Livro
            txtBuscarAluguel.AutoCompleteCustomSource = aluguelSugestao;
        }
        private void rabBuscarTituloLivro_CheckedChanged(object sender, EventArgs e)
        {
            AutoCompleteStringCollection aluguelSugestao = new();
            foreach (DataRow aluguel in aluguelDb.VerTodosAluguel().Rows) aluguelSugestao.Add($"{aluguel[0]} - {aluguel[2]}"); // Livro - Cliente
            txtBuscarAluguel.AutoCompleteCustomSource = aluguelSugestao;
        }

        private void rabBuscarNovoLivroCodigo_CheckedChanged(object sender, EventArgs e) =>
            txtMudarLivroAluguel.AutoCompleteMode = AutoCompleteMode.None;

        private void rabBuscarNovoLivroTitulo_CheckedChanged(object sender, EventArgs e)
        {
            AutoCompleteStringCollection livrosSugestao = new AutoCompleteStringCollection();
            txtMudarLivroAluguel.AutoCompleteMode = AutoCompleteMode.Suggest;

            foreach (DataRow livro in livrosDb.VerTodosLivros().Rows) livrosSugestao.Add(livro[1].ToString()); // Titulo livro
            txtMudarLivroAluguel.AutoCompleteCustomSource = livrosSugestao;
        }
        private void rabBuscarNovoLivroAutor_CheckedChanged(object sender, EventArgs e)
        {
            AutoCompleteStringCollection livrosSugestao = new AutoCompleteStringCollection();
            txtMudarLivroAluguel.AutoCompleteMode = AutoCompleteMode.Suggest;

            foreach (DataRow livro in livrosDb.VerTodosLivros().Rows) livrosSugestao.Add(livro[2].ToString()); // Autor livro
            txtMudarLivroAluguel.AutoCompleteCustomSource = livrosSugestao;
        }

        private void rabBuscarNovoClienteCodigo_CheckedChanged(object sender, EventArgs e) =>
            txtMudarClienteAluguel.AutoCompleteMode = AutoCompleteMode.None;

        private void rabBuscarNovoClienteNome_CheckedChanged(object sender, EventArgs e)
        {
            AutoCompleteStringCollection clienteSugestao = new AutoCompleteStringCollection();
            txtMudarClienteAluguel.AutoCompleteMode = AutoCompleteMode.Suggest;

            foreach (DataRow cliente in clienteDb.VerTodosClientes().Rows) clienteSugestao.Add(cliente[1].ToString()); // Nome cliente
            txtMudarClienteAluguel.AutoCompleteCustomSource = clienteSugestao;
        }
        #endregion

        private void btnBuscarEditarAluguel_Click(object sender, EventArgs e)
        {
            string[] buscarEditarAluguel = txtBuscarAluguel.Text.Trim().Split("-");

            if (Verificadores.VerificarStrings(txtBuscarAluguel.Text))
            {
                MessageBox.Show(Resources.PreecherCampoBusca, Resources.MessageBoxError,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                if (rabBuscarNomeCliente.Checked)
                {
                    infoAluguel = aluguelDb.BuscarAluguelCliente(buscarEditarAluguel[0].Trim());
                    infoLivro = livrosDb.BuscarLivrosTitulo(buscarEditarAluguel[1].Trim());
                    infoCliente = clienteDb.BuscarClienteNome(buscarEditarAluguel[0].Trim());
                }
                else if (rabBuscarTituloLivro.Checked)
                {
                    infoAluguel = aluguelDb.BuscarAluguelLivro(buscarEditarAluguel[0].Trim());
                    infoLivro = livrosDb.BuscarLivrosTitulo(buscarEditarAluguel[0].Trim());
                    infoCliente = clienteDb.BuscarClienteNome(buscarEditarAluguel[1].Trim());
                }
            }
            catch
            {
                MessageBox.Show(Resources.clienteLivroNaoAlugados, Resources.MessageBoxError,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            primeiroLivro = infoAluguel.Rows[0][0].ToString();
            primeiroDono = infoAluguel.Rows[0][2].ToString();
            PreencherCamposAluguel();
            PreencharCamposLivro();
            PreencherCamposCliente();
        }
        private void btnBuscarNovoLivro_Click(object sender, EventArgs e)
        {
            string buscarLivro = txtMudarLivroAluguel.Text;

            if (Verificadores.VerificarStrings(buscarLivro))
            {
                MessageBox.Show(Resources.PreecherCampoBusca, Resources.MessageBoxError,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (rabBuscarNovoLivroCodigo.Checked) infoLivro = livrosDb.BuscarLivrosId(buscarLivro);
            else if (rabBuscarNovoLivroTitulo.Checked) infoLivro = livrosDb.BuscarLivrosTitulo(buscarLivro);
            else infoLivro = livrosDb.BuscarLivrosAutor(buscarLivro);

            PreencharCamposLivro();
        }

        private void btnBuscarNovoCliente_Click(object sender, EventArgs e)
        {
            string buscarCliete = txtMudarClienteAluguel.Text;

            if (Verificadores.VerificarStrings(buscarCliete))
            {
                MessageBox.Show(Resources.PreecherCampoBusca, Resources.MessageBoxError,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            infoCliente = rabBuscarNovoClienteCodigo.Checked ? 
                clienteDb.BuscarClienteId(buscarCliete) : clienteDb.BuscarClienteNome(buscarCliete);
            
            PreencherCamposCliente();
        }

        private void btnSalvarEditarAluguel_Click(object sender, EventArgs e)
        {
            Aluguel aluguel = new(txtNovoTituloLivroAluguel.Text, txtNovoAutorAluguel.Text, txtNovoClienteAluguel.Text,
                dtpEditarDataEntrega.Value, dtpEditarDataRecebimento.Value, cmbNovoStatus.Text);

            if (Verificadores.VerificarCamposAluguel(aluguel))
            {
                MessageBox.Show(Resources.PreecherCampoBusca, Resources.MessageBoxError,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            aluguelDb.AtualizarAluguelNomeCliente(aluguel, primeiroDono, primeiroLivro);

            LimparCampos();
        }

        private void PreencherCamposAluguel()
        {
            txtTituloLivroAluguel.Text = infoAluguel.Rows[0][0].ToString();
            txtAlugadoPorAluguel.Text = infoAluguel.Rows[0][2].ToString();
            dtpEditarDataEntrega.Value = Convert.ToDateTime(infoAluguel.Rows[0][3]);
            dtpEditarDataRecebimento.Value = Convert.ToDateTime(infoAluguel.Rows[0][4]);
            cmbNovoStatus.Text = infoAluguel.Rows[0][5].ToString();
        }
        private void PreencharCamposLivro()
        {
            txtNovoTituloLivroAluguel.Text = infoLivro.Rows[0][1].ToString();
            txtNovoAutorAluguel.Text = infoLivro.Rows[0][2].ToString();
            txtNovoEditoraLivro.Text = infoLivro.Rows[0][3].ToString();
            txtNovoEdicaoLivro.Text = infoLivro.Rows[0][4].ToString();
        }
        private void PreencherCamposCliente()
        {
            txtNovoClienteAluguel.Text = infoCliente.Rows[0][1].ToString();
            txtNovoEnderecoAluguel.Text = infoCliente.Rows[0][2].ToString();
            txtNovoTelefoneAluguel.Text = infoCliente.Rows[0][6].ToString();
            txtNovoEmailAluguel.Text = infoCliente.Rows[0][8].ToString();
        }

        private void btnLimparTxtAluguel_Click(object sender, EventArgs e) => LimparCampos();
        private void btnCancelarEditarAluguel_Click(object sender, EventArgs e) => Close();
        private void LimparCampos()
        {
            infoAluguel.Clear();
            infoLivro.Clear();
            infoCliente.Clear();

            primeiroDono = string.Empty;
            primeiroLivro = string.Empty;

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
