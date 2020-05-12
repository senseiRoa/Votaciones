using Demokratianweb.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demokratianweb.Models
{
    public class VotoWrapper
    {
        public Guid RondaId { get; set; }
        public Guid? CandidatoId { get; set; }
        
    }
}
