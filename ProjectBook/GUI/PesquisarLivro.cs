using System;
using System.Data;
using System.Windows.Forms;
using ProjectBook.AppInsight;
using ProjectBook.DB.SqlServerExpress;

namespace ProjectBook.GUI
{
    public partial class PesquisarLivro : Form
    {
        LivrosDb livrosDb = new();
        public PesquisarLivro()
        {
            InitializeComponent();

            Load += (_, _) => AppInsightMetrics.TrackForm("PesquisarLivro");
        }

        #region CheckedChanged
        private void rabPesquisarId_CheckedChanged(object sender, EventArgs e) => txtTermoPesquisa.AutoCompleteMode = AutoCompleteMode.None;

        private void rabPesquisarTitulo_CheckedChanged(object sender, EventArgs e) => txtTermoPesquisa.AutoCompleteMode = AutoCompleteMode.None;

        private void rabPesquisarAutor_CheckedChanged(object sender, EventArgs e)
        {
            txtTermoPesquisa.Clear();
            txtTermoPesquisa.AutoCompleteMode = AutoCompleteMode.Suggest;

            AutoCompleteStringCollection autores = new();
            foreach (DataRow autor in livrosDb.VerTodosLivros().Rows) autores.Add(autor[2].ToString());
            txtTermoPesquisa.AutoCompleteCustomSource = autores;
        }

        private void rabPesquisarGenero_CheckedChanged(object sender, EventArgs e)
        {
            txtTermoPesquisa.AutoCompleteCustomSource.Clear();
            txtTermoPesquisa.AutoCompleteMode = AutoCompleteMode.Suggest;

            AutoCompleteStringCollection generos = new();
            foreach (DataRow genero in livrosDb.PegarGeneros().Rows) generos.Add(genero[0].ToString());
            txtTermoPesquisa.AutoCompleteCustomSource = generos;
        }
        #endregion

        private void btnPesquisarSeletiva_Click(object sender, EventArgs e)
        {
            string termoPesquisa = txtTermoPesquisa.Text;
            DataTable resultadoPesquisa;

            if (rabPesquisarId.Checked) resultadoPesquisa = livrosDb.BuscarLivrosId(termoPesquisa);
            else if (rabPesquisarTitulo.Checked) resultadoPesquisa = livrosDb.BuscarLivrosTitulo(termoPesquisa);
            else if (rabPesquisarAutor.Checked) resultadoPesquisa = livrosDb.BuscarLivrosAutor(termoPesquisa);
            else if (rabPesquisarGenero.Checked) resultadoPesquisa = livrosDb.BuscarLivrosGenero(termoPesquisa);
            else return;

            ListaPesquisa listaPesquisa = new(resultadoPesquisa);
            listaPesquisa.Show();

            txtTermoPesquisa.Clear();
        }

        private void btnFecharPesquisaLivro_Click(object sender, EventArgs e) => Close();
    }
}
