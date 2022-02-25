using ProjectBook.Tipos;
using SerializedConfig;
using SerializedConfig.Types.Serialization;

namespace ProjectBook.Managers.Configuration
{
    public static class AppConfigurationManager
    {
        private static ConfigurationModel defaultConfig { get; }
        private static ConfigManager<ConfigurationModel> configManager { get; }
        public static ConfigurationModel configuration => configManager.configuration;

        static AppConfigurationManager()
        {
            defaultConfig = new()
            {
                printer = new()
                {
                    PreviewPrinter = false,
                    ShowId = false
                },
                formating = new()
                {
                    FormatClient = false,
                    FormatBook = false
                },
                renting = new()
                {
                    UpdateRentStatus = true
                },
                telemetry = new()
                {
                    UseTelemetry = true
                },
                database = new()
                {
                    DbEngine = TipoDatabase.SqlServerLocalDb,
                    DbFolder = string.Empty,
                    SqlConnectionString = string.Empty
                },
                login = new()
                {
                    keepConnected = false
                }
            };
            
            configManager = new(Consts.CONFIGURATION_PATH, SerializationFormat.Json, defaultConfig);
        }
        
        public static void SaveConfig() => configManager.Save();
        public static void LoadConfig()
        {
            if(!Verificadores.VerificarConfiguracoes())
            {
                configManager.Save();
                return;
            }
            
            configManager.Load();
        }
        public static void ResetConfig() => configManager.Reset();
    }
}
