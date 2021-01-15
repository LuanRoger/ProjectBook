using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ProjectBook.DB.SqlServerExpress;
using ProjectBook.Livros;

namespace ProjectBook
{
    public partial class EditarCadastro : Form
    {
        private LivrosDb db = new LivrosDb();

        private DataTable resultadoBusca;

        public EditarCadastro()
        {
            InitializeComponent();

            //Colocar todos os generos no combobox
            foreach (DataRow itens in db.VerTodosLivros().Rows)
            {
                txtEditarGenero.Items.Add(itens["Genero"]);
            }
        }

        private void btnFecharEdicao_Click(object sender, EventArgs e) => this.Close();

        private void btnBuscarEditar_Click(object sender, EventArgs e)
        {
            string paraBuscar = txtEditarBuscar.Text;

            if(Verificadores.VerificarStrings(paraBuscar))
            {
                MessageBox.Show(Properties.Resources.preencherCampos_MessageBox, Properties.Resources.error_MessageBox,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (rabEditarId.Checked) resultadoBusca = db.BuscarLivrosId(paraBuscar); 
            else if (rabEditarTitulo.Checked) resultadoBusca = db.BuscarLivrosTitulo(paraBuscar); 
            else if (rabEditarAutor.Checked) resultadoBusca = db.BuscarLivrosAutor(paraBuscar); 
            else return; 

            gpbBuscar.Enabled = false;

            PreencherCampos(resultadoBusca);
        }

        private void btnLimparTxtEditar_Click(object sender, EventArgs e) { gpbBuscar.Enabled = true; LimparCamposEditar(); }

        private void btnSalvarEditar_Click(object sender, EventArgs e)
        {
            Livro livro = Livro.LivroFactory(txtEditarTitulo.Text, txtEditarAutor.Text, txtEditarEditora.Text, txtEditarEdicao.Text,
                txtEditarAno.Text, txtEditarGenero.Text, txtEditarIsbn.Text);
            if (Verificadores.VerificarCamposLivros(livro) == true)
            {
                MessageBox.Show(Properties.Resources.preencherCampos_MessageBox, Properties.Resources.error_MessageBox,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            db.AbrirConexaoDb();
            db.AtualizarViaId(resultadoBusca.Rows[0][0].ToString(), livro);
            db.FechaConecxaoDb();

            LimparCamposEditar();
            gpbBuscar.Enabled = true;
        }
        private void PreencherCampos(DataTable info)
        {
            try
            {
                txtEditarTitulo.Text = info.Rows[0][1].ToString();
                txtEditarAutor.Text = info.Rows[0][2].ToString();
                txtEditarEditora.Text = info.Rows[0][3].ToString();
                txtEditarEdicao.Text = info.Rows[0][4].ToString();
                txtEditarAno.Text = info.Rows[0][5].ToString();
                txtEditarGenero.Text = info.Rows[0][6].ToString();
                txtEditarIsbn.Text = info.Rows[0][7].ToString();
            } 
            catch
            {
                MessageBox.Show(Properties.Resources.livroNaoExiste_MessageBox, Properties.Resources.error_MessageBox,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                gpbBuscar.Enabled = true;
                return;
            }
        }
        private void LimparCamposEditar()
        {
            txtEditarTitulo.Clear();
            txtEditarAutor.Clear();
            txtEditarEditora.Clear();
            txtEditarEdicao.Clear();
            txtEditarAno.Clear();
            txtEditarGenero.Text = "";
            txtEditarIsbn.Clear();

            resultadoBusca = new DataTable();
        }
    }
}
