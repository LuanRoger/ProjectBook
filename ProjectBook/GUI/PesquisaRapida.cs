using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using ProjectBook.DB.SqlServerExpress;
using Color = System.Drawing.Color;
using ProjectBook.Properties.Languages;

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
                MessageBox.Show(Strings.preencherCampoBusca_MessageBox, Strings.error_MessageBox,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (rabLivroId.Checked) resultado = livrosDb.BuscarLivrosId(termoPesquisa);
            else if (rabLivroNome.Checked) resultado = livrosDb.BuscarLivrosTitulo(termoPesquisa);
            else if (rabClienteId.Checked) resultado = clienteDb.BuscarClienteId(termoPesquisa);
            else if (rabClienteNome.Checked) resultado = clienteDb.BuscarClienteNome(termoPesquisa);

            if (Verificadores.VerificarDataTable(resultado))
            {
                MessageBox.Show(Strings.naoExisteLivroCliente, Strings.error_MessageBox,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ListaPesquisa listaPesquisa = new ListaPesquisa(resultado);
            listaPesquisa.Show();
            listaPesquisa.BringToFront();
        }

        #region CheckChange
        private void rabLivroNome_CheckedChanged(object sender, EventArgs e)
        {
            txtPesquisaRapida.AutoCompleteMode = AutoCompleteMode.Suggest;

            AutoCompleteStringCollection livroSugestao = new AutoCompleteStringCollection();
            foreach (DataRow livro in livrosDb.VerTodosLivros().Rows) livroSugestao.Add(livro[1].ToString());

            txtPesquisaRapida.AutoCompleteCustomSource = livroSugestao;
        }
        private void rabClienteNome_CheckedChanged(object sender, EventArgs e)
        {
            txtPesquisaRapida.AutoCompleteMode = AutoCompleteMode.Suggest;

            AutoCompleteStringCollection clienteSugestao = new AutoCompleteStringCollection();
            foreach (DataRow cliente in clienteDb.VerTodosClientes().Rows) clienteSugestao.Add(cliente[1].ToString());

            txtPesquisaRapida.AutoCompleteCustomSource = clienteSugestao;
        }
        private void rabLivroId_CheckedChanged(object sender, EventArgs e) => RemoverSugestao();
        private void rabClienteId_CheckedChanged(object sender, EventArgs e) => RemoverSugestao();
        private void RemoverSugestao() => txtPesquisaRapida.AutoCompleteMode = AutoCompleteMode.None;
        #endregion

        private void PesquisaRapida_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.NumPad1:
                case Keys.D1:
                    rabLivroId.Checked = true;
                    break;
                case Keys.NumPad2:
                case Keys.D2:
                    rabLivroNome.Checked = true;
                    break;
                case Keys.NumPad3:
                case Keys.D3:
                    rabClienteId.Checked = true;
                    break;
                case Keys.NumPad4:
                case Keys.D4:
                    rabClienteNome.Checked = true;
                    break;
            }
        }
    }
}
