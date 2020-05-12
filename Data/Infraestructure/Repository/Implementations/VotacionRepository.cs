

using Demokratianweb.Data.Entities;
using System;


namespace Demokratianweb.Data.Infraestructure
{
    public class VotacionRepository : Repository<VotacionEntity,ApplicationDbContext>
    {
        private ApplicationDbContext _context;

        //Add any additional repository methods other than the generic ones (GetAll, Get, Delete, Add)
        public VotacionRepository(ApplicationDbContext context) : base(context)
        {
           
        }
    }
}
