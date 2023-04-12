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
                    CadastrarProduto();
                    break;
                case 2:
                    AlterarProduto();
                    break;
                case 3:
                    BuscarTodosProdutos();
                    break;
                case 4:
                    BuscarProdutoPorId();
                    break;
                case 5:
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

            Console.WriteLine("Escolha a categoria do produto:");

            foreach (Categoria categoria in categorias)
            {
                Console.WriteLine($"{categoria.Id} - {categoria.Nome}");
            }

            int categoriaId = int.Parse(Console.ReadLine());

            produto.Categoria = categorias.Find(c => c.Id == categoriaId);

            produto.Id = produtos.Count + 1;

            produtos.Add(produto);

            Console.WriteLine("Produto cadastrado com sucesso!");
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
        }

        public void BuscarTodosProdutos()
        {
            Console.WriteLine("Lista de produtos:");

            foreach (Produto produto in produtos)
            {
                Console.WriteLine($"ID: {produto.Id} | Nome: {produto.Nome} | Descrição: {produto.Descricao} | Preço: {produto.Preco} | Categoria: {produto.Categoria.Nome}");
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
                Console.WriteLine($"ID: {produto.Id} | Nome: {produto.Nome} | Descrição: {produto.Descricao} | Preço: {produto.Preco} | Categoria: {produto.Categoria.Nome}");
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
        }
    }
}
