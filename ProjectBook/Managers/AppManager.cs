using System;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
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

        public static async Task DownloadFonts()
        {
            if (File.Exists(@$"{Consts.FONTS_FOLDER}\{Consts.FONTS_DOWNLOAD[0]}") && 
                File.Exists(@$"{Consts.FONTS_FOLDER}\{Consts.FONTS_DOWNLOAD[1]}") &&
                File.Exists(@$"{Consts.FONTS_FOLDER}\{Consts.FONTS_DOWNLOAD[2]}"))
                return;

            Directory.CreateDirectory(Consts.FONTS_FOLDER);

            using HttpClient httpClient = new();
            foreach (string font in Consts.FONTS_DOWNLOAD)
            {
                HttpResponseMessage response = await httpClient.GetAsync(new Uri(Consts.URI_DOWNLAD_FONTS + font));

                await using FileStream fileStream = new(@$"{Consts.FONTS_FOLDER}\{font}", FileMode.Create);
                await response.Content.CopyToAsync(fileStream);
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
            UserInfo.UserNowInstance.tipoUsuario = 
                UsuarioDb.VerTipoUsuario(UserInfo.UserNowInstance.userName);

            AppInsightMetrics.SendUserInfo(
                UserInfo.UserNowInstance.idUsuario,
                UserInfo.UserNowInstance.userName,
                UserInfo.UserNowInstance.tipoUsuario.ToString());
        }
    }
}
