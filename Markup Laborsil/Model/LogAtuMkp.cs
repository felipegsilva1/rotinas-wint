using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Markup_Laborsil.Model
{
    public class LogAtuMkp
    {
		public int? CodProd { get; set; }
		public string Descricao { get; set; }
		public long? CodAuxiliar { get; set; }
		public string Marca { get; set; }
		public decimal? ValorUltEnt { get; set; }
		public decimal? PrecoFabrica { get; set; }
		public decimal? PercMarkup { get; set; }
		public decimal? Desconto { get; set; }
		public DateTime? DataInic { get; set; }
		public DateTime? DataFim { get; set; }
		public DateTime? Data { get; set; }
        public string Maquina { get; set; }
		public string Usuario { get; set; }
		public string Programa { get; set; }
		public int? CodPromocaoMed { get; set; }
    }
}
