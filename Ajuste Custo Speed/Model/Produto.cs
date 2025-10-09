using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ajuste_Custo_Speed.Model
{
    public class Produto
    {
        public int Codigo { get; set; }
        public string Descricao { get; set; }
        public decimal CustoAtual { get; set; }
        public decimal CustoNovo { get; set; }
    }
}
