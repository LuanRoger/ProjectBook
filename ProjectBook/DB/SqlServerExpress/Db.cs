﻿using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;
using ProjectBook.GUI;
using ProjectBook.Properties;

namespace ProjectBook.DB.SqlServerExpress
{
    internal abstract class Db
    {
        protected static readonly SqlConnection connection = 
            new SqlConnection(ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString);

        public string DbStatus() => connection.State.ToString();
        #region Modificar conexão
        public void AbrirConexaoDb()
        {
            try { connection.Open(); }
            catch(Exception e)
            {
                if (Application.OpenForms.Count < 2)
                {
                    DialogResult dialogResult = MessageBox.Show(
                        string.Format(Resources.não_foi_possivel_conectar_se_a_base_de_dados___0___Deseja_abrir_a_configurações_, e.Message),
                        Resources.error_MessageBox,
                        MessageBoxButtons.YesNo, MessageBoxIcon.Error);

                    if (dialogResult == DialogResult.Yes)
                    {
                        Configuracoes.config.AppSettings.Settings["tipoUsuario"].Value = Tipos.TipoUsuário.ADM.ToString();
                        Configuracoes.config.Save();
                        ConfigurationManager.RefreshSection("appSettings");
                        Configuracoes configuracoes = new Configuracoes();
                        configuracoes.Closing += delegate
                        {
                            if (String.IsNullOrEmpty(ConfigurationManager.AppSettings["usuarioLogado"]) ||
                                String.IsNullOrEmpty(ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString))
                                Environment.Exit(0);
                        };
                        configuracoes.Show();
                    }
                    else Environment.Exit(0);
                }
            }

        }
        public void FechaConecxaoDb() => connection.Close();
        #endregion
    }
}
