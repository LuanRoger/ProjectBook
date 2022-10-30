using ProjectBook.Model.Enums;

namespace ProjectBook.Model.Configuration.Sections
{
    public class DatabaseSection
    {
        public TipoDatabase DbEngine { get; set; }
        public string DbFolder { get; set; }
        public string SqlConnectionString { get; set; }
    }
}