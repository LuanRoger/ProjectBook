namespace ProjectBook.Managers.Configuration.Sections
{
    public class DatabaseSection
    {
        public Tipos.TipoDatabase DbEngine { get; set; }
        public string DbFolder { get; set; }
        public string SqlConnectionString { get; set; }
    }
}