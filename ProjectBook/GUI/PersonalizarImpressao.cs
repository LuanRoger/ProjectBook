using System;
using System.Configuration;
using System.Windows.Forms;
using ProjectBook.Properties;

namespace ProjectBook.GUI
{
    public partial class PersonalizarImpressao : Form
    {
        public PersonalizarImpressao()
        {
            InitializeComponent();

            CarregarConfigurações();
        }

        private void CarregarConfigurações()
        {
            txtTituloPagina.Text = ConfigurationManager.AppSettings["TituloFolha"];
            txtSubtituloPagina.Text = ConfigurationManager.AppSettings["SubtituloFolha"];
            txtRodape.Text = ConfigurationManager.AppSettings["Rodape"];

            chbExibirCodigo.Checked = ConfigurationManager.AppSettings["ExibirID"] == "1";
            chbNPagina.Checked = ConfigurationManager.AppSettings["NumeroPaginas"] == "1";
        }

        private void btnSalvarPersonalizacao_Click(object sender, EventArgs e)
        {
            if (Verificadores.VerificarStrings(txtTituloPagina.Text))
            {
                MessageBox.Show(Properties.Resources.preencherCamposObrigatorios_MessageBox, Properties.Resources.error_MessageBox,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Configuracoes.config.AppSettings.Settings["TituloFolha"].Value = txtTituloPagina.Text;
            Configuracoes.config.AppSettings.Settings["SubtituloFolha"].Value = txtSubtituloPagina.Text;
            Configuracoes.config.AppSettings.Settings["Rodape"].Value = txtRodape.Text;
            Configuracoes.config.AppSettings.Settings["ExibirID"].Value = chbExibirCodigo.Checked ? "1" : "0";
            Configuracoes.config.AppSettings.Settings["NumeroPaginas"].Value = chbNPagina.Checked ? "1" : "0";

            Configuracoes.config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");

            MessageBox.Show(Resources.configuracoesSalvas_MessageBox, Resources.concluido_MessageBox,
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
