using System;
using System.Linq;
using Domain.Entities;
using Infra.UoW;
using static System.Console;

namespace Console
{
    public class Program
    {
        private static void Main(string[] args)
        {
            var uow = new UnitOfWork();

            var endereco = new Endereco
            {
                Logradouro = "Rua Guaricanga",
                Numero = "12",
                Bairro = "Lapa",
                Municipio = "São Paulo",
                Cep = "27285195",
                Uf = "SP"
            };

            uow.EnderecoRepository.Adicionar(endereco);

            var fornecedor = new Fornecedor
            {
                Cnpj = "1234567891234",
                RazaoSocial = "Loja Info",
                InscricaoMunicipal = "123546",
                ReceitaBruta = 5000,
                Endereco = endereco
            };

            uow.FornecedorRepository.Adicionar(fornecedor);

            var produto = new Produto
            {
                Nome = "SSD 128gb",
                Marca = "Kingston",
                Estoque = "Almo",
                Fornecedor = fornecedor
            };

            uow.ProdutoRepository.Adicionar(produto);

            var ai = new AutoDeInfracao
            {
                Gravidade = 2,
                Atenuante = true,
                Agravante = false,
                Multa = 150
            };

            uow.AutoDeInfracaoRepository.Adicionar(ai);

            var processo = new Processo
            {
                RelatoFiscalizacao = "Relato da lava jato",
                DataRelato = DateTime.Now,
                FiscalResponsavel = "Luiz Inacio",
                Fornecedor = fornecedor,
                AutoDeInfracao = ai
            };

            uow.ProcessoRepository.Adicionar(processo);

            uow.Commit();

            var fornecedores = uow.FornecedorRepository.ObterTodos().ToArray();
            foreach (var fornec in fornecedores)
            {
                WriteLine($@"Nome: {fornec.RazaoSocial}");
                WriteLine($@"CNPJ: {fornec.Cnpj}");
                WriteLine($@"Inscrição Municipal: {fornec.InscricaoMunicipal}");
                WriteLine($@"Receita Bruta: {fornec.ReceitaBruta}");
                WriteLine($@"Endereço: {uow.EnderecoRepository.ObterPorId(fornec.FornecedorId).Logradouro}");
                WriteLine("************************************");
            }
            var processos = uow.ProcessoRepository.ObterTodos().ToArray();
            foreach (var process in processos)
            {
                WriteLine($@"Processo: {process.ProcessoId}");
                WriteLine($@"Fornecedor: {uow.FornecedorRepository.ObterPorId(process.ProcessoId).RazaoSocial}/{uow.FornecedorRepository.ObterPorId(process.ProcessoId).Cnpj}");
                WriteLine($@"Data Relato: {process.DataRelato}");
                WriteLine($@"Fiscal Responsavel: {process.FiscalResponsavel}");
                WriteLine("************************************");
            }
            
            ReadKey();
        }
    }
}
