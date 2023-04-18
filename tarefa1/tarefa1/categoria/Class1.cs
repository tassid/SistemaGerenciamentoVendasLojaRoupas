using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tarefa1.categoria
{

        public class Categoria
        {
            public int Id { get; set; }
            public string Nome { get; set; }
            public string Descricao { get; set; }

        public void arrumaproblema()
        {
            Nome = string.Empty; 
        }
    }
    
}
