

using Demokratianweb.Data.Entities;
using System;


namespace Demokratianweb.Data.Infraestructure
{
    public class ControlVotoVotanteRepository : Repository<ControlVotoVotanteEntity, ApplicationDbContext>
    {
        private ApplicationDbContext _context;

        //Add any additional repository methods other than the generic ones (GetAll, Get, Delete, Add)
        public ControlVotoVotanteRepository(ApplicationDbContext context) : base(context)
        {
           
        }
    }
}
