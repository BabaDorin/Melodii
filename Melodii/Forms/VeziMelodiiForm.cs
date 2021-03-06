﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Melodii.Models;
using System.Diagnostics;
using static Melodii.DB_Methods;
using static Melodii.Reusable;

namespace Melodii.Forms
{
    public partial class VeziMelodiiForm : Form
    {
        private static List<Melodie> melodii = new List<Melodie>();
        bool formMinimized = false;

        public VeziMelodiiForm()
        {
            InitializeComponent();

            //Amplasarea elementelor vizuale
            slidingBar.Left = -slidingBar.Width;
            speedSlidingBar = (label1.Left - slidingBar.Left) / 6;
            panelInfo.Left = panelMelodii.Right + 50;
            panelMelodii.Width = Width / 100 * 50;

            //Extragerea datelor din BD
            LoadData();

            timerSlidingBar.Start();
        }

        private void LoadData()
        {

            //-----------------< Extrage melodiile din baza de date si stabileste locurile in top >----------------

            try
            {
                LoadMelodii(ref melodii, false);

                //Sortarea listei in ordine descrescatoare dupa punctele acumulate
                melodii.Sort((x, y) => x.Puncte.CompareTo(y.Puncte));
                
                //Stabilirea locurilor in top
                for(int i=0; i<melodii.Count; i++)
                {
                    melodii[i].LoculInTop = melodii.Count - i;
                }

                // Pentru fiecare melodie va fi creat un buton care va contine informatii
                // privind Denumirea, Interpretul si numarul de puncte ale acesteia.
                GenerateButtons(melodii, panelMelodiiButtons);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                lbError.Text = "Ne pare rau, s-a produs o eroare la incarcarea datelor.";
            }
        }

