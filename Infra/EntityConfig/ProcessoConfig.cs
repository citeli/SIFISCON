using System.Data.Entity.ModelConfiguration;
using Domain.Entities;

namespace Infra.EntityConfig
{
    public class ProcessoConfig : EntityTypeConfiguration<Processo>
    {
        public ProcessoConfig()
        {
            ToTable("Processos");
            HasKey(p => p.ProcessoId);
            Property(p => p.RelatoFiscalizacao).IsRequired().HasMaxLength(1000);
            Property(p => p.DataRelato).IsRequired();
            Property(p => p.FiscalResponsavel).IsRequired().HasMaxLength(100);

            HasRequired(p => p.Fornecedor)
                .WithMany(f => f.Processos);

            HasRequired(p => p.AutoDeInfracao)
                .WithMany(a => a.Processos);

        }
    }
}
