using Demokratianweb.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demokratianweb.Models
{
    public class RondaVotacionWrapper
    {
        public RondaVotacionEntity Rondavotacion { get; set; }
        public List<string> Candidatos { get; set; }
        public List<string> Votantes { get; set; }
    }
}
