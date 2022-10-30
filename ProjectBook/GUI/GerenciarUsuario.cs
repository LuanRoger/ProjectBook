using System.Windows.Forms;
using ProjectBook.DB;
using ProjectBook.DB.Models;
using ProjectBook.Model;
using ProjectBook.Model.Enums;
using ProjectBook.Properties;

namespace ProjectBook.GUI
{
    public partial class GerenciarUsuario : Form
    {
        public GerenciarUsuario()
        {
            InitializeComponent();
        }

        private void btnCadastrarUsuario_Click(object sender, EventArgs e)
        {
            UsuarioModel usuario = new()
            {
                usuario = txtUsuarioCadastrar.Text,
                senha = txtSenhaCadastrar.Text,
                tipo = TipoUsuario.USU 
            };

            if (Verificadores.VerificarCamposUsuario(usuario))
            {
                MessageBox.Show(Resources.PesquiseParaContinuar, Resources.Error_MessageBox,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            IContextTransaction transaction = Globals.databaseController.GetTransactionContext();
            ICrudContext<UsuarioModel> usuariosContext = (UsuariosContext)transaction.StartTransaction<UsuarioModel>();
            usuariosContext.Create(usuario);
            transaction.EndTransaction();
            
            MessageBox.Show(Resources.UsuarioCadastrado, Resources.Concluido_MessageBox,
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            LimparCampos();
        }

        private void btnSalvarEditarUsuario_Click(object sender, EventArgs e)
        {
            UsuarioModel usuario = new()
            {
                usuario = txtNovoUsuario.Text,
                senha = txtNovoSenhaUsuario.Text,
                tipo = (TipoUsuario)cmbNovoStatus.SelectedIndex
            };
            if (Verificadores.VerificarCamposUsuario(usuario))
            {
                MessageBox.Show(Resources.PesquiseParaContinuar, Resources.Error_MessageBox,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            IContextTransaction transaction = Globals.databaseController.GetTransactionContext();
            ICrudContext<UsuarioModel> usuariosContext = (UsuariosContext)transaction.StartTransaction<UsuarioModel>();
            usuariosContext.UpdateById(int.Parse(txtIdBuscarUsuario.Text), usuario);
            transaction.EndTransaction();
            
            MessageBox.Show(Resources.InformacoesAtualizadas_MessageBox, Resources.Concluido_MessageBox,
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            LimparCampos();
        }

        private void btnBuscarUsuario_Click(object sender, EventArgs e)
        {
            IContextTransaction transaction = Globals.databaseController.GetTransactionContext();
            ICrudContext<UsuarioModel> usuariosContext = (UsuariosContext)transaction.StartTransaction<UsuarioModel>();
            UsuarioModel infoUsuario = usuariosContext.ReadById(int.Parse(txtIdBuscarUsuario.Text));

            if (Verificadores.VerificarCamposUsuario(infoUsuario))
            {
                MessageBox.Show(Resources.PesquiseParaContinuar, Resources.Error_MessageBox,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            txtNovoUsuario.Text = infoUsuario.usuario;
            txtNovoSenhaUsuario.Text = infoUsuario.senha;
            cmbNovoStatus.Text = infoUsuario.tipo.ToString();
        }

        private void btnLimparEditarUsuario_Click(object sender, EventArgs e) => LimparCampos();
        private void btnLimparCadastrarUsuario_Click(object sender, EventArgs e) => LimparCampos();

        private void LimparCampos()
        {
            txtUsuarioCadastrar.Clear();
            txtSenhaCadastrar.Clear();
            txtNovoUsuario.Clear();
            txtNovoSenhaUsuario.Clear();
            cmbNovoStatus.Text = "";
            txtIdBuscarUsuario.Enabled = true;
            txtIdBuscarUsuario.Clear();
        }
    }
}