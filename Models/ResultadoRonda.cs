using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demokratianweb.Models
{
    public class ResultadoRonda
    {
        public int TotalVotos { get; set; }
        public List<string> Candidatos { get; set; }
        public List<int> Votos { get; set; }
        public ResultadoRonda()
        {
            Votos = new List<int>();
            Candidatos = new List<string>();
        }
    }
}
