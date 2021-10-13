using System;
using System.Collections.Generic;
using System.Text;

namespace SorteioVagas
{
    public class Vaga
    {        
        public string Id { get; set; }
        public string Descricao { get; set; }
        public bool VagaPresa { get; set; }
        public bool VagaSolta { get; set; }
        public string ApAtual { get; set; }
        public string ApSorteado { get; set; }
    }
}
