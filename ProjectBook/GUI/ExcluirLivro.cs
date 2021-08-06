using System;
using System.Data;
using System.Windows.Forms;
using ProjectBook.AppInsight;
using ProjectBook.DB.SqlServerExpress;
using ProjectBook.Properties;

namespace ProjectBook.GUI
{
    public partial class ExcluirLivro : Form
    {
        LivrosDb livrosDb = new();
        public ExcluirLivro()
        {
            InitializeComponent();

            Load += (_, _) => AppInsightMetrics.TrackForm("ExcluirLivro");
        }

        #region CheckChange
        private void rabIdExcluirLivro_CheckedChanged(object sender, EventArgs e) => txtExcluirLivro.AutoCompleteMode = AutoCompleteMode.None;
        private void rabExcluirTitulo_CheckedChanged(object sender, EventArgs e)
        {
            AutoCompleteStringCollection sugestaoLivro = new();
            txtExcluirLivro.AutoCompleteMode = AutoCompleteMode.Suggest;

            foreach(DataRow livro in livrosDb.VerTodosLivros().Rows) sugestaoLivro.Add(livro[1].ToString());

            txtExcluirLivro.AutoCompleteCustomSource = sugestaoLivro;
        }
        #endregion

        private void btnBuscarExcluirLivro_Click(object sender, EventArgs e)
        {
            string termoBusca = txtExcluirLivro.Text;
            DataTable data = new();
            
            if (Verificadores.VerificarStrings(termoBusca))
            {
                MessageBox.Show(Resources.PesquiseParaContinuar, Resources.Error_MessageBox,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(!rabIdExcluirLivro.Checked && !rabExcluirTitulo.Checked)
            {
                MessageBox.Show(Resources.PesquiseParaContinuar, Resources.Error_MessageBox,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (rabIdExcluirLivro.Checked) data = livrosDb.BuscarLivrosId(termoBusca);
            else if (rabExcluirTitulo.Checked) data = livrosDb.BuscarLivrosTitulo(termoBusca);

            if (Verificadores.VerificarDataTable(data))
            {
                MessageBox.Show(Resources.LivroNaoExiste, Resources.Excluir_MessageBox,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult resultadoExcluir = MessageBox.Show(
                string.Format(Resources.ConfirmarExclusao1, data.Rows[0][1]),
                Resources.Excluir_MessageBox, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            
            if (resultadoExcluir == DialogResult.Yes)
            {
                if (rabExcluirTitulo.Checked) livrosDb.DeletarLivroTitulo(termoBusca);
                else if (rabIdExcluirLivro.Checked) livrosDb.DeletarLivroId(termoBusca);
            }

            txtExcluirLivro.Clear();
        }
        private void btnCancelarExcluirLivro_Click(object sender, EventArgs e) => Close();
    }
}
