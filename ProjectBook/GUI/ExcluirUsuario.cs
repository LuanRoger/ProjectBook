using ProjectBook.DB.SqlServerExpress;
using System;
using System.Data;
using System.Windows.Forms;
using ProjectBook.Properties;
using ProjectBook.AppInsight;
using ProjectBook.Livros;

namespace ProjectBook.GUI
{
    public partial class ExcluirUsuario : Form
    {
        public ExcluirUsuario()
        {
            InitializeComponent();

            Load += (_, _) => AppInsightMetrics.TrackForm("ExcluirUsuario");
        }

        private async void btnPesquisarExcluirUsuario_Click(object sender, EventArgs e)
        {
            UsuarioModel infoUsuario = await UsuarioDb.BuscarUsuarioId(int.Parse(txtCodigoDeletarUsuario.Text));

            if (Verificadores.VerificarCamposUsuario(infoUsuario))
            {
                MessageBox.Show(Resources.PesquiseParaContinuar, Resources.Error_MessageBox,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult dialogResult = MessageBox.Show(string.Format(Resources.ConfirmarExclusao1, infoUsuario.usuario),
                Resources.Error_MessageBox,
                MessageBoxButtons.YesNo, MessageBoxIcon.Stop);

            if (dialogResult != DialogResult.Yes) return;
            
            if(Verificadores.VerificarAdmin(infoUsuario))
            {
                dialogResult = MessageBox.Show(Resources.AvisoDeletarAdmin, Resources.Aviso_MessageBox,
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if(dialogResult != DialogResult.Yes) return;
            }

            UsuarioDb.DeletarUsuarioId(int.Parse(txtCodigoDeletarUsuario.Text));
            LimparCampos();
        }

        private void LimparCampos() =>
            txtCodigoDeletarUsuario.Clear();

        private void btnCancelar_Click(object sender, EventArgs e) => Close();
    }
}
