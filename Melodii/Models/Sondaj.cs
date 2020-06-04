using System;
using System.Collections.Generic;

namespace Melodii.Models
{
    public class Sondaj
    {
        public int IdSondaj { get; set; }
        public int IdParticipant { get; set; }
        public string NumeParticipant { get; set; }
        public DateTime Data { get; set; }
        public int ScorFinal { get; set; }
        public IEnumerable<Vot> Voturi { get; set; }
    }
}
