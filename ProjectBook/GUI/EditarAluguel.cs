using System;
using System.Data;
using System.Windows.Forms;
using ProjectBook.DB.SqlServerExpress;
using ProjectBook.Livros;

namespace ProjectBook.GUI
{
    public partial class EditarAluguel : Form
    {
        private AluguelDb aluguelDb = new AluguelDb();
        private ClienteDb clienteDb = new ClienteDb();
        private LivrosDb livrosDb = new LivrosDb();

        private DataTable infoAluguel;
        private DataTable infoCliente;
        public EditarAluguel()
        {
            InitializeComponent();
            
            //Preparar sugestões
            AutoCompleteStringCollection aluguelSugestao = new AutoCompleteStringCollection();
            
            //Livro
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
            foreach (DataRow cliente in aluguelDb.VerTodosAluguel().Rows) aluguelSugestao.Add($"{cliente[2]} - {cliente[0]}");
            txtBuscarAluguel.AutoCompleteCustomSource = aluguelSugestao;
        }
        private void rabBuscarTituloLivro_CheckedChanged(object sender, EventArgs e)
        {
            AutoCompleteStringCollection aluguelSugestao = new AutoCompleteStringCollection();
            foreach (DataRow livro in aluguelDb.VerTodosAluguel().Rows) aluguelSugestao.Add($"{livro[0]} - {livro[2]}");
            txtBuscarAluguel.AutoCompleteCustomSource = aluguelSugestao;
        }

        private void btnBuscarEditarAluguel_Click(object sender, EventArgs e)
        {
            string[] buscarEditarAluguel = txtBuscarAluguel.Text.Split("-");
            if (Verificadores.VerificarStrings(txtBuscarAluguel.Text))
            {
                MessageBox.Show(Properties.Resources.preencherCampoBusca_MessageBox, Properties.Resources.error_MessageBox,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                if (rabBuscarNomeCliente.Checked)
                {
                    infoAluguel = aluguelDb.BuscarAluguelCliente(buscarEditarAluguel[0].Trim());
                    infoCliente = clienteDb.BuscarClienteNome(infoAluguel.Rows[0][2].ToString());
                }
                else if (rabBuscarTituloLivro.Checked)
                {
                    infoAluguel = aluguelDb.BuscarAluguelLivro(buscarEditarAluguel[0].Trim());
                    infoCliente = clienteDb.BuscarClienteNome(infoAluguel.Rows[0][2].ToString());
                }
            }
            catch
            {
                MessageBox.Show(Properties.Resources.clienteLivroNaoAlugados, Properties.Resources.error_MessageBox,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            PreencherCamposCliente(infoCliente);
            PreencherCamposAluguel(infoAluguel);
        }
        private void btnBuscarNovoLivro_Click(object sender, EventArgs e)
        {
            string buscarLivro = txtMudarLivroAluguel.Text;

            if (Verificadores.VerificarStrings(buscarLivro))
            {
                MessageBox.Show(Properties.Resources.preencherCampoBusca_MessageBox, Properties.Resources.error_MessageBox,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DataTable resultadoBusca = livrosDb.BuscarLivrosTitulo(buscarLivro);

            //Preencher campo dos livros
            txtNovoTituloLivroAluguel.Text = resultadoBusca.Rows[0][1].ToString();
            txtNovoAutorAluguel.Text = resultadoBusca.Rows[0][2].ToString();
        }

        private void btnBuscarNovoCliente_Click(object sender, EventArgs e)
        {
            string buscarCliete = txtMudarClienteAluguel.Text;

            if (Verificadores.VerificarStrings(buscarCliete))
            {
                MessageBox.Show(Properties.Resources.preencherCampoBusca_MessageBox, Properties.Resources.error_MessageBox,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DataTable resultadoBusca = clienteDb.BuscarClienteNome(buscarCliete);
            
            PreencherCamposCliente(resultadoBusca);
        }

        private void btnSalvarEditarAluguel_Click(object sender, EventArgs e)
        {
            Aluguel aluguel = new Aluguel(txtNovoTituloLivroAluguel.Text, txtNovoAutorAluguel.Text, txtNovoClienteAluguel.Text,
                dtpEditarDataEntrega.Value, dtpEditarDataRecebimento.Value, cmbNovoStatus.Text);

            if (Verificadores.VerificarCamposAluguel(aluguel))
            {
                MessageBox.Show(Properties.Resources.preencherCampoBusca_MessageBox, Properties.Resources.error_MessageBox,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            aluguelDb.AtualizarAluguelNomeCliente(aluguel, infoCliente.Rows[0][1].ToString());

            LimparCampos();
        }

        private void btnLimparTxtAluguel_Click(object sender, EventArgs e) => LimparCampos();
        private void btnCancelarEditarAluguel_Click(object sender, EventArgs e) => this.Close();

        private void PreencherCamposCliente(DataTable infoCliente)
        {
            txtNovoClienteAluguel.Text = infoCliente.Rows[0][1].ToString();
            txtNovoEnderecoAluguel.Text = infoCliente.Rows[0][2].ToString();
            txtNovoTelefoneAluguel.Text = infoCliente.Rows[0][6].ToString();
            txtNovoEmailAluguel.Text = infoCliente.Rows[0][8].ToString();
        }
        private void PreencherCamposAluguel(DataTable infoAluguel)
        {
            txtNovoTituloLivroAluguel.Text = infoAluguel.Rows[0][0].ToString();
            txtNovoAutorAluguel.Text = infoAluguel.Rows[0][1].ToString();
            dtpEditarDataEntrega.Value = Convert.ToDateTime(infoAluguel.Rows[0][3]);
            dtpEditarDataRecebimento.Value = Convert.ToDateTime(infoAluguel.Rows[0][4]);
            cmbNovoStatus.Text = infoAluguel.Rows[0][5].ToString();
        }

        private void LimparCampos()
        {
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
