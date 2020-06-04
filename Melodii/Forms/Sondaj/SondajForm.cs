using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Melodii.Models;
using System.Diagnostics;
using static Melodii.DB_Methods;
using static Melodii.Reusable;

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
        private static RezultateSondaj rezultateSondaj;

        public SondajForm(int IdParticipant, bool top3)
        {
            InitializeComponent();
            UpGoingPanel = null;
            string NumeParticipant = ParticipantNumeByID(IdParticipant, true);

            //Pozitionarea label-urilor
            label.Left = 0;
            label.ForeColor = Color.FromArgb(255, 190, 0);
            lbMelodiiRamase.Left = 0;
            lbParticipant.Left = 0;

            //Viteza initiala pentru UpGoingPanel si UpComingPanel;
            speed = Width / 6;

            //Extragerea melodiilor din baza de date
            LoadMelodii(ref melodii, top3);

            //Stabilirea pozitiilor in top a melodiilor
            melodii.Sort((x, y) => x.Puncte.CompareTo(y.Puncte));
            for (int i = 0; i < melodii.Count; i++)
            {
                melodii[i].LoculInTop = melodii.Count - i;
            }

            nrMelodiiInitial = melodii.Count();
            lbMelodiiRamase.Text = "Melodii ramase: " + (nrMelodiiInitial-1);
            lbParticipant.Text = "Participant: " + NumeParticipant;
            lbProgessBar.Width = 0;
            lbProgessBar.Tag = ((double)( 100 / nrMelodiiInitial)).ToString();
            btNext.Enabled = false;

            //Crearea unui obiect Sondaj si inserarea acestuia in BD;
            //Sondajul va fi inregistrat in baza de date, initial avand 0 puncte.
            //La sfarsitul sondajului, scorul va fi actualizat in dependenta de punctele acumulate.
            Sondaj = new Models.Sondaj();
            Sondaj.IdParticipant = IdParticipant;
            Sondaj.Data = DateTime.Now;
            Sondaj.ScorFinal = 0;
            InsertSondaj(Sondaj);
            Sondaj.IdSondaj = LastInsertedID("Sondaje");

            rezultateSondaj = new RezultateSondaj();
            rezultateSondaj.Participant = NumeParticipant;

            //Extragerea unei melodii aleatoare
            RandomMelodie();
        }

        private void RandomMelodie()
        {

            //-----------------< Extrage o melodie si completeaza un panou cu informatii despre melodia respectiva >-----------------

            if (melodii.Count == 0)
            {
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

                //Label care va servi drept bara de subliniere
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
            //-----------------< Proceseaza votul, construieste pas cu pas obiectul Sondaj >-----------------
            try
            {
                //Voturile vor fi stocate intr-o structura generica si vor fi inserate in baza de date
                //la sfarsitul sondajului.
                Vot vot = new Vot();
                vot.IdParticipant = Sondaj.IdParticipant;
                vot.IdMelodie = melodii[CurrentId].IdMelodie;
                vot.PozitieTop = melodii[CurrentId].LoculInTop;
                vot.PozitiaIndicata = pozitiaAleasa;

                //Instantierea unui obiect de tip Rezultat care va contine informatii despre
                //votul curent
                Rezultat rezultat = new Rezultat();
                rezultat.Melodie = melodii[CurrentId].Denumire;
                rezultat.PozitieInTop = melodii[CurrentId].LoculInTop;
                rezultat.Interpret = melodii[CurrentId].Interpret;
                rezultat.PozitiaIndicata = pozitiaAleasa;

                //Verificarea raspunsului
                if (pozitiaAleasa == melodii[CurrentId].LoculInTop)
                {
                    //A ghicit exact pozitia
                    vot.ScorVot = 10;
                    rezultat.PuncteAcumulate = 10;
                }
                else if (Math.Abs(pozitiaAleasa - melodii[CurrentId].LoculInTop) == 1)
                {
                    //A gresit pozitia cu o singura unitate
                    vot.ScorVot = 5;
                    rezultat.PuncteAcumulate = 5;
                }
                else if (Math.Abs(pozitiaAleasa - melodii[CurrentId].LoculInTop) == 2)
                {
                    //A gresit pozitia cu 2 unitati
                    vot.ScorVot = 3;
                    rezultat.PuncteAcumulate = 3;
                }
                else
                {
                    //A gresit pozitia cu mai mult de 2 unitati
                    vot.ScorVot = 0;
                    rezultat.PuncteAcumulate = 0;
                }

                vot.IdSondaj = Sondaj.IdSondaj;
                voturi.Add(vot);
                rezultateSondaj.Rezultate.Add(rezultat);
                Sondaj.ScorFinal += vot.ScorVot;
                rezultateSondaj.ScorFinal += vot.ScorVot;

                if (CurrentId != -1)
                    melodii.RemoveAt(CurrentId);

                if (melodii.Count() == 0)
                {
                    //Am ajuns la finalul sondajului.
                    //Datele sunt salvate si este afisat un rezumat al sondajului.
                    SalveazaDate();
                    AfiseazaRezultate();
                }
                else
                    lbMelodiiRamase.Text = "Melodii ramase: " + (melodii.Count() - 1);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Eroare procesare vot: " + ex.Message);
                System.Windows.Forms.MessageBox.Show("S-a produs o eroare la procesarea votului.");
            }
        }
        
        private void SalveazaDate()
        {
            try
            {
                //Salvarea voturilor in baza de date
                foreach (Vot v in voturi)
                {
                    InsertVot(v);
                }

                //Actualizarea sondajului (ScorFinal)
                UpdateScorFinalSondaj(Sondaj);

                //Actualizarea numarului de puncte a participantului
                if (Sondaj.ScorFinal > 0)
                    UpdateParticipantScor(Sondaj.IdParticipant, Sondaj.ScorFinal);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Eroare Salvare date: " + ex.Message);
                System.Windows.Forms.MessageBox.Show("S-a produs o eroare la salvarea datelor.");
            }
            
        }

        private void AfiseazaRezultate()
        {

            //--------------------< Afiseaza rezumatul sondajului >------------------------

            //Panoul ce va contine informatiile despre sondaj
            Panel panelRezultate = new Panel();
            panelRezultate.AutoScroll = true;
            panelRezultate.Dock = DockStyle.Fill;

            Label lbText = new Label();
            lbText.Dock = DockStyle.Top;
            lbText.Font = new Font("Leelawadee", 15);
            lbText.ForeColor = Color.WhiteSmoke;
            lbText.TextAlign = ContentAlignment.MiddleCenter;
            lbText.Text = "Rezultatele sondajului:";

            Label lbPuncteAcumulate = new Label();
            lbPuncteAcumulate.Dock = DockStyle.Top;
            lbPuncteAcumulate.Font = new Font("Leelawadee", 13);
            lbPuncteAcumulate.ForeColor = Color.WhiteSmoke;
            lbPuncteAcumulate.TextAlign = ContentAlignment.MiddleCenter;
            lbPuncteAcumulate.Text = "Puncte acumulate in total: " + rezultateSondaj.ScorFinal;

            //Pentru fiecare raspuns dat in cadrul sondajului, se va crea un nou panel in care
            //vor fi include urmatoarele:
            //  Numele Melodiei
            //  Interpretul
            //  Pozitia in TOP
            //  Pozitia indicata (pozitia pe care a ales-o participantul)
            //  Punctele acumulate pentru acest raspuns (0, 3, 5, 10).
            for (int i= rezultateSondaj.Rezultate.Count-1; i>=0; i--)
            {
                Panel element = new Panel();
                element.Dock = DockStyle.Top;
                element.AutoSize = true;

                Label lbMelodie = new Label();
                lbMelodie.Font = new Font("Leelawadee", 15);
                lbMelodie.ForeColor = Color.WhiteSmoke;
                lbMelodie.TextAlign = ContentAlignment.MiddleCenter;
                lbMelodie.Text = rezultateSondaj.Rezultate[i].Melodie;
                lbMelodie.Dock = DockStyle.Top;

                Label lbInterpret = new Label();
                lbInterpret.Font = new Font("Leelawadee", 10);
                lbInterpret.ForeColor = Color.LightGray;
                lbInterpret.TextAlign = ContentAlignment.MiddleCenter;
                lbInterpret.Text = rezultateSondaj.Rezultate[i].Interpret;
                lbInterpret.Dock = DockStyle.Top;

                Label lbPozitieTop = new Label();
                lbPozitieTop.Font = new Font("Leelawadee", 13);
                lbPozitieTop.ForeColor = Color.LightGray;
                lbPozitieTop.TextAlign = ContentAlignment.MiddleCenter;
                lbPozitieTop.Text = "Pozitie in TOP: " + rezultateSondaj.Rezultate[i].PozitieInTop;
                lbPozitieTop.Dock = DockStyle.Top;

                Label lbPozitieIndicata = new Label();
                lbPozitieIndicata.Font = new Font("Leelawadee", 13);
                lbPozitieIndicata.ForeColor = Color.LightGray;
                lbPozitieIndicata.TextAlign = ContentAlignment.MiddleCenter;
                lbPozitieIndicata.Text = "Pozitia indicata: " + rezultateSondaj.Rezultate[i].PozitiaIndicata;
                lbPozitieIndicata.Dock = DockStyle.Top;

                Label lbPuncte = new Label();
                lbPuncte.Font = new Font("Leelawadee", 13);
                lbPuncte.ForeColor = Color.LightGray;
                lbPuncte.TextAlign = ContentAlignment.MiddleCenter;
                lbPuncte.Text = "Puncte acumulate: " + rezultateSondaj.Rezultate[i].PuncteAcumulate;
                lbPuncte.Dock = DockStyle.Top;

                Label spatiu = new Label();
                spatiu.Height = 30;
                spatiu.Dock = DockStyle.Top;

                element.Controls.Add(lbPuncte);
                element.Controls.Add(lbPozitieIndicata);
                element.Controls.Add(lbPozitieTop);
                element.Controls.Add(lbInterpret);
                element.Controls.Add(lbMelodie);
                element.Controls.Add(spatiu);

                panelRezultate.Controls.Add(element);
            }

            //Panoul panelTop este eliminat pentru a avea mai mult spatiu de afisare si
            //afisam panoul ce contine rezultatele sondajului.
            panelTop.Dispose();
            panelSondaj.Padding = new Padding(0);
            btNext.Text = "OK";
            btNext.Enabled = true;
            panelSondaj.Controls.Clear();
            panelRezultate.Controls.Add(lbPuncteAcumulate);
            panelSondaj.Controls.Add(panelRezultate);
            panelRezultate.Controls.Add(lbText);

            Label PaddingTop = new Label();
            PaddingTop.Height = 50;
            PaddingTop.Dock = DockStyle.Top;

            panelRezultate.Controls.Add(PaddingTop);
        }

        private void cmb_ValueChanged(object sender, EventArgs e)
        {
            //Odata ce a fost aleasa pozitia pentru melodia curenta, putem trece la urmatoarea melodie,
            //Adica butonul btNext va fi activat
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
                speed = UpComingPanel.Left / 6;

                if (speed <= 1)
                {
                    speed = 1;
                }
            }
        }

        private void btNext_Click(object sender, EventArgs e)
        {
            if (melodii.Count() == 0)
            {
                //Sondajul s-a terminat, se revine la fereastra 'Acasa'
                //Eliberare resurse
                melodii.Clear();
                voturi.Clear();
                UpComingPanel = UpComingPanel = null;
                Sondaj = null;
                rezultateSondaj.Rezultate.Clear();
                rezultateSondaj = null;

                Panel parent = this.Parent as Panel;
                openChildForm(new HomeForm(), parent);
            }
            else
            {
                //Procesarea votului curent si alegerea urmatoarei melodii
                int optiuneAleasa = int.Parse(btNext.Tag.ToString());
                ProcesareVot(optiuneAleasa);
                RandomMelodie();

                if (melodii.Count >= 1)
                    (sender as Button).Enabled = false;
                else
                    (sender as Button).FlatAppearance.BorderSize = 1;

                //Incrementarea progressBar-ului
                if (melodii.Count() == 0)
                    lbProgessBar.Width = Width;
                else
                    lbProgessBar.Width += (int)((Width / 100) * (double.Parse(lbProgessBar.Tag.ToString())));
            }
            
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
