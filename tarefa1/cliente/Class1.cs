using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tarefa1.cliente
{
    public class ClienteUI
    {
        private List<Cliente> clientes = new List<Cliente>();
        public void Menu()
        {
            Console.WriteLine("=== Menu de Produtos ===");
            Console.WriteLine("1. Cadastrar Cliente");
            Console.WriteLine("2. Alterar Cliente");
            Console.WriteLine("3. Buscar Todos Clientes");
            Console.WriteLine("4. Buscar Cliente Por Id");
            Console.WriteLine("5. Remover Cliente");
            Console.WriteLine("6. Sair");

            int opcao = int.Parse(Console.ReadLine());

            switch (opcao)
            {
                case 1:
                    CadastrarCliente();
                    break;
                case 2:
                    AlterarCliente();
                    break;
                case 3:
                    BuscarTodosClientes();
                    break;
                case 4:
                    BuscarClientePorId();
                    break;
                case 5:
                    RemoverCliente();
                    break;
                case 6:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }


        }
        public void CadastrarCliente()
        {
            Cliente cliente = new Cliente();
            Console.WriteLine("Digite o nome do cliente:");
            cliente.Nome = Console.ReadLine();

            Console.WriteLine("Digite o sobrenome do cliente:");
            cliente.Sobrenome = Console.ReadLine();

            Console.WriteLine("Digite o endereço do cliente:");
            cliente.Endereco = Console.ReadLine();

            Console.WriteLine("Digite o número de telefone do cliente:");
            cliente.Telefone = Console.ReadLine();

            cliente.Id = clientes.Count + 1;

            clientes.Add(cliente);

            Console.WriteLine("Cliente cadastrado com sucesso!");
        }

        public void AlterarCliente()
        {
            Console.WriteLine("Digite o ID do cliente que deseja alterar:");
            int id = int.Parse(Console.ReadLine());

            Cliente cliente = clientes.Find(c => c.Id == id);

            if (cliente == null)
            {
                Console.WriteLine("Cliente não encontrado.");
            }
            else
            {
                Console.WriteLine("Digite o novo nome do cliente:");
                cliente.Nome = Console.ReadLine();

                Console.WriteLine("Digite o novo sobrenome do cliente:");
                cliente.Sobrenome = Console.ReadLine();

                Console.WriteLine("Digite o novo endereço do cliente:");
                cliente.Endereco = Console.ReadLine();

                Console.WriteLine("Digite o novo número de telefone do cliente:");
                cliente.Telefone = Console.ReadLine();

                Console.WriteLine("Cliente alterado com sucesso!");
            }
        }

        public void BuscarTodosClientes()
        {
            Console.WriteLine("Lista de clientes:");

            foreach (Cliente cliente in clientes)
            {
                Console.WriteLine($"ID: {cliente.Id} | Nome: {cliente.Nome} | Sobrenome: {cliente.Sobrenome} | Endereço: {cliente.Endereco} | Telefone: {cliente.Telefone}");
            }
        }

        public void BuscarClientePorId()
        {
            Console.WriteLine("Digite o ID do cliente que deseja buscar:");
            int id = int.Parse(Console.ReadLine());

            Cliente cliente = clientes.Find(c => c.Id == id);

            if (cliente == null)
            {
                Console.WriteLine("Cliente não encontrado.");
            }
            else
            {
                Console.WriteLine($"ID: {cliente.Id} | Nome: {cliente.Nome} | Sobrenome: {cliente.Sobrenome} | Endereço: {cliente.Endereco} | Telefone: {cliente.Telefone}");
            }
        }

        public void RemoverCliente()
        {
            Console.WriteLine("Digite o ID do cliente que deseja remover:");
            int id = int.Parse(Console.ReadLine());

            Cliente cliente = clientes.Find(c => c.Id == id);

            if (cliente == null)
            {
                Console.WriteLine("Cliente não encontrado.");
            }
            else
            {
                clientes.Remove(cliente);

                Console.WriteLine("Cliente removido com sucesso!");
            }
        }
    }
}
