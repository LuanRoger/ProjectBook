using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectBook.Livros
{
    class Aluguel
    {
        public string titulo { get; private set; }
        public string autor { get; private set; }
        public string alugadoPor { get; private set; }
        public DateTime dataEntrega { get; private set; }
        public DateTime dataRecebimento { get; private set; }
        public string status { get; private set; } = "Pendente";

        public static Aluguel AluguelFactory(string titulo, string autor, string alugadoPor, DateTime dataEntrega,
            DateTime dateRecebimento, string status)
        {
            Aluguel aluguel = new Aluguel
            {
                titulo = titulo,
                autor = autor,
                alugadoPor = alugadoPor,
                dataEntrega = dataEntrega,
                dataRecebimento = dateRecebimento,
                status = status
            };
            return aluguel;
        }
    }
}
