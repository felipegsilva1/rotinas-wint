using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Markup_Laborsil.Model
{
    public class Produto
    {
        public int codProd { get; set; }
        public string descricao { get; set; }
        public long? codAuxiliar { get; set; }
        public int? codMarca { get; set; }
        public string Marca { get; set; }
        public string atualizaAuto { get; set; }
        public string tipoAtuPreco { get; set; }
        public decimal? percMkp { get; set; }
    }
}
