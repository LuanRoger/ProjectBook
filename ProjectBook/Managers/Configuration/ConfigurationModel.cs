using System;
using ProjectBook.Managers.Configuration.Sections;
using SerializedConfig.SectionsAtribute;
using SerializedConfig.Types;

namespace ProjectBook.Managers.Configuration
{
    public class ConfigurationModel : IConfigurationModel
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
        [Section]
        public LoginPreferencesSection login { get; set; }
    }
}
