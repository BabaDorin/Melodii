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
using System.Diagnostics;
using static Melodii.DB_Methods;
using System.IO.IsolatedStorage;

namespace Melodii.Forms.Sondaj
{
    public partial class SondajForm : Form
    {
        private static List<Melodie> melodii = new List<Melodie>();
        private static int nrMelodiiInitial = 0;
        private static int CurrentId = 0;
        private static Panel UpgoingPanel;
        private static Panel UpComingPanel;
        private static int speed;

        public SondajForm(int IdParticipant)
        {
            InitializeComponent();
            panelSondaj.Controls.Clear();
            UpgoingPanel = null;
            label.Left = Width / 2 - label.Width / 2;
            lbMelodiiRamase.Left = Width / 2 - lbMelodiiRamase.Width / 2;
            lbParticipant.Left = Width / 2 - lbParticipant.Width / 2;
            speed = Width / 10;

            //Extragerea melodiilor din baza de date
            DB_Methods.LoadMelodii(ref melodii);
            nrMelodiiInitial = melodii.Count();
            lbMelodiiRamase.Text = "Melodii ramase: " + (nrMelodiiInitial-1);
            lbProgessBar.Width = 0;
            lbProgessBar.Tag = (100 / (nrMelodiiInitial-1)).ToString();
            btNext.Enabled = false;

            RandomMelodie();
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
                //UpgoingPanel este panoul care va iesi din limitele ecranului atunci cand
                //se va trece la urmatoarea melodie
                if (UpgoingPanel == null)
                {
                    Panel empty = new Panel();
                    empty.Width = panelSondaj.Width;
                    panelSondaj.Controls.Add(empty);
                }else
                    UpgoingPanel.Dispose();
                UpgoingPanel = panelSondaj.Controls[0] as Panel;
                UpgoingPanel.Dock = DockStyle.None;

                //Melodiile for fi afisate in ordine aleatorie.
                Random rnd = new Random();
                int randomIndex = rnd.Next(0, melodii.Count);
                Melodie random = melodii[randomIndex];
                Debug.WriteLine(randomIndex);
                CurrentId = randomIndex;

                //Panoul pentru afisarea informatiilor despre melodie
                Panel info = new Panel();
                //info.AutoSize = true;
                info.AutoScroll = true;
                info.Width = panelSondaj.Width;
                info.Height = panelSondaj.Height;

                Label Denumire = new Label();
                Denumire.Dock = DockStyle.Top;
                Denumire.Text = random.Denumire;
                Denumire.Font = new Font("Leelawadee", 20);
                Denumire.AutoSize = true;
                Denumire.MaximumSize = new Size(panelSondaj.Width, 0);


                Label Interpret = new Label();
                Interpret.Dock = DockStyle.Top;
                Interpret.Text = String.Format("\t" + random.Interpret);
                Interpret.Font = new Font("Leelawadee", 15);
                Interpret.ForeColor = Color.LightGray;
                Interpret.AutoSize = true;
                Interpret.MaximumSize = new Size(panelSondaj.Width, 0);

                Label Gen = new Label();
                Gen.Dock = DockStyle.Top;
                Gen.Text = String.Format($"Genul muzical: {random.GenMuzical}");
                Gen.Font = new Font("Leelawadee", 13);
                Gen.ForeColor = Color.LightGray;
                Gen.MaximumSize = new Size(info.Width, 0);
                Gen.Padding = new Padding(20);
                Gen.AutoSize = true;
                Gen.MaximumSize = new Size(panelSondaj.Width, 0);

                Panel comboPanel = new Panel();
                comboPanel.Dock = DockStyle.Top;
                comboPanel.Padding = new Padding(20);
                Label Text = new Label();
                Text.Dock = DockStyle.Left;
                Text.Text = "Pozitia in TOP: ";
                Text.Font = new Font("Leelawadee", 15);
                Text.ForeColor = Color.LightGray;
                Text.AutoSize = true;

                ComboBox cmbPozitieTop = new ComboBox();
                cmbPozitieTop.Dock = DockStyle.Top;
                cmbPozitieTop.MaximumSize = new Size(50, 50);
                for(int i=1; i<=50; i++)
                {
                    cmbPozitieTop.Items.Add(i);
                }
                cmbPozitieTop.BackColor = Color.FromArgb(10, 7, 36);
                cmbPozitieTop.Font = new Font("Leelawadee", 15);
                cmbPozitieTop.ForeColor = Color.WhiteSmoke;
                cmbPozitieTop.DropDownStyle = ComboBoxStyle.DropDownList;
                cmbPozitieTop.Width = 50;
                cmbPozitieTop.Dock = DockStyle.Left;
                cmbPozitieTop.SelectedValueChanged += cmb_ValueChanged;

                comboPanel.Controls.Add(cmbPozitieTop);
                comboPanel.Controls.Add(Text);

                info.Controls.Add(comboPanel);

                if (random.Informatii != "")
                {
                    Label Informatii = new Label();
                    Informatii.Dock = DockStyle.Top;
                    Informatii.Text = String.Format($"Informatii: {random.Informatii}");
                    Informatii.Font = new Font("Leelawadee", 13);
                    Informatii.ForeColor = Color.LightGray;
                    Informatii.Padding = new Padding(20);
                    Informatii.AutoSize = true;
                    Informatii.MaximumSize = new Size(panelSondaj.Width, 0);

                    info.Controls.Add(Informatii);
                }

                Label bar = new Label();
                bar.Height = 1;
                bar.Dock = DockStyle.Top;
                bar.Width = Denumire.Width;
                bar.BackColor = Color.WhiteSmoke;


                info.Controls.Add(Gen);
                info.Controls.Add(bar);
                info.Controls.Add(Interpret);
                info.Controls.Add(Denumire);
                panelSondaj.Controls.Add(info);
                speed = Width / 15;

                //UpComingPanel va fi panoul ce se va deplasa din dreapta catre mijlocul ecranului.
                UpComingPanel = info;
                UpComingPanel.Left = Width;
                SlidingPanel.Start();
            }
        }

