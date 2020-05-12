
using System;
using Demokratianweb.Data.Entities;

namespace Demokratianweb.Data.Infraestructure
{
    public class RondaVotacionRepository : Repository<RondaVotacionEntity,ApplicationDbContext>
    {
        private ApplicationDbContext _context;

        //Add any additional repository methods other than the generic ones (GetAll, Get, Delete, Add)
        public RondaVotacionRepository(ApplicationDbContext context) : base(context)
        {
           
        }
    }
}