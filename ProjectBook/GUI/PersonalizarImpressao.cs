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
            trbAlinhamentoTitulo.Value = int.Parse(ConfigurationManager.AppSettings["AlinhamentoTitulo"]);
            txtSubtituloPagina.Text = ConfigurationManager.AppSettings["SubtituloFolha"];
            trbAlinhamentoSubtitulo.Value = int.Parse(ConfigurationManager.AppSettings["AlinhamentoSubtitulo"]);
            txtRodape.Text = ConfigurationManager.AppSettings["Rodape"];
            trbAlinhamentoRodape.Value = int.Parse(ConfigurationManager.AppSettings["AlinhamentoRodape"]);

            
            chbNPagina.Checked = ConfigurationManager.AppSettings["NumeroPaginas"] == "1";
        }

        private void btnSalvarPersonalizacao_Click(object sender, EventArgs e)
        {
            if (Verificadores.VerificarStrings(txtTituloPagina.Text))
            {
                MessageBox.Show(Resources.preencherCamposObrigatorios_MessageBox, Resources.MessageBoxError,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Configuracoes.config.AppSettings.Settings["TituloFolha"].Value = txtTituloPagina.Text;
            Configuracoes.config.AppSettings.Settings["AlinhamentoTitulo"].Value = trbAlinhamentoTitulo.Value.ToString();
            Configuracoes.config.AppSettings.Settings["SubtituloFolha"].Value = txtSubtituloPagina.Text;
            Configuracoes.config.AppSettings.Settings["AlinhamentoSubtitulo"].Value = trbAlinhamentoSubtitulo.Value.ToString();
            Configuracoes.config.AppSettings.Settings["Rodape"].Value = txtRodape.Text;
            Configuracoes.config.AppSettings.Settings["AlinhamentoRodape"].Value = trbAlinhamentoRodape.Value.ToString();
            Configuracoes.config.AppSettings.Settings["NumeroPaginas"].Value = chbNPagina.Checked ? "1" : "0";

            Configuracoes.config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");

            MessageBox.Show(Resources.ConfiguracoesSalvas, Resources.concluido_MessageBox,
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
