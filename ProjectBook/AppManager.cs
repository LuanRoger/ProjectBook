using System;
using System.Net;
using System.IO;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;

namespace ProjectBook
{
    static class AppManager
    {
        private static readonly string[] fontsParaBaixar = 
            new string[] { "Lato-Bold.ttf", "Montserrat-ExtraBold.ttf", "Montserrat-ExtraLight.ttf" };
<<<<<<< HEAD
        private static readonly string FONTS_FOLDER = Application.StartupPath + @"\font";
        private static readonly string URI_DOWNLADFONTS = "https://github.com/LuanRoger/ProjectBook/raw/master/ProjectBook/Properties/assets/fontes/";
=======
        private static readonly string pastaFontes = Application.StartupPath + @"\font";
>>>>>>> parent of e20e8c2 (v0.5.4-beta)

        public static void ReiniciarPrograma()
        {
            Process.Start(Application.StartupPath + Assembly.GetExecutingAssembly().GetName().Name + ".exe");
            Process.GetCurrentProcess().Kill();
        }

        public static void DownloadFonts()
        {
<<<<<<< HEAD
            if (File.Exists(@$"{FONTS_FOLDER}\{FONTS_DOWNLOAD[0]}") && File.Exists(@$"{FONTS_FOLDER}\{FONTS_DOWNLOAD[1]}") &&
                File.Exists(@$"{FONTS_FOLDER}\{FONTS_DOWNLOAD[2]}")) return;
            Directory.CreateDirectory(FONTS_FOLDER);
=======
            Directory.CreateDirectory(pastaFontes);
>>>>>>> parent of e20e8c2 (v0.5.4-beta)

            using WebClient webClient = new WebClient();
            foreach (string font in FONTS_DOWNLOAD)
            {
<<<<<<< HEAD
                webClient.DownloadFile(URI_DOWNLADFONTS + font,
                @$"{FONTS_FOLDER}\{font}");
=======
                foreach (string font in fontsParaBaixar)
                {
                    webClient.DownloadFile("https://github.com/LuanRoger/ProjectBook/raw/master/ProjectBook/assets/fontes/" + font,
                    @$"{pastaFontes}\{font}");
                }
>>>>>>> parent of e20e8c2 (v0.5.4-beta)
            }
        }
    }

    public static class Consts
    {
        public const int SPLASH_SCREEN_LOADTIME = 2500;
    }
}
