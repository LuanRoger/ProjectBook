using ProjectBook.Model.Configuration.Sections;
using SerializedConfig.SectionsAttribute;
using SerializedConfig.Types.Model;

namespace ProjectBook.Model.Configuration
{
    [ConfigSection]
    public class ConfigurationModel : IConfigurationModel
    {
        public PrinterSection printer { get; set; }
        public FormatingSection formating { get; set; }
        public RentingSection renting { get; set; }
        public TelemetrySection telemetry { get; set; }
        public DatabaseSection database { get; set; }
        public LoginPreferencesSection login { get; set; }
    }
}
