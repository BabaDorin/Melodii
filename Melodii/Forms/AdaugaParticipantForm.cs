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
using System.Data.SqlClient;
using System.IO;
using System.Reflection.Emit;
using System.Diagnostics;

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
        }

        #region ButtonEvents
        private void btSave_Click(object sender, EventArgs e)
        {
            //Valideaza datele
            //Daca totul este ok, datele sunt salvate in baza de date, iar in locul acestei forme
            //este afisat un mesaj de succes pentru 1 secunda, dupa care forma va reveni avand campurile goale.

            try
            {
                //-----------------------------------< Validare >-----------------------------------

                //Validarea datelor.

                if (tbNume.Text == tbNume.Tag.ToString())
                    InvalidTextBoxes.Add(tbNume);
                int validare;
                if (tbScor.Text != tbScor.Tag.ToString() && !int.TryParse(tbScor.Text, out validare))
                    InvalidTextBoxes.Add(tbScor);
                if (tbVarsta.Text == tbVarsta.Tag.ToString() || !int.TryParse(tbVarsta.Text, out validare))
                    InvalidTextBoxes.Add(tbVarsta);

                if (InvalidTextBoxes.Count > 0)
                {
                    throw new Exception("Eroare. Asigurati-va ca ati completat toate campurile necesare cu date valide."
                        + Environment.NewLine + "Campurile pentru Varsta si Scor acceapta doar numere intregi.");
                }

                //-----------------------------------< Salvarea datelor >-----------------------------------

                try
                {
                    string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + Directory.GetCurrentDirectory() + @"\Database.mdf;Integrated Security=True";
                    SqlConnection Connection = new SqlConnection(connectionString);

                    //Vom folosi parametri sql pentru ca aplicatia sa fie imuna atacurilor de tip SQL Injection
                    SqlCommand cmd = new SqlCommand("INSERT INTO PARTICIPANTI" +
                    "(Nume, Scor, Informatii, Varsta)" +
                    "VALUES" +
                    "(@Nume, @Scor, @Informatii, @Varsta); ", Connection);
                    SqlParameter parNume = new SqlParameter("@Nume", tbNume.Text);
                    cmd.Parameters.Add(parNume);

                    SqlParameter parScor;
                    if (tbScor.Text != tbScor.Tag.ToString())
                        parScor = new SqlParameter("@Scor", tbScor.Text);
                    else
                        parScor = new SqlParameter("@Scor", "0");
                    cmd.Parameters.Add(parScor);

                    SqlParameter parInformatii;
                    if (tbInformatii.Text != tbInformatii.Tag.ToString())
                        parInformatii = new SqlParameter("@Informatii", tbInformatii.Text);
                    else
                        parInformatii = new SqlParameter("@Informatii", DBNull.Value);
                    cmd.Parameters.Add(parInformatii);

                    SqlParameter parVarsta = new SqlParameter("@Varsta", int.Parse(tbVarsta.Text));
                    cmd.Parameters.Add(parVarsta);

                    //Executarea comenzii INSERT
                    if (Connection.State != ConnectionState.Open)
                        Connection.Open();
                    cmd.ExecuteNonQuery();
                    Connection.Close();
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
            label6.Dispose();
            timer3.Stop();
            Panel parent = (Panel)this.Parent;
            this.Close();
            openChildForm(new AdaugaParticipantForm(), parent);
        }
        #endregion
    }
}
