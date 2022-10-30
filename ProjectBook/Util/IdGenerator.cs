namespace ProjectBook.Util
{
    public static class IdGenerator
    {
        public static int GenerateIdLivro()
        {
            return new Random().Next(0, Consts.ID_GENERATION_RANGE);;
        }
    }
}