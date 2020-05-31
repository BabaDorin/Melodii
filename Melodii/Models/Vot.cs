using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Melodii.Models
{
    public class Vot
    {
        public int IdVot { get; set; }
        public int IdParticipant { get; set; }
        public string NumeParticipant { get; set; }
        public int IdMelodie { get; set; }
        public string DenumireMelodie { get; set; }
        public int ScorVot { get; set; }
        public int IdSondaj { get; set; }
        public int PozitieTop { get; set; }
        public int PozitiaIndicata { get; set; }
    }
}
