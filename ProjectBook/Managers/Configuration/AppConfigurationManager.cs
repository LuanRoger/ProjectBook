using System.Text.Json;
using System.IO;

namespace ProjectBook.Managers.Configuration
{
    public static class AppConfigurationManager
    {
        private static ConfigurationModel configurationModel {get; set;}
        public static ConfigurationModel configuration
        {
            get
            {
                if(configurationModel == null) Reload();
                return configurationModel;
            }
            set
            {
                configurationModel = value;
                SaveConfiguration();
            }
        }

        public static void Reload() =>
            configurationModel = JsonSerializer.Deserialize<ConfigurationModel>(File.ReadAllText(Consts.CONFIGURATION_PATH));
        public static void CreateConfigurationFile()
        {
            if(Verificadores.VerificarConfiguracoes()) return;

            ConfigurationModel configurationModel = new()
            {
                PreviewPrinter = false,
                ShowId = false,
                FormatClient = false,
                FormatBook = false,
                UpdateRentStatus = true,
                UseTelemetry = true,
                DbEngine = Tipos.TipoDatabase.SqlServerLocalDb,
                DbFolder = string.Empty,
                SqlConnectionString = string.Empty
            };

            File.WriteAllText(Consts.CONFIGURATION_PATH, JsonSerializer.Serialize<ConfigurationModel>(configurationModel));
        }
        private static void SaveConfiguration() =>
            File.WriteAllText(Consts.CONFIGURATION_PATH, JsonSerializer.Serialize(configurationModel));
    }
}
