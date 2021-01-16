using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectBook.Livros
{
    class Cliente
    {
        public Cliente(string nomeCompleto, string endereco, string cidade, string estado, string cep, string telefone1, string telefone2, string email)
        {
            this.nomeCompleto = nomeCompleto;
            this.endereco = endereco;
            this.cidade = cidade;
            this.estado = estado;
            this.cep = cep;
            this.telefone1 = telefone1;
            this.telefone2 = telefone2;
            this.email = email;
        }

        public string nomeCompleto { get;}
        public string endereco { get;}
        public string cidade { get;}
        public string estado { get;}
        public string cep { get;}
        public string telefone1 { get;}
        public string telefone2 { get;}
        public string email { get;}
    }
}
