using Demokratianweb.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Demokratianweb.Data.Enums.HelpConstantes;

namespace Demokratianweb.Models
{
    public class VotacionWrapper
    {
        public VotacionDTO Votacion { get; set; }
        public List<string> Candidatos { get; set; }
        public List<string> Votantes { get; set; }
    }

    public class VotacionDTO 
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public EstadoVotacion Estado { get; set; }
        public DateTime fechaInicial { get; set; }
        public DateTime fechaFinal { get; set; }

    }
}
