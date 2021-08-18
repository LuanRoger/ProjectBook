using System;
using System.Data;
using System.Windows.Forms;
using ProjectBook.DB.SqlServerExpress;
using ProjectBook.Properties;
using ProjectBook.AppInsight;

namespace ProjectBook.GUI
{
    public partial class PesquisarUsuario : Form
    {
        private UsuarioDb usuarioDb = new();
        public PesquisarUsuario()
        {
            InitializeComponent();

            #region MenuClick
            mnuVerAdm.Click += (sender, e) =>
            {
                ListaPesquisa listaPesquisa = new(usuarioDb.PegarTodosAdm());
                listaPesquisa.Show();
            };
            mnuVerUsuarios.Click += (sender, e) =>
            {
                ListaPesquisa listaPesquisa = new(usuarioDb.PegarTodosUsu());
                listaPesquisa.Show();
            };
            #endregion

            Load += (_, _) => AppInsightMetrics.TrackForm("PesquisarUsuario");
        }

        private void btnCancelarBuscaUsuario_Click(object sender, EventArgs e) => Close();
        private void bntBuscarUsuario_Click(object sender, EventArgs e)
        {
            if (Verificadores.VerificarStrings(txtNomeUsuarioBusca.Text))
            {
                MessageBox.Show(Resources.PesquiseParaContinuar, Resources.Error_MessageBox,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DataTable infoUsuario = new();
            if (rabCodigoUsuario.Checked) infoUsuario = usuarioDb.BuscarUsuarioId(txtNomeUsuarioBusca.Text);
            else if (rabUsuarioNome.Checked) infoUsuario = usuarioDb.PesquisarUsuarioNome(txtNomeUsuarioBusca.Text);

            ListaPesquisa lista = new(infoUsuario);
            lista.Show();
        }
    }
}
