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
        private AluguelDb aluguelDb = new AluguelDb();
        private LivrosDb livrosDb = new LivrosDb();
        private ClienteDb clienteDb = new ClienteDb();

        private DataTable infoAluguel;
        private DataTable infoLivro;
        private DataTable infoCliente;

        private string primeiroDono;
        private string primeiroLivro;
        public EditarAluguel()
        {
            InitializeComponent();
            PrepararSugestaoLivroCliente();
        }

        #region CheckedChanged & Sugestões
        private void PrepararSugestaoLivroCliente()
        {
            AutoCompleteStringCollection aluguelSugestao;

            //Livro
            aluguelSugestao = new AutoCompleteStringCollection();
            foreach (DataRow livro in livrosDb.VerTodosLivros().Rows) aluguelSugestao.Add(livro[1].ToString());
            txtMudarLivroAluguel.AutoCompleteCustomSource = aluguelSugestao;

            //Cliente
            aluguelSugestao = new AutoCompleteStringCollection();
            foreach (DataRow cliente in clienteDb.VerTodosClientes().Rows) aluguelSugestao.Add(cliente[1].ToString());
            txtMudarClienteAluguel.AutoCompleteCustomSource = aluguelSugestao;
        }
        private void rabBuscarNomeCliente_CheckedChanged(object sender, EventArgs e)
        {
            AutoCompleteStringCollection aluguelSugestao = new AutoCompleteStringCollection();
            foreach (DataRow cliente in aluguelDb.VerTodosAluguel().Rows) aluguelSugestao.Add($"{cliente[2]} - {cliente[0]}"); // Cliente - Livro
            txtBuscarAluguel.AutoCompleteCustomSource = aluguelSugestao;
        }
        private void rabBuscarTituloLivro_CheckedChanged(object sender, EventArgs e)
        {
            AutoCompleteStringCollection aluguelSugestao = new AutoCompleteStringCollection();
            foreach (DataRow livro in aluguelDb.VerTodosAluguel().Rows) aluguelSugestao.Add($"{livro[0]} - {livro[2]}"); // Livro - Cliente
            txtBuscarAluguel.AutoCompleteCustomSource = aluguelSugestao;
        }
        #endregion

        private void btnBuscarEditarAluguel_Click(object sender, EventArgs e)
        {
            string[] buscarEditarAluguel = txtBuscarAluguel.Text.Trim().Split("-");

            if(!rabBuscarNomeCliente.Checked && !rabBuscarTituloLivro.Checked)
            {
                MessageBox.Show(Resources.marcar_opcao_busca, Resources.error_MessageBox,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Verificadores.VerificarStrings(txtBuscarAluguel.Text))
            {
                MessageBox.Show(Resources.preencherCampoBusca_MessageBox, Resources.error_MessageBox,
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
                MessageBox.Show(Resources.clienteLivroNaoAlugados, Resources.error_MessageBox,
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
                MessageBox.Show(Resources.preencherCampoBusca_MessageBox, Resources.error_MessageBox,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            infoLivro = livrosDb.BuscarLivrosTitulo(buscarLivro);

            PreencharCamposLivro();
        }

        private void btnBuscarNovoCliente_Click(object sender, EventArgs e)
        {
            string buscarCliete = txtMudarClienteAluguel.Text;

            if (Verificadores.VerificarStrings(buscarCliete))
            {
                MessageBox.Show(Resources.preencherCampoBusca_MessageBox, Resources.error_MessageBox,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            infoCliente = clienteDb.BuscarClienteNome(buscarCliete);
            
            PreencherCamposCliente();
        }

        private void btnSalvarEditarAluguel_Click(object sender, EventArgs e)
        {
            Aluguel aluguel = new Aluguel(txtNovoTituloLivroAluguel.Text, txtNovoAutorAluguel.Text, txtNovoClienteAluguel.Text,
                dtpEditarDataEntrega.Value, dtpEditarDataRecebimento.Value, cmbNovoStatus.Text);

            if (Verificadores.VerificarCamposAluguel(aluguel))
            {
                MessageBox.Show(Resources.preencherCampoBusca_MessageBox, Resources.error_MessageBox,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            aluguelDb.AtualizarAluguelNomeCliente(aluguel, primeiroDono, primeiroLivro);

            LimparCampos();
        }

        private void PreencherCamposAluguel()
        {
            txtNovoTituloLivroAluguel.Text = infoAluguel.Rows[0][0].ToString();
            txtNovoAutorAluguel.Text = infoAluguel.Rows[0][1].ToString();
            dtpEditarDataEntrega.Value = Convert.ToDateTime(infoAluguel.Rows[0][3]);
            dtpEditarDataRecebimento.Value = Convert.ToDateTime(infoAluguel.Rows[0][4]);
            cmbNovoStatus.Text = infoAluguel.Rows[0][5].ToString();
        }
        private void PreencharCamposLivro()
        {
            txtNovoTituloLivroAluguel.Text = infoLivro.Rows[0][1].ToString();
            txtNovoAutorAluguel.Text = infoLivro.Rows[0][2].ToString();
        }
        private void PreencherCamposCliente()
        {
            txtNovoClienteAluguel.Text = infoCliente.Rows[0][1].ToString();
            txtNovoEnderecoAluguel.Text = infoCliente.Rows[0][2].ToString();
            txtNovoTelefoneAluguel.Text = infoCliente.Rows[0][6].ToString();
            txtNovoEmailAluguel.Text = infoCliente.Rows[0][8].ToString();
        }

        private void btnLimparTxtAluguel_Click(object sender, EventArgs e) => LimparCampos();
        private void btnCancelarEditarAluguel_Click(object sender, EventArgs e) => this.Close();
        private void LimparCampos()
        {
            infoAluguel.Clear();
            infoLivro.Clear();
            infoCliente.Clear();

            txtBuscarAluguel.Clear();
            txtMudarLivroAluguel.Clear();
            txtNovoTituloLivroAluguel.Clear();
            txtNovoAutorAluguel.Clear();
            txtMudarClienteAluguel.Clear();
            txtNovoClienteAluguel.Clear();
            txtNovoEnderecoAluguel.Clear();
            txtNovoTelefoneAluguel.Clear();
            txtNovoEmailAluguel.Clear();
            cmbNovoStatus.Text = "";
        }
    }
}
