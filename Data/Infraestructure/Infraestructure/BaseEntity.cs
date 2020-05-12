
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Demokratianweb.Data.Enums.HelpConstantes;

namespace Demokratianweb.Data.Infraestructure
{
    public class BaseEntity
    {
        public EstadoRegistro EstadoRegistro { get; set; }
        public DateTime fechaCreacion { get; set; }        
        public DateTime fechaEdicion { get; set; }        
        public DateTime? fechaEliminacion { get; set; }
        
    }
}
