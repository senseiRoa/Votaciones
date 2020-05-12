

using Demokratianweb.Data.Entities;
using System;


namespace Demokratianweb.Data.Infraestructure
{
    public class VotoRondaRepository : Repository<VotoRondaEntity,ApplicationDbContext>
    {
        private ApplicationDbContext _context;

        //Add any additional repository methods other than the generic ones (GetAll, Get, Delete, Add)
        public VotoRondaRepository(ApplicationDbContext context) : base(context)
        {
           
        }
    }
}
