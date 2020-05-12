using Demokratianweb.Data.Infraestructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Demokratianweb.Data.Entities
{
    public class ControlVotoVotanteEntity: BaseEntity
    {
        [Key]
        public Guid Id { get; set; }

        [ForeignKey("RondaVotacion")]
        public Guid IdRondaVotacion { get; set; }
        public virtual RondaVotacionEntity RondaVotacion { get; set; }

        [ForeignKey("VotacionVotante")]
        public Guid IdVotacionVotante { get; set; }
        public virtual VotacionVotanteEntity VotacionVotante { get; set; }
    }
   
}
