using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectBook.Livros
{
    class Livro
    {
        public string titulo { get; private set; }
        public string autor { get; private set; }
        public string editora { get; private set; }
        public string edicao { get; private set; }
        public string ano { get; private set; }
        public string genero { get; private set; }
        public string isbn { get; private set; }

        public static Livro LivroFactory(string titulo, string autor, string editora, string edicao, string ano, string genero, string isbn)
        {
            Livro livro = new Livro()
            {
                titulo = titulo,
                autor = autor,
                editora = editora,
                edicao = edicao,
                ano = ano,
                genero = genero,
                isbn = isbn,
            };
            return livro;
        }
    }
}
