using System;
using System.Data;
using System.Windows.Forms;
using ProjectBook.DB.SqlServerExpress;
using ProjectBook.Properties;

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
                MessageBox.Show(Resources.PreecherCampoBusca, Resources.MessageBoxError,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(!rabExcluirAluguelTitulo.Checked && !rabExcluirAluguelCliente.Checked)
            {
                MessageBox.Show(Resources.MarcarOpcao, Resources.MessageBoxError,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            if (rabExcluirAluguelCliente.Checked) data = aluguelDb.BuscarAluguelCliente(termoBusca);
            else if (rabExcluirAluguelTitulo.Checked) data = aluguelDb.BuscarAluguelLivro(termoBusca);

            if (Verificadores.VerificarDataTable(data))
            {
                MessageBox.Show(Resources.clienteLivroNaoAlugados, Resources.MessageBoxError,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult resultadoExcluir = MessageBox.Show(
           string.Format(Resources.ConfirmarExclusao2, data.Rows[0][2], data.Rows[0][0]),
                Resources.MessageBoxExcluir, MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
            
            if (resultadoExcluir == DialogResult.Yes)
            {
                if (rabExcluirAluguelCliente.Checked) aluguelDb.DeletarAluguelCliente(data.Rows[0][2].ToString());
                else if (rabExcluirAluguelTitulo.Checked) aluguelDb.DeletarAluguelTitulo(data.Rows[0][0].ToString());
                txtBuscaAluguel.Clear();
            }
        }
        private void btnCancelarExcluirAluguel_Click(object sender, EventArgs e) => this.Close();

        private void rabExcluirAluguelTitulo_CheckedChanged(object sender, EventArgs e)
        {
            AutoCompleteStringCollection livrosSugestoes = new AutoCompleteStringCollection();
            foreach (DataRow livro in aluguelDb.VerTodosAluguel().Rows) livrosSugestoes.Add(livro[0].ToString());
            txtBuscaAluguel.AutoCompleteCustomSource = livrosSugestoes;
        }

        private void rabExcluirAluguelCliente_CheckedChanged(object sender, EventArgs e)
        {
            AutoCompleteStringCollection livrosSugestoes = new AutoCompleteStringCollection();
            foreach (DataRow livro in aluguelDb.VerTodosAluguel().Rows) livrosSugestoes.Add(livro[2].ToString());
            txtBuscaAluguel.AutoCompleteCustomSource = livrosSugestoes;
        }
    }
}
