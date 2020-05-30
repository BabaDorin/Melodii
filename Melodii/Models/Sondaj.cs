using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Melodii.Models
{
    public class Sondaj
    {
        public int IdSondaj { get; set; }
        public int IdParticipant { get; set; }
        public DateTime Data { get; set; }
        public int ScorFinal { get; set; }
        public IEnumerable<Vot> Voturi { get; set; }
    }
}
