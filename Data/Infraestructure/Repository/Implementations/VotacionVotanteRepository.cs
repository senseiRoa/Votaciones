

using System;
using Demokratianweb.Data.Entities;

namespace Demokratianweb.Data.Infraestructure
{
    public class VotacionVotanteRepository : Repository<VotacionVotanteEntity,ApplicationDbContext>
    {
        private ApplicationDbContext _context;

        //Add any additional repository methods other than the generic ones (GetAll, Get, Delete, Add)
        public VotacionVotanteRepository(ApplicationDbContext context) : base(context)
        {
           
        }
    }
}
