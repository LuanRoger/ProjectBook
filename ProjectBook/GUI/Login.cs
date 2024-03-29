﻿using System;
using System.Linq;
using System.Windows.Forms;
using ProjectBook.DB.SqlServerExpress;
using ProjectBook.Properties;
using ProjectBook.Tipos;
using ProjectBook.Managers;
using ProjectBook.Managers.Configuration;
using ProjectBook.Model;

namespace ProjectBook.GUI
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        private void Login_Load(object sender, EventArgs e)
        {
            chbKeepConnected.Checked = AppConfigurationManager.configuration.login.keepConnected;
        }

        private void btnFecharLogin_Click(object sender, EventArgs e) => Application.Exit();
        private void Login_FormClosing(object sender, FormClosingEventArgs e) => Application.Exit();
        private void btnEntrarLogin_Click(object sender, EventArgs e)
        {
            if(Verificadores.VerificarStrings(txtLoginUsuario.Text, txtLoginSenha.Text) || 
                Verificadores.VerificarStrings(txtLoginCodigo.Text, txtLoginSenha.Text))
            {
                MessageBox.Show(Resources.PreencherCamposObrigatorios, Resources.Error_MessageBox,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            UsuarioModel infoUsuario = UsuarioDb.LoginUsuario(txtLoginUsuario.Text, txtLoginSenha.Text);
            
            if(Verificadores.VerificarCamposUsuario(infoUsuario))
            {
                infoUsuario = UsuarioDb.LoginCodigo(int.Parse(txtLoginCodigo.Text), txtLoginSenha.Text);

                if(Verificadores.VerificarCamposUsuario(infoUsuario))
                {
                    MessageBox.Show(Resources.InformacoesIncorretasLogin, Resources.Error_MessageBox,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            UserInfo.UserNowInstance = new()
            {
                idUsuario = infoUsuario.id,
                userName = infoUsuario.usuario, 
                tipoUsuario = infoUsuario.tipo
            };
            AppConfigurationManager.configuration.login = new()
            {
                keepConnected = chbKeepConnected.Checked
            };
            AppConfigurationManager.SaveConfig();

            AppManager.ReiniciarPrograma();
        }

        #region txtLeave
        private async void txtLoginCodigo_Leave(object sender, EventArgs e)
        {
            if(Verificadores.VerificarStrings(txtLoginCodigo.Text)) return;

            UsuarioModel codigoUsuario = await UsuarioDb.BuscarUsuarioId(int.Parse(txtLoginCodigo.Text));

            if(Verificadores.VerificarCamposUsuario(codigoUsuario)) return;

            txtLoginUsuario.Text = codigoUsuario.usuario;
        }
        private async void txtLoginUsuario_Leave(object sender, EventArgs e)
        {
            if(Verificadores.VerificarStrings(txtLoginUsuario.Text)) return;

            UsuarioModel nomeUsuario = (await UsuarioDb.BuscarUsuarioNome(txtLoginUsuario.Text)).FirstOrDefault();

            if(Verificadores.VerificarCamposUsuario(nomeUsuario)) return;

            txtLoginCodigo.Text = nomeUsuario.id.ToString();
        }
        #endregion

        private void txtLoginSenha_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter) btnEntrarLogin.PerformClick();
        }
    }
}