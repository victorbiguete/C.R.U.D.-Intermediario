using ConsoleCrud.Exceptions;
using ConsoleCrud.Modals;
using ConsoleCrud.Services;

namespace ConsoleCrud
{
    public class Program
    {
        public static List<Funcionario> listaFuncionarios = new List<Funcionario>();
        public static List<Cliente> listasClientes = new List<Cliente>();
        public static void Main(string[] args)
        {
            string opcao, opcaoMenus;


            do
            {
                opcao = MenuPrincipal();
                switch (opcao)
                {

                    case "1":
                        opcaoMenus = MenuFuncionario();
                        SwitchFuncionario(opcaoMenus);
                        break;

                    case "2":
                        opcaoMenus = MenuCliente();
                        SwitchCliente(opcaoMenus);
                        break;
                    default:
                        Console.WriteLine("Opção Invalida !");
                        Console.ReadLine();
                        break;
                }
                Console.Clear();
            } while (opcao != "0");

        }

        private static string MenuPrincipal()
        {
            Console.Write("[1] - Área Funcionario\n" +
                          "[2] - Área Cliente\n" +
                          "[0] - Sair\n" +
                          "Opção: ");

            string opcao = Console.ReadLine();
            Console.Clear();
            return opcao;
        }

        private static string MenuFuncionario()
        {
            Console.Write("[1] - Cadastrar Funcionario\n" +
                          "[2] - Alterar Funcionario\n" +
                          "[3] - Excluir Funcionario\n" +
                          "[4] - Exibir Funcionario por Nome\n" +
                          "[5] - Exibir Funcionario por Letra\n" +
                          "[6] - Exibir Todos os Funcionarios\n" +
                          "[7] - Exibir por ID\n" +
                          "[0] - Sair\n" +
                          "Opção: ");

            string opcao = Console.ReadLine();
            Console.Clear();
            return opcao;
        }

        private static string MenuCliente()
        {
            Console.Write("[1] - Cadastrar Funcionario\n" +
                          "[2] - Alterar Funcionario\n" +
                          "[3] - Excluir Funcionario\n" +
                          "[4] - Exibir Funcionario por Nome\n" +
                          "[5] - Exibir Funcionario por Letra\n" +
                          "[6] - Exibir Todos os Funcionarios\n" +
                          "[7] - Exibir por ID\n" +
                          "[0] - Sair\n" +
                          "Opção: ");

            string opcao = Console.ReadLine();
            Console.Clear();
            return opcao;
        }

        private static void SwitchCliente(string opcao)
        {
            do
            {
                switch (opcao)
                {
                    case "1":
                        Cadastrar();
                        break;

                    case "2":
                        Alterar();
                        break;

                    case "3":
                        Excluir();
                        break;

                    case "4":
                        ExibirNome();
                        break;

                    case "5":
                        ExibirLetra();
                        break;

                    case "6":
                        ExibirTodos();
                        break;

                    case "7":
                        ExibirID();
                        break;
                    default:
                        Console.WriteLine("Opção Invalida !");
                        Console.ReadLine();
                        break;
                }
                Console.Clear();
            } while (opcao != "0");
        }

        private static void SwitchFuncionario(string opcao)
        {
            do
            {
                switch (opcao)
                {

                    case "1":
                        CadastrarFuncionario();
                        break;

                    case "2":
                        AlterarFuncionario();
                        break;

                    case "3":
                        ExcluirFuncionario();
                        break;

                    case "4":
                        ExibirNomeFuncionario();
                        break;

                    case "5":
                        ExibirLetraFuncionario();
                        break;

                    case "6":
                        ExibirTodosFuncionario();
                        break;

                    case "7":
                        ExibirIDFuncionario();
                        break;
                    default:
                        Console.WriteLine("Opção Invalida !");
                        Console.ReadLine();
                        break;
                }
                Console.Clear();
            } while (opcao != "0");
        }

