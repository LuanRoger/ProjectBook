using System;
using System.Linq;
using System.Windows.Forms;
using ProjectBook.AppInsight;
using ProjectBook.DB.SqlServerExpress;
using ProjectBook.Model;
using ProjectBook.Properties;

namespace ProjectBook.GUI
{
    public partial class ExcluirAluguel : Form
    {
        public ExcluirAluguel()
        {
            InitializeComponent();

            Load += (_, _) => AppInsightMetrics.TrackForm("ExcluirAluguel");
        }

        #region CheckedChanged
        private async void rabExcluirAluguelTitulo_CheckedChanged(object sender, EventArgs e)
        {
            AutoCompleteStringCollection livrosSugestoes = new();
            
            foreach (AluguelModel aluguel in await AluguelDb.VerTodosAluguel()) 
                livrosSugestoes.Add($"{aluguel.titulo} - {aluguel.autor}");
            
            txtBuscaAluguel.AutoCompleteCustomSource = livrosSugestoes;
        }

        private async void rabExcluirAluguelCliente_CheckedChanged(object sender, EventArgs e)
        {
            AutoCompleteStringCollection livrosSugestoes = new();
            foreach (AluguelModel aluguel in await AluguelDb.VerTodosAluguel()) 
                livrosSugestoes.Add($"{aluguel.autor} - {aluguel.titulo}");
            
            txtBuscaAluguel.AutoCompleteCustomSource = livrosSugestoes;
        }
        #endregion

        private async void btnBuscarExcluirAluguel_Click(object sender, EventArgs e)
        {
            string[] termoBusca = txtBuscaAluguel.Text.Split('-', 2, StringSplitOptions.TrimEntries);
            AluguelModel infoAluguel = new();

            if (Verificadores.VerificarStrings(txtBuscaAluguel.Text))
            {
                MessageBox.Show(Resources.PesquiseParaContinuar, Resources.Error_MessageBox,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(termoBusca.Length == 1)
            {
                if (rabExcluirAluguelCliente.Checked) 
                    infoAluguel = (await AluguelDb.BuscarAluguelCliente(termoBusca[0])).First();
                else if (rabExcluirAluguelTitulo.Checked) 
                    infoAluguel = (await AluguelDb.BuscarAluguelLivro(termoBusca[0])).First();
            }
            else 
            {
                string titulo = rabExcluirAluguelTitulo.Checked ? termoBusca[0] : termoBusca[1];
                string nomeCliente = rabExcluirAluguelCliente.Checked ? termoBusca[0] : termoBusca[2];

                infoAluguel = (await AluguelDb.BuscarAluguelLivroCliente(titulo, nomeCliente)).First();
            }

            if(Verificadores.VerificarCamposAluguel(infoAluguel))
            {
                MessageBox.Show(Resources.ClienteLivroNaoAlugados, Resources.Error_MessageBox,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult resultadoExcluir = MessageBox.Show(
           string.Format(Resources.ConfirmarExclusao2, infoAluguel.titulo, infoAluguel.alugadoPor),
                Resources.Excluir_MessageBox, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (resultadoExcluir != DialogResult.Yes) return;

            if(termoBusca.Length == 1)
            {
                if (rabExcluirAluguelCliente.Checked) AluguelDb.DeletarAluguelCliente(infoAluguel.alugadoPor);
                else if (rabExcluirAluguelTitulo.Checked) AluguelDb.DeletarAluguelTitulo(infoAluguel.titulo);
            }
            else AluguelDb.DeletarAluguelTituloLivro(infoAluguel.titulo, infoAluguel.alugadoPor);
            
            MessageBox.Show(Resources.AluguelExcluido, Resources.Concluido_MessageBox, MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            txtBuscaAluguel.Clear();
        }

        private void btnCancelarExcluirAluguel_Click(object sender, EventArgs e) => Close();
    }
}
