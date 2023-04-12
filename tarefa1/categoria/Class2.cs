using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace tarefa1.categoria
{
    public class CategoriaUI
    {
        private List<Categoria> categorias = new List<Categoria>();

        public void Menu()
        {
            Console.WriteLine("=== Menu de Produtos ===");
            Console.WriteLine("1. Cadastrar Categoria");
            Console.WriteLine("2. Alterar Categoria");
            Console.WriteLine("3. Buscar Todos Categoria");
            Console.WriteLine("4. Altere Categoria Por Id");
            Console.WriteLine("4. Remover Categoria");
            Console.WriteLine("6. Sair");

            int opcao = int.Parse(Console.ReadLine());

            switch (opcao)
            {
                case 1:
                    CadastrarCategoria();
                    break;
                case 2:
                    AlterarCategoria();
                    break;
                case 3:
                    BuscarTodasCategorias();
                    break;
                case 4:
                    BuscarCategoriaPorId();
                    break;
                case 5:
                    RemoverCategoria();
                    break;
                case 6:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }

        }
        public void CadastrarCategoria()
        {
            Categoria categoria = new Categoria();

            Console.WriteLine("Digite o nome da categoria:");
            categoria.Nome = Console.ReadLine();

            Console.WriteLine("Digite a descrição da categoria:");
            categoria.Descricao = Console.ReadLine();

            categoria.Id = categorias.Count + 1;

            categorias.Add(categoria);

            Console.WriteLine("Categoria cadastrada com sucesso!");
        }

        public void AlterarCategoria()
        {
            Console.WriteLine("Digite o ID da categoria que deseja alterar:");
            int id = int.Parse(Console.ReadLine());

            Categoria categoria = categorias.Find(c => c.Id == id);

            if (categoria == null)
            {
                Console.WriteLine("Categoria não encontrada.");
            }
            else
            {
                Console.WriteLine("Digite o novo nome da categoria:");
                categoria.Nome = Console.ReadLine();

                Console.WriteLine("Digite a nova descrição da categoria:");
                categoria.Descricao = Console.ReadLine();

                Console.WriteLine("Categoria alterada com sucesso!");
            }
        }

        public void BuscarTodasCategorias()
        {
            Console.WriteLine("Lista de categorias:");

            foreach (Categoria categoria in categorias)
            {
                Console.WriteLine($"ID: {categoria.Id} | Nome: {categoria.Nome} | Descrição: {categoria.Descricao}");
            }
        }

        public void BuscarCategoriaPorId()
        {
            Console.WriteLine("Digite o ID da categoria que deseja buscar:");
            int id = int.Parse(Console.ReadLine());

            Categoria categoria = categorias.Find(c => c.Id == id);

            if (categoria == null)
            {
                Console.WriteLine("Categoria não encontrada.");
            }
            else
            {
                Console.WriteLine($"ID: {categoria.Id} | Nome: {categoria.Nome} | Descrição: {categoria.Descricao}");
            }
        }

        public void RemoverCategoria()
        {
            Console.WriteLine("Digite o ID da categoria que deseja remover:");
            int id = int.Parse(Console.ReadLine());

            Categoria categoria = categorias.Find(c => c.Id == id);

            if (categoria == null)
            {
                Console.WriteLine("Categoria não encontrada.");
            }
            else
            {
                categorias.Remove(categoria);

                Console.WriteLine("Categoria removida com sucesso!");
            }
        }
    }
}
