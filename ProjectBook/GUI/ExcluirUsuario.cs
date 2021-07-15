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
                MessageBox.Show(Resources.PreecherCampoBusca, Resources.MessageBoxError,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult dialogResult = MessageBox.Show(string.Format(Resources.ConfirmarExclusao1, infoUsuario.Rows[0][1]),
                Resources.MessageBoxError,
                MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
            if (dialogResult == DialogResult.No) return;

            usuarioDb.DeletarUsuarioId(txtCodigoDeletarUsuario.Text);
            LimparCampos();
        }

        private void LimparCampos()
        {
            txtCodigoDeletarUsuario.Clear();
        }

        private void btnCancelar_Click(object sender, EventArgs e) => Close();
    }
}
