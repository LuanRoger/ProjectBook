namespace ProjectBook.Managers.Configuration.Sections
{
    public record DatabaseSection
    {
        public Tipos.TipoDatabase DbEngine { get; set; }
        public string DbFolder { get; set; }
        public string SqlConnectionString { get; set; }
    }
}