using System;
using System.Threading.Tasks;

namespace ProjectBook.Util
{
    public static class IdGenerator
    {
        public static async Task<int> GenerateIdLivro()
        {
            int codigo = new Random().Next(0, Consts.ID_GENERATION_RANGE);

            while(await Verificadores.VerificarIdLivro(codigo)) codigo = new Random().Next(0, 999);

            return codigo;
        }
    }
}