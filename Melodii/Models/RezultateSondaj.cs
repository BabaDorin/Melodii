using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Melodii.Models
{
    public struct Rezultat
    {
        public string Melodie;
        public string Interpret;
        public int PozitieInTop;
        public int PozitiaIndicata;
        public int PuncteAcumulate;
    }
    class RezultateSondaj
    {
        public string Participant { get; set; }
        public List<Rezultat> Rezultate { get; set; }
        public int ScorFinal { get; set; }
    }
}
