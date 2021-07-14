using System;
using System.Configuration;

namespace ProjectBook
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
        public static string idUsuario
        {
            get => ConfigurationManager.AppSettings["idUsuario"];
            set
            {
                config.AppSettings.Settings["idUsuario"].Value = value;
                SaveConfig();
            }
        }
        public static string usuarioLogado
        {
            get => ConfigurationManager.AppSettings["usuarioLogado"];
            set
            {
                config.AppSettings.Settings["usuarioLogado"].Value = value;
                SaveConfig();
            }
        }
        public static Tipos.TipoUsuário tipoUsuario
        {
            get => ConfigurationManager.AppSettings["tipoUsuario"].ToTipoUsuário();
            set
            {
                config.AppSettings.Settings["tipoUsuario"].Value = value.TipoUsuárioToString();
                SaveConfig();
            }
        }
        public static Tipos.DatabaseType dbPadrao
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
        public static string updateFileServer
        {
            get => ConfigurationManager.AppSettings["updateFileServer"];
            set
            {
                config.AppSettings.Settings["updateFileServer"].Value = value;
                SaveConfig();
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

        private static Tipos.TipoUsuário ToTipoUsuário(this string toConvert) =>
            toConvert switch
            {
                "ADM" => Tipos.TipoUsuário.ADM,
                "USU" => Tipos.TipoUsuário.USU,
                _ => throw new Exception("Isto não é um TipoUsuário")
            };
        private static string TipoUsuárioToString(this Tipos.TipoUsuário tipoUsuário) =>
            tipoUsuário switch
            {
                Tipos.TipoUsuário.ADM => "ADM",
                Tipos.TipoUsuário.USU => "USU",
                _ => throw new Exception("Isto não é um TipoUsuário")
            };

        private static Tipos.DatabaseType ToDatabaseType(this string toConvert) =>
            toConvert switch
            {
                "OneDrive" => Tipos.DatabaseType.OneDrive,
                "SqlServerLocalDb" => Tipos.DatabaseType.SqlServerLocalDb,
                "SqlServerExpress" => Tipos.DatabaseType.SqlServerExpress,
                _ => throw new Exception("Isto não é um DatabaseType"),
            };
        private static string DatabaseTypeToString(this Tipos.DatabaseType databaseType) =>
            databaseType switch
            {
                Tipos.DatabaseType.OneDrive => "OneDrive",
                Tipos.DatabaseType.SqlServerLocalDb => "SqlServerLocalDb",
                Tipos.DatabaseType.SqlServerExpress => "SqlServerExpress",
                _ => throw new Exception("Isto não é um DatabaseType"),
            };
        #endregion
    }
}