        #region DesignMethods
        private void GenerateButtons(List<Melodie> melodii, Panel parentPanel)
        {
            //Genereaza cate un buton pentru fiecare melodie. Butonul va contine informatii despre melodie,
            //precum: Denumirea, interpretul, numarul de puncte.
            panelMelodiiButtons.Controls.Clear();
            try
            {
                if (melodii != null && melodii.Count > 0)
                {
                    parentPanel.Controls.Clear();

                    for (int i = 0; i < melodii.Count; i++)
                    {
                        //Butonul propriu zis.
                        //Proprietatea Text va contine numele melodiei
                        //Proprietatea Tag va contine ID-ul melodiei.
                        Button btn = new Button();
                        btn.Dock = DockStyle.Top;
                        btn.Text = melodii[i].Denumire;
                        btn.Tag = melodii[i].IdMelodie;
                        btn.FlatStyle = FlatStyle.Flat;
                        btn.FlatAppearance.BorderSize = 0;
                        btn.Height = 60;
                        btn.TextAlign = ContentAlignment.MiddleLeft;
                        btn.Font = new Font("Leelawadee", 13);
                        btn.Click += new EventHandler(btInfo_Click);

                        //Label pentru a afisa numarul de puncte al melodiei
                        System.Windows.Forms.Label lbPoints = new System.Windows.Forms.Label();
                        lbPoints.Text = melodii[i].Puncte.ToString();
                        lbPoints.AutoSize = false;
                        lbPoints.Dock = DockStyle.Right;
                        lbPoints.BackColor = Color.Transparent;
                        lbPoints.Font = new Font("Leelawadee", 10);
                        lbPoints.TextAlign = ContentAlignment.MiddleCenter;

                        //Label pentru afisarea interpretului
                        System.Windows.Forms.Label lbInterpret = new System.Windows.Forms.Label();
                        lbInterpret.Text = melodii[i].Interpret;
                        lbInterpret.ForeColor = Color.LightGray;
                        lbInterpret.BackColor = Color.Transparent;
                        lbInterpret.Dock = DockStyle.Bottom;
                        lbInterpret.Font = new Font("Leelawadee", 10);

                        btn.Controls.Add(lbInterpret);
                        btn.Controls.Add(lbPoints);

                        parentPanel.Controls.Add(btn);
                    }
                }
                else
                {
                    //Baza de date nu contine melodii inregistrate, Afisam un mesaj informativ
                    System.Windows.Forms.Label label = new System.Windows.Forms.Label();
                    label.Font = new Font("Leelawadee", 13);
                    label.ForeColor = Color.WhiteSmoke;
                    label.Dock = DockStyle.Fill;
                    label.TextAlign = ContentAlignment.TopCenter;
                    label.Text = "Nu exista melodii spre afisare.";
                    label.Image = Properties.Resources.shrug;
                    label.ImageAlign = ContentAlignment.MiddleCenter;
                    panelMelodiiButtons.Controls.Add(label);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                lbError.Text = "S-a produs o eroare la incarcarea datelor. Incercati din nou.";
            }        
        }

        private void VeziMelodiiForm_Resize(object sender, EventArgs e)
        {
            // In cazul in care are loc redimensionarea ferestrei:
            //
            // 1) Vom modifica pozitia si dimensiunile celor 2 panele, cel pentru afisarea listei
            // melodiilor, si cel pentru afisarea informatiei despre fiecare melodie in parte.
            //
            // 2) Vom re-analiza modul in care este afisat numele melodiei
            // Daca fereastra a fost marita, atunci denumirea va contine mai multe litere ca urmare
            // a maririi lungimii butoanelor, in caz contrar, denumirea va fi scurtata.

            Debug.WriteLine("Resize called");
            int lastMelodiiWidth = panelMelodii.Width;
            panelMelodii.Width = Width / 100 * 45;
            panelMelodii.Height = this.Height - panelMelodii.Top - 50;
            panelInfo.Left = panelMelodii.Right + 50;
            panelInfo.Width = this.Right - panelInfo.Left - 20;
            btTop3.Left = panelMelodii.Right - btTop3.Width;

            if (lastMelodiiWidth > panelMelodii.Width)
                formMinimized = true;
            else
                formMinimized = false;

            if(melodii.Count>0)
                foreach(Button btn in panelMelodiiButtons.Controls)
                {
                    if (formMinimized)
                    {
                        //In cazul in care forma este minimizata, denumirea este scurtata.
                        ScurtareDenumire(btn, panelMelodii.Width);
                    }
                    else
                    {
                        // In cazul in care forma este maximizata, verificam daca 
                        // denumirea care este afisata este scurtata. In caz afirmativ,
                        // marim numarul de caractere ce vor fi afisate.
                        string initialButtonText = melodii.First(x => x.IdMelodie == int.Parse(btn.Tag.ToString())).Denumire;
                        if (btn.Text.Length < initialButtonText.Length)
                        {
                            btn.Text = initialButtonText;
                            ScurtareDenumire(btn, panelMelodii.Width);
                        }
                    }
                }
        }
        #endregion

        #region ButtonEvents
        private void btInfo_Click(object sender, EventArgs e)
        {
            // Evenimentul declansat de catre un click pe butonul destinat unei melodii.
            // Acesta va crea un nou panel in care va introduce toate datele disponibile
            // despre melodia aleasa.

            panelInfo.Controls.Clear();
            Panel panelMelody = new Panel();
            panelMelody.Width = panelInfo.Width;
            panelMelody.Height = panelInfo.Height;

            // Id-ul melodiei se afla in propritatea [Tag] a butonului, drept urmare
            Melodie melodie = melodii.First(m => m.IdMelodie == int.Parse((sender as Button).Tag.ToString()));

            //Label pentru denumire
            System.Windows.Forms.Label Denumire = new System.Windows.Forms.Label();
            Denumire.Text = melodie.Denumire;
            Denumire.Font = new Font("Leelawadee", 16);
            Denumire.AutoSize = true;
            Denumire.Width = panelInfo.Width;
            Denumire.Dock = DockStyle.Top;
            Denumire.MaximumSize = new Size(Denumire.Width, 0);

            //Label pentru Interpret
            System.Windows.Forms.Label Interpret = new System.Windows.Forms.Label();
            Interpret.Text = melodie.Interpret;
            Interpret.ForeColor = Color.LightGray;
            Interpret.Font = new Font("Leelawadee", 12);
            Interpret.AutoSize = true;
            Interpret.Width = Denumire.Width;
            Interpret.Dock = DockStyle.Top;
            Interpret.MaximumSize = new Size(Interpret.Width, 0);
            Interpret.Padding = new Padding(5);

            //Label pentru butonul de excludere a melodiei
            Button exclude = new Button();
            exclude.Padding = new Padding(10);
            exclude.Dock = DockStyle.Top;
            exclude.FlatStyle = FlatStyle.Flat;
            exclude.ForeColor = Color.WhiteSmoke;
            exclude.FlatAppearance.BorderSize = 0;
            exclude.Text = "Exclude melodia";
            exclude.AutoSize = true;
            exclude.Click += btExclude_Click;
            exclude.Tag = melodie.IdMelodie;
            panelMelody.Controls.Add(exclude);

            System.Windows.Forms.Label Spatiu = new System.Windows.Forms.Label();
            Spatiu.Height = 50;
            Spatiu.Dock = DockStyle.Top;
            Spatiu.AutoSize = true;
            panelMelody.Controls.Add(Spatiu);

            //Label pentru afisarea punctelor
            System.Windows.Forms.Label Puncte = new System.Windows.Forms.Label();
            Puncte.Text = String.Format("Puncte: " + melodie.Puncte.ToString());
            Puncte.ForeColor = Color.LightGray;
            Puncte.Font = new Font("Leelawadee", 10);
            Puncte.AutoSize = true;
            Puncte.Width = Denumire.Width;
            Puncte.Dock = DockStyle.Top;
            Puncte.MaximumSize = new Size(Interpret.Width, 0);
            Puncte.Padding = new Padding(5);
            panelMelody.Controls.Add(Puncte);

            //Label pentru afisarea locului in top
            System.Windows.Forms.Label LocTop = new System.Windows.Forms.Label();
            LocTop.Text = String.Format("Locul in top: " + melodie.LoculInTop.ToString());
            LocTop.ForeColor = Color.LightGray;
            LocTop.Font = new Font("Leelawadee", 10);
            LocTop.AutoSize = true;
            LocTop.Width = Denumire.Width;
            LocTop.Dock = DockStyle.Top;
            LocTop.MaximumSize = new Size(Interpret.Width, 0);
            LocTop.Padding = new Padding(5);
            panelMelody.Controls.Add(LocTop);

            if (melodie.Informatii != "")
            {
                //Label pentru afisarea informatiilor aditionale, in cazul in care acestea exista.
                System.Windows.Forms.Label Informatii = new System.Windows.Forms.Label();
                Informatii.Text = String.Format($"Informatii: {melodie.Informatii}");
                Informatii.ForeColor = Color.LightGray;
                Informatii.Font = new Font("Leelawadee", 10);
                Informatii.AutoSize = true;
                Informatii.Width = Denumire.Width;
                Informatii.Dock = DockStyle.Top;
                Informatii.MaximumSize = new Size(panelInfo.Width, 0);
                Informatii.Padding = new Padding(5);
                panelMelody.Controls.Add(Informatii);
            }

            panelMelody.Controls.Add(Interpret);
            panelMelody.Controls.Add(Denumire);

            //Deplasarea panelului spre stanga si pregatirea terenului pentru slide.
            panelMelody.Left = -panelMelody.Width;
            speedMovingPanel = (panelMelody.Left) / 3;
            panelInfo.Controls.Add(panelMelody);
            movingPanel = panelMelody;
            timerSlideInDetails.Start();
        }

        private void btExclude_Click(object sender, EventArgs e)
        {
            //In urma apasarii butonului [Exclude], va aparea un messagebox pentru confirmare.
            //In cazul in care raspunstul este OK, se va purcede la eliminarea melodiei din baza de date.
            Form Messagebox = new MessageBox();
            int idMelodie = int.Parse((sender as Button).Tag.ToString());
            string Denumire = melodii.First(m => m.IdMelodie == idMelodie).Denumire;
            Messagebox.Tag = String.Format("Sunteti sigur ca doriti sa excludeti melodia {0}?", Denumire);
            Messagebox.ShowDialog();

            if (Messagebox.DialogResult == DialogResult.OK)
            {
                //Eliminarea melodiei din baza de date
                try
                {
                    RemoveMelodie(idMelodie);
                    LoadData();
                    panelInfo.Controls.Clear();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    lbError.Text = "Ne pare rau, s-a produs o eroare, melodia nu a fost exclusa.";
                }
            }
        }

        private void btTop3_Click(object sender, EventArgs e)
        {
            //Lista deja este sortata. Ultimele 3 melodii sunt cele mai populare.
            if (melodii.Count > 3)
            {
                melodii.RemoveRange(0, melodii.Count - 3);
            }

            GenerateButtons(melodii, panelMelodiiButtons);
        }
        #endregion

        #region TimerEvents
        //Deplasarea liniei
        private static int speedSlidingBar;
        private static bool slideIn = true;
        private void timerSlidingBar_Tick(object sender, EventArgs e)
        {
            if (slideIn)
            {
                //Bara vine
                if (slidingBar.Left >= label1.Left)
                {
                    timerSlidingBar.Stop();
                }
                else
                {
                    slidingBar.Left += speedSlidingBar;
                    speedSlidingBar = (label1.Left - slidingBar.Left) / 6;
                    if (speedSlidingBar < 1) speedSlidingBar = 1;
                }
            }
            else
            {
                //bara pleaca
                if (slidingBar.Left <= this.Width)
                {
                    slidingBar.Left += speedSlidingBar;
                    speedSlidingBar += slidingBar.Left / 30;
                }
                else
                {
                    //Bara iese din limitele ferestrei, este distrusa pentru a elibera resursele
                    //dupa care este afisat mesajul de confirmare.
                    timerSlidingBar.Stop();
                    slidingBar.Dispose();
                    slideIn = true;
                }
            }
        }

        //Deplasarea blocului cu informatii despre melodia aleasa.
        private static Panel movingPanel;
        private static int speedMovingPanel;
        private void timerSlideInDetails_Tick(object sender, EventArgs e)
        {
            if (movingPanel.Left >= 0)
            {
                timerSlideInDetails.Stop();
                movingPanel.Dock = DockStyle.Fill;
            }
            else
            {
                movingPanel.Left += speedMovingPanel;
                speedMovingPanel = (-movingPanel.Left) / 3;
                if (speedMovingPanel < 1) speedMovingPanel = 1;
            }
        }
        #endregion
    }
}
