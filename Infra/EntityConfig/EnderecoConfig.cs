using System.Data.Entity.ModelConfiguration;
using Domain.Entities;

namespace Infra.EntityConfig
{
    public class EnderecoConfig : EntityTypeConfiguration<Endereco>
    {
        public EnderecoConfig()
        {
            ToTable("Enderecos");
            HasKey(e => e.EnderecoId);
            Property(e => e.Logradouro).IsRequired().HasMaxLength(100);
            Property(e => e.Numero).IsRequired().HasMaxLength(50);
            Property(e => e.Complemento).IsOptional().HasMaxLength(50);
            Property(e => e.Bairro).IsRequired().HasMaxLength(100);
            Property(e => e.Cep).IsRequired().HasMaxLength(8);
            Property(e => e.Municipio).IsRequired().HasMaxLength(200);
            Property(e => e.Uf).IsRequired().HasMaxLength(2);
        }
    }
}
