using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using ProjectBook.DB.SqlServerExpress;
using Color = System.Drawing.Color;

namespace ProjectBook.GUI
{
    public partial class PesquisaRapida : Form
    {
        private LivrosDb livrosDb = new LivrosDb();
        private ClienteDb clienteDb = new ClienteDb();

        public PesquisaRapida()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel1_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
            if (e.Row == 0)
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.CornflowerBlue), e.CellBounds);
            }
        }

        private void PesquisaRapida_Load(object sender, EventArgs e) => lblParaCaixaTexto.BackColor = Color.Transparent;
        private void PesquisaRapida_Deactivate(object sender, EventArgs e) => this.Close();

        private void txtPesquisaRapida_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) Pesquisar();
        }
        private void Pesquisar()
        {
            string termoPesquisa = txtPesquisaRapida.Text;
            DataTable resultado = new DataTable();

            if (Verificadores.VerificarStrings(termoPesquisa))
            {
                MessageBox.Show(Properties.Resources.preencherCampoBusca_MessageBox, Properties.Resources.error_MessageBox,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (rabLivroId.Checked) resultado = livrosDb.BuscarLivrosId(termoPesquisa);
            else if (rabLivroNome.Checked) resultado = livrosDb.BuscarLivrosTitulo(termoPesquisa);
            else if (rabClienteId.Checked) resultado = clienteDb.BuscarClienteId(termoPesquisa);
            else if (rabClienteNome.Checked) resultado = clienteDb.BuscarClienteNome(termoPesquisa);

            if (Verificadores.VerificarDataTable(resultado))
            {
                MessageBox.Show(Properties.Resources.naoExisteLivroCliente, Properties.Resources.error_MessageBox,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ListaPesquisa listaPesquisa = new ListaPesquisa(resultado);
            listaPesquisa.Show();
            listaPesquisa.BringToFront();
        }
    }
}
