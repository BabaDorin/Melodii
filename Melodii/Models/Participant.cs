﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Melodii.Models
{
    public class Participant
    {
        public int IdParticipant { get; set; }
        public string Nume { get; set; }
        public int Scor { get; set; }
        public string Informatii { get; set; }
        public int Varsta { get; set; }
    }
}
