namespace Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AutoDeInfracoes",
                c => new
                    {
                        AutoDeInfracaoId = c.Int(nullable: false, identity: true),
                        Gravidade = c.Int(nullable: false),
                        Atenuante = c.Boolean(nullable: false),
                        Agravante = c.Boolean(nullable: false),
                        Multa = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.AutoDeInfracaoId);
            
            CreateTable(
                "dbo.Processos",
                c => new
                    {
                        ProcessoId = c.Int(nullable: false, identity: true),
                        RelatoFiscalizacao = c.String(nullable: false, maxLength: 1000, unicode: false),
                        DataRelato = c.DateTime(nullable: false),
                        FiscalResponsavel = c.String(nullable: false, maxLength: 100, unicode: false),
                        AutoDeInfracao_AutoDeInfracaoId = c.Int(nullable: false),
                        Fornecedor_FornecedorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProcessoId)
                .ForeignKey("dbo.AutoDeInfracoes", t => t.AutoDeInfracao_AutoDeInfracaoId)
                .ForeignKey("dbo.Fornecedores", t => t.Fornecedor_FornecedorId)
                .Index(t => t.AutoDeInfracao_AutoDeInfracaoId)
                .Index(t => t.Fornecedor_FornecedorId);
            
            CreateTable(
                "dbo.Fornecedores",
                c => new
                    {
                        FornecedorId = c.Int(nullable: false, identity: true),
                        Cnpj = c.String(nullable: false, maxLength: 14, unicode: false),
                        RazaoSocial = c.String(nullable: false, maxLength: 200, unicode: false),
                        InscricaoMunicipal = c.String(maxLength: 8, unicode: false),
                        ReceitaBruta = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Endereco_EnderecoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FornecedorId)
                .ForeignKey("dbo.Enderecos", t => t.Endereco_EnderecoId)
                .Index(t => t.Endereco_EnderecoId);
            
            CreateTable(
                "dbo.Enderecos",
                c => new
                    {
                        EnderecoId = c.Int(nullable: false, identity: true),
                        Logradouro = c.String(nullable: false, maxLength: 100, unicode: false),
                        Numero = c.String(nullable: false, maxLength: 50, unicode: false),
                        Complemento = c.String(maxLength: 50, unicode: false),
                        Bairro = c.String(nullable: false, maxLength: 100, unicode: false),
                        Municipio = c.String(nullable: false, maxLength: 200, unicode: false),
                        Cep = c.String(nullable: false, maxLength: 8, unicode: false),
                        Uf = c.String(nullable: false, maxLength: 2, unicode: false),
                    })
                .PrimaryKey(t => t.EnderecoId);
            
            CreateTable(
                "dbo.Produtos",
                c => new
                    {
                        ProdutoId = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 8000, unicode: false),
                        Marca = c.String(maxLength: 8000, unicode: false),
                        Estoque = c.String(maxLength: 8000, unicode: false),
                        Fornecedor_FornecedorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProdutoId)
                .ForeignKey("dbo.Fornecedores", t => t.Fornecedor_FornecedorId)
                .Index(t => t.Fornecedor_FornecedorId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Processos", "Fornecedor_FornecedorId", "dbo.Fornecedores");
            DropForeignKey("dbo.Produtos", "Fornecedor_FornecedorId", "dbo.Fornecedores");
            DropForeignKey("dbo.Fornecedores", "Endereco_EnderecoId", "dbo.Enderecos");
            DropForeignKey("dbo.Processos", "AutoDeInfracao_AutoDeInfracaoId", "dbo.AutoDeInfracoes");
            DropIndex("dbo.Produtos", new[] { "Fornecedor_FornecedorId" });
            DropIndex("dbo.Fornecedores", new[] { "Endereco_EnderecoId" });
            DropIndex("dbo.Processos", new[] { "Fornecedor_FornecedorId" });
            DropIndex("dbo.Processos", new[] { "AutoDeInfracao_AutoDeInfracaoId" });
            DropTable("dbo.Produtos");
            DropTable("dbo.Enderecos");
            DropTable("dbo.Fornecedores");
            DropTable("dbo.Processos");
            DropTable("dbo.AutoDeInfracoes");
        }
    }
}
