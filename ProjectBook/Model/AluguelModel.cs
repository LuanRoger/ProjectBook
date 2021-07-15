using System;

namespace ProjectBook.Livros
{
    class AluguelModel
    {
        public AluguelModel(string titulo, string autor, string alugadoPor, DateTime dataEntrega, DateTime dataDevolucao, string status)
        {
            this.titulo = titulo;
            this.autor = autor;
            this.alugadoPor = alugadoPor;
            this.dataEntrega = dataEntrega;
            this.dataDevolucao = dataDevolucao;
            this.status = status;
        }

        public string titulo { get;}
        public string autor { get;}
        public string alugadoPor { get;}
        public DateTime dataEntrega { get;}
        public DateTime dataDevolucao { get;}
        public string status { get;}
    }
}
