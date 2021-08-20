﻿using System.Data;
using System.IO;
using System.Management;
using ProjectBook.Livros;
using ProjectBook.DB.SqlServerExpress;
using ProjectBook.Tipos;
using System.Windows.Forms;
using ProjectBook.Managers.Configuration;

namespace ProjectBook
{
    class Verificadores //TODO - Organizar
    {
        /// <summary>
        /// Verificar todos os campos obrigatórios em <c>Livro</c>.
        /// </summary>
        /// <param name="livro"><c>Livro</c> que será analisado</param>.
        /// <returns>Retorna <c>error</c></returns>
        public static bool VerificarCamposLivros(LivroModel livro) =>
            livro.titulo.Length == 0 || livro.autor.Length == 0 || livro.editora.Length == 0 || livro == null;
        public static bool VerificarIdLivro(int id)
        {
            LivroModel? livro = LivrosDb.BuscarLivrosId(id).Result;
            return livro != null;
        }
        public static bool VerificarAnoLivro(string stringId) => int.TryParse(stringId, out _);

        /// <summary>
        /// Verificar todos os campos obrigatórios em <c>Aluguel</c>.
        /// </summary>
        /// <param name="aluguel"><c>Aluguel</c> que será analisado</param>.
        /// <returns>Retorna <c>error</c></returns>
        public static bool VerificarCamposAluguel(AluguelModel aluguel) =>
            aluguel.titulo.Length == 0 || aluguel.autor.Length == 0 || aluguel.alugadoPor.Length == 0;

        /// <summary>
        /// Verificar todos os campos obrigatórios em <c>Cliente</c>.
        /// </summary>
        /// <param name="cliente"><c>Cliente</c> que será analisado</param>.
        /// <returns>Retorna <c>error</c></returns>
        public static bool VerificarCamposCliente(ClienteModel cliente) => 
            cliente.nomeCompleto.Length == 0 || cliente.cidade.Length == 0 || cliente.estado.Length == 0 ||
            cliente.telefone1.Length == 0 || cliente == null;

        /// <summary>
        /// Verificar todos os campos obrigatórios em <c>Usuario</c>.
        /// </summary>
        /// <param name="usuario"><c>Usuario</c> que será analisado</param>.
        /// <returns>Retorna <c>error</c></returns>
        public static bool VerificarCamposUsuario(UsuarioModel usuario) =>
            usuario.usuario.Length == 0 || usuario.senha.Length == 0 || usuario == null;
        
        public static bool VerificarDataGrid(DataGridView dataGridView) => dataGridView.Rows.Count == 0;

        /// <summary>
        /// Verifica se o sistema usado é o Windows 10
        /// </summary>
        /// <returns><c>isWin10</c></returns>
        public static bool IsWin10()
        {
            string so = null;

            using (ManagementObjectSearcher searcher = new("SELECT * FROM Win32_OperatingSystem"))
                foreach (var infos in searcher.Get()) so = infos["Caption"].ToString();

            return so.Contains("Windows 10");
        }

        /// <summary>
        /// Verifica se o banco de dados está sincronizado com o OneDrive
        /// </summary>
        /// <param name="directoryInfo"></param>
        /// <returns><c>exists</c></returns>
        public static bool HasSyncOneDrive(DirectoryInfo directoryInfo) =>
            directoryInfo.FullName.Contains("OneDrive") && 
                   directoryInfo.GetFiles("*.mdf", SearchOption.AllDirectories).Length >= 1 &&
                   AppConfigurationManager.configuration.database.DbEngine == TipoDatabase.OneDrive;

        /// <summary>
        /// Verifica se há um usuario logado
        /// </summary>
        /// <returns><c>exists</c></returns>
        public static bool VerificarUsuarioLogado()
        {
            bool usuarioValido;

            if (File.Exists(Consts.FILE_FULL_NAME))
            {
                usuarioValido = UserInfo.UserNowInstance.userName != "placeholder" &&
                    !string.IsNullOrEmpty(UserInfo.UserNowInstance.userName);
            }
            else usuarioValido = false;

            return usuarioValido;
        }

        /// <summary>
        /// Verifica se o arquivo de configuração existe
        /// </summary>
        /// <returns><c>exists</c></returns>
        public static bool VerificarConfiguracoes() => File.Exists(Consts.CONFIGURATION_PATH);

        /// <summary>
        /// Verifica se o usuario é ADM
        /// </summary>
        /// <returns>isAdm</returns>
        public static bool VerificarAdmin(UsuarioModel infoUser) => 
            infoUser.id == 1 && infoUser.usuario == "admin" && infoUser.tipo == TipoUsuario.ADM;

        #region Verificar strings
        /// <summary>
        /// Verifica se <c>string.IsNullOrEmpty(valor1)</c>
        /// </summary>
        /// <param name="valor1">Valor que será verificado</param>
        /// <returns>Retorna <c>error</c></returns>
        public static bool VerificarStrings(string valor1) => string.IsNullOrEmpty(valor1);
        public static bool VerificarStrings(string valor1, string valor2) => string.IsNullOrEmpty(valor1) || string.IsNullOrEmpty(valor2);
        public static bool VerificarStrings(string valor1, string valor2, string valor3) => string.IsNullOrEmpty(valor1) || string.IsNullOrEmpty(valor2) || string.IsNullOrEmpty(valor3);
        #endregion
    }
}
