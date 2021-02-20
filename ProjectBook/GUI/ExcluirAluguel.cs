using System;
using System.Data;
using System.Windows.Forms;
using ProjectBook.DB.SqlServerExpress;

namespace ProjectBook.GUI
{
    public partial class ExcluirAluguel : Form
    {
        AluguelDb aluguelDb = new AluguelDb();
        public ExcluirAluguel()
        {
            InitializeComponent();
        }

        private void btnBuscarExcluirAluguel_Click(object sender, EventArgs e)
        {
            string termoBusca = txtBuscaAluguel.Text;
            DataTable data = new DataTable();
            
            if (Verificadores.VerificarStrings(termoBusca))
            {
                MessageBox.Show(Properties.Resources.preencherCampoBusca_MessageBox, Properties.Resources.error_MessageBox,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (rabExcluirAluguelCliente.Checked)
            {
                aluguelDb.AbrirConexaoDb();
                data = aluguelDb.BuscarAluguelCliente(termoBusca);
                aluguelDb.FechaConecxaoDb();
            }
            else if (rabExcluirAluguelTitulo.Checked)
            {
                aluguelDb.AbrirConexaoDb();
                data = aluguelDb.BuscarAluguelLivro(termoBusca);
                aluguelDb.FechaConecxaoDb();
            }

            if (Verificadores.VerificarDataTable(data))
            {
                MessageBox.Show(Properties.Resources.clienteLivroNaoAlugados, Properties.Resources.error_MessageBox,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult resultadoExcluir = MessageBox.Show(
            $@"{Properties.Resources.confirmarExclusao} {data.Rows[0][0]} {Properties.Resources.confirmarExclusaoAluguel2} {data.Rows[0][2]}",
                Properties.Resources.excluir_MessageBox, MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
            
            if (resultadoExcluir == DialogResult.Yes)
            {
                if (rabExcluirAluguelCliente.Checked)
                {
                    aluguelDb.AbrirConexaoDb();
                    aluguelDb.DeletarAluguelCliente(data.Rows[0][2].ToString());
                    aluguelDb.FechaConecxaoDb();
                }
                else if (rabExcluirAluguelTitulo.Checked)
                {
                    aluguelDb.AbrirConexaoDb();
                    aluguelDb.DeletarAluguelTitulo(data.Rows[0][0].ToString());
                    aluguelDb.FechaConecxaoDb();
                }
                txtBuscaAluguel.Clear();
            }
        }
        private void btnCancelarExcluirAluguel_Click(object sender, EventArgs e) => this.Close();

        private void rabExcluirAluguelTitulo_CheckedChanged(object sender, EventArgs e)
        {
            AutoCompleteStringCollection livrosSugestoes = new AutoCompleteStringCollection();
            aluguelDb.AbrirConexaoDb();
            foreach (DataRow livro in aluguelDb.VerTodosAluguel().Rows) livrosSugestoes.Add(livro[0].ToString());
            aluguelDb.FechaConecxaoDb();
            txtBuscaAluguel.AutoCompleteCustomSource = livrosSugestoes;
        }

        private void rabExcluirAluguelCliente_CheckedChanged(object sender, EventArgs e)
        {
            AutoCompleteStringCollection livrosSugestoes = new AutoCompleteStringCollection();
            aluguelDb.AbrirConexaoDb();
            foreach (DataRow livro in aluguelDb.VerTodosAluguel().Rows) livrosSugestoes.Add(livro[2].ToString());
            aluguelDb.FechaConecxaoDb();
            txtBuscaAluguel.AutoCompleteCustomSource = livrosSugestoes;
        }
    }
}
