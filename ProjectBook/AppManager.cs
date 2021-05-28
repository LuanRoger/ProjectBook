using System;
using System.Net;
using System.IO;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;
using AutoUpdaterDotNET;
using System.Configuration;
using ProjectBook.DB.SqlServerExpress;
using ProjectBook.GUI;

namespace ProjectBook
{
    static class AppManager
    {
        private static readonly string[] FONTS_DOWNLOAD = 
            { "Lato-Bold.ttf", "Montserrat-ExtraBold.ttf", "Montserrat-ExtraLight.ttf" };
        private static readonly string FONTS_FOLDER = Application.StartupPath + @"\font";
        private static readonly string URI_DOWNLAD_FONTS = "https://github.com/LuanRoger/ProjectBook/raw/master/ProjectBook/assets/fontes/";

        private static readonly string[] SCRIPTS_DOWNLOAD = {"startdb_instance.ps1"};
        private static readonly string SCRIPTS_FOLDER = Application.StartupPath + @"\scripts";
        private static readonly string URI_DOWNLOAD_SCRIPTS = "https://github.com/LuanRoger/ProjectBook/raw/master/scripts/";

        public static void ReiniciarPrograma()
        {
            Process.Start(Application.StartupPath + Assembly.GetExecutingAssembly().GetName().Name + ".exe");
            Process.GetCurrentProcess().Kill();
        }

        public static void DownloadFonts()
        {
            if (File.Exists(@$"{FONTS_FOLDER}\{FONTS_DOWNLOAD[0]}") && File.Exists(@$"{FONTS_FOLDER}\{FONTS_DOWNLOAD[1]}") &&
                File.Exists(@$"{FONTS_FOLDER}\{FONTS_DOWNLOAD[2]}")) return;
            Directory.CreateDirectory(FONTS_FOLDER);

            using WebClient webClient = new();
            foreach (string font in FONTS_DOWNLOAD)
            {
                webClient.DownloadFile(new Uri(URI_DOWNLAD_FONTS + font),
                @$"{FONTS_FOLDER}\{font}");
            }
        }
        public static void DownloadScripts()
        {
            if (File.Exists(@$"{SCRIPTS_FOLDER}\{SCRIPTS_DOWNLOAD[0]}")) return;
            Directory.CreateDirectory(SCRIPTS_FOLDER);

            using WebClient webClient = new();
            foreach (var script in SCRIPTS_DOWNLOAD)
            {
                webClient.DownloadFile(new Uri(URI_DOWNLOAD_SCRIPTS + script),
                    @$"{SCRIPTS_FOLDER}\{script}");
            }
        }
        public static void ProcurarAtualizacoes()
        {
            AutoUpdater.ShowRemindLaterButton = false;

            AutoUpdater.Start(ConfigurationManager.AppSettings["updateFileServer"],
                Assembly.GetExecutingAssembly());
        }
        public static void GiveAdm()
        {
            Configuracoes.config.AppSettings.Settings["tipoUsuario"].Value = Tipos.TipoUsuário.ADM.ToString();
            Configuracoes.config.Save();
            ConfigurationManager.RefreshSection("appSettings");
        }
        public static void RemoveAdm()
        {
            Configuracoes.config.AppSettings.Settings["tipoUsuario"].Value = Tipos.TipoUsuário.USU.ToString();
            Configuracoes.config.Save();
            ConfigurationManager.RefreshSection("appSettings");
        }
        public static void UpdateUserInfo()
        {
            Configuracoes.config.AppSettings.Settings["tipoUsuario"].Value = 
                new UsuarioDb().ReceberTipoUsuario(ConfigurationManager.AppSettings["usuarioLogado"]).Rows[0][0].ToString();
            Configuracoes.config.Save();
            ConfigurationManager.RefreshSection("appSettings");
        }
    }

    public static class Consts
    {
        public const int SPLASH_SCREEN_LOADTIME = 2500;
    }
}
