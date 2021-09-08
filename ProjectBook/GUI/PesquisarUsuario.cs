using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ProjectBook.DB.SqlServerExpress;
using ProjectBook.Properties;
using ProjectBook.AppInsight;
using ProjectBook.Livros;

namespace ProjectBook.GUI
{
    public partial class PesquisarUsuario : Form
    {
        public PesquisarUsuario()
        {
            InitializeComponent();

            Load += (_, _) =>
            {
                #region MenuClick
                mnuVerAdm.Click += async (_, _) =>
                {
                    ListaPesquisa<UsuarioModel> listaPesquisa = new(await UsuarioDb.PegarTodosAdm());
                    listaPesquisa.Show();
                };
                mnuVerUsuarios.Click += async (_, _) =>
                {
                    ListaPesquisa<UsuarioModel> listaPesquisa = new(await UsuarioDb.PegarTodosUsu());
                    listaPesquisa.Show();
                };
                #endregion
                
                AppInsightMetrics.TrackForm("PesquisarUsuario");  
            };
        }

        private void btnCancelarBuscaUsuario_Click(object sender, EventArgs e) => Close();
        private async void bntBuscarUsuario_Click(object sender, EventArgs e)
        {
            if (Verificadores.VerificarStrings(txtNomeUsuarioBusca.Text))
            {
                MessageBox.Show(Resources.PesquiseParaContinuar, Resources.Error_MessageBox,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            List<UsuarioModel> infoUsuario = new();
            
            if (rabCodigoUsuario.Checked) infoUsuario.Add(await UsuarioDb.BuscarUsuarioId(int.Parse(txtNomeUsuarioBusca.Text)));
            else if (rabUsuarioNome.Checked) infoUsuario = await UsuarioDb.BuscarUsuarioNome(txtNomeUsuarioBusca.Text);

            ListaPesquisa<UsuarioModel> lista = new(infoUsuario);
            lista.Show();
        }
    }
}
