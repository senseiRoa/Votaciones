using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demokratianweb.Models
{
    public class ResultadoRonda
    {
        public int TotalVotos { get; set; }
        //public List<string> Candidatos { get; set; }
        //public List<int> Votos { get; set; }
        public List<ResultTemp> resultados { get; set; }
        public ResultadoRonda()
        {
            resultados = new List<ResultTemp>();
            
        }
    }

    public class ResultTemp {
        public int votos { get; set; }
        public string candidato { get; set; }
    }
}
