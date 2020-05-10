using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using static Demokratianweb.Data.Enums.HelpConstantes;

namespace Demokratianweb.Data.Entities
{
    public class RondaVotacionEntity
    {
        [Key]
        public Guid Id { get; set; }
        public string Descripcion { get; set; }
        public EstadoRondaVotacion Estado { get; set; }

        [ForeignKey("Votacion")]
        public Guid IdVotacion { get; set; }
        public virtual VotacionEntity Votacion { get; set; }


    }
}
