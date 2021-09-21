using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using ProjectBook.DB.SqlServerExpress;
using Color = System.Drawing.Color;
using ProjectBook.Properties;
using ProjectBook.AppInsight;
using ProjectBook.Model;

namespace ProjectBook.GUI
{
    public partial class PesquisaRapida : Form
    {
        public PesquisaRapida()
        {
            InitializeComponent();

            Load += (_, _) => AppInsightMetrics.TrackForm("PesquisaRapida");
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
                ListaPesquisa<LivroModel> livroModels = new(null);
                List<LivroModel> livroHolder = new();

                if (rabLivroId.Checked)
                {
                    livroHolder.Add(await LivrosDb.BuscarLivrosId(int.Parse(termoPesquisa)));
                    livroModels = new(livroHolder);
                }
                else if (rabLivroNome.Checked) livroModels = new(await LivrosDb.BuscarLivrosTitulo(termoPesquisa));

                livroModels.Show();
                livroModels.BringToFront();
            }
            else
            {
                ListaPesquisa<ClienteModel> clienteModels = new(null);
                List<ClienteModel> clienteHolder = new();

                if(rabClienteId.Checked)
                {
                    clienteHolder.Add(await ClienteDb.BuscarClienteId(int.Parse(termoPesquisa)));
                    clienteModels = new(clienteHolder);
                }
                else if(rabClienteNome.Checked) clienteModels = new(await ClienteDb.BuscarClienteNome(termoPesquisa));
                
                clienteModels.Show();
                clienteModels.BringToFront();
            }
        }

        #region CheckChange
        private async void rabLivroNome_CheckedChanged(object sender, EventArgs e)
        {
            txtPesquisaRapida.AutoCompleteMode = AutoCompleteMode.SuggestAppend;

            txtPesquisaRapida.AutoCompleteCustomSource ??= new();
            
            foreach (LivroModel livro in await LivrosDb.VerTodosLivros()) 
                txtPesquisaRapida.Invoke(new MethodInvoker(delegate
                {
                    txtPesquisaRapida.AutoCompleteCustomSource.Add(livro.titulo);
                }));
        }
        private async void rabClienteNome_CheckedChanged(object sender, EventArgs e)
        {
            txtPesquisaRapida.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            
            foreach (ClienteModel cliente in await ClienteDb.VerTodosClientes()) 
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
