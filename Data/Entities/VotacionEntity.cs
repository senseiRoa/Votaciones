using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using static Demokratianweb.Data.Enums.HelpConstantes;

namespace Demokratianweb.Data.Entities
{
    public class VotacionEntity
    {
        [Key]
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public EstadoVotacion Estado { get; set; }
        public DateTime  fechaInicial { get; set; }
        public DateTime  fechaFinal { get; set; }
        
    }
    
}
