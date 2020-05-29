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
using static Melodii.DB_Methods;

namespace Melodii.Forms.Sondaj
{
    public partial class SondajForm : Form
    {
        private static List<Melodie> melodii = new List<Melodie>();
        private static int CurrentId = 0;
        public SondajForm(int IdParticipant)
        {
            InitializeComponent();
            label.Left = Width / 2 - label.Width / 2;
            lbMelodiiRamase.Left = Width / 2 - lbMelodiiRamase.Width / 2;
            lbParticipant.Left = Width / 2 - lbParticipant.Width / 2;
            
            //Extragerea melodiilor din baza de date
            DB_Methods.LoadMelodii(ref melodii);
        }

        private void RandomMelodie()
        { 
            if(melodii.Count == 0)
            {
                panelSondaj.BackColor = Color.Red;
                CurrentId = -1;
            }
            else
            {
                panelSondaj.Controls.Clear();
                //Melodiile for fi afisate in ordine aleatorie.
                Random rnd = new Random();
                int randomIndex = rnd.Next(0, melodii.Count - 1);
                Melodie random = melodii[randomIndex];

                Label lb = new Label();
                lb.Text = random.Denumire;
                panelSondaj.Controls.Add(lb);
                CurrentId = randomIndex;
            }
        }

        private void ProcesareVot()
        {
            //Remove melody from list
            //build vot object
            //insert vot into db and build sted by step the Sondaj object
            if (CurrentId != -1)
                melodii.RemoveAt(CurrentId);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ProcesareVot();
            RandomMelodie();
        }
    }
}
