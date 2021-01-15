using ProjectBook.DB.SqlServerExpress;
using ProjectBook.Livros;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
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
            try
            {
                aluguelDb.AbrirConexaoDb();
                if (rabBuscarNomeCliente.Checked == true)
                {
                    infoAluguel = aluguelDb.BuscarAluguelCliente(buscarEditarAluguel);
                    infoCliente = clienteDb.BuscarClienteNome(infoAluguel.Rows[0][2].ToString());
                    aluguelDb.FechaConecxaoDb();
                }
                else if (rabBuscarTituloLivro.Checked == true)
                {
                    infoAluguel = aluguelDb.BuscarAluguelLivro(buscarEditarAluguel);
                    infoCliente = clienteDb.BuscarClienteNome(infoAluguel.Rows[0][2].ToString());
                    aluguelDb.FechaConecxaoDb();
                }
                else
                {
                    aluguelDb.FechaConecxaoDb();
                    return;
                }
            }catch
            {
                MessageBox.Show("O livro ou o cliente não existem", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                aluguelDb.FechaConecxaoDb();
                return;
            }

            PreencherCamposBuscaAluguel(infoAluguel, infoCliente);
        }

        private void btnSalvarEditarAluguel_Click(object sender, EventArgs e)
        {
            Aluguel aluguel = Aluguel.AluguelFactory(txtNovoTituloLivroAluguel.Text, txtNovoAutorAluguel.Text, txtNovoClienteAluguel.Text,
                dtpEditarDataEntrega.Value, dtpEditarDataRecebimento.Value, cmbNovoStatus.Text);

            if (Verificadores.VerificarCamposAluguel(aluguel))
            {
                MessageBox.Show("Faça uma pesquisa para continuar", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            aluguelDb.AbrirConexaoDb();
            aluguelDb.AtualizarAluguelNomeCliente(aluguel, infoCliente.Rows[0][1].ToString());
            aluguelDb.FechaConecxaoDb();

            LimparCampos();
        }

        private void btnBuscarNovoLivro_Click(object sender, EventArgs e)
        {
            string buscarLivro = txtMudarLivroAluguel.Text;
            DataTable resultadoBusca;

            if (Verificadores.VerificarStrings(buscarLivro) == true)
            {
                MessageBox.Show("Você deve preencher o campo de busca para continuar.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            livrosDb.AbrirConexaoDb();
            resultadoBusca = livrosDb.BuscarLivrosTitulo(buscarLivro);
            livrosDb.FechaConecxaoDb();

            txtNovoTituloLivroAluguel.Text = resultadoBusca.Rows[0][1].ToString();
            txtNovoAutorAluguel.Text = resultadoBusca.Rows[0][2].ToString();
        }

        private void btnBuscarNovoCliente_Click(object sender, EventArgs e)
        {
            string buscarCliete = txtMudarClienteAluguel.Text;
            DataTable resultadoBusca;

            if (Verificadores.VerificarStrings(buscarCliete) == true)
            {
                MessageBox.Show("Você deve preencher o campo de busca para continuar.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            clienteDb.AbrirConexaoDb();
            resultadoBusca = clienteDb.BuscarClienteNome(buscarCliete);
            clienteDb.FechaConecxaoDb();

            txtNovoClienteAluguel.Text = resultadoBusca.Rows[0][1].ToString();
            txtNovoEnderecoAluguel.Text = resultadoBusca.Rows[0][2].ToString();
            txtNovoTelefoneAluguel.Text = resultadoBusca.Rows[0][6].ToString();
            txtNovoEmailAluguel.Text = resultadoBusca.Rows[0][7].ToString();
        }

        private void btnLimparTxtAluguel_Click(object sender, EventArgs e) => LimparCampos();
        private void btnCancelarEditarAluguel_Click(object sender, EventArgs e) => this.Close();

        private void PreencherCamposBuscaAluguel(DataTable infoAluguel, DataTable infoCliente)
        {
            txtNovoTituloLivroAluguel.Text = infoAluguel.Rows[0][0].ToString();
            txtNovoAutorAluguel.Text = infoAluguel.Rows[0][1].ToString();
            dtpEditarDataEntrega.Value = Convert.ToDateTime(infoAluguel.Rows[0][3]);
            dtpEditarDataRecebimento.Value = Convert.ToDateTime(infoAluguel.Rows[0][4]);
            cmbNovoStatus.Text = infoAluguel.Rows[0][5].ToString();
            txtNovoClienteAluguel.Text = infoCliente.Rows[0][1].ToString();
            txtNovoEnderecoAluguel.Text = infoCliente.Rows[0][2].ToString();
            txtNovoTelefoneAluguel.Text = infoCliente.Rows[0][6].ToString();
            txtNovoEmailAluguel.Text = infoCliente.Rows[0][7].ToString();
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

            infoAluguel = new DataTable();
            infoCliente = new DataTable();
        }
    }
}
