using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using Domain.Entities;
using Infra.Context;

namespace Infra.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DataContext context)
        {
            context.Database.ExecuteSqlCommand("sp_MSForEachTable 'ALTER TABLE ? NOCHECK CONSTRAINT ALL'");
            context.Database.ExecuteSqlCommand("sp_MSForEachTable 'IF OBJECT_ID(''?'') NOT IN (ISNULL(OBJECT_ID(''[dbo].[__MigrationHistory]''),0)) DELETE FROM ?'");
            context.Database.ExecuteSqlCommand("EXEC sp_MSForEachTable 'ALTER TABLE ? CHECK CONSTRAINT ALL'");
            
            var endereco = new Endereco
            {
                Cep = "27215510",
                Bairro = "Vila Cosmos",
                Logradouro = "Rua B",
                Municipio = "Rio de Janeiro",
                Uf = "RJ",
                Numero = "997",
                Complemento = "Apto. 201"
            };

            var autoDeInfracao = new AutoDeInfracao
            {
                Multa = 100,
                Agravante = true,
                Atenuante = true,
                Gravidade = 2
            };
            
            var fornecedor = new Fornecedor
            {
                RazaoSocial = "High Tech Informatica",
                Cnpj = "1234567891234",
                InscricaoMunicipal = "inscmuni",
                ReceitaBruta = 16000,
                Endereco = endereco
            };
            
            var produto = new Produto
            {
                Nome = "Notebook",
                Marca = "Dell",
                Estoque = "Armazem 11",
                Fornecedor = fornecedor
            };

            var processo = new Processo
            {
                DataRelato = DateTime.Now,
                FiscalResponsavel = "Manuel",
                Fornecedor = fornecedor,
                AutoDeInfracao = autoDeInfracao,
                RelatoFiscalizacao = "Relato relatado"
            };
            
            context.Enderecos.AddOrUpdate(endereco);
            context.AutoDeInfracoes.AddOrUpdate(autoDeInfracao);
            context.Fornecedores.AddOrUpdate(fornecedor);
            context.Produtos.AddOrUpdate(produto);
            context.Processos.AddOrUpdate(processo);
        }
    }
}
