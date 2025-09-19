using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicoMacro.Model
{
    public class Servicos
    {
        public int codService { get; set; }
        public string nomeService { get; set; }
        public string directorService { get; set; }
        public string statusService { get; set; }
        public int? horaService { get; set; }
        public int? minutoService { get; set; }
        public DateTime? dataService { get; set; }
        public string macroService { get; set; }
    }
}
