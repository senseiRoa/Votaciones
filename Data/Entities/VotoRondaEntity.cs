using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Demokratianweb.Data.Entities
{
    public class VotoRondaEntity
    {
        [Key]
        public Guid Id { get; set; }
        public string _hash { get; set; }


        [ForeignKey("RondaCandidato")]
        public Guid idRondaCandidato { get; set; }
        public virtual RondaCandidatoEntity RondaCandidato { get; set; }
    }
    
}
