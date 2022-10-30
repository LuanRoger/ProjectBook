using ProjectBook.Model;
using ProjectBook.Model.Enums;

namespace ProjectBook.Services;

public class SerializationService
{
    public void SerializeUserInfo(UsuarioModel usuarioModel)
    {
        BinaryWriter binaryWriter = new(File.Open(Consts.USER_FILE, FileMode.OpenOrCreate));

        binaryWriter.Write(usuarioModel.id);
        binaryWriter.Write(usuarioModel.usuario);
        binaryWriter.Write((int)usuarioModel.tipo);

        binaryWriter.Close();
    }
    public UsuarioModel DeserializeUserInfo()
    {
        BinaryReader binaryReader = new(File.Open(Consts.USER_FILE, FileMode.Open));
            
        return new()
        {
            id = binaryReader.ReadInt32(),
            usuario = binaryReader.ReadString(),
            tipo = (TipoUsuario)binaryReader.ReadInt32()
        };
    }
}