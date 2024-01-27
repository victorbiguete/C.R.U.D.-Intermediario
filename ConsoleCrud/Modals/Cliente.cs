using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleCrud.Enums;
using ConsoleCrud.Exceptions;
using ConsoleCrud.Services;

namespace ConsoleCrud.Modals
{
    public class Cliente : Pessoa
    {
        public int Id { get; set; }
        public CategoriaCliente Tipo { get; private set; }

        public Cliente(CategoriaCliente tipo,string nome, string endereco, string cpf, string telefone) : base(nome, endereco, cpf, telefone) => Tipo = tipo;

        public override string? ToString()
        {
            return $"ID:{Id}\nNome: {Nome}\nEndereço: {Endereco}\nCPF:{CPF}\nTelefone:{Telefone}\nCategoria: {Tipo.ToString()}";
        }

        public static Cliente Cadastrar()
        {
            int tipo;
            bool flag = false;
            string cpf;
            CategoriaCliente tipoCliente = CategoriaCliente.Classic;


            Console.WriteLine("Digite o nome do Cliente: ");
            string nome = Servicos.VerificarVazio();

            Console.WriteLine("Digite o Endereço do Cliente: ");
            string endereco = Servicos.VerificarVazio();

            do
            {
                Console.WriteLine("Digite o CPF do Cliente: ");
                cpf = Servicos.VerificarVazio();

                if (!Servicos.ValidarCPF(cpf))
                {
                    Console.WriteLine("CPF Invalido");
                    flag = true;
                }
                else
                    flag = false;

            } while (flag);

            Console.WriteLine("Digite o Telefone do Cliente: ");
            string telefone = Servicos.VerificarVazio();


            do
            {
                Console.WriteLine("Digite o tipo do Cliente:\n" +
                          $"[0] - {CategoriaCliente.Classic.GetDescription()} " +
                          $"[1] - {CategoriaCliente.VIP.GetDescription()}" +
                          $"[2] - {CategoriaCliente.Diamond.GetDescription()}");

                while (!int.TryParse(Console.ReadLine(), out tipo))
                    Console.WriteLine("Digite o tipo correto");

                if (Enum.IsDefined(typeof(CategoriaCliente), tipo))
                {
                    switch (tipo)
                    {
                        case (int)CategoriaCliente.Classic:
                            tipoCliente = CategoriaCliente.Classic;
                            break;
                        case (int)CategoriaCliente.VIP:
                            tipoCliente = CategoriaCliente.VIP;
                            break;
                        case (int)CategoriaCliente.Diamond:
                            tipoCliente = CategoriaCliente.Diamond;
                            break;
                        default:
                            Console.WriteLine("Tipo Invalido\nDigite Novamente");
                            flag = true;
                            break;

                    }
                }
            } while (flag);

            return new Cliente(tipoCliente, nome, endereco, cpf, telefone);
        }
    }
}
