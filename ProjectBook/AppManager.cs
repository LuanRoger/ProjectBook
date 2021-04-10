using System;
using System.Collections.Generic;
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
        private static readonly string pastaFontes = Application.StartupPath + @"\font";

        public static void ReiniciarPrograma()
        {
            Process.Start(Application.StartupPath + Assembly.GetExecutingAssembly().GetName().Name + ".exe");
            Process.GetCurrentProcess().Kill();
        }

        public static void DownloadFonts()
        {
            Directory.CreateDirectory(pastaFontes);

            using (WebClient webClient = new WebClient())
            {
                foreach (string font in fontsParaBaixar)
                {
                    webClient.DownloadFile("https://github.com/LuanRoger/ProjectBook/raw/master/ProjectBook/assets/fontes/" + font,
                    @$"{pastaFontes}\{font}");
                }
            }
        }
    }
}
