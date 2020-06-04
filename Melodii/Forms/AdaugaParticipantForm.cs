using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using static Melodii.Reusable;
using static Melodii.DB_Methods;
using System.Diagnostics;
using Melodii.Models;

namespace Melodii.Forms
{
    public partial class AdaugaParticipantForm : Form
    {
        private static int speed = 1;
        private static List<TextBox> InvalidTextBoxes = new List<TextBox>();

        public AdaugaParticipantForm()
        {
            InitializeComponent();

            label6.Visible = false;
            label2.Left = -label2.Width;
            speed = (label1.Left - label2.Left) / 10;

            //Efectul de placeholder
            tbNume.Enter += tb_Enter;
            tbNume.Leave += tb_Leave;
            tbScor.Enter += tb_Enter;
            tbScor.Leave += tb_Leave;
            tbInformatii.Enter += tb_Enter;
            tbInformatii.Leave += tb_Leave;
            tbVarsta.Enter += tb_Enter;
            tbVarsta.Leave += tb_Leave;
        }

        #region ButtonEvents
        private void btSave_Click(object sender, EventArgs e)
        {
            //Valideaza datele
            //Daca totul este ok, datele sunt salvate in baza de date, iar in locul acestei forme
            //este afisat un mesaj de succes pentru 2 secunde, dupa care forma va reveni avand campurile goale.
            try
            {
                //-----------------------------------< Validare >-----------------------------------

                if (tbNume.Text == tbNume.Tag.ToString())
                    InvalidTextBoxes.Add(tbNume);
                int validare;
                if (tbScor.Text != tbScor.Tag.ToString() && !int.TryParse(tbScor.Text, out validare))
                    InvalidTextBoxes.Add(tbScor);
                if (tbVarsta.Text == tbVarsta.Tag.ToString() || !int.TryParse(tbVarsta.Text, out validare)
                    || int.Parse(tbVarsta.Text) < 0)
                    InvalidTextBoxes.Add(tbVarsta);

                if (InvalidTextBoxes.Count > 0)
                {
                    throw new Exception("Eroare. Asigurati-va ca ati completat toate campurile necesare cu date valide."
                        + Environment.NewLine + "Campurile pentru Varsta si Scor acceapta doar numere intregi.");
                }

                //-----------------------------------< Salvarea datelor >-----------------------------------

                try
                {
                    int Scor;
                    if (!int.TryParse(tbScor.Text, out Scor))
                        Scor = 0;

                    Participant participant = new Participant
                    {
                        Nume = tbNume.Text,
                        Scor = Scor,
                        Informatii = (tbInformatii.Text.Trim() == tbInformatii.Tag.ToString()) ? null : tbInformatii.Text,
                        Varsta = int.Parse(tbVarsta.Text)
                    };

                    InsertParticipant(participant);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    throw new Exception("Eroare. Datele nu au fost salvate din cauza unei probleme tehnice.");
                }

                slideIn = false;
                timer1.Start();
            }
            catch (Exception ex)
            {
                //Verificam daca exceptia este cauzata de invaliditatea datelor
                if(InvalidTextBoxes.Count > 0)
                {
                    //Zguduirea campurilor invalide
                    speed = 1;
                    lbEroare.Text = ex.Message;
                    Shakes = 0;
                    foreach (TextBox t in InvalidTextBoxes)
                        t.Left = label4.Left;
                    timer2.Start();
                }

                lbEroare.Text = ex.Message;
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
                    speed += label2.Left / 30;
                }
                else
                {
                    timer1.Stop();
                    label2.Dispose();
                    slideIn = true;

                    label6.Top = 0;
                    label6.Left = 0;
                    label6.Width = this.Width;
                    label6.Height = this.Height;
                    label6.BringToFront();
                    label6.TextAlign = ContentAlignment.MiddleCenter;
                    label6.Text = "Participantul a fost intregistrat cu succes!";
                    label6.Visible = true;
                    timer3.Start();
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
            //Zguduirea campurilor invalide
            if (Shakes == 3 && InvalidTextBoxes[0].Left == label4.Left)
            {
                Shakes = 0;
                InvalidTextBoxes.Clear();
                timer2.Stop();
            }
            else
            {
                if (InvalidTextBoxes[0].Left - label4.Left >= 5 || label4.Left - InvalidTextBoxes[0].Left >= 5)
                {
                    speed *= -1;
                    Shakes++;
                }

                foreach (TextBox tb in InvalidTextBoxes)
                {
                    tb.Left += speed;
                }
            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            //Afisarea mesajului de confirmare pentru 2 secunde.
            label6.Dispose();
            timer3.Stop();
            Panel parent = (Panel)this.Parent;
            this.Close();
            openChildForm(new AdaugaParticipantForm(), parent);
        }
        #endregion
    }
}
