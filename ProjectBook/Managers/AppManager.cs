using System;
using System.Net;
using System.IO;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;
using AutoUpdaterDotNET;
using ProjectBook.DB.SqlServerExpress;
using ProjectBook.AppInsight;
using ProjectBook.Tipos;

namespace ProjectBook.Managers
{
    static class AppManager
    {
        private static readonly string[] FONTS_DOWNLOAD = 
            { "Lato-Bold.ttf", "Montserrat-ExtraBold.ttf", "Montserrat-ExtraLight.ttf" };
        private static readonly string FONTS_FOLDER = Application.StartupPath + @"\font";
        private static readonly string URI_DOWNLAD_FONTS = "https://github.com/LuanRoger/ProjectBook/raw/master/ProjectBook/assets/fontes/";

        public static void ReiniciarPrograma()
        {
            AppInsightMetrics.FlushTelemetry();
            UserInfo.SerializeUserInstance();

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
            UserInfo.UserNowInstance.tipoUsuario = TipoUsuario.ADM;
        }
        public static void RemoveAdm()
        {
            UserInfo.UserNowInstance.tipoUsuario = TipoUsuario.USU;
        }

        public static void LoadUser()
        {
            if(File.Exists(Consts.FILE_FULL_NAME)) UserInfo.DeserializeUserInstance();
        }
        public static void UpdateUserInfo()
        {
            UsuarioDb usuarioDb = new();
            
            UserInfo.UserNowInstance.tipoUsuario = 
                usuarioDb.ReceberTipoUsuario(UserInfo.UserNowInstance.userName);

            AppInsightMetrics.SendUserInfo(
                UserInfo.UserNowInstance.idUsuario,
                UserInfo.UserNowInstance.userName,
                UserInfo.UserNowInstance.tipoUsuario.ToString());
        }
    }
    public class Consts
    {
        public const int SPLASH_SCREEN_LOADTIME = 2500;

        public const string USER_FORMAT = ".puf";
        public const string USER_FILE_NAME = "UserInfo";
        public const string FILE_FULL_NAME = USER_FILE_NAME + USER_FORMAT;

        public static readonly string PASTA_APLICACAO_ONEDRIVE = 
            Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\OneDrive\ProjectBook";
    }
}
