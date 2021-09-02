using ProjectBook.Managers.Configuration.Sections;
using SerializedConfig.Types;

namespace ProjectBook.Managers.Configuration
{
    public record ConfigurationModel : IConfigurationModel
    {
        [Section]
        public PrinterSection printer { get; set; }
        [Section]
        public FormatingSection formating { get; set; }
        [Section]
        public RentingSection renting { get; set; }
        [Section]
        public TelemetrySection telemetry { get; set; }
        [Section]
        public DatabaseSection database { get; set; }
    }
}
