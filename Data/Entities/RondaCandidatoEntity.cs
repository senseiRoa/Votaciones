using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Demokratianweb.Data.Entities
{
    public class RondaCandidatoEntity
    {
        [Key]
        public Guid Id { get; set; }

        [ForeignKey("RondaVotacion")]
        public Guid IdRondaVotacion { get; set; }
        public virtual RondaVotacionEntity RondaVotacion { get; set; }

        [ForeignKey("VotacionCandidato")]
        public Guid IdVotacionCandidato { get; set; }
        public virtual VotacionCandidatoEntity VotacionCandidato { get; set; }
    }
}