        private void ProcesareVot()
        {
            //Remove melody from list
            //build vot object
            //insert vot into db and build sted by step the Sondaj object
            if (CurrentId != -1)
                melodii.RemoveAt(CurrentId);
            
            if(melodii.Count() == 0)
            {
                lbMelodiiRamase.Text = "";
            }
            else
                lbMelodiiRamase.Text = "Melodii ramase: " + (melodii.Count()-1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void cmb_ValueChanged(object sender, EventArgs e)
        {
            Debug.WriteLine("Dogto");
            btNext.Enabled = true;
        }
        private void SlidingPanel_Tick(object sender, EventArgs e)
        {
            if (UpComingPanel.Left <= 10)
            {
                UpgoingPanel.Dispose();
                UpComingPanel.Dock = DockStyle.Fill;
                SlidingPanel.Stop();
            }
            else
            {
                UpComingPanel.Left -= speed;
                UpgoingPanel.Left -= speed+10;
                speed = UpComingPanel.Left / 15;

                if (speed <= 1)
                {
                    speed = 1;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ProcesareVot();
            RandomMelodie();
            (sender as Button).Enabled = false;


            if (melodii.Count() == 0)
                lbProgessBar.Width = Width;
            else
                lbProgessBar.Width += (int)(Width / 100 * (double.Parse(lbProgessBar.Tag.ToString())));
        }

        private void SondajForm_Resize(object sender, EventArgs e)
        {
            lbProgessBar.Left = 0;
            if (melodii.Count == 0)
            {
                lbProgessBar.Width = Width;
            }
            else
            {
                int IntrebariParcurse = nrMelodiiInitial - melodii.Count();
                lbProgessBar.Width = IntrebariParcurse * (int)(Width / 100 * (double.Parse(lbProgessBar.Tag.ToString())));
            }
            
        }
    }
}
