using System;
using System.Data;
using System.Windows.Forms;
using ProjectBook.DB.SqlServerExpress;

namespace ProjectBook.GUI
{
    public partial class Excluir : Form
    {
        LivrosDb livrosDb = new LivrosDb();
        public Excluir()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string termoBusca = txtExcluirLivro.Text;
            DataTable data = new DataTable();
            
            if (Verificadores.VerificarStrings(termoBusca))
            {
                MessageBox.Show(Properties.Resources.preencherCampoBusca_MessageBox, Properties.Resources.error_MessageBox,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (rabIdExcluirLivro.Checked)
            {
                livrosDb.AbrirConexaoDb();
                data = livrosDb.BuscarLivrosId(termoBusca);
                livrosDb.FechaConecxaoDb();
            }
            else if (rabExcluirTitulo.Checked)
            {
                livrosDb.AbrirConexaoDb();
                data = livrosDb.BuscarLivrosTitulo(termoBusca);
                livrosDb.FechaConecxaoDb();
            }

            if (Verificadores.VerificarDataTable(data))
            {
                MessageBox.Show(Properties.Resources.livroNaoExiste_MessageBox, Properties.Resources.error_MessageBox,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult resultadoExcluir = MessageBox.Show(
                $@"{Properties.Resources.confirmarExclusao} {data.Rows[0][1]}",
                Properties.Resources.excluir_MessageBox, MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
            
            if (resultadoExcluir == DialogResult.Yes)
            {
                if (rabExcluirTitulo.Checked)
                {
                    livrosDb.AbrirConexaoDb();
                    livrosDb.DeletarLivroTitulo(termoBusca);
                    livrosDb.FechaConecxaoDb();
                }
                else if (rabIdExcluirLivro.Checked)
                {
                    livrosDb.AbrirConexaoDb();
                    livrosDb.DeletarLivroId(termoBusca);
                    livrosDb.FechaConecxaoDb();
                }
            }

            txtExcluirLivro.Clear();
        }
        private void btnCancelarExcluirLivro_Click(object sender, EventArgs e) => this.Close();
    }
}
