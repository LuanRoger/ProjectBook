using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectBook.Livros
{
    class Livro
    {
        public Livro(string id, string titulo, string autor, string editora, string edicao, string ano, string genero, string isbn)
        {
            this.id = id;
            this.titulo = titulo;
            this.autor = autor;
            this.editora = editora;
            this.edicao = edicao;
            this.ano = ano;
            this.genero = genero;
            this.isbn = isbn;
        }

        public string id { get; private set; }
        public string titulo { get; private set; }
        public string autor { get; private set; }
        public string editora { get; private set; }
        public string edicao { get; private set; }
        public string ano { get; private set; }
        public string genero { get; private set; }
        public string isbn { get; private set; }
    }
}
