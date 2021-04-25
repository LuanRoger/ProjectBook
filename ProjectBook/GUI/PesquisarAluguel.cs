using System;
using System.Data;
using System.Windows.Forms;
using ProjectBook.DB.SqlServerExpress;
using ProjectBook.Tipos;

namespace ProjectBook.GUI
{
    public partial class PesquisarAluguel : Form
    {
        private AluguelDb aluguelDb = new AluguelDb();

        public PesquisarAluguel()
        {
            InitializeComponent();

            #region MenuClick
            mnuVerLivroAlugado.Click += (sender, e) =>
            {
                ListaPesquisa lista = new ListaPesquisa(aluguelDb.PegarLivrosAlugados());
                lista.Show();
            };
            mnuVerLivrosAtasados.Click += (sender, e) =>
            {
                ListaPesquisa lista = new ListaPesquisa(aluguelDb.PegarLivroAtrassado());
                lista.Show();
            };
            mnuVerLivrosDevolvidos.Click += (sender, e) =>
            {
                ListaPesquisa lista = new ListaPesquisa(aluguelDb.PegarLivroDevolvido());
                lista.Show();
            };
            #endregion
        }
        #region CheckChange
        private void rabTituloLivro_CheckedChanged(object sender, EventArgs e)
        {
            AutoCompleteStringCollection aluguelSugestao = new AutoCompleteStringCollection();
            foreach (DataRow livro in aluguelDb.VerTodosAluguel().Rows) aluguelSugestao.Add($"{livro[0]} - {livro[2]}");
            txtBuscarAluguel.AutoCompleteCustomSource = aluguelSugestao;
        }
        private void rabNomeCliente_CheckedChanged(object sender, EventArgs e)
        {
            AutoCompleteStringCollection aluguelSugestao = new AutoCompleteStringCollection();
            foreach (DataRow cliente in aluguelDb.VerTodosAluguel().Rows) aluguelSugestao.Add($"{cliente[2]} - {cliente[0]}");
            txtBuscarAluguel.AutoCompleteCustomSource = aluguelSugestao;
        }
        #endregion

        private void btnBuscarClientePesquisaAluguel_Click(object sender, EventArgs e)
        {
            string[] termoBusca = txtBuscarAluguel.Text.Split("-");
            DataTable data = new DataTable();
            
            if (Verificadores.VerificarStrings(txtBuscarAluguel.Text))
            {
<<<<<<< HEAD
                MessageBox.Show(Strings.PreecherCampoBusca, Strings.MessageBoxError,
=======
                MessageBox.Show(Properties.Resources.preencherCampoBusca_MessageBox, Properties.Resources.error_MessageBox,
>>>>>>> parent of e20e8c2 (v0.5.4-beta)
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            if (rabNomeCliente.Checked) data = aluguelDb.BuscarAluguelCliente(termoBusca[0].Trim());
            else if (rabTituloLivro.Checked) data = aluguelDb.BuscarAluguelLivro(termoBusca[0].Trim());

            if(Verificadores.VerificarDataTable(data))
            {
<<<<<<< HEAD
                MessageBox.Show(Strings.LivroNAlugado, Strings.MessageBoxError,
=======
                MessageBox.Show(Properties.Resources.livroNaoAlugado, Properties.Resources.error_MessageBox,
>>>>>>> parent of e20e8c2 (v0.5.4-beta)
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            PreencherCampos(data);
        }
        private void btnVerEmRelatorio_Click(object sender, EventArgs e)
        {
            string[] termoBusca = txtBuscarAluguel.Text.Split("-");

            if (Verificadores.VerificarStrings(txtBuscarAluguel.Text))
            {
<<<<<<< HEAD
                MessageBox.Show(Strings.PreecherCampoBusca, Strings.MessageBoxError,
=======
                MessageBox.Show(Properties.Resources.preencherCampoBusca_MessageBox, Properties.Resources.error_MessageBox,
>>>>>>> parent of e20e8c2 (v0.5.4-beta)
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ListaPesquisa lista;

            if (rabNomeCliente.Checked)
            {
                lista = new ListaPesquisa(aluguelDb.BuscarAluguelCliente(termoBusca[0].Trim()));
                lista.Show();
            }
            else if (rabTituloLivro.Checked)
            {
                lista = new ListaPesquisa(aluguelDb.BuscarAluguelLivro(termoBusca[0].Trim()));
                lista.Show();
            }

            LimaprCampos();
        }

        private void PreencherCampos(DataTable data)
        {
            txtResultadoCliete.Text = data.Rows[0][2].ToString();
            txtResultadoLivro.Text = data.Rows[0][0].ToString();
            txtResultadoStatus.Text = data.Rows[0][5].ToString();

            if (txtResultadoStatus.Text == StatusAluguel.Devolvido.ToString()) return;
            DateTime hoje = DateTime.Now.Date;
            DateTime devolucao = (DateTime)data.Rows[0][4];
            txtAVencer.Text = Convert.ToInt32((devolucao.Date - hoje).Days) <= 0
                ? "-" : (devolucao.Date - hoje).Days.ToString();
            txtAtraso.Text = Convert.ToInt32((hoje - devolucao.Date).Days) <= 0
                ? "-" : (hoje - devolucao.Date).Days.ToString();
        }

        private void btnFecharPesquisaAluguel_Click(object sender, EventArgs e) => this.Close();
        private void btnLimparPequisaAluguel_Click(object sender, EventArgs e) => LimaprCampos();
        
        private void LimaprCampos()
        {
            txtBuscarAluguel.Clear();
            txtAtraso.Clear();
            txtAVencer.Clear();
            txtResultadoCliete.Clear();
            txtResultadoLivro.Clear();
            txtResultadoStatus.Clear();
        }
    }
}
