using System.Data.Entity.ModelConfiguration;
using Domain.Entities;

namespace Infra.EntityConfig
{
    public class AutoDeInfracaoConfig : EntityTypeConfiguration<AutoDeInfracao>
    {
        public AutoDeInfracaoConfig()
        {
            ToTable("AutoDeInfracoes");
            HasKey(a => a.AutoDeInfracaoId);
            Property(a => a.Gravidade).IsRequired();
            Property(a => a.Agravante).IsRequired();
            Property(a => a.Atenuante).IsRequired();
            Property(a => a.Multa).IsRequired();
        }
    }
}
