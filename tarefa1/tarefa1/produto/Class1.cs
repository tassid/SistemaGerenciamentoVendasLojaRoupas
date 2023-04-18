using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tarefa1.categoria;

namespace tarefa1.produto
{
    public class ProdutoUI
    {
        private List<Produto> produtos = new List<Produto>();
        private List<Categoria> categorias;

        public ProdutoUI(List<Categoria> categorias)
        {
            this.categorias = categorias;
        }
        public void Menu()
        {
            Console.WriteLine("=== Menu de Produtos ===");
            Console.WriteLine("1. Cadastrar Produto");
            Console.WriteLine("2. Alterar Produto");
            Console.WriteLine("3. Buscar Todos Produtos");
            Console.WriteLine("4. Buscar Produto Por Id");
            Console.WriteLine("5. Remover Produto");
            Console.WriteLine("6. Sair");

            int opcao = int.Parse(Console.ReadLine());

            switch (opcao)
            {
                case 1:
                    Console.Clear();
                    CadastrarProduto();
                    break;
                case 2:
                    Console.Clear();
                    AlterarProduto();
                    break;
                case 3:
                    Console.Clear();
                    BuscarTodosProdutos();
                    break;
                case 4:
                    Console.Clear();
                    BuscarProdutoPorId();
                    break;
                case 5:
                    Console.Clear();
                    RemoverProduto();
                    break;
                case 6:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }


        }
        public void CadastrarProduto()
        {
            Produto produto = new Produto();

            Console.WriteLine("Digite o nome do produto:");
            produto.Nome = Console.ReadLine();

            Console.WriteLine("Digite a descrição do produto:");
            produto.Descricao = Console.ReadLine();

            Console.WriteLine("Digite o preço do produto:");
            produto.Preco = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Escolha a categoria do produto(por ID):");

            foreach (Categoria categoria in categorias)
            {
                Console.WriteLine($"{categoria.Id} - {categoria.Nome}");
            }

            int categoriaId = int.Parse(Console.ReadLine());

            produto.Categoria = categorias.Find(c => c.Id == categoriaId);

            var Kategoria = categorias.Find(c => c.Id == categoriaId);
            if (Kategoria != null)
            {
                produto.Categoria = Kategoria;
            }
            else
            {
                Console.WriteLine($"Categoria with Id {categoriaId} not found.");
            }

            produto.Id = produtos.Count + 1;

            produtos.Add(produto);

            Console.WriteLine("Produto cadastrado com sucesso!");
            Console.Clear();
        }

        public void AlterarProduto()
        {
            Console.WriteLine("Digite o ID do produto que deseja alterar:");
            int id = int.Parse(Console.ReadLine());

            Produto produto = produtos.Find(p => p.Id == id);

            if (produto == null)
            {
                Console.WriteLine("Produto não encontrado.");
            }
            else
            {
                Console.WriteLine("Digite o novo nome do produto:");
                produto.Nome = Console.ReadLine();

                Console.WriteLine("Digite a nova descrição do produto:");
                produto.Descricao = Console.ReadLine();

                Console.WriteLine("Digite o novo preço do produto:");
                produto.Preco = decimal.Parse(Console.ReadLine());

                Console.WriteLine("Escolha a nova categoria do produto:");

                foreach (Categoria categoria in categorias)
                {
                    Console.WriteLine($"{categoria.Id} - {categoria.Nome}");
                }

                int categoriaId = int.Parse(Console.ReadLine());

                produto.Categoria = categorias.Find(c => c.Id == categoriaId);

                Console.WriteLine("Produto alterado com sucesso!");
            }
            Console.Clear();
        }

        public void BuscarTodosProdutos()
        {
            Console.WriteLine("Lista de produtos:");

            Console.WriteLine($"categorias: {string.Join(", ", categorias.Select(c => c.Nome))}");
            foreach (Produto produto in produtos)
            {
                Console.WriteLine($"ID: {produto.Id} | Nome: {produto.Nome} | Descrição: {produto.Descricao} | Preço: {produto.Preco} | Categoria: {produto.Categoria?.Nome}\n\n");
            }
        }

        public void BuscarProdutoPorId()
        {
            Console.WriteLine("Digite o ID do produto que deseja buscar:");
            int id = int.Parse(Console.ReadLine());

            Produto produto = produtos.Find(p => p.Id == id);

            if (produto == null)
            {
                Console.WriteLine("Produto não encontrado.");
            }
            else
            {
                Console.WriteLine($"ID: {produto.Id} | Nome: {produto.Nome} | Descrição: {produto.Descricao} | Preço: {produto.Preco} | Categoria: {produto.Nome} \n\n");
            }
        }

        public void RemoverProduto()
        {
            Console.WriteLine("Digite o ID do produto que deseja remover:");
            int id = int.Parse(Console.ReadLine());

            Produto produto = produtos.Find(p => p.Id == id);

            if (produto == null)
            {
                Console.WriteLine("Produto não encontrado.");
            }
            else
            {
                produtos.Remove(produto);

                Console.WriteLine("Produto removido com sucesso!");
            }
            Console.Clear();

        }
    }
}
