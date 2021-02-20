using System;
using System.Data;
using System.Windows.Forms;
using ProjectBook.DB.SqlServerExpress;

namespace ProjectBook.GUI
{
    public partial class PesquisaSeletiva : Form
    {
        LivrosDb livrosDb = new LivrosDb();
        public PesquisaSeletiva()
        {
            InitializeComponent();
        }

        private void btnPesquisarSeletiva_Click(object sender, EventArgs e)
        {
            string termoPesquisa = txtTermoPesquisa.Text;
            DataTable resultadoPesquisa;

            livrosDb.AbrirConexaoDb();
            if (rabPesquisarId.Checked) resultadoPesquisa = livrosDb.BuscarLivrosId(termoPesquisa);
            else if (rabPesquisarTitulo.Checked) resultadoPesquisa = livrosDb.BuscarLivrosTitulo(termoPesquisa);
            else if (rabPesquisarAutor.Checked) resultadoPesquisa = livrosDb.BuscarLivrosAutor(termoPesquisa);
            else return;
            livrosDb.FechaConecxaoDb();

            ListaPesquisa listaPesquisa = new ListaPesquisa(resultadoPesquisa);
            listaPesquisa.Show();

            txtTermoPesquisa.Clear();
        }

        private void btnFecharPesquisaLivro_Click(object sender, EventArgs e) => this.Close();
    }
}
