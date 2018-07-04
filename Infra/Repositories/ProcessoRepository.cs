using System.Data.Entity;
using Domain.Entities;
using Domain.Interfaces;

namespace Infra.Repositories
{
    public class ProcessoRepository : Repository<Processo>, IProcessoRepository
    {
        public ProcessoRepository(DbContext context) : base(context)
        {
        }
    }
}
