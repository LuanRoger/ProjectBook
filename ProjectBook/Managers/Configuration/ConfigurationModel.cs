using ProjectBook.Managers.Configuration.Sections;
using SerializedConfig.SectionsAtribute;
using SerializedConfig.Types;

namespace ProjectBook.Managers.Configuration
{
    [SectionClass]
    public record ConfigurationModel : IConfigurationModel
    {
        public PrinterSection printer { get; set; }
        public FormatingSection formating { get; set; }
        public RentingSection renting { get; set; }
        public TelemetrySection telemetry { get; set; }
        public DatabaseSection database { get; set; }
    }
}
