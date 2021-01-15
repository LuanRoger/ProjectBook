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
    public partial class NovoCadastro : Form
    {
        LivrosDb db = new LivrosDb();
        public NovoCadastro()
        {
            InitializeComponent();

            //Colocar todos os generos no combobox
            foreach(DataRow itens in db.PegarGeneros().Rows)
            {
                txtGenero.Items.Add(itens["Genero"]);
            }
        }

        private void btnSalvarLivro_Click(object sender, EventArgs e)
        {
            Livro livro = Livro.LivroFactory(txtTituloLivro.Text, txtAutorLivro.Text, txtEditoraLivro.Text, txtEdicaoLivro.Text,
                   txtAno.Text, txtGenero.Text, txtIsbn.Text);
            if (Verificadores.VerificarCamposLivros(livro))
            {
                MessageBox.Show(Properties.Resources.preencherCampos_MessageBox, Properties.Resources.error_MessageBox,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            db.AbrirConexaoDb();
            db.AdicionarLivro(livro);
            db.FechaConecxaoDb();
            
            LimparCamposCadastro();
        }

        private void btnFecharCadastro_Click(object sender, EventArgs e) => this.Close();
        private void btnLimparTxtLivros_Click(object sender, EventArgs e) => LimparCamposCadastro();

        private void LimparCamposCadastro()
        {
            txtTituloLivro.Clear();
            txtAutorLivro.Clear();
            txtEditoraLivro.Clear();
            txtEdicaoLivro.Clear();
            txtAno.Clear();
            txtGenero.Text = "";
            txtIsbn.Clear();
        }
    }
}
