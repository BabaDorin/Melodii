using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Melodii.DesignFunctionalities;

namespace Melodii.Forms
{
    public partial class AdaugaParticipantForm : Form
    {
        private static int speed = 1;
        public AdaugaParticipantForm()
        {
            InitializeComponent();
            label6.Visible = false;
            label2.Left = -label2.Width;
            speed = (label1.Left - label2.Left) / 10;
        }

        #region ButtonEvents
        private void btSave_Click(object sender, EventArgs e)
        {
            //Valideaza datele
            //Daca totul este ok, datele sunt salvate in baza de date, iar in locul acestei forme
            //este afisat un mesaj de succes pentru 1 secunda, dupa care forma va reveni avand campurile goale.

            if (tbNume.Text == tbNume.Tag.ToString())
            {
                speed = 1;
                lbEroare.Text = "*Eroare. Asigurati-va ca ati completat toate campurile.";
                Shakes = 0;
                tbNume.Left = label4.Left;

                //Zguduirea campurilui lipsa (in cazul dat, doar a campului 'Nume', celelate sunt optionale).
                timer2.Start();
            }
            else
            {
                slideIn = false;
                timer1.Start();

                //Salvarea tuturor datelor si asigurarea ca totul s-a decurs cum trebuie

                label6.Top = 0;
                label6.Left = 0;
                label6.Width = this.Width;
                label6.Height = this.Height;
                label6.TextAlign = ContentAlignment.MiddleCenter;
                label6.Text = "Participantul a fost inregistrat cu succes!";
                label6.Visible = true;
                timer3.Start();
            }
        }

        private void tb_Enter(object sender, EventArgs e)
        {
            TextBox tb = sender as TextBox;
            if (tb.Tag.ToString() == tb.Text)
            {
                tb.Text = "";
                tb.ForeColor = Color.WhiteSmoke;
            }
        }

        private void tb_Leave(object sender, EventArgs e)
        {
            TextBox tb = sender as TextBox;
            if (tb.Text.Trim() == "")
            {
                tb.Text = tb.Tag.ToString();
                tb.ForeColor = Color.Gray;
            }
        }
        #endregion

        #region TimerEvents
        private static bool slideIn = true;
        private static int Shakes = 0;

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (slideIn)
            {
                //Bara vine
                if (label2.Left >= label1.Left)
                {
                    timer1.Stop();
                }
                else
                {
                    label2.Left += speed;
                    speed = (label1.Left - label2.Left) / 6;
                    if (speed < 1) speed = 1;
                }
            }
            else
            {
                //bara pleaca
                if (label2.Left <= this.Width)
                {
                    label2.Left += speed;
                    speed += label2.Left / 20;
                }
                else
                {
                    timer1.Stop();
                    label2.Dispose();
                    slideIn = true;
                }

                //Totodata sterge treptat si mesajul de eroare, in caz in care acesta exista
                if (lbEroare.Text.Length > 0)
                {
                    int lungime = (lbEroare.Text.Length - 6 < 0) ? 0 : lbEroare.Text.Length - 6;
                    lbEroare.Text = lbEroare.Text.Substring(0, lungime);
                }
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (Shakes == 3 && tbNume.Left == label4.Left)
            {
                Shakes = 0;
                timer2.Stop();
            }
            else
            {
                if (tbNume.Left - label4.Left >= 5 || label4.Left - tbNume.Left >= 5)
                {
                    speed *= -1;
                    Shakes++;
                }

                tbNume.Left += speed;
            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            label6.Dispose();
            timer3.Stop();
            Panel parent = (Panel)this.Parent;
            this.Close();
            openChildForm(new AdaugaParticipantForm(), parent);
        }
        #endregion
    }
}
