

using System;
using Demokratianweb.Data.Entities;

namespace Demokratianweb.Data.Infraestructure
{
    public class RondaCandidatoRepository : Repository<RondaCandidatoEntity,ApplicationDbContext>
    {
        private ApplicationDbContext _context;

        //Add any additional repository methods other than the generic ones (GetAll, Get, Delete, Add)
        public RondaCandidatoRepository(ApplicationDbContext context) : base(context)
        {
           
        }
    }
}
