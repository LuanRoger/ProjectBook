using System;

namespace ProjectBook.Managers.Configuration.Extensions
{
    public static class ConfigurationUtilities
    {
        private static bool ToBool(this string toConvert) => toConvert == "1" ? true : false;
        private static string ToStringBool(this bool toConvert) => toConvert ? "1" : "0";

        private static Tipos.TipoUsuario ToTipoUsuário(this string toConvert) =>
            toConvert switch
            {
                "ADM" => Tipos.TipoUsuario.ADM,
                "USU" => Tipos.TipoUsuario.USU,
                _ => throw new Exception("Isto não é um TipoUsuário")
            };
        private static string TipoUsuárioToString(this Tipos.TipoUsuario tipoUsuário) =>
            tipoUsuário switch
            {
                Tipos.TipoUsuario.ADM => "ADM",
                Tipos.TipoUsuario.USU => "USU",
                _ => throw new Exception("Isto não é um TipoUsuário")
            };

        private static Tipos.TipoDatabase ToDatabaseType(this string toConvert) =>
            toConvert switch
            {
                "OneDrive" => Tipos.TipoDatabase.OneDrive,
                "SqlServerLocalDb" => Tipos.TipoDatabase.SqlServerLocalDb,
                "SqlServerExpress" => Tipos.TipoDatabase.SqlServerExpress,
                _ => throw new Exception("Isto não é um DatabaseType"),
            };
        private static string DatabaseTypeToString(this Tipos.TipoDatabase databaseType) =>
            databaseType switch
            {
                Tipos.TipoDatabase.OneDrive => "OneDrive",
                Tipos.TipoDatabase.SqlServerLocalDb => "SqlServerLocalDb",
                Tipos.TipoDatabase.SqlServerExpress => "SqlServerExpress",
                _ => throw new Exception("Isto não é um DatabaseType"),
            };
    }
}
