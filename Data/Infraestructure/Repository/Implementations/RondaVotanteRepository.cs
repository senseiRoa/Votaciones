

using System;
using Demokratianweb.Data.Entities;

namespace Demokratianweb.Data.Infraestructure
{
    public class RondaVotanteRepository : Repository<RondaVotanteEntity,ApplicationDbContext>
    {
        private ApplicationDbContext _context;

        //Add any additional repository methods other than the generic ones (GetAll, Get, Delete, Add)
        public RondaVotanteRepository(ApplicationDbContext context) : base(context)
        {
           
        }
    }
}
