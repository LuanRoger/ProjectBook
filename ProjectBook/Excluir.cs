using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
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

            if (Verificadores.VerificarDataTable(data) == true)
            {
                MessageBox.Show(Properties.Resources.livroNaoExiste_MessageBox, Properties.Resources.error_MessageBox,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult resultadoExcluir = MessageBox.Show($"Deseja realmente excluir {data.Rows[0][1]}?",
                "Excluir", MessageBoxButtons.YesNo, MessageBoxIcon.Stop);

            db.AbrirConexaoDb();
            if (resultadoExcluir == DialogResult.Yes) db.DeletarLivroId(idLivroExcluir);
            db.FechaConecxaoDb();
        }
    }
}
