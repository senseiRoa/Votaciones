

using System;
using Demokratianweb.Data.Entities;


namespace Demokratianweb.Data.Infraestructure
{
    public class VotanteRepository : Repository<VotanteEntity,ApplicationDbContext>
    {
        private ApplicationDbContext _context;

        //Add any additional repository methods other than the generic ones (GetAll, Get, Delete, Add)
        public VotanteRepository(ApplicationDbContext context) : base(context)
        {
           
        }
    }
}
