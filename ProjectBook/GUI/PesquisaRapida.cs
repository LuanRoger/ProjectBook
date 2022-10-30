using System.Drawing;
using System.Windows.Forms;
using ProjectBook.DB;
using ProjectBook.DB.Models;
using Color = System.Drawing.Color;
using ProjectBook.Properties;
using ProjectBook.Model;

namespace ProjectBook.GUI
{
    public partial class PesquisaRapida : Form
    {
        public PesquisaRapida()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel1_CellPaint(object sender, TableLayoutCellPaintEventArgs e) =>
            e.Graphics.FillRectangle(new SolidBrush(Color.CornflowerBlue), e.CellBounds);

        private void PesquisaRapida_Load(object sender, EventArgs e) => lblParaCaixaTexto.BackColor = Color.Transparent;
        private void PesquisaRapida_Deactivate(object sender, EventArgs e)
        {
            Close();
        }

        private void txtPesquisaRapida_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            
            if(rabLivroId.Checked || rabLivroNome.Checked) Pesquisar<LivroModel>();
            else if(rabClienteId.Checked || rabClienteNome.Checked) Pesquisar<ClienteModel>();
            else throw new ArgumentException();
        }
        private async void Pesquisar<T>()
        {
            string termoPesquisa = txtPesquisaRapida.Text;

            if (Verificadores.VerificarStrings(termoPesquisa))
            {
                MessageBox.Show(Resources.PesquiseParaContinuar, Resources.Error_MessageBox,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(typeof(T) == typeof(LivroModel))
            {
                List<LivroModel> results = new();
                ListaPesquisa<LivroModel>? listForm = null;
                IContextTransaction transaction = Globals.databaseController.GetTransactionContext();
                LivrosContext livrosContext = (LivrosContext)transaction.StartTransaction<LivroModel>();
                
                if (rabLivroId.Checked)
                {
                    results.Add(livrosContext.ReadById(int.Parse(termoPesquisa)));
                    listForm = new(results);
                }
                else if (rabLivroNome.Checked) listForm = new(await livrosContext.SearchLivrosTitulo(termoPesquisa));

                listForm?.Show();
                listForm?.BringToFront();
            }
            else
            {
                ListaPesquisa<ClienteModel>? clienteModels = null;
                List<ClienteModel> clienteHolder = new();
                IContextTransaction transaction = Globals.databaseController.GetTransactionContext();
                ClienteContext clienteContext = (ClienteContext)transaction.StartTransaction<ClienteModel>();

                if(rabClienteId.Checked)
                {
                    clienteHolder.Add(clienteContext.ReadById(int.Parse(termoPesquisa)));
                    clienteModels = new(clienteHolder);
                }
                else if(rabClienteNome.Checked) clienteModels = new(await clienteContext.SearchClienteNome(termoPesquisa));
                
                clienteModels?.Show();
                clienteModels?.BringToFront();
            }
        }

        #region CheckChange
        private async void rabLivroNome_CheckedChanged(object sender, EventArgs e)
        {
            txtPesquisaRapida.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtPesquisaRapida.AutoCompleteCustomSource ??= new();
            
            IContextTransaction transaction = Globals.databaseController.GetTransactionContext();
            LivrosContext livrosContext = (LivrosContext)transaction.StartTransaction<LivroModel>();
            
            foreach (LivroModel livro in await livrosContext.ReadAllAsync()) 
                txtPesquisaRapida.Invoke(new MethodInvoker(delegate
                {
                    txtPesquisaRapida.AutoCompleteCustomSource.Add(livro.titulo);
                }));
        }
        private async void rabClienteNome_CheckedChanged(object sender, EventArgs e)
        {
            txtPesquisaRapida.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            
            IContextTransaction transaction = Globals.databaseController.GetTransactionContext();
            ICrudContext<ClienteModel> clienteContext = (ClienteContext)transaction.StartTransaction<ClienteModel>();
            
            foreach (ClienteModel cliente in await clienteContext.ReadAllAsync())
                txtPesquisaRapida.Invoke(new MethodInvoker(delegate
                {
                    txtPesquisaRapida.AutoCompleteCustomSource.Add(cliente.nomeCompleto);
                }));
        }
        private void rabLivroId_CheckedChanged(object sender, EventArgs e) => RemoverSugestao();
        private void rabClienteId_CheckedChanged(object sender, EventArgs e) => RemoverSugestao();
        private void RemoverSugestao() => txtPesquisaRapida.AutoCompleteMode = AutoCompleteMode.None;
        #endregion

        private void PesquisaRapida_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F1 or Keys.Escape:
                    Close();
                    break;
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
