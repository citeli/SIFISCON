using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Processo
    {
        public int ProcessoId { get; set; }
        public string RelatoFiscalizacao { get; set; }
        public DateTime DataRelato { get; set; }
        public string FiscalResponsavel { get; set; }
        public virtual Fornecedor Fornecedor { get; set; }
        public virtual AutoDeInfracao AutoDeInfracao { get; set; }
    }
}
