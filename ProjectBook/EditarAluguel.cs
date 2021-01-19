using ProjectBook.DB.SqlServerExpress;
using ProjectBook.Livros;
using System;
using System.Data;
using System.Windows.Forms;

namespace ProjectBook
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
        }

        private void btnBuscarEditarAluguel_Click(object sender, EventArgs e)
        {
            string buscarEditarAluguel = txtBuscarAluguel.Text;
            if (Verificadores.VerificarStrings(buscarEditarAluguel))
            {
                MessageBox.Show(Properties.Resources.preencherCampoBusca_MessageBox, Properties.Resources.error_MessageBox,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                aluguelDb.AbrirConexaoDb();
                if (rabBuscarNomeCliente.Checked)
                {
                    infoAluguel = aluguelDb.BuscarAluguelCliente(buscarEditarAluguel);
                    infoCliente = clienteDb.BuscarClienteNome(infoAluguel.Rows[0][2].ToString());
                }
                else if (rabBuscarTituloLivro.Checked)
                {
                    infoAluguel = aluguelDb.BuscarAluguelLivro(buscarEditarAluguel);
                    infoCliente = clienteDb.BuscarClienteNome(infoAluguel.Rows[0][2].ToString());
                }

                aluguelDb.FechaConecxaoDb();
            }
            catch
            {
                MessageBox.Show(Properties.Resources.clienteLivroNaoAlugados, Properties.Resources.error_MessageBox,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                aluguelDb.FechaConecxaoDb();

                return;
            }

            PreencherCamposCliente(infoCliente);
            PreencherCamposAluguel(infoAluguel);
        }
        private void btnBuscarNovoLivro_Click(object sender, EventArgs e)
        {
            string buscarLivro = txtMudarLivroAluguel.Text;
            DataTable resultadoBusca;

            if (Verificadores.VerificarStrings(buscarLivro))
            {
                MessageBox.Show(Properties.Resources.preencherCampoBusca_MessageBox, Properties.Resources.error_MessageBox,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            livrosDb.AbrirConexaoDb();
            resultadoBusca = livrosDb.BuscarLivrosTitulo(buscarLivro);
            livrosDb.FechaConecxaoDb();

            //Preencher campo dos livros
            txtNovoTituloLivroAluguel.Text = resultadoBusca.Rows[0][1].ToString();
            txtNovoAutorAluguel.Text = resultadoBusca.Rows[0][2].ToString();
        }

        private void btnBuscarNovoCliente_Click(object sender, EventArgs e)
        {
            string buscarCliete = txtMudarClienteAluguel.Text;
            DataTable resultadoBusca;

            if (Verificadores.VerificarStrings(buscarCliete))
            {
                MessageBox.Show(Properties.Resources.preencherCampoBusca_MessageBox, Properties.Resources.error_MessageBox,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            clienteDb.AbrirConexaoDb();
            resultadoBusca = clienteDb.BuscarClienteNome(buscarCliete);
            clienteDb.FechaConecxaoDb();
            
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

            aluguelDb.AbrirConexaoDb();
            aluguelDb.AtualizarAluguelNomeCliente(aluguel, infoCliente.Rows[0][1].ToString());
            aluguelDb.FechaConecxaoDb();

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
