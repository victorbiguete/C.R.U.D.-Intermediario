using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCrud.Modals
{
    public abstract class Pessoa
    {
        public string Nome { get; protected set; }
        public string Endereco { get; protected set; }
        public string CPF { get; protected set; }
        public string Telefone { get; protected set; }


        protected Pessoa(string nome, string endereco, string cpf, string telefone)
        {
            Nome = nome;
            Endereco = endereco;
            CPF = cpf;
            Telefone = telefone;
        }

    }
}
