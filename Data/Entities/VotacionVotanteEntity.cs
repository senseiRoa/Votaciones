using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Demokratianweb.Data.Entities
{
    public class VotacionVotanteEntity
    {
        [Key]
        public Guid Id { get; set; }


        [ForeignKey("Votacion")]
        public Guid IdVotacion { get; set; }
        public virtual VotacionEntity Votacion { get; set; }

        [ForeignKey("Votante")]
        public Guid IdVotante { get; set; }
        public virtual VotanteEntity Votante { get; set; }
    }
   
}
