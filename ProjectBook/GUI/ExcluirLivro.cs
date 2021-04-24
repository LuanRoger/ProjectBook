using System;
using System.Data;
using System.Windows.Forms;
using ProjectBook.DB.SqlServerExpress;
using ProjectBook.Properties.Languages;

namespace ProjectBook.GUI
{
    public partial class Excluir : Form
    {
        LivrosDb livrosDb = new LivrosDb();
        public Excluir()
        {
            InitializeComponent();
        }

        private void btnBuscarExcluirLivro_Click(object sender, EventArgs e)
        {
            string termoBusca = txtExcluirLivro.Text;
            DataTable data = new DataTable();
            
            if (Verificadores.VerificarStrings(termoBusca))
            {
                MessageBox.Show(Strings.PreecherCampoBusca, Strings.MessageBoxError,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(!rabIdExcluirLivro.Checked && !rabExcluirTitulo.Checked)
            {
                MessageBox.Show(Strings.MarcarOpcao, Strings.MessageBoxError,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (rabIdExcluirLivro.Checked) data = livrosDb.BuscarLivrosId(termoBusca);
            else if (rabExcluirTitulo.Checked) data = livrosDb.BuscarLivrosTitulo(termoBusca);

            if (Verificadores.VerificarDataTable(data))
            {
                MessageBox.Show(Strings.LivroNExiste, Strings.MessageBoxError,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult resultadoExcluir = MessageBox.Show(
                string.Format(Strings.ConfirmarExcluisao1, data.Rows[0][1]),
                Strings.MessageBoxExcluir, MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
            
            if (resultadoExcluir == DialogResult.Yes)
            {
                if (rabExcluirTitulo.Checked) livrosDb.DeletarLivroTitulo(termoBusca);
                else if (rabIdExcluirLivro.Checked) livrosDb.DeletarLivroId(termoBusca);
            }

            txtExcluirLivro.Clear();
        }
        private void btnCancelarExcluirLivro_Click(object sender, EventArgs e) => this.Close();
    }
}
