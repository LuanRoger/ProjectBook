using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectBook.Livros
{
    class Aluguel
    {
        public Aluguel(string titulo, string autor, string alugadoPor, DateTime dataEntrega, DateTime dataRecebimento, string status)
        {
            this.titulo = titulo;
            this.autor = autor;
            this.alugadoPor = alugadoPor;
            this.dataEntrega = dataEntrega;
            this.dataRecebimento = dataRecebimento;
            this.status = status;
        }

        public string titulo { get;}
        public string autor { get;}
        public string alugadoPor { get;}
        public DateTime dataEntrega { get;}
        public DateTime dataRecebimento { get;}
        public string status { get;}
    }
}
