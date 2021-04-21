using System;
using System.Data;
using System.Windows.Forms;
using ProjectBook.DB.SqlServerExpress;
using ProjectBook.Livros;
using ProjectBook.Properties.Languages;
using ProjectBook.Tipos;

namespace ProjectBook.GUI
{
    public partial class GerenciarUsuario : Form
    {
        private UsuarioDb usuarioDb = new UsuarioDb();
        public GerenciarUsuario()
        {
            InitializeComponent();
        }

        private void btnCadastrarUsuario_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario(txtUsuarioCadastrar.Text, txtSenhaCadastrar.Text, TipoUsuário.USU.ToString());
            if (Verificadores.VerificarCamposUsuario(usuario))
            {
                MessageBox.Show(Strings.preencherCampoBusca_MessageBox, Strings.error_MessageBox,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            usuarioDb.CadastrarUsuario(usuario);
            
            LimparCampos();
        }

        private void btnSalvarEditarUsuario_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario(txtNovoUsuario.Text, txtNovoSenhaUsuario.Text, cmdNovoStatus.Text);
            if (Verificadores.VerificarCamposUsuario(usuario))
            {
                MessageBox.Show(Strings.preencherCampoBusca_MessageBox, Strings.error_MessageBox,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            usuarioDb.AtualizarUsuarioId(txtIdBuscarUsuario.Text, usuario);

            LimparCampos();
        }

        private void btnBuscarUsuario_Click(object sender, EventArgs e)
        {
            txtIdBuscarUsuario.Enabled = false;

            DataTable infoUsuario = usuarioDb.BuscarUsuarioId(txtIdBuscarUsuario.Text);

            if (Verificadores.VerificarDataTable(infoUsuario))
            {
                MessageBox.Show(Strings.preencherCampoBusca_MessageBox, Strings.error_MessageBox,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            txtNovoUsuario.Text = infoUsuario.Rows[0][1].ToString();
            txtNovoSenhaUsuario.Text = infoUsuario.Rows[0][2].ToString();
            cmdNovoStatus.Text = infoUsuario.Rows[0][3].ToString();
        }

        private void btnDeletarUsuario_Click(object sender, EventArgs e)
        {
            DataTable infoUsuario = usuarioDb.BuscarUsuarioId(txtIdDeletarUsuario.Text);

            if (Verificadores.VerificarDataTable(infoUsuario))
            {
                MessageBox.Show(Strings.preencherCampoBusca_MessageBox, Strings.error_MessageBox,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult dialogResult = MessageBox.Show($"{Strings.confirmarExclusao} {infoUsuario.Rows[0][1]}",
                Strings.excluir_MessageBox,
                MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
            if (dialogResult == DialogResult.No) return;

            usuarioDb.DeletarUsuarioId(txtIdDeletarUsuario.Text);
            LimparCampos();
        }

        private void btnLimparEditarUsuario_Click(object sender, EventArgs e) => LimparCampos();
        private void btnLimparCadastrarUsuario_Click(object sender, EventArgs e) => LimparCampos();

        private void LimparCampos()
        {
            txtUsuarioCadastrar.Clear();
            txtSenhaCadastrar.Clear();
            txtNovoUsuario.Clear();
            txtNovoSenhaUsuario.Clear();
            cmdNovoStatus.Text = "";
            txtIdBuscarUsuario.Enabled = true;
            txtIdDeletarUsuario.Clear();
        }
    }
}