using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Demokratianweb.Data.Entities
{
    public class VotacionCandidatoEntity
    {
        [Key]
        public Guid Id { get; set; }


        [ForeignKey("Votacion")]
        public Guid IdVotacion { get; set; }
        public virtual VotacionEntity Votacion { get; set; }

        [ForeignKey("Candidato")]
        public Guid IdCandidato { get; set; }
        public virtual CandidatoEntity Votante { get; set; }
    }
   
}
