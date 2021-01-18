using ProjectBook.DB.SqlServerExpress;
using System;
using System.Data;
using System.Windows.Forms;

namespace ProjectBook
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
            aluguelDb.AbrirConexaoDb();
            DataTable data = aluguelDb.BuscarAluguelLivro(txtBuscaAluguel.Text);
            aluguelDb.FechaConecxaoDb();

            if (Verificadores.VerificarDataTable(data))
            {
                MessageBox.Show(Properties.Resources.clienteLivroNaoAlugados, Properties.Resources.error_MessageBox,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult resultadoExcluir = MessageBox.Show(
            $"{Properties.Resources.confirmarExclusao} {data.Rows[0][1]} {Properties.Resources.confirmarExclusaoAluguel2} {data.Rows[0][2]}",
                Properties.Resources.excluir_MessageBox, MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
            
            aluguelDb.AbrirConexaoDb();
            if (rabExcluirAluguelTitulo.Checked && resultadoExcluir == DialogResult.Yes)
                aluguelDb.DeletarAluguelTitulo(data.Rows[0][0].ToString());
            else if (rabExcluirAluguelCliente.Checked && resultadoExcluir == DialogResult.Yes)
                aluguelDb.DeletarAluguelCliente(data.Rows[0][2].ToString());
            aluguelDb.FechaConecxaoDb();
        }
    }
}
