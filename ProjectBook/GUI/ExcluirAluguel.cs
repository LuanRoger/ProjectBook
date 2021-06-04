using System;
using System.Data;
using System.Windows.Forms;
using ProjectBook.AppInsight;
using ProjectBook.DB.SqlServerExpress;
using ProjectBook.Properties;

namespace ProjectBook.GUI
{
    public partial class ExcluirAluguel : Form
    {
        AluguelDb aluguelDb = new();
        public ExcluirAluguel()
        {
            InitializeComponent();

            Load += (_, _) => AppInsightMetrics.TrackForm("ExcluirAluguel");
        }

        #region CheckedChanged
        private void rabExcluirAluguelTitulo_CheckedChanged(object sender, EventArgs e)
        {
            AutoCompleteStringCollection livrosSugestoes = new();
            foreach (DataRow livro in aluguelDb.VerTodosAluguel().Rows) livrosSugestoes.Add($"{livro[0]} - {livro[2]}");
            txtBuscaAluguel.AutoCompleteCustomSource = livrosSugestoes;
        }

        private void rabExcluirAluguelCliente_CheckedChanged(object sender, EventArgs e)
        {
            AutoCompleteStringCollection livrosSugestoes = new();
            foreach (DataRow livro in aluguelDb.VerTodosAluguel().Rows) livrosSugestoes.Add($"{livro[2]} - {livro[0]}");
            txtBuscaAluguel.AutoCompleteCustomSource = livrosSugestoes;
        }
        #endregion

        private void btnBuscarExcluirAluguel_Click(object sender, EventArgs e)
        {
            string[] termoBusca = txtBuscaAluguel.Text.Split('-', 2, StringSplitOptions.TrimEntries);
            DataTable infoAluguel = new();

            if (Verificadores.VerificarStrings(txtBuscaAluguel.Text))
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
            
            if(termoBusca.Length == 1)
            {
                if (rabExcluirAluguelCliente.Checked) infoAluguel = aluguelDb.BuscarAluguelCliente(termoBusca[0]);
                else if (rabExcluirAluguelTitulo.Checked) infoAluguel = aluguelDb.BuscarAluguelLivro(termoBusca[0]);
            }
            else 
            {
                string titulo = rabExcluirAluguelTitulo.Checked ? termoBusca[0] : termoBusca[1];
                string nomeCliente = rabExcluirAluguelCliente.Checked ? termoBusca[0] : termoBusca[1];

                infoAluguel = aluguelDb.BuscarAluguelLivroCliente(titulo, nomeCliente);
            }

            if(Verificadores.VerificarDataTable(infoAluguel))
            {
                MessageBox.Show(Resources.clienteLivroNaoAlugados, Resources.MessageBoxError,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult resultadoExcluir = MessageBox.Show(
           string.Format(Resources.ConfirmarExclusao2, infoAluguel.Rows[0][0], infoAluguel.Rows[0][2]),
                Resources.MessageBoxExcluir, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (resultadoExcluir != DialogResult.Yes) return;

            if(termoBusca.Length == 1)
            {
                if (rabExcluirAluguelCliente.Checked) aluguelDb.DeletarAluguelCliente(infoAluguel.Rows[0][2].ToString());
                else if (rabExcluirAluguelTitulo.Checked) aluguelDb.DeletarAluguelTitulo(infoAluguel.Rows[0][0].ToString());
            }else aluguelDb.DeletarAluguelTituloLivro(infoAluguel.Rows[0][0].ToString(), infoAluguel.Rows[0][2].ToString());

            txtBuscaAluguel.Clear();
        }

        private void btnCancelarExcluirAluguel_Click(object sender, EventArgs e) => Close();
    }
}
