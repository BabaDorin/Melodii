using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Melodii.Models
{
    class Melodie
    {
        public int IdMelodie { get; set; }
        public string Denumire { get; set; }
        public string Interpret { get; set; }
        public string Informatii { get; set; }
        public int Puncte { get; set; }
        public int LoculInTop { get; set; }
    }
}
