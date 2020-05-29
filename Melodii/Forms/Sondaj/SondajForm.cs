using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Melodii.Models;

namespace Melodii.Forms.Sondaj
{
    public partial class SondajForm : Form
    {
        private static List<Melodie> melodii = new List<Melodie>();
        public SondajForm(int IdParticipant)
        {
            InitializeComponent();
            label.Left = Width / 2 - label.Width / 2;
            lbMelodiiRamase.Left = Width / 2 - lbMelodiiRamase.Width / 2;
            lbParticipant.Left = Width / 2 - lbParticipant.Width / 2;
        }

        private void LoadMelodii()
        {

        }

        private Melodie RandomMelodie()
        {
            //Melodiile for fi afisare in ordine aleatorie.
            return new Melodie();
        }

    }
}
