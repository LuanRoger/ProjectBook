using System;
using System.Configuration;

namespace ProjectBook.Managers
{
    public static class AppConfigurationManager
    {
        private static Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

        public static bool visualizarImpressao
        {
            get => ConfigurationManager.AppSettings["visualizarImpressao"].ToBool();
            set
            {
                config.AppSettings.Settings["visualizarImpressao"].Value = value.ToStringBool();
                SaveConfig();
            }
        }
        public static string tituloFolha
        {
            get => ConfigurationManager.AppSettings["tituloFolha"];
            set
            {
                config.AppSettings.Settings["tituloFolha"].Value = value;
                SaveConfig();
            }
        }
        public static bool alinhamentoTitulo
        {
            get => ConfigurationManager.AppSettings["alinhamentoTitulo"].ToBool();
            set
            {
                config.AppSettings.Settings["alinhamentoTitulo"].Value = value.ToStringBool();
                SaveConfig();
            }
        }
        public static string subtituloFolha
        {
            get => ConfigurationManager.AppSettings["subtituloFolha"];
            set
            {
                config.AppSettings.Settings["subtituloFolha"].Value = value;
                SaveConfig();
            }
        }
        public static string rodape
        {
            get => ConfigurationManager.AppSettings["rodape"];
            set
            {
                config.AppSettings.Settings["rodape"].Value = value;
                SaveConfig();
            }
        }
        public static bool alinhamentoRodape
        {
            get => ConfigurationManager.AppSettings["alinhamentoRodape"].ToBool();
            set
            {
                config.AppSettings.Settings["alinhamentoRodape"].Value = value.ToStringBool();
                SaveConfig();
            }
        }
        public static bool mostrarNumeroPaginas
        {
            get => ConfigurationManager.AppSettings["mostrarNumeroPaginas"].ToBool();
            set
            {
                config.AppSettings.Settings["mostrarNumeroPaginas"].Value = value.ToStringBool();
                SaveConfig();
            }
        }
        public static bool exibirId
        {
            get => ConfigurationManager.AppSettings["exibirId"].ToBool();
            set
            {
                config.AppSettings.Settings["exibirId"].Value = value.ToStringBool();
                SaveConfig();
            }
        }
        public static bool formatarCliente
        {
            get => ConfigurationManager.AppSettings["formatarCliente"].ToBool();
            set
            {
                config.AppSettings.Settings["formatarCliente"].Value = value.ToStringBool();
                SaveConfig();
            }
        }
        public static bool formatarLivro
        {
            get => ConfigurationManager.AppSettings["formatarLivro"].ToBool();
            set
            {
                config.AppSettings.Settings["formatarLivro"].Value = value.ToStringBool();
                SaveConfig();
            }
        }
        public static bool atualizarStatusAluguel
        {
            get => ConfigurationManager.AppSettings["atualizarStatusAluguel"].ToBool();
            set
            {
                config.AppSettings.Settings["atualizarStatusAluguel"].Value = value.ToStringBool();
                SaveConfig();
            }
        }
        public static Tipos.TipoDatabase dbPadrao
        {
            get => ConfigurationManager.AppSettings["dbPadrao"].ToDatabaseType();
            set
            {
                config.AppSettings.Settings["dbPadrao"].Value = value.DatabaseTypeToString();
                SaveConfig();
            }
        }
        public static string pastaDb
        {
            get => ConfigurationManager.AppSettings["pastaDb"];
            set
            {
                config.AppSettings.Settings["pastaDb"].Value = value;
            }
        }
        public static bool telemetry
        {
            get => ConfigurationManager.AppSettings["telemetry"].ToBool();
            set
            {
                config.AppSettings.Settings["telemetry"].Value = value.ToStringBool();
                SaveConfig();
            }
        }
        public static string SqlConnectionString
        {
            get => ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString;
            set
            {
                config.ConnectionStrings.ConnectionStrings["SqlConnectionString"].ConnectionString = value;
                SaveConfig();
            }
        }

        private static void SaveConfig()
        {
            config.Save();
            
            ConfigurationManager.RefreshSection("appSettings");
            ConfigurationManager.RefreshSection("connectionStrings");
        }

        #region Extensions
        private static bool ToBool(this string toConvert) => toConvert == "1" ? true : false;
        private static string ToStringBool(this bool toConvert) => toConvert ? "1" : "0";

        private static Tipos.TipoUsuario ToTipoUsuário(this string toConvert) =>
            toConvert switch
            {
                "ADM" => Tipos.TipoUsuario.ADM,
                "USU" => Tipos.TipoUsuario.USU,
                _ => throw new Exception("Isto não é um TipoUsuário")
            };
        private static string TipoUsuárioToString(this Tipos.TipoUsuario tipoUsuário) =>
            tipoUsuário switch
            {
                Tipos.TipoUsuario.ADM => "ADM",
                Tipos.TipoUsuario.USU => "USU",
                _ => throw new Exception("Isto não é um TipoUsuário")
            };

        private static Tipos.TipoDatabase ToDatabaseType(this string toConvert) =>
            toConvert switch
            {
                "OneDrive" => Tipos.TipoDatabase.OneDrive,
                "SqlServerLocalDb" => Tipos.TipoDatabase.SqlServerLocalDb,
                "SqlServerExpress" => Tipos.TipoDatabase.SqlServerExpress,
                _ => throw new Exception("Isto não é um DatabaseType"),
            };
        private static string DatabaseTypeToString(this Tipos.TipoDatabase databaseType) =>
            databaseType switch
            {
                Tipos.TipoDatabase.OneDrive => "OneDrive",
                Tipos.TipoDatabase.SqlServerLocalDb => "SqlServerLocalDb",
                Tipos.TipoDatabase.SqlServerExpress => "SqlServerExpress",
                _ => throw new Exception("Isto não é um DatabaseType"),
            };
        #endregion
    }
}
