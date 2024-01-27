using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleCrud.Exceptions;
using ConsoleCrud.Services;
using ConsoleCrud;

namespace ConsoleCrud.Modals
{
    public class Funcionario : Pessoa
    {
        public int Id { get; set; }
        public string Cargo { get; private set; }

        public Funcionario(string cargo, string name, string endereco, string cpf, string telefone) : base(name, endereco, cpf, telefone) => Cargo = cargo;
        

        public static Funcionario Cadastrar()
        {
            bool flag;
            Funcionario funcionario = null;

            do
            {
                flag = false;
                try
                {
                    Console.WriteLine("Digite o nome do Funcionario:");
                    string nome = Servicos.VerificarVazio();

                    Console.WriteLine("Digite o CPF:");
                    string cpf = Servicos.VerificarVazio();

                    if (!Servicos.ValidarCPF(cpf))
                        throw new DomainException("CPF Invalido, digite novamente");

                    Console.WriteLine("Digite o Endereço:");
                    string endereco = Servicos.VerificarVazio();

                    Console.WriteLine("Digite a Cidade:");
                    string cidade = Servicos.VerificarVazio();

                    Console.WriteLine("Digite o Telefone:");
                    string telefone = Servicos.VerificarVazio();

                    Console.WriteLine("Digite o Cargo do Funcionario;");
                    string cargo = Servicos.VerificarVazio();


                    funcionario = new Funcionario(cargo, nome, cidade, endereco, telefone);

                }
                catch (DomainException ex)
                {
                    Console.WriteLine(ex.Message);
                    flag = true;
                }
            } while (flag);

            return funcionario;
        }

        public static Funcionario Alterar(Funcionario auxiliar)
        {
            string nome, cpf, endereco, cidade, telefone, cargo,opcao;
            
            do
            {
                Console.WriteLine("Digite o nome do Funcionario:");
                nome = Servicos.VerificarVazio();

                Console.WriteLine("Digite o CPF:");
                cpf = Servicos.VerificarVazio();

                if (!Servicos.ValidarCPF(cpf))
                    throw new DomainException("CPF Invalido, digite novamente");

                Console.WriteLine("Digite o Endereço:");
                endereco = Servicos.VerificarVazio();

                Console.WriteLine("Digite o Telefone:");
                telefone = Servicos.VerificarVazio();

                Console.WriteLine("Digite o Cargo do Funcionario;");
                cargo = Servicos.VerificarVazio(); ;

                Console.WriteLine($"Nome:{nome}\n" +
                              $"Endereço:{endereco}\n" +
                              $"Cargo:{cargo}\n" +
                              $"CPF:{cpf}"+
                              $"Telefone:{telefone}\n\n" +
                              $"Confirma os novos dados?[S/N]\n" +
                              $"Opção");

                opcao = Console.ReadLine().ToUpper();

            } while (opcao == "N");

            auxiliar.Nome = nome;
            auxiliar.Endereco = endereco;
            auxiliar.Cargo = cargo;
            auxiliar.CPF = cpf;
            auxiliar.Telefone = telefone;

            return auxiliar;
        }

        public override string? ToString()
        {
            return $"Id: {Id}\nNome: {Nome}\nCargo: {Cargo}\nEndereço: {Endereco}\nCPF: {CPF}\nTelefone: {Telefone}";
        }


    }
}
