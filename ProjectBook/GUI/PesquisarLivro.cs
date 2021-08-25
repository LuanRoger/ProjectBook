using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using ProjectBook.AppInsight;
using ProjectBook.DB.SqlServerExpress;
using ProjectBook.Livros;

namespace ProjectBook.GUI
{
    public partial class PesquisarLivro : Form
    {
        public PesquisarLivro()
        {
            InitializeComponent();

            Load += (_, _) => AppInsightMetrics.TrackForm("PesquisarLivro");
        }

        #region CheckedChanged
        private void rabPesquisarId_CheckedChanged(object sender, EventArgs e) => txtTermoPesquisa.AutoCompleteMode = AutoCompleteMode.None;

        private void rabPesquisarTitulo_CheckedChanged(object sender, EventArgs e) => txtTermoPesquisa.AutoCompleteMode = AutoCompleteMode.None;

        private async void rabPesquisarAutor_CheckedChanged(object sender, EventArgs e)
        {
            txtTermoPesquisa.Clear();
            txtTermoPesquisa.AutoCompleteMode = AutoCompleteMode.Suggest;

            AutoCompleteStringCollection autores = new();
            foreach (LivroModel livro in await LivrosDb.VerTodosLivros()) 
                autores.Add(livro.autor);
            
            txtTermoPesquisa.AutoCompleteCustomSource = autores;
        }

        private async void rabPesquisarGenero_CheckedChanged(object sender, EventArgs e)
        {
            txtTermoPesquisa.AutoCompleteCustomSource.Clear();
            txtTermoPesquisa.AutoCompleteMode = AutoCompleteMode.Suggest;

            AutoCompleteStringCollection generos = new();
            foreach (string genero in await LivrosDb.PegarGeneros()) 
                generos.Add(genero);
            
            txtTermoPesquisa.AutoCompleteCustomSource = generos;
        }
        #endregion

        private async void btnPesquisarSeletiva_Click(object sender, EventArgs e)
        {
            string termoPesquisa = txtTermoPesquisa.Text;
            
            List<LivroModel> resultadoPesquisa = new();

            if (rabPesquisarId.Checked) resultadoPesquisa.Add(await LivrosDb.BuscarLivrosId(int.Parse(termoPesquisa)));
            else if (rabPesquisarTitulo.Checked) resultadoPesquisa = await LivrosDb.BuscarLivrosTitulo(termoPesquisa);
            else if (rabPesquisarAutor.Checked) resultadoPesquisa = await LivrosDb.BuscarLivrosAutor(termoPesquisa);
            else if (rabPesquisarGenero.Checked) resultadoPesquisa = await LivrosDb.BuscarLivrosGenero(termoPesquisa);
            else return;

            ListaPesquisa<LivroModel> listaPesquisa = new(resultadoPesquisa);
            listaPesquisa.Show();

            txtTermoPesquisa.Clear();
        }

        private void btnFecharPesquisaLivro_Click(object sender, EventArgs e) => Close();
    }
}