        private static void CadastrarFuncionario()
        {
            try
            {
                Funcionario funcionario = Funcionario.Cadastrar();

                if (listaFuncionarios.Count == 0)
                    funcionario.Id = 1;
                else
                    funcionario.Id = listaFuncionarios[listaFuncionarios.Count - 1].Id + 1;

                listaFuncionarios.Add(funcionario);

                Console.WriteLine("Cadastro Concluido");

            }
            catch (DomainException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        private static void AlterarFuncionario()
        {
            bool flag;
            int id;
            do
            {
                flag = false;
                try
                {
                    Console.WriteLine("Digite o ID do Funcionario que deseja alterar os dados:");
                    while (int.TryParse(Console.ReadLine(), out id))
                        throw new DomainException("Formatação de entrada incorreta, digite apenas numeros");

                    Funcionario? auxiliar = listaFuncionarios.FirstOrDefault(x => x.Id == id);

                    if (auxiliar == null)
                        throw new DomainException("Funcionario não encontrado, digite novamente");

                    Console.WriteLine(auxiliar.ToString() +
                                      $"Desejar alterar os dados ?[S/N]\n" +
                                      $"Opção: ");

                    string opcao = Servicos.VerificarVazio().ToUpper();

                    if (opcao.Equals("S"))
                    {
                        auxiliar = Funcionario.Alterar(auxiliar);

                        Console.WriteLine("Dados alterados com Sucesso");
                    }
                }
                catch (DomainException ex)
                {
                    flag = true;
                    Console.WriteLine(ex.Message);
                }
            } while (flag == true);

            Console.WriteLine("Aperte qualquer tecla para sair");

            Console.ReadLine();
        }

        private static void ExibirIDFuncionario()
        {
            try
            {
                int Id;
                if (listaFuncionarios.Count == 0)
                    throw new DomainException("Lista Vazia.");


                Console.Write("Buscar funcionario que tenha o ID:");
                while (!int.TryParse(Console.ReadLine(), out Id))
                    throw new DomainException("ID invalido, digita novamente");

                Funcionario? busca = listaFuncionarios.FirstOrDefault(x => x.Id == Id);

                if (busca == null)
                    throw new DomainException("Nenhum dado encontrado.");

                Console.WriteLine(busca.ToString());
            }
            catch (DomainException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("Aperte qualquer tecla para sair");
            Console.ReadLine();
        }

        private static void ExibirTodosFuncionario()
        {
            try
            {
                if (listaFuncionarios.Count == 0)
                    throw new DomainException("Lista vazia");

                foreach (var lista in listaFuncionarios)
                    Console.WriteLine(lista.ToString());
            }
            catch (DomainException e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine("Aperte qualquer tecla para sair");
            Console.ReadLine();
        }

        private static void ExibirLetraFuncionario()
        {
            bool flag;
            do
            {
                flag = false;
                try
                {
                    if (listaFuncionarios.Count == 0)
                        throw new DomainException("Lista Vazia");

                    Console.Write("Buscar funcionario que tenha a letra: ");
                    string letra = Servicos.VerificarVazio(); ;

                    List<Funcionario> listaBusca = listaFuncionarios.Where(x => x.Nome.Contains(letra)).ToList();

                    if (listaBusca.Count == 0)
                        throw new DomainException("Nenhum dado encontrado");

                    foreach (var lista in listaBusca)
                        Console.WriteLine(lista.ToString());
                }
                catch (DomainException e)
                {
                    Console.WriteLine(e.Message);
                    flag = true;
                }
            } while (flag == true && listaFuncionarios.Count > 0);

            Console.WriteLine("Aperte qualquer tecla para sair");

            Console.ReadLine();
        }

        private static void ExibirNomeFuncionario()
        {
            bool flag;
            do
            {
                flag = false;

                if (listaFuncionarios.Count == 0)
                    throw new DomainException("Lista Vazia.\n");
                try
                {
                    Console.Write("Buscar funcionario que tenha o Nome: ");
                    string Nome = Servicos.VerificarVazio();

                    List<Funcionario> listaBusca = listaFuncionarios.Where(x => x.Nome.Equals(Nome, StringComparison.OrdinalIgnoreCase)).ToList();

                    if (listaBusca.Count == 0)
                        throw new DomainException("Nenhum dado encontrado.\nPressione qualquer tecla para sair");

                    foreach (var lista in listaBusca)
                        Console.WriteLine(lista.ToString());
                }
                catch (DomainException e)
                {
                    Console.WriteLine(e.Message);
                    flag = true;
                }
            } while (flag == true && listaFuncionarios.Count > 0);

            Console.WriteLine("Aperte qualquer tecla para sair");

            Console.ReadLine();
        }

        private static void ExcluirFuncionario()
        {
            bool flag;
            int id;
            do
            {
                flag = false;
                try
                {
                    Console.WriteLine("Digite o ID do Funcionario que deseja excluir os dados:");
                    while (int.TryParse(Console.ReadLine(), out id))
                        throw new DomainException("ID invalido, digite novamente");

                    Funcionario? auxiliar = listaFuncionarios.FirstOrDefault(x => x.Id == id);

                    Console.WriteLine(auxiliar.ToString() +
                                      $"Desejar excluir os dados ?[S/N]\n" +
                                      $"Opção: ");

                    string opcao = Servicos.VerificarVazio().ToUpper();

                    if (opcao.Equals("S"))
                    {
                        listaFuncionarios.Remove(auxiliar);
                        Console.Write("Remoção bem sucedida");
                        Console.ReadLine();
                    }
                }
                catch (DomainException ex)
                {
                    Console.WriteLine(ex.ToString());
                    flag = true;
                }
            } while (flag == true);

            Console.WriteLine("Aperte qualquer tecla para sair");

            Console.ReadLine();
        }
    }
}
