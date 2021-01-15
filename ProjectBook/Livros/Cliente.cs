using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectBook.Livros
{
    class Cliente
    {
        public string nomeCompleto { get; private set; }
        public string endereco { get; private set; }
        public string cidade { get; private set; }
        public string estado { get; private set; }
        public string cep { get; private set; }
        public string telefone1 { get; private set; }
        public string telefone2 { get; private set; }
        public string email { get; private set; }

        public static Cliente ClienteFactory(string nomeCompleto, string endereco, string cidade, string estado, string cep,
            string telefone1, string telefone2, string email)
        {
            Cliente cliente = new Cliente
            {
                nomeCompleto = nomeCompleto,
                endereco = endereco,
                cidade = cidade,
                estado = estado,
                cep = cep,
                telefone1 = telefone1,
                telefone2 = telefone2,
                email = email
            };

            return cliente;
        }
    }
}
