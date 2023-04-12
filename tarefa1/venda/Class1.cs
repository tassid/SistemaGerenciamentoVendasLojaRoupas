using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using tarefa1.cliente;
using tarefa1.produto;

namespace tarefa1.venda
{
    public class VendaUI
    {
        private List<Cliente> clientes;
        private List<Produto> produtos = new List<Produto>();
        private List<Venda> vendas = new List<Venda>();

        public VendaUI(List<Cliente> clientes, List<Produto> produtos)
        {
            this.clientes = clientes;
            this.produtos = produtos;
        }

        public void RealizarVenda()
        {
            Console.WriteLine("Digite o ID do cliente que realizou a compra:");
            int clienteId = int.Parse(Console.ReadLine());

            Cliente cliente = clientes.Find(c => c.Id == clienteId);

            if (cliente == null)
            {
                Console.WriteLine("Cliente não encontrado.");
            }
            else
            {
                Venda venda = new Venda();

                venda.Cliente = cliente;
                venda.Data = DateTime.Now;

                List<Produto> idos = new List<Produto>();
                bool continuarAdicionandoProdutos = true;

                while (continuarAdicionandoProdutos)
                {
                    Console.WriteLine("Digite o ID do produto que foi vendido:");
                    int produtoId = int.Parse(Console.ReadLine());

                    Produto produto = produtos.Find(p => p.Id == produtoId);

                    if (produto == null)
                    {
                        Console.WriteLine("Produto não encontrado.");
                    }
                    else
                    {
                        venda.Total += produto.Preco;

                        venda.ProdutosVendidos.Add(produto);

                        Console.WriteLine("Produto adicionado à venda com sucesso!");

                        Console.WriteLine("Deseja adicionar mais produtos à venda? (S/N)");
                        string resposta = Console.ReadLine();

                        if (resposta.ToUpper() != "S")
                        {
                            continuarAdicionandoProdutos = false;
                        }
                    }
                }

                venda.Id = vendas.Count + 1;

                vendas.Add(venda);

                Console.WriteLine("Venda realizada com sucesso!");
            }
        }

        public void BuscarVendasPorCliente()
        {
            Console.WriteLine("Digite o ID do cliente que deseja buscar as vendas:");
            int clienteId = int.Parse(Console.ReadLine());

            Cliente cliente = clientes.Find(c => c.Id == clienteId);

            if (cliente == null)
            {
                Console.WriteLine("Cliente não encontrado.");
            }
            else
            {
                List<Venda> vendasCliente = vendas.FindAll(v => v.Cliente.Id == clienteId);

                if (vendasCliente.Count == 0)
                {
                    Console.WriteLine("Esse cliente ainda não realizou nenhuma compra.");
                }
                else
                {
                    Console.WriteLine($"Lista de vendas do cliente {cliente.Nome} {cliente.Sobrenome}:");
                    foreach (Venda venda in vendasCliente)
                    {
                        Console.WriteLine($"ID da venda: {venda.Id} | Data da venda: {venda.Data} | Total da venda: R${venda.Total}");

                        Console.WriteLine("Produtos vendidos:");
                        foreach (Produto produto in venda.ProdutosVendidos)
                        {
                            Console.WriteLine($"Nome: {produto.Nome} | Preço: R${produto.Preco} | Descrição: {produto.Descricao} | Categoria: {produto.Categoria.Nome}");
                        }

                        Console.WriteLine("---------------------------------------------------");
                    }
                }
            }
        }
    }
}
