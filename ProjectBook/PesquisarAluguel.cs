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
        public PesquisarAluguel()
        {
            InitializeComponent();
        }

        private void btnBuscarClientePesquisaAluguel_Click(object sender, EventArgs e)
        {
            string termoBusca = txtBuscarCliente.Text;
            if (Verificadores.VerificarStrings(termoBusca))
            {
                MessageBox.Show(Properties.Resources.preencherCampoBusca_MessageBox, Properties.Resources.error_MessageBox,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            aluguelDb.AbrirConexaoDb();
            DataTable data = aluguelDb.BuscarAluguelCliente(txtBuscarCliente.Text);
            aluguelDb.FechaConecxaoDb();

            if(Verificadores.VerificarDataTable(data))
            {
                MessageBox.Show(Properties.Resources.livroNaoAlugado, Properties.Resources.error_MessageBox,
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            PreencherCampos(data);
        }

        private void btnBuscarTituloPesquisarAluguel_Click(object sender, EventArgs e)
        {
            string termoBusca = txtBuscarTitulo.Text;
            if (Verificadores.VerificarStrings(termoBusca))
            {
                MessageBox.Show(Properties.Resources.preencherCampoBusca_MessageBox, Properties.Resources.error_MessageBox,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            aluguelDb.AbrirConexaoDb();
            DataTable data = aluguelDb.BuscarAluguelLivro(txtBuscarTitulo.Text);
            aluguelDb.FechaConecxaoDb();

            if (Verificadores.VerificarDataTable(data))
            {
                MessageBox.Show(Properties.Resources.livroNaoAlugado, Properties.Resources.error_MessageBox,
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            PreencherCampos(data);
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
    }
}
