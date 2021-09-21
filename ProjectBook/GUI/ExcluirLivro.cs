using System;
using System.Linq;
using System.Windows.Forms;
using ProjectBook.AppInsight;
using ProjectBook.DB.SqlServerExpress;
using ProjectBook.Model;
using ProjectBook.Properties;

namespace ProjectBook.GUI
{
    public partial class ExcluirLivro : Form
    {
        public ExcluirLivro()
        {
            InitializeComponent();

            Load += (_, _) => AppInsightMetrics.TrackForm("ExcluirLivro");
        }

        #region CheckChange
        private void rabIdExcluirLivro_CheckedChanged(object sender, EventArgs e) => txtExcluirLivro.AutoCompleteMode = AutoCompleteMode.None;
        private async void rabExcluirTitulo_CheckedChanged(object sender, EventArgs e)
        {
            AutoCompleteStringCollection sugestaoLivro = new();
            txtExcluirLivro.AutoCompleteMode = AutoCompleteMode.Suggest;

            foreach(LivroModel livro in await LivrosDb.VerTodosLivros()) 
                sugestaoLivro.Add(livro.titulo);

            txtExcluirLivro.AutoCompleteCustomSource = sugestaoLivro;
        }
        #endregion

        private async void btnBuscarExcluirLivro_Click(object sender, EventArgs e)
        {
            string termoBusca = txtExcluirLivro.Text;
            LivroModel infoLivro = new();
            
            if (Verificadores.VerificarStrings(termoBusca))
            {
                MessageBox.Show(Resources.PesquiseParaContinuar, Resources.Error_MessageBox,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(!rabIdExcluirLivro.Checked && !rabExcluirTitulo.Checked)
            {
                MessageBox.Show(Resources.PesquiseParaContinuar, Resources.Error_MessageBox,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (rabIdExcluirLivro.Checked) 
                infoLivro = await LivrosDb.BuscarLivrosId(int.Parse(termoBusca));
            else if (rabExcluirTitulo.Checked) 
                infoLivro = (await LivrosDb.BuscarLivrosTitulo(termoBusca)).First();

            if (Verificadores.VerificarCamposLivros(infoLivro))
            {
                MessageBox.Show(Resources.LivroNaoExiste, Resources.Excluir_MessageBox,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult resultadoExcluir = MessageBox.Show(
                string.Format(Resources.ConfirmarExclusao1, infoLivro.titulo),
                Resources.Excluir_MessageBox, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            
            if (resultadoExcluir != DialogResult.Yes) return;
            
            if (rabIdExcluirLivro.Checked) LivrosDb.DeletarLivroId(int.Parse(termoBusca));
            else if (rabExcluirTitulo.Checked) LivrosDb.DeletarLivroTitulo( termoBusca);
            
            txtExcluirLivro.Clear();
        }
        private void btnCancelarExcluirLivro_Click(object sender, EventArgs e) => Close();
    }
}
