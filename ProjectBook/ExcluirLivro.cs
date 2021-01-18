using System;
using System.Data;
using System.Windows.Forms;
using ProjectBook.DB.SqlServerExpress;

namespace ProjectBook
{
    public partial class Excluir : Form
    {
        LivrosDb db = new LivrosDb();
        public Excluir()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string idLivroExcluir = txtExcluirLivro.Text;
            DataTable data = db.BuscarLivrosId(idLivroExcluir);

            if (Verificadores.VerificarDataTable(data))
            {
                MessageBox.Show(Properties.Resources.livroNaoExiste_MessageBox, Properties.Resources.error_MessageBox,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult resultadoExcluir = MessageBox.Show(
                $"{Properties.Resources.confirmarExclusao} {data.Rows[0][1]} {Properties.Resources.confirmarExclusaoDe} {data.Rows[0][2]}",
                Properties.Resources.excluir_MessageBox, MessageBoxButtons.YesNo, MessageBoxIcon.Stop);

            db.AbrirConexaoDb();
            if (resultadoExcluir == DialogResult.Yes) db.DeletarLivroId(idLivroExcluir);
            db.FechaConecxaoDb();
            
            txtExcluirLivro.Clear();
        }
    }
}
