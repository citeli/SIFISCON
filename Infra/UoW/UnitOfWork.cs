using System;
using System.Data.Entity;
using Domain.Entities;
using Domain.Interfaces;
using Infra.Context;
using Infra.Repositories;

namespace Infra.UoW
{
    public class UnitOfWork
    {
        private DbContext Db = new DataContext();

        private IRepository<Endereco> enderecoRepository;
        private IRepository<AutoDeInfracao> autoDeInfracaoRepository;
        private IRepository<Fornecedor> fornecedoRepository;
        private IRepository<Produto> produtoRepository;
        private IRepository<Processo> processoRepository;
        

        public IRepository<Endereco> EnderecoRepository
        {
            get
            {
                if (this.enderecoRepository == null)
                {
                    this.enderecoRepository = new EnderecoRepository(Db);
                }
                return enderecoRepository;
            }
        }

        public IRepository<AutoDeInfracao> AutoDeInfracaoRepository
        {
            get
            {
                if (this.autoDeInfracaoRepository == null)
                {
                    this.autoDeInfracaoRepository = new AutoDeInfracaoRepository(Db);
                }
                return autoDeInfracaoRepository;
            }
        }

        public IRepository<Fornecedor> FornecedorRepository
        {
            get
            {
                if (this.fornecedoRepository == null)
                {
                    this.fornecedoRepository = new FornecedorRepository(Db);
                }
                return fornecedoRepository;
            }
        }

        public IRepository<Produto> ProdutoRepository
        {
            get
            {
                if (this.produtoRepository == null)
                {
                    this.produtoRepository = new ProdutoRepository(Db);
                }
                return produtoRepository;
            }
        }

        public IRepository<Processo> ProcessoRepository
        {
            get
            {
                if (this.processoRepository == null)
                {
                    this.processoRepository = new ProcessoRepository(Db);
                }
                return processoRepository;
            }
        }

        public void Commit()
        {
            Db.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    Db.Dispose();
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
