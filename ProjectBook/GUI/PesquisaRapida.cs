using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Runtime.Remoting;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjectBook.DB.SqlServerExpress;
using Color = System.Drawing.Color;
using ProjectBook.Properties;
using ProjectBook.AppInsight;
using ProjectBook.Livros;

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
            if (e.KeyCode == Keys.Enter) Pesquisar();
        }
        private async void Pesquisar()
        {
            string termoPesquisa = txtPesquisaRapida.Text;

            if (Verificadores.VerificarStrings(termoPesquisa))
            {
                MessageBox.Show(Resources.PesquiseParaContinuar, Resources.Error_MessageBox,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            dynamic resultado;
            
            if (rabLivroId.Checked) resultado = await LivrosDb.BuscarLivrosId(int.Parse(termoPesquisa));
            else if (rabLivroNome.Checked) resultado = await LivrosDb.BuscarLivrosTitulo(termoPesquisa);
            else if (rabClienteId.Checked) resultado = await ClienteDb.BuscarClienteId(int.Parse(termoPesquisa));
            else resultado = await ClienteDb.BuscarClienteNome(termoPesquisa);

            if(((ObjectHandle)resultado).Unwrap().GetType() == typeof(LivroModel))
            {
                ListaPesquisa<LivroModel> listaPesquisa = new((List<LivroModel>)resultado);
                listaPesquisa.Show();
                listaPesquisa.BringToFront();
            }
            else
            {
                ListaPesquisa<ClienteModel> listaPesquisa = new((List<ClienteModel>)resultado);
                listaPesquisa.Show();
                listaPesquisa.BringToFront();
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
