using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCrud.Modals
{
    public abstract class Pessoa
    {
        public string Nome { get;  set; }
        public string Endereco { get;  set; }
        public string CPF { get;  set; }
        public string Telefone { get;  set; }


        protected Pessoa(string name, string endereco, string cpf, string telefone)
        {
            Nome = name;
            Endereco = endereco;
            CPF = cpf;
            Telefone = telefone;
        }

    }
}
