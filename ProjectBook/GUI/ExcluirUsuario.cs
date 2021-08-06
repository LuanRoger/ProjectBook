using ProjectBook.DB.SqlServerExpress;
using System;
using System.Data;
using System.Windows.Forms;
using ProjectBook.Properties;
using ProjectBook.AppInsight;

namespace ProjectBook.GUI
{
    public partial class ExcluirUsuario : Form
    {
        public ExcluirUsuario()
        {
            InitializeComponent();

            Load += (_, _) => AppInsightMetrics.TrackForm("ExcluirUsuario");
        }

        private void btnPesquisarExcluirUsuario_Click(object sender, EventArgs e)
        {
            UsuarioDb usuarioDb = new();
            DataTable infoUsuario = usuarioDb.BuscarUsuarioId(txtCodigoDeletarUsuario.Text);

            if (Verificadores.VerificarDataTable(infoUsuario))
            {
                MessageBox.Show(Resources.PesquiseParaContinuar, Resources.Error_MessageBox,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult dialogResult = MessageBox.Show(string.Format(Resources.ConfirmarExclusao1, infoUsuario.Rows[0][1]),
                Resources.Error_MessageBox,
                MessageBoxButtons.YesNo, MessageBoxIcon.Stop);

            if (dialogResult != DialogResult.Yes) return;
            if(Verificadores.VerificarAdmin(infoUsuario.Rows[0]))
            {
                dialogResult = MessageBox.Show(Resources.AvisoDeletarAdmin, Resources.Aviso_MessageBox,
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if(dialogResult != DialogResult.Yes) return;
            }

            usuarioDb.DeletarUsuarioId(txtCodigoDeletarUsuario.Text);
            LimparCampos();
        }

        private void LimparCampos() =>
            txtCodigoDeletarUsuario.Clear();

        private void btnCancelar_Click(object sender, EventArgs e) => Close();
    }
}
