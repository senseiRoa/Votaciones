

using Demokratianweb.Data.Entities;
using System;


namespace Demokratianweb.Data.Infraestructure
{
    public class CandidatoRepository : Repository<CandidatoEntity,ApplicationDbContext>
    {
        private ApplicationDbContext _context;

        //Add any additional repository methods other than the generic ones (GetAll, Get, Delete, Add)
        public CandidatoRepository(ApplicationDbContext context) : base(context)
        {
           
        }
    }
}
