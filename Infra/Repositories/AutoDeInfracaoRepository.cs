using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;

namespace Infra.Repositories
{
    public class AutoDeInfracaoRepository : Repository<AutoDeInfracao>, IAutoDeInfracaoRepository
    {
        public AutoDeInfracaoRepository(DbContext context) : base(context)
        {
        }
    }
}
