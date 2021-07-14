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
using ProjectBook.AppInsight;

namespace ProjectBook
{
    static class AppManager
    {
        private static readonly string[] FONTS_DOWNLOAD = 
            { "Lato-Bold.ttf", "Montserrat-ExtraBold.ttf", "Montserrat-ExtraLight.ttf" };
        private static readonly string FONTS_FOLDER = Application.StartupPath + @"\font";
        private static readonly string URI_DOWNLAD_FONTS = "https://github.com/LuanRoger/ProjectBook/raw/master/ProjectBook/assets/fontes/";

        public static void ReiniciarPrograma()
        {
            AppInsight.AppInsightMetrics.FlushTelemetry();

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
        public static void ProcurarAtualizacoes()
        {
            AutoUpdater.ShowRemindLaterButton = false;

            AutoUpdater.Start(AppConfigurationManager.updateFileServer,
                Assembly.GetExecutingAssembly());
        }
        public static void GiveAdm()
        {
            AppConfigurationManager.tipoUsuario = Tipos.TipoUsuário.ADM;
        }
        public static void RemoveAdm()
        {
            AppConfigurationManager.tipoUsuario = Tipos.TipoUsuário.USU;
        }
        public static void UpdateUserInfo()
        {
            UsuarioDb usuarioDb = new();

            AppConfigurationManager.tipoUsuario = 
                usuarioDb.ReceberTipoUsuario(AppConfigurationManager.usuarioLogado).ToString() == "ADM" ? 
                Tipos.TipoUsuário.ADM : Tipos.TipoUsuário.USU;

            AppInsightMetrics.SendUserInfo(
                AppConfigurationManager.idUsuario,
                AppConfigurationManager.usuarioLogado,
                AppConfigurationManager.tipoUsuario.ToString());
        }
    }
    public class Consts
    {
        public const int SPLASH_SCREEN_LOADTIME = 2500;
    }
}
