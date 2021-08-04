using System;

namespace ProjectBook
{
    public static class Consts
    {
        public const int SPLASH_SCREEN_LOADTIME = 2500;

        public static string APPLOCAL_FOLDER = 
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\LuanRoger\ProjectBook\";

        public const string USER_FORMAT = ".puf";
        public const string USER_FILE_NAME = "UserInfo";
        public static readonly string FILE_FULL_NAME = APPLOCAL_FOLDER + USER_FILE_NAME + USER_FORMAT;

        public static readonly string[] FONTS_DOWNLOAD = 
            { "Lato-Bold.ttf", "Montserrat-ExtraBold.ttf", "Montserrat-ExtraLight.ttf" };

        public static readonly string FONTS_FOLDER = APPLOCAL_FOLDER + @"font\";
        public static readonly string URI_DOWNLAD_FONTS = "https://github.com/LuanRoger/ProjectBook/raw/master/ProjectBook/assets/fontes/";
        public static readonly string FONT_MONTSERRAT_EXTRABOLD = FONTS_FOLDER + "Montserrat-ExtraBold.ttf";
        public static readonly string FONT_MONTSERRAT_EXTRALIGHT = FONTS_FOLDER + "Montserrat-ExtraLight.ttf";
        public static readonly string FONT_LATO_BOLD = FONTS_FOLDER + "Lato-Bold.ttf";

        public const string YAML_UPDATER_SERVER_URL = "https://raw.githubusercontent.com/LuanRoger/ProjectBook/dev/update.yaml";

        public static readonly string PASTA_APLICACAO_ONEDRIVE = 
            Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\OneDrive\ProjectBook";

        public static readonly string CONFIGURATION_PATH = APPLOCAL_FOLDER + @"appsettings.json";
    }
}
