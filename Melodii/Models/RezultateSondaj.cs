using System.Collections.Generic;

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
        public List<Rezultat> Rezultate = new List<Rezultat>();
        public int ScorFinal { get; set; }
    }
}
