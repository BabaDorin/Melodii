using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Melodii.Forms
{
    public partial class HomeForm : Form
    {
        public HomeForm()
        {
            InitializeComponent();
            string[] Citate = new string[]
            {
                "\"A cânta este cu adevărat un alt fel de a respira\", Rainer Maria Rilke",
                "\"Oamenii care nu știu nimic despre muzică sunt cei care vorbesc întotdeauna despre ea\", Nat King Cole",
                "\"Dacă poate fi schimbat ceva în lume, acest lucru se poate întâmpla numai prin muzică\", Jimi Hendrix",
                "\"Un pictor își realizează opera pe o pânză, iar muzicienii își pictează creațiile pe tăcere\", Leopold Stokowski",
                "\"Muzică este felul în care sună viața\", Eric Olson",
                "\"Muzica este o revelație mai mare decât toată înțelepciunea și filosofia\", Ludwig van Beethoven",
                "\"Muzica este leacul minții\", John A. Logan",
                "\"Muzica este aritmetica sunetelor\", Claude Debussy",
                "\"Muzica este un dialog\", Alex Van Halen",
                "\"Muzica este refugiul universal pentru sufletele alungate de acasă\", Octavian Bibere",
                "\"Muzica este vibrația iubirii pe înțelesul fiecărei inimi\", Ioan Gyuri Pascu",
                "\"Fără muzică, viața ar putea fi doar o eroare\", Friedrich Wilhelm Nietzsche",
                "\"Pentru refacerea sufletului nu există terapii mai eficiente decât muzica\", Joseph Gangemi",
            };

            lbQuote.Text = RandomQuote(Citate);
        }

        private static string RandomQuote(string[] Citate)
        {
            Random rnd = new Random();
            int index = rnd.Next(Citate.Length - 1);
            return Citate[index];
        }
    }
}
