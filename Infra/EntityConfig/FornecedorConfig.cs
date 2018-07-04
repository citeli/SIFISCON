using System.Data.Entity.ModelConfiguration;
using Domain.Entities;

namespace Infra.EntityConfig
{
    public class FornecedorConfig : EntityTypeConfiguration<Fornecedor>
    {
        public FornecedorConfig()
        {
            ToTable("Fornecedores");
            HasKey(f => f.FornecedorId);
            Property(f => f.Cnpj).IsRequired().HasMaxLength(14);
            Property(f => f.RazaoSocial).IsRequired().HasMaxLength(200);
            Property(f => f.ReceitaBruta).IsRequired();
            Property(f => f.InscricaoMunicipal).IsOptional().HasMaxLength(8);
            
            HasRequired<Endereco>(f => f.Endereco);
        }
    }
}
