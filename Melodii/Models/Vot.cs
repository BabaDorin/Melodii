using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Melodii.Models
{
    class Vot
    {
        public int IdVot { get; set; }
        public int IdParticipant { get; set; }
        public int IdMelodie { get; set; }
        public int ScorVot { get; set; }
    }
}
