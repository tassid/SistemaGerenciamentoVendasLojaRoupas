using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tarefa1.cliente;
using tarefa1.produto;

namespace tarefa1.venda
{
        public class Venda
        {
            public int Id { get; set; }
            public Cliente Cliente { get; set; }
            public List<Produto> ProdutosVendidos { get; set; }                                   
            public DateTime Data { get; set; }
            public decimal Total { get; set; }
        }
}
