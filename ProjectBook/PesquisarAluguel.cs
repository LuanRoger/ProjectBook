using ProjectBook.DB.SqlServerExpress;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ProjectBook.Tipos;

namespace ProjectBook
{
    public partial class PesquisarAluguel : Form
    {
        private AluguelDb aluguelDb = new AluguelDb();
        private ClienteDb clienteDb = new ClienteDb();
        private LivrosDb livrosDb = new LivrosDb();
        
        public PesquisarAluguel()
        {
            InitializeComponent();
        }

        private void btnBuscarClientePesquisaAluguel_Click(object sender, EventArgs e)
        {
            string[] termoBusca = txtBuscarAluguel.Text.Split("-");
            DataTable data = new DataTable();
            
            if (Verificadores.VerificarStrings(txtBuscarAluguel.Text))
            {
                MessageBox.Show(Properties.Resources.preencherCampoBusca_MessageBox, Properties.Resources.error_MessageBox,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            if (rabNomeCliente.Checked)
            {
                aluguelDb.AbrirConexaoDb();
                data = aluguelDb.BuscarAluguelCliente(termoBusca[0].Trim());
                aluguelDb.FechaConecxaoDb();
            }
            else if (rabTituloLivro.Checked)
            {
                aluguelDb.AbrirConexaoDb();
                data = aluguelDb.BuscarAluguelLivro(termoBusca[0].Trim());
                aluguelDb.FechaConecxaoDb();
            }

            if(Verificadores.VerificarDataTable(data))
            {
                MessageBox.Show(Properties.Resources.livroNaoAlugado, Properties.Resources.error_MessageBox,
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            PreencherCampos(data);
        }
        private void rabTituloLivro_CheckedChanged(object sender, EventArgs e)
        {
            AutoCompleteStringCollection aluguelSugestao = new AutoCompleteStringCollection();
            livrosDb.AbrirConexaoDb();
            foreach (DataRow livro in aluguelDb.VerTodosAluguel().Rows) aluguelSugestao.Add($"{livro[0]} - {livro[2]}");
            livrosDb.FechaConecxaoDb();
            txtBuscarAluguel.AutoCompleteCustomSource = aluguelSugestao;
        }
        private void rabNomeCliente_CheckedChanged(object sender, EventArgs e)
        {
            AutoCompleteStringCollection aluguelSugestao = new AutoCompleteStringCollection();
            clienteDb.AbrirConexaoDb();
            foreach (DataRow cliente in aluguelDb.VerTodosAluguel().Rows) aluguelSugestao.Add($"{cliente[2]} - {cliente[0]}");
            clienteDb.FechaConecxaoDb();
            txtBuscarAluguel.AutoCompleteCustomSource = aluguelSugestao;
        }

        private void PreencherCampos(DataTable data)
        {
            txtResultadoCliete.Text = data.Rows[0][2].ToString();
            txtResultadoLivro.Text = data.Rows[0][0].ToString();
            txtResultadoStatus.Text = data.Rows[0][5].ToString();
            DateTime hoje = DateTime.Now.Date;
            DateTime devolucao = (DateTime)data.Rows[0][4];
            txtAVencer.Text = Convert.ToInt32((devolucao.Date - hoje).Days) <= 0
                ? "-" : (devolucao.Date - hoje).Days.ToString();
            txtAtraso.Text = Convert.ToInt32((hoje - devolucao.Date).Days) <= 0
                ? "-" : (hoje - devolucao.Date).Days.ToString();
        }

        private void btnFecharPesquisaAluguel_Click(object sender, EventArgs e) => this.Close();
        private void btnLimparPequisaAluguel_Click(object sender, EventArgs e) => LimaprCampos();
        
        private void LimaprCampos()
        {
            txtBuscarAluguel.Clear();
            // txtBuscarTitulo.Clear();
            txtAtraso.Clear();
            txtAVencer.Clear();
            txtResultadoCliete.Clear();
            txtResultadoLivro.Clear();
            txtResultadoStatus.Clear();
        }
    }
}
