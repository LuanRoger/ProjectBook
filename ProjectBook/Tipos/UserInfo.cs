using System;
using System.IO;
using ProjectBook.Managers;

namespace ProjectBook.Tipos
{
    [Serializable]
    // Não instancie isso
    public class UserInfo
    {
        private static UserInfo UserNow { get; set; } // TODO - Made UsuarioModel model
        public static UserInfo UserNowInstance
        {
            get
            {
                if(UserNow == null)
                {
                    UserNowInstance = new()
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
        public int idUsuario { get; set; }
        public string userName { get; set; }
        public TipoUsuario tipoUsuario { get; set; }

        public static void SerializeUserInstance()
        {
            AppManager.CriarPastaDataApp();

            BinaryWriter binaryWriter = new(File.Open(Consts.FILE_FULL_NAME, FileMode.OpenOrCreate));

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
