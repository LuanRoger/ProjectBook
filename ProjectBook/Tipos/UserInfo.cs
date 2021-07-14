using System;
using System.IO;

namespace ProjectBook.Tipos
{
    [Serializable]
    // Não instancie isso
    public class UserInfo
    {
        private static UserInfo UserNow { get; set; }
        public static UserInfo UserNowInstance
        {
            get
            {
                if(UserNow == null)
                {
                    UserNowInstance = new UserInfo()
                    {
                        idUsuario = 0,
                        userName = "placeholder",
                        tipoUsuario = TipoUsuario.USU
                    };
                }
                return UserNow;
            }
            set => UserNow = value;
        }
        public static void SetUser(int idUsuario, string userName, TipoUsuario tipoUsuario)
        {
            UserNowInstance = new UserInfo
            {
                idUsuario = idUsuario,
                userName = userName,
                tipoUsuario = tipoUsuario
            };
        }
        public int idUsuario { get; set; }
        public string userName { get; set; }
        public TipoUsuario tipoUsuario { get; set; }

        public static void SerializeUserInstance()
        {
            BinaryWriter binaryWriter = new(File.Open(Consts.FILE_FULL_NAME, FileMode.Create));

            binaryWriter.Write(UserNow.idUsuario);
            binaryWriter.Write(UserNow.userName);
            binaryWriter.Write((int)UserNow.tipoUsuario);

            binaryWriter.Close();
        }
        public static void DeserializeUserInstance()
        {
            BinaryReader binaryReader = new(File.Open(Consts.FILE_FULL_NAME, FileMode.Open));
            
            UserNow = new()
            {
                idUsuario = binaryReader.ReadInt32(),
                userName = binaryReader.ReadString(),
                tipoUsuario = (TipoUsuario)binaryReader.ReadInt32()
            };
        }
    }
}
