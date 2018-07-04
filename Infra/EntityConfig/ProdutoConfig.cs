using System.Data.Entity.ModelConfiguration;
using Domain.Entities;

namespace Infra.EntityConfig
{
    public class ProdutoConfig : EntityTypeConfiguration<Produto>
    {
        public ProdutoConfig()
        {
            ToTable("Produtos");
            HasKey(p => p.ProdutoId);
            Property(p => p.Nome).IsRequired();
            HasRequired(p => p.Fornecedor)
                .WithMany(f => f.Produtos);
        }
    }
}
