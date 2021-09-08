using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ProjectBook.AppInsight;
using ProjectBook.DB.SqlServerExpress;
using ProjectBook.Livros;
using ProjectBook.Properties;

namespace ProjectBook.GUI
{
    public partial class PesquisarCliente : Form
    {
        public PesquisarCliente()
        {
            InitializeComponent();

            Load += (_, _) => AppInsightMetrics.TrackForm("PesquisarCliente");
        }

        private async void btnPesquisarCliente_Click(object sender, EventArgs e)
        {
            string termoPesquisa = txtPesquisarCliente.Text;
            if (Verificadores.VerificarStrings(termoPesquisa))
            {
                MessageBox.Show(Resources.PesquiseParaContinuar, Resources.Error_MessageBox,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            List<ClienteModel> cliente = new();

            if (rabPesquisarId.Checked) cliente.Add(await ClienteDb.BuscarClienteId(int.Parse(termoPesquisa)));
            else if (rabPesquisarNome.Checked) cliente = await ClienteDb.BuscarClienteNome(termoPesquisa);

            ListaPesquisa<ClienteModel> listaPesquisa = new(cliente);
            listaPesquisa.Show();
            
            txtPesquisarCliente.Clear();
        }
        private void btnCancelarPesquisarCliente_Click(object sender, EventArgs e) => Close();
    }
}
