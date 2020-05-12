using Demokratianweb.Data.Infraestructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Demokratianweb.Data.Entities
{
    public class CandidatoEntity: BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        //public string urlImage { get; set; }
    }
    
}
