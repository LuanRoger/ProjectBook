using System;
using System.Net;
using System.IO;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;
using ProjectBook.DB.SqlServerExpress;
using ProjectBook.AppInsight;
using ProjectBook.Tipos;

namespace ProjectBook.Managers
{
    static class AppManager
    {
        public static void ReiniciarPrograma()
        {
            AppInsightMetrics.FlushTelemetry();
            UserInfo.SerializeUserInstance();

            Process.Start(Application.StartupPath + Assembly.GetExecutingAssembly().GetName().Name + ".exe");
            Process.GetCurrentProcess().Kill();
        }

        public static void DownloadFonts()
        {
            if (File.Exists(@$"{Consts.FONTS_FOLDER}\{Consts.FONTS_DOWNLOAD[0]}") && 
                File.Exists(@$"{Consts.FONTS_FOLDER}\{Consts.FONTS_DOWNLOAD[1]}") &&
                File.Exists(@$"{Consts.FONTS_FOLDER}\{Consts.FONTS_DOWNLOAD[2]}")) return;

            Directory.CreateDirectory(Consts.FONTS_FOLDER);

            using WebClient webClient = new();
            foreach (string font in Consts.FONTS_DOWNLOAD)
            {
                webClient.DownloadFile(new Uri(Consts.URI_DOWNLAD_FONTS + font),
                @$"{Consts.FONTS_FOLDER}\{font}");
            }
        }

        public static void CriarPastaDataApp()
        {
            if(!Directory.Exists(Consts.APPLOCAL_FOLDER)) Directory.CreateDirectory(Consts.APPLOCAL_FOLDER);
        }

        public static void GiveAdm() =>
            UserInfo.UserNowInstance.tipoUsuario = TipoUsuario.ADM;
        public static void RemoveAdm() =>
            UserInfo.UserNowInstance.tipoUsuario = TipoUsuario.USU;

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
}
