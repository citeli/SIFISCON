using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class AutoDeInfracao
    {
        public int AutoDeInfracaoId { get; set; }
        public int Gravidade { get; set; }
        public Boolean Atenuante { get; set; }
        public Boolean Agravante { get; set; }
        public Decimal Multa { get; set; }
        public virtual ICollection<Processo> Processos { get; set; }
    }
}
