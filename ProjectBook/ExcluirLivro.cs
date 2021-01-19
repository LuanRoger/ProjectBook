using System;
using System.Data;
using System.Windows.Forms;
using ProjectBook.DB.SqlServerExpress;

namespace ProjectBook
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
            string idLivroExcluir = txtExcluirLivro.Text;
            if (Verificadores.VerificarStrings(idLivroExcluir))
            {
                MessageBox.Show(Properties.Resources.preencherCampoBusca_MessageBox, Properties.Resources.error_MessageBox,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            livrosDb.AbrirConexaoDb();
            DataTable data = livrosDb.BuscarLivrosId(idLivroExcluir);
            livrosDb.FechaConecxaoDb();
            
            if (Verificadores.VerificarDataTable(data))
            {
                MessageBox.Show(Properties.Resources.livroNaoExiste_MessageBox, Properties.Resources.error_MessageBox,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult resultadoExcluir = MessageBox.Show(
                $"{Properties.Resources.confirmarExclusao} {data.Rows[0][1]} {Properties.Resources.confirmarExclusaoDe} {data.Rows[0][2]}",
                Properties.Resources.excluir_MessageBox, MessageBoxButtons.YesNo, MessageBoxIcon.Stop);

            livrosDb.AbrirConexaoDb();
            if (resultadoExcluir == DialogResult.Yes) livrosDb.DeletarLivroId(idLivroExcluir);
            livrosDb.FechaConecxaoDb();
            
            txtExcluirLivro.Clear();
        }
    }
}
