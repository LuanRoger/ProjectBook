using System;
using System.Collections.Generic;
using System.Net;
using System.IO;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;
using System.Threading;
using System.Globalization;
using ProjectBook.Properties.Languages;
using System.Configuration;
using ProjectBook.GUI;
using AutoUpdaterDotNET;

namespace ProjectBook
{
    static class AppManager
    {
        private static readonly string[] FONTS_DOWNLOAD = 
            new string[] { "Lato-Bold.ttf", "Montserrat-ExtraBold.ttf", "Montserrat-ExtraLight.ttf" };
        private static readonly string FONTS_FOLDER = Application.StartupPath + @"\font";
        private static readonly string URI_ATUALIZACAO = "https://github.com/LuanRoger/ProjectBook/raw/master/ProjectBook/assets/fontes/";

        public static void ReiniciarPrograma()
        {
            Process.Start(Application.StartupPath + Assembly.GetExecutingAssembly().GetName().Name + ".exe");
            Process.GetCurrentProcess().Kill();
        }

        public static void DownloadFonts()
        {
            Directory.CreateDirectory(FONTS_FOLDER);

            using WebClient webClient = new WebClient();
            foreach (string font in FONTS_DOWNLOAD)
            {
                webClient.DownloadFile(URI_ATUALIZACAO + font,
                @$"{FONTS_FOLDER}\{font}");
            }
        }

        public static void SetLanguage(LangCode langCode)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo(langCode.ToString());
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(langCode.ToString());

            Configuracoes.config.AppSettings.Settings["language"].Value = langCode.ToString();
        }

        public static void ProcurarAtualizacoes()
        {
            AutoUpdater.ShowRemindLaterButton = false;

            AutoUpdater.Start(ConfigurationManager.AppSettings["updateFileServer"],
                Assembly.GetExecutingAssembly());
        }

        public static void UnlogUser()
        {
            Configuracoes.config.AppSettings.Settings["usuarioLogado"].Value = string.Empty;
            Configuracoes.config.Save();

            ReiniciarPrograma();
        }
    }

    public static class Consts
    {
        public const int SPLASH_SCREEN_LOADTIME = 2500;
    }
}
