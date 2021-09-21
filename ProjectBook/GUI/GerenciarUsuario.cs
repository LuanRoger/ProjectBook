using System;
using System.Windows.Forms;
using ProjectBook.AppInsight;
using ProjectBook.DB.SqlServerExpress;
using ProjectBook.Model;
using ProjectBook.Properties;
using ProjectBook.Tipos;

namespace ProjectBook.GUI
{
    public partial class GerenciarUsuario : Form
    {
        public GerenciarUsuario()
        {
            InitializeComponent();

            Load += (_, _) => AppInsightMetrics.TrackForm("GerenciarUsuario");
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
            
            UsuarioDb.CadastrarUsuario(usuario);
            
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
            
            UsuarioDb.AtualizarUsuarioId(int.Parse(txtIdBuscarUsuario.Text), usuario);

            LimparCampos();
        }

        private async void btnBuscarUsuario_Click(object sender, EventArgs e)
        {
            txtIdBuscarUsuario.Enabled = false;

            UsuarioModel infoUsuario = await UsuarioDb.BuscarUsuarioId(int.Parse(txtIdBuscarUsuario.Text));

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