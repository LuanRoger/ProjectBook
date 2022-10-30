using ProjectBook.Model.Configuration;
using ProjectBook.Model.Enums;
using SerializedConfig;
using SerializedConfig.Types.Serialization;

namespace ProjectBook.Controllers
{
    public class ConfigurationController
    {
        private ConfigManager<ConfigurationModel> configManager { get; }
        public ConfigurationModel configuration => configManager.configuration;

        public ConfigurationController()
        {
            configManager = new(Consts.CONFIGURATION_PATH, SerializationFormat.Json, CreateDefaultConfiguration());
        }
        
        public ConfigurationModel CreateDefaultConfiguration() => new()
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
        
        public void SaveConfig() => configManager.Save();
        public async Task LoadConfig()
        {
            if(!Verificadores.VerificarConfiguracoes())
            {
                await configManager.SaveAsync();
                return;
            }
            
            await configManager.LoadAsync();
        }
        public void ResetConfig() => configManager.Reset();
    }
}
