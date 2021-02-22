using System;
using System.Configuration;
using System.Data;
using System.Windows.Forms;
using ProjectBook.DB.SqlServerExpress;
using ProjectBook.Livros;

namespace ProjectBook.GUI
{
    public partial class CadastroLivro : Form
    {
        LivrosDb db = new LivrosDb();
        public CadastroLivro()
        {
            InitializeComponent();
            ColocarGeneros();
        }

        private void btnSalvarLivro_Click(object sender, EventArgs e)
        {

            if (Verificadores.VerificarStrings(txtCodigoLivro.Text))
            {
                int codigo = new Random().Next(0, 999);

                while (Verificadores.VerificarIdLivro(codigo))
                {
                    codigo = new Random().Next(0, 999);
                }

                txtCodigoLivro.Text = codigo.ToString();
            }

            Livro livro;
            //Aplicar a formatação na instânciação do cliente
            if (ConfigurationManager.AppSettings["formatarLivro"] == "1")
            {
                livro = new Livro(txtCodigoLivro.Text, txtTituloLivro.Text.ToUpper(), txtAutorLivro.Text.ToUpper(),
                    txtEditoraLivro.Text.ToUpper(), txtEdicaoLivro.Text.ToUpper(), txtAno.Text.ToUpper(),
                    cmdGenero.Text.ToUpper(), txtIsbn.Text.ToUpper());
            }
            else
            {
                livro = new Livro(txtCodigoLivro.Text, txtTituloLivro.Text, txtAutorLivro.Text,
                    txtEditoraLivro.Text, txtEdicaoLivro.Text, txtAno.Text,
                    cmdGenero.Text, txtIsbn.Text);
            }
            
            if (Verificadores.VerificarCamposLivros(livro))
            {
                MessageBox.Show(Properties.Resources.preencherCampos, Properties.Resources.error_MessageBox,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            db.AbrirConexaoDb();
            db.AdicionarLivro(livro);
            db.FechaConecxaoDb();
            
            ColocarGeneros();
            LimparCamposCadastro();
        }

        private void btnFecharCadastro_Click(object sender, EventArgs e) => this.Close();
        private void btnLimparTxtLivros_Click(object sender, EventArgs e) => LimparCamposCadastro();

        private void ColocarGeneros()
        {
            //Colocar todos os generos no combobox
            db.AbrirConexaoDb();
            foreach(DataRow itens in db.PegarGeneros().Rows) cmdGenero.Items.Add(itens["Genero"]);
            db.FechaConecxaoDb();
        }
        private void LimparCamposCadastro()
        {
            txtCodigoLivro.Clear();
            txtTituloLivro.Clear();
            txtAutorLivro.Clear();
            txtEditoraLivro.Clear();
            txtEdicaoLivro.Clear();
            txtAno.Clear();
            cmdGenero.Text = "";
            txtIsbn.Clear();
        }
    }
}
