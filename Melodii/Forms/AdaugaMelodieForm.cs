﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using static Melodii.Reusable;
using static Melodii.DB_Methods;
using Melodii.Models;

namespace Melodii.Forms
{
    public partial class AdaugaMelodieForm : Form
    {
        private static int speed = 1;
        public AdaugaMelodieForm()
        {
            InitializeComponent();
            label6.Visible = false;
            slidingBar.Left = -slidingBar.Width;
            speed = (label1.Left - slidingBar.Left) / 6;

            //Efectul de placeholder
            tbDenumire.Enter += tb_Enter;
            tbDenumire.Leave += tb_Leave;
            tbInterpret.Enter += tb_Enter;
            tbInterpret.Leave += tb_Leave;
            tbGen.Enter += tb_Enter;
            tbGen.Leave += tb_Leave;
            tbPuncte.Enter += tb_Enter;
            tbPuncte.Leave += tb_Leave;
            tbInformatii.Enter += tb_Enter;
            tbInformatii.Leave += tb_Leave;
        }

        #region ButtonEvents
        private void btSave_Click(object sender, EventArgs e)
        {
            int puncte;
            try
            {
                //-----------------------------------< Validare >-----------------------------------

                //Un input este considerat invalid atunci cand acesta fie lipseste, fie nu corespunde tipului de date necesar. 
                if (tbInterpret.Text.Trim() == (string)tbInterpret.Tag
                || tbDenumire.Text.Trim() == (string)tbDenumire.Tag
                || tbGen.Text.Trim() == (string)tbGen.Tag
                || tbPuncte.Text.Trim() == (string)tbPuncte.Tag
                || !int.TryParse(tbPuncte.Text, out puncte))
                    throw new Exception("Eroare. Asigurati-va ca ati completat toate campurile necesare cu date valide.");

                //-----------------------------------< Salvarea datelor >-----------------------------------

                try
                {
                    Melodie melodie = new Melodie
                    {
                        Denumire = tbDenumire.Text,
                        GenMuzical = tbGen.Text,
                        Interpret = tbInterpret.Text,
                        Puncte = int.Parse(tbPuncte.Text),
                        Informatii = (tbInformatii.Text.Trim() == tbInformatii.Tag.ToString()) ? null : tbInformatii.Text,
                    };

                    InsertMelodie(melodie);
                }
                catch (Exception)
                { 
                    throw new Exception("Eroare. Datele nu au fost salvate din cauza unei probleme tehnice.");
                }

                //-----------------------------------< Afisarea mesajului de confirmare >-----------------------------------

                //Bara se va deplasa spre dreapta.
                slideIn = false;
                timer1.Start();
            }
            catch (Exception ex)
            {
                //----------------------< Atentionarea utilizatorului privind invaliditatea datelor>-----------------------------------

                lbEroare.Text = ex.Message;

                //Zguduirea campurilor lipsa
                speed = 1;
                Shakes = 0;
                tbInterpret.Left = tbDenumire.Left = tbGen.Left = tbPuncte.Left = label4.Left;
                InvalidTextBoxes = new List<TextBox>();
                if (tbInterpret.Text.Trim() == (string)tbInterpret.Tag)
                    InvalidTextBoxes.Add(tbInterpret);
                if (tbDenumire.Text.Trim() == (string)tbDenumire.Tag)
                    InvalidTextBoxes.Add(tbDenumire);
                if (tbGen.Text.Trim() == (string)tbGen.Tag)
                    InvalidTextBoxes.Add(tbGen);
                if (tbPuncte.Text.Trim() == (string)tbPuncte.Tag || !int.TryParse(tbPuncte.Text, out puncte))
                    InvalidTextBoxes.Add(tbPuncte);
                timer2.Start();
            }
        }
        #endregion

        #region TimerEvents
        private static bool slideIn = true;
        private List<TextBox> InvalidTextBoxes;
        private static int Shakes = 0;

        private void timer1_Tick(object sender, EventArgs e)
        {
            //Sliding bar
            if (slideIn)
            {
                //Bara vine
                if (slidingBar.Left >= label1.Left)
                {
                    timer1.Stop();
                }
                else
                {
                    slidingBar.Left += speed;
                    speed = (label1.Left - slidingBar.Left) / 6;
                    if (speed < 1) speed = 1;
                }
            }
            else
            {
                //Bara pleaca
                if (slidingBar.Left <= this.Width)
                {
                    slidingBar.Left += speed;
                    speed += slidingBar.Left / 30;
                }
                else
                {
                    //Bara iese din limitele ferestrei, este distrusa pentru a elibera resursele
                    //dupa care este afisat mesajul de confirmare.
                    timer1.Stop();
                    slidingBar.Dispose();
                    slideIn = true;

                    label6.Top = 0;
                    label6.Left = 0;
                    label6.Width = this.Width;
                    label6.Height = this.Height;
                    label6.BringToFront();
                    label6.TextAlign = ContentAlignment.MiddleCenter;
                    label6.Text = "Melodia a fost inregistrata cu succes!";
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
            try
            {
                if (InvalidTextBoxes == null)
                {
                    timer2.Stop();
                }

                if (Shakes == 3 && InvalidTextBoxes[0].Left == label4.Left)
                {
                    Shakes = 0;
                    timer2.Stop();
                }
                else
                {
                    if (InvalidTextBoxes[0].Left - label4.Left >= 5 || label4.Left - InvalidTextBoxes[0].Left >= 5)
                    {
                        speed *= -1;
                        Shakes++;
                    }

                    foreach (TextBox t in InvalidTextBoxes)
                    {
                        t.Left += speed;
                    }
                }
            }
            catch (Exception ex)
            {
                timer2.Stop();
                Debug.WriteLine("Eroare Timer" + ex.Message);
                lbEroare.Text = "Datele n-au fost salvate.";
            }
            
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            //Afisarea mesajului de confirmare pentru 2 secunde.
            label6.Dispose();
            timer3.Stop();
            this.DialogResult = DialogResult.OK;
            Panel parent = (Panel)this.Parent;
            this.Close();
            openChildForm(new AdaugaMelodieForm(), parent);
        }
        #endregion
    }
}
