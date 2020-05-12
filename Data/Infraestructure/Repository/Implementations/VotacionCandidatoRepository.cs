

using System;
using System.Collections.Generic;
using System.Linq;
using Demokratianweb.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Demokratianweb.Data.Infraestructure
{
    public class VotacionCandidatoRepository : Repository<VotacionCandidatoEntity, ApplicationDbContext>
    {
        private ApplicationDbContext _context;

        //Add any additional repository methods other than the generic ones (GetAll, Get, Delete, Add)
        public VotacionCandidatoRepository(ApplicationDbContext context) : base(context)
        {

        }
    
    }
}
