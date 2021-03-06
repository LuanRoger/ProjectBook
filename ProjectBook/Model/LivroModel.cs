﻿using System;

namespace ProjectBook.Livros
{
    class LivroModel
    {
        public LivroModel(string id, string titulo, string autor, string editora, string edicao, string ano,
            string genero, string isbn, DateTime dataCadastro, string observacoes)
        {
            this.id = id;
            this.titulo = titulo;
            this.autor = autor;
            this.editora = editora;
            this.edicao = edicao;
            this.ano = ano;
            this.genero = genero;
            this.dataCadastro = dataCadastro;
            this.isbn = isbn;
            this.observacoes = observacoes;
        }

        public string id { get; private set; }
        public string titulo { get; private set; }
        public string autor { get; private set; }
        public string editora { get; private set; }
        public string edicao { get; private set; }
        public string ano { get; private set; }
        public string genero { get; private set; }
        public DateTime dataCadastro { get; private set; }
        public string isbn { get; private set; }
        public string observacoes { get; private set; }
    }
}
