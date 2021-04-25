using System;
using System.Net;
using System.IO;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;
using AutoUpdaterDotNET;
using System.Configuration;

namespace ProjectBook
{
    static class AppManager
    {
        private static readonly string[] FONTS_DOWNLOAD = 
            new string[] { "Lato-Bold.ttf", "Montserrat-ExtraBold.ttf", "Montserrat-ExtraLight.ttf" };
        private static readonly string FONTS_FOLDER = Application.StartupPath + @"\font";
        private static readonly string URI_DOWNLADFONTS = "https://github.com/LuanRoger/ProjectBook/raw/master/ProjectBook/assets/fontes/";

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

            using WebClient webClient = new WebClient();
            foreach (string font in FONTS_DOWNLOAD)
            {
                webClient.DownloadFile(URI_DOWNLADFONTS + font,
                @$"{FONTS_FOLDER}\{font}");
            }
        }
        public static void ProcurarAtualizacoes()
        {
            AutoUpdater.ShowRemindLaterButton = false;

            AutoUpdater.Start(ConfigurationManager.AppSettings["updateFileServer"],
                Assembly.GetExecutingAssembly());
        }
    }

    public static class Consts
    {
        public const int SPLASH_SCREEN_LOADTIME = 2500;
    }
}
