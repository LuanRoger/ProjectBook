using ProjectBook.DB.SqlServerExpress;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

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
            aluguelDb.AbrirConexaoDb();
            DataTable data = aluguelDb.BuscarAluguelCliente(txtBuscarCliente.Text);
            aluguelDb.FechaConecxaoDb();

            if(Verificadores.VerificarDataTable(data) == true)
            {
                MessageBox.Show("Este cliente não tem livro alugado", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            txtResultadoCliete.Text = data.Rows[0][2].ToString();
            txtResultadoLivro.Text = data.Rows[0][0].ToString();
            txtResultadoStatus.Text = data.Rows[0][5].ToString();
            DateTime entrega = (DateTime)data.Rows[0][3];
            DateTime recebimento = (DateTime)data.Rows[0][4];
            txtAVencer.Text = Convert.ToInt32((recebimento.Date - entrega.Date).Days) <= 0 ? "-" : (recebimento.Date - entrega.Date).Days.ToString();
            txtAtraso.Text = Convert.ToInt32((entrega.Date - recebimento.Date).Days) <= 0 || data.Rows[0][5].ToString() == "Devolvido" ?
                 "-" : (entrega.Date - recebimento.Date).Days.ToString();
        }

        private void btnBuscarTituloPesquisarAluguel_Click(object sender, EventArgs e)
        {
            aluguelDb.AbrirConexaoDb();
            DataTable data = aluguelDb.BuscarAluguelLivro(txtBuscarTitulo.Text);
            aluguelDb.FechaConecxaoDb();

            if (Verificadores.VerificarDataTable(data) == true)
            {
                MessageBox.Show("Este livro não foi alugado", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            txtResultadoCliete.Text = data.Rows[0][2].ToString();
            txtResultadoLivro.Text = data.Rows[0][0].ToString();
            txtResultadoStatus.Text = data.Rows[0][5].ToString();
            DateTime entrega = (DateTime)data.Rows[0][3];
            DateTime recebimento = (DateTime)data.Rows[0][4];
            txtAVencer.Text = Convert.ToInt32((recebimento.Date - entrega.Date).Days) <= 0 ? "-" : (recebimento.Date - entrega.Date).Days.ToString();
            txtAtraso.Text = Convert.ToInt32((entrega.Date - recebimento.Date).Days) <= 0 || data.Rows[0][5].ToString() == "Devolvido" ?
                 "-" : (entrega.Date - recebimento.Date).Days.ToString();
        }
    }
}
