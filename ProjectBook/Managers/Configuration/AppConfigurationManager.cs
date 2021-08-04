using System;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.Hosting;
using ProjectBook.Managers.Configuration.Sections;
using System.Text.Json;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace ProjectBook.Managers.Configuration
{
    public static class AppConfigurationManager
    {
        private static IConfigurationRoot configurationRoot {get; set;}
        public static void CreateHostBuilder()
        {
            Host.CreateDefaultBuilder()
            .ConfigureAppConfiguration((hostingContext, configuration) =>
            {
                configuration.Sources.Clear();

                IHostEnvironment hostEnvironment = hostingContext.HostingEnvironment;

                configuration.AddJsonFile(Consts.CONFIGURATION_PATH, true, true);

                configurationRoot = configuration.Build();
            }).Build();
        }
        public static async Task SerializeConfiguration()
        {
            PrinterConfiguration printerConfigurationModel = new()
            {
                PreviewPrinter = false,
                ShowId = false
            };
            FormattingConfiguration formattingConfigurationModel = new()
            {
                FormatClient = false,
                FormatBook = false
            };
            RentingConfiguration rentingConfigurationModel = new()
            {
                UpdateRentStatus = true
            };
            TelemetryConfiguration telemetryConfigurationModel = new()
            {
                UseTelemetry = true
            };
            DatabaseConfiguration databaseConfigurationModel = new()
            {
                DbEngine = Tipos.TipoDatabase.SqlServerLocalDb,
                DbFolder = "",
                SqlConnectionString = ""
            };

            StringBuilder stringBuilder = new();
            stringBuilder.Append(JsonSerializer.Serialize(printerConfigurationModel));
            stringBuilder.Append(JsonSerializer.Serialize(formattingConfigurationModel));
            stringBuilder.Append(JsonSerializer.Serialize(rentingConfigurationModel));
            stringBuilder.Append(JsonSerializer.Serialize(telemetryConfigurationModel));
            stringBuilder.Append(JsonSerializer.Serialize(databaseConfigurationModel));

            await File.WriteAllTextAsync(Consts.CONFIGURATION_PATH, stringBuilder.ToString());
        }

        #region ConfigurationSections
        private static PrinterConfiguration printer;
        public static PrinterConfiguration printerConfiguration
        {
            get
            {
                printer = new();
                if(printer == null)
                {
                    configurationRoot.GetSection(nameof(PrinterConfiguration))
                    .Bind(printer);
                }
                return printer;
            }
            set => printer = value;
        }

        private static FormattingConfiguration formatting;
        public static FormattingConfiguration formattingConfiguration
        {
            get
            {
                if(formatting == null)
                {
                    formatting = new();
                    configurationRoot.GetSection(nameof(FormattingConfiguration))
                    .Bind(formatting);
                }
                return formatting;
            }
            set => formatting = value;
        }

        private static RentingConfiguration renting;
        public static RentingConfiguration rentingConfiguration
        {
            get
            {
                renting = new();
                if(renting == null)
                {
                    configurationRoot.GetSection(nameof(RentingConfiguration))
                    .Bind(renting);
                }
                return renting;
            }
            set => renting = value;
        }

        private static TelemetryConfiguration telemetry;
        public static TelemetryConfiguration TelemetryConfiguration
        {
            get
            {
                if(telemetry == null)
                {
                    telemetry = new();
                    configurationRoot.GetSection(nameof(TelemetryConfiguration))
                    .Bind(telemetry);
                }
                return telemetry;
            }
            set => telemetry = value;
        }

        private static DatabaseConfiguration database;
        public static DatabaseConfiguration databaseConfiguration
        {
            get
            {
                if(database == null)
                {
                    database = new();
                    configurationRoot.GetSection(nameof(DatabaseConfiguration))
                    .Bind(database);
                }
                return database;
            }
            set => database = value;
        }
        #endregion

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
