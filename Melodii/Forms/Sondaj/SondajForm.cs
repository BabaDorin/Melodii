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
        private static List<Vot> voturi = new List<Vot>();
        private static int nrMelodiiInitial = 0;
        private static int CurrentId = 0;
        private static Panel UpGoingPanel;
        private static Panel UpComingPanel;
        private static int speed;
        private static Melodii.Models.Sondaj Sondaj;

        //BEFREE>> ProcesareVot, Inserare vot in BD, construire Sondaj, Inserare sondaj, Calcularea
        //rezultatelor, afisarea rezultatelor.

        public SondajForm(int IdParticipant)
        {
            InitializeComponent();
            UpGoingPanel = null;

            //Pozitionarea label-urilor la mijlocul ferestrei
            label.Left = Width / 2 - label.Width / 2;
            lbMelodiiRamase.Left = Width / 2 - lbMelodiiRamase.Width / 2;
            lbParticipant.Left = Width / 2 - lbParticipant.Width / 2;

            //Viteza initiala pentru UpGoingPanel si UpComingPanel;
            speed = Width / 10;

            //Extragerea melodiilor din baza de date
            DB_Methods.LoadMelodii(ref melodii);

            //Stabilirea pozitiilor in top a melodiilor
            melodii.Sort((x, y) => x.Puncte.CompareTo(y.Puncte));
            for (int i = 0; i < melodii.Count; i++)
            {
                melodii[i].LoculInTop = melodii.Count - i;
            }

            nrMelodiiInitial = melodii.Count();
            lbMelodiiRamase.Text = "Melodii ramase: " + (nrMelodiiInitial-1);
            lbProgessBar.Width = 0;
            lbProgessBar.Tag = (100 / (nrMelodiiInitial-1)).ToString();
            btNext.Enabled = false;

            //Crearea unui obiect Sondaj si inserarea acestuia in BD;
            Sondaj = new Models.Sondaj();
            Sondaj.IdParticipant = IdParticipant;
            Sondaj.Data = DateTime.Now;
            Sondaj.ScorFinal = 0;
            InsertSondaj(Sondaj);
            Sondaj.IdSondaj = LastInsertedID("Sondaje");

            //Extragerea unei melodii aleatoare
            RandomMelodie();
        }

        private void RandomMelodie()
        {

            //-----------------< Extrage o melodie si completeaza un panou cu informatii despre melodia respectiva >-----------------

            if (melodii.Count == 0)
            {
                panelSondaj.BackColor = Color.Red;
                CurrentId = -1;
            }
            else
            {
                //UpgoingPanel este panoul care va iesi din limitele ecranului atunci cand
                //se va trece la urmatoarea melodie
                if (UpGoingPanel == null)
                {
                    Panel empty = new Panel();
                    empty.Width = panelSondaj.Width;
                    panelSondaj.Controls.Add(empty);
                }else
                    UpGoingPanel.Dispose();
                UpGoingPanel = panelSondaj.Controls[0] as Panel;
                UpGoingPanel.Dock = DockStyle.None;

                //Melodiile for fi extrase una cate una, in mod aleator
                Random rnd = new Random();
                int randomIndex = rnd.Next(0, melodii.Count);
                Melodie random = melodii[randomIndex];
                Debug.WriteLine(randomIndex);
                CurrentId = randomIndex;

                //Panoul pentru afisarea informatiilor despre melodie
                Panel info = new Panel();
                info.AutoScroll = true;
                info.Width = panelSondaj.Width;
                info.Height = panelSondaj.Height;

                //Label pentru afisarea Denumirii
                Label Denumire = new Label();
                Denumire.Dock = DockStyle.Top;
                Denumire.Text = random.Denumire;
                Denumire.Font = new Font("Leelawadee", 20);
                Denumire.AutoSize = true;
                Denumire.MaximumSize = new Size(panelSondaj.Width, 0);

                //Label pentru afisarea Interpretului
                Label Interpret = new Label();
                Interpret.Dock = DockStyle.Top;
                Interpret.Text = String.Format("\t" + random.Interpret);
                Interpret.Font = new Font("Leelawadee", 15);
                Interpret.ForeColor = Color.LightGray;
                Interpret.AutoSize = true;
                Interpret.MaximumSize = new Size(panelSondaj.Width, 0);

                //Label care va servi ca o bara de subliniere
                Label bar = new Label();
                bar.Height = 1;
                bar.Dock = DockStyle.Top;
                bar.Width = Denumire.Width;
                bar.BackColor = Color.WhiteSmoke;

                //Label pentru afisarea Genului Muzical
                Label Gen = new Label();
                Gen.Dock = DockStyle.Top;
                Gen.Text = String.Format($"Genul muzical: {random.GenMuzical}");
                Gen.Font = new Font("Leelawadee", 13);
                Gen.ForeColor = Color.LightGray;
                Gen.MaximumSize = new Size(info.Width, 0);
                Gen.Padding = new Padding(20);
                Gen.AutoSize = true;
                Gen.MaximumSize = new Size(panelSondaj.Width, 0);

                //Panoul care va contine 2 elemente, 1: Textul "Pozitia in Top", 2: Un comboBox
                //pentru alegerea pozitiei
                Panel comboPanel = new Panel();
                comboPanel.Dock = DockStyle.Top;
                comboPanel.Padding = new Padding(20);

                //Label pentru afisarea mesajului
                Label Text = new Label();
                Text.Dock = DockStyle.Left;
                Text.Text = "Pozitia in TOP: ";
                Text.Font = new Font("Leelawadee", 15);
                Text.ForeColor = Color.LightGray;
                Text.AutoSize = true;

                //ComboBox-ul pentru selectarea pozitiei
                ComboBox cmbPozitieTop = new ComboBox();
                cmbPozitieTop.Dock = DockStyle.Top;
                cmbPozitieTop.MaximumSize = new Size(50, 50);
                for(int i=1; i<=nrMelodiiInitial; i++)
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

                //Label pentru afisarea informatiilor suplimentare
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

                //Inserarea elementelor mai sus declarate in panoul parinte
                info.Controls.Add(Gen);
                info.Controls.Add(bar);
                info.Controls.Add(Interpret);
                info.Controls.Add(Denumire);
                panelSondaj.Controls.Add(info);
                speed = Width / 15;

                //UpComingPanel va fi panoul ce se va deplasa din dreapta catre mijlocul ecranului.
                UpComingPanel = info;
                UpComingPanel.Left = Width;

                //Declansarea animatiei de schimbare a melodiei afisate
                SlidingPanel.Start();
            }
        }

        private void ProcesareVot(int pozitiaAleasa)
        {
            //-----------------< Proceseaza votul construieste pas cu pas obiectul [Sondaj] >-----------------

            //Voturile vor fi stocate intr-o structura generica si vor fi inserate in baza de date
            //la sfarsitul sondajului.

            Vot vot = new Vot();
            vot.IdParticipant = Sondaj.IdParticipant;
            vot.IdMelodie = melodii[CurrentId].IdMelodie;
            
            //Verificarea raspunsului
            if(pozitiaAleasa == melodii[CurrentId].LoculInTop)
            {
                //A ghicit exact pozitia
                vot.ScorVot = 10;
            }
            else if(Math.Abs(pozitiaAleasa - melodii[CurrentId].LoculInTop) == 1)
            {
                //A gresit pozitia cu o singura unitate
                vot.ScorVot = 5;
            }
            else if(Math.Abs(pozitiaAleasa - melodii[CurrentId].LoculInTop) == 2)
            {
                //A gresit pozitia cu 2 unitati
                vot.ScorVot = 3;
            }
            else
            {
                //A gresit pozitia cu mai mult de 2 unitati
                vot.ScorVot = 0;
            }

            vot.IdSondaj = Sondaj.IdSondaj;
            voturi.Add(vot);

            Sondaj.ScorFinal += vot.ScorVot;

            if (CurrentId != -1)
                melodii.RemoveAt(CurrentId);
            
            if(melodii.Count() == 0)
            {
                lbMelodiiRamase.Text = "";
                SalveazaDate();
            }
            else
                lbMelodiiRamase.Text = "Melodii ramase: " + (melodii.Count()-1);
        }
        
        private void SalveazaDate()
        {
            //Salvarea voturilor in baza de date
            foreach(Vot v in voturi)
            {
                InsertVot(v);
            }

            //Actualizarea sondajului (ScorFinal)
            UpdateScorFinalSondaj(Sondaj);

            Debug.WriteLine("Totul actualizat.");
        }

        private void cmb_ValueChanged(object sender, EventArgs e)
        {
            //Odata ce a fost aleasa pozitia pentru melodia curenta, putem trece la urmatoarea melodie
            btNext.Enabled = true;
            btNext.Tag = (sender as ComboBox).SelectedItem;
        }

        private void SlidingPanel_Tick(object sender, EventArgs e)
        {
            //Deplasarea panourilor
            if (UpComingPanel.Left <= 10)
            {
                UpGoingPanel.Dispose();
                UpComingPanel.Dock = DockStyle.Fill;
                SlidingPanel.Stop();
            }
            else
            {
                UpComingPanel.Left -= speed;
                UpGoingPanel.Left -= speed+10;
                speed = UpComingPanel.Left / 15;

                if (speed <= 1)
                {
                    speed = 1;
                }
            }
        }

        private void btNext_Click(object sender, EventArgs e)
        {
            //Procesarea votului curent si alegerea urmatoarei melodii
            int optiuneAleasa = int.Parse(btNext.Tag.ToString());
            ProcesareVot(optiuneAleasa);
            RandomMelodie();
            (sender as Button).Enabled = false;

            //Incrementarea progressBar-ului
            if (melodii.Count() == 0)
                lbProgessBar.Width = Width;
            else
                lbProgessBar.Width += (int)(Width / 100 * (double.Parse(lbProgessBar.Tag.ToString())));
        }

        private void SondajForm_Resize(object sender, EventArgs e)
        {
            //Ajustarea progressBar-ului atunci cand fereastra este redimensionata.
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
