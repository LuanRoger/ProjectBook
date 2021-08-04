namespace ProjectBook.Managers.Configuration
{
    public record ConfigurationModel
    {
        #region Printer
        public bool PreviewPrinter { get; set; }
        public bool ShowId { get; set; }
        #endregion

        #region Formating
        public bool FormatClient { get; set; }
        public bool FormatBook { get; set; }
        #endregion

        #region Renting
        public bool UpdateRentStatus { get; set; }
        #endregion

        #region Telemetry
        public bool UseTelemetry { get; set; }
        #endregion

        #region DatabaseSection
        public Tipos.TipoDatabase DbEngine { get; set; }
        public string DbFolder { get; set; }
        public string SqlConnectionString { get; set; }
        #endregion
    }
}
