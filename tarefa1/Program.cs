using tarefa1.categoria;
using tarefa1.cliente;
using tarefa1.produto;
using tarefa1.venda;

namespace tarefa1
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Categoria> categorias = new List<Categoria>();
            List<Produto> produtos = new List<Produto>();
            List<Cliente> clientes = new List<Cliente>();

            CategoriaUI categoriaUI = new CategoriaUI();
            ProdutoUI produtoUI = new ProdutoUI(categorias);
            ClienteUI clienteUI = new ClienteUI();
            VendaUI vendaUI = new VendaUI(clientes, produtos);

            bool continuarExecutando = true;

            while (continuarExecutando)
            {
                Console.WriteLine("Selecione uma opção:");
                Console.WriteLine("1 - Gerenciar categorias");
                Console.WriteLine("2 - Gerenciar produtos");
                Console.WriteLine("3 - Gerenciar clientes");
                Console.WriteLine("4 - Realizar venda");
                Console.WriteLine("5 - Buscar vendas por cliente");
                Console.WriteLine("0 - Sair");

                int opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        categoriaUI.Menu();
                        break;
                    case 2:
                        produtoUI.Menu();
                        break;
                    case 3:
                        clienteUI.Menu();
                        break;
                    case 4:
                        vendaUI.RealizarVenda();
                        break;
                    case 5:
                        vendaUI.BuscarVendasPorCliente();
                        break;
                    case 0:
                        continuarExecutando = false;
                        break;
                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }
            }
        }
    }
}