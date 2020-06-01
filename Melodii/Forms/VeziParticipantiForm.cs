using Melodii.Forms.Sondaj;
using Melodii.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using static Melodii.DesignFunctionalities;
using static Melodii.DB_Methods;

namespace Melodii.Forms
{
    public partial class VeziParticipantiForm : Form
    {
        private static List<Participant> participanti = new List<Participant>();
        bool formMinimized = false;

        public VeziParticipantiForm()
        {
            InitializeComponent();

            //Pozitionarea elementelor vizuale
            slidingBar.Left = -slidingBar.Width;
            speedSlidingBar = (label1.Left - slidingBar.Left) / 6;
            panelInfo.Left = panelParticipanti.Right + 50;
            panelParticipanti.Width = Width / 100 * 50;

            //Extragerea datelor din BD
            LoadData();
            timerSlidingBar.Start();
        }

        private void LoadData()
        {
            //Extragerea participantilor din baza de date. Sortarea dupa puncte.
            try
            {
                LoadParticipanti(ref participanti);

                //Sortarea listei participantilor
                participanti.Sort((x, y) => x.Scor.CompareTo(y.Scor));

                // Pentru fiecare participant va fi creat cate un buton
                GenerateButtons(participanti, panelParticipantiButtons);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                lbError.Text = "Ne pare rau, s-a produs o eroare la incarcarea datelor.";
            }
        }

        #region DesignMethods
        private void GenerateButtons(List<Participant> participanti, Panel parentPanel)
        {
            //Va fi creat cate un buton pentru fiecare participant.

            panelParticipantiButtons.Controls.Clear();
            try
            {
                if (participanti != null && participanti.Count > 0)
                {
                    parentPanel.Controls.Clear();

                    for (int i = 0; i < participanti.Count; i++)
                    {
                        //Butonul propriu zis.
                        //Proprietatea Text va contine numele participantului
                        //Proprietatea Tag va contine ID-ul participantului.
                        Button btn = new Button();
                        btn.Dock = DockStyle.Top;
                        btn.Text = participanti[i].Nume;
                        btn.Tag = participanti[i].IdParticipant;
                        btn.FlatStyle = FlatStyle.Flat;
                        btn.FlatAppearance.BorderSize = 0;
                        btn.Height = 60;
                        btn.TextAlign = ContentAlignment.MiddleLeft;
                        btn.Font = new Font("Leelawadee", 13);
                        btn.Click += new EventHandler(btInfo_Click);

                        //Label pentru afisarea scorului fiecarul participant.
                        System.Windows.Forms.Label lbScor = new System.Windows.Forms.Label();
                        lbScor.Text = participanti[i].Scor.ToString();
                        lbScor.AutoSize = false;
                        lbScor.Dock = DockStyle.Right;
                        lbScor.BackColor = Color.Transparent;
                        lbScor.Font = new Font("Leelawadee", 10);
                        lbScor.TextAlign = ContentAlignment.MiddleCenter;
                        
                        btn.Controls.Add(lbScor);

                        parentPanel.Controls.Add(btn);
                    }
                }
                else
                {
                    //Nu exista participanti inregistrati in baza de date. Afisam un mesaj corespunzator.
                    System.Windows.Forms.Label label = new System.Windows.Forms.Label();
                    label.Font = new Font("Leelawadee", 13);
                    label.ForeColor = Color.WhiteSmoke;
                    label.Dock = DockStyle.Fill;
                    label.TextAlign = ContentAlignment.TopCenter;
                    label.Text = "Nu exista participanti spre afisare.";
                    label.Image = Properties.Resources.shrug;
                    label.ImageAlign = ContentAlignment.MiddleCenter;
                    panelParticipantiButtons.Controls.Add(label);
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
            // participantilor, si cel pentru afisarea informatiei despre fiecare participant in parte.
            //
            // 2) Vom re-analiza modul in care este afisat numele participantului
            // Daca fereastra a fost marita, atunci denumirea va contine mai multe litere ca urmare
            // a maririi lungimii butoanelor, in caz contrar, denumirea va fi scurtata.

            int lastParticipantWidth = panelParticipanti.Width;
            panelParticipanti.Width = Width / 100 * 45;
            panelInfo.Left = panelParticipanti.Right + 50;
            panelInfo.Width = this.Right - panelInfo.Left - 20;
            btVarsta18.Left = panelParticipanti.Right - btVarsta18.Width;
            btnTop5.Left = btVarsta18.Left - btnTop5.Width;

            if (lastParticipantWidth > panelParticipanti.Width)
                formMinimized = true;
            else
                formMinimized = false;

            if (participanti.Count > 0)
                foreach (Button btn in panelParticipantiButtons.Controls)
                {
                    if (formMinimized)
                    {
                        //In cazul in care forma este minimizata, denumirea este scurtata.
                        ScurtareDenumire(btn, panelParticipanti.Width);
                    }
                    else
                    {
                        // In cazul in care forma este maximizata, atunci verificam daca 
                        // denumirea care este afisata este scurtata. In caz afirmativ,
                        // marim numarul de caractere ce vor fi afisate.
                        string initialButtonText = participanti.First(x => x.IdParticipant == int.Parse(btn.Tag.ToString())).Nume;
                        if (btn.Text.Length < initialButtonText.Length)
                        {
                            btn.Text = initialButtonText;
                            ScurtareDenumire(btn, panelParticipanti.Width);
                        }
                    }
                }
        }
        #endregion

        #region ButtonEvents
        private void btInfo_Click(object sender, EventArgs e)
        {
            try
            {
                // Evenimentul declansat de catre un click pe butonul destinat unui participant.
                // Acesta va crea un nou panel in care va introduce toate datele disponibile
                // despre participantul selectat.

                panelInfo.Controls.Clear();
                Panel panelParticipant = new Panel();
                panelParticipant.Width = panelInfo.Width;
                panelParticipant.Height = panelInfo.Height;

                // Id-ul persoanei se afla in propritatea [Tag] a butonului, drept urmare
                Participant participant = participanti.First(m => m.IdParticipant == int.Parse((sender as Button).Tag.ToString()));

                //Label pentru Nume
                System.Windows.Forms.Label Nume = new System.Windows.Forms.Label();
                Nume.Text = participant.Nume;
                Nume.Font = new Font("Leelawadee", 16);
                Nume.AutoSize = true;
                Nume.Width = panelInfo.Width;
                Nume.Dock = DockStyle.Top;
                Nume.MaximumSize = new Size(Nume.Width, 0);

                //butonul de excludere a persoanei
                Button exclude = new Button();
                exclude.Padding = new Padding(10);
                exclude.Dock = DockStyle.Top;
                exclude.FlatStyle = FlatStyle.Flat;
                exclude.ForeColor = Color.WhiteSmoke;
                exclude.FlatAppearance.BorderSize = 0;
                exclude.Text = "Exclude participantul";
                exclude.AutoSize = true;
                exclude.Click += btExclude_Click;
                exclude.Tag = participant.IdParticipant;
                panelParticipant.Controls.Add(exclude);

                //butonul de creare a unui sondaj
                Button sondaj = new Button();
                sondaj.Padding = new Padding(10);
                sondaj.Dock = DockStyle.Top;
                sondaj.FlatStyle = FlatStyle.Flat;
                sondaj.ForeColor = Color.WhiteSmoke;
                sondaj.FlatAppearance.BorderSize = 0;
                sondaj.Text = "Creaza un sondaj";
                sondaj.AutoSize = true;
                sondaj.Click += btSondaj_Click;
                sondaj.Tag = participant.IdParticipant;
                panelParticipant.Controls.Add(sondaj);

                System.Windows.Forms.Label Spatiu = new System.Windows.Forms.Label();
                Spatiu.Height = 50;
                Spatiu.Dock = DockStyle.Top;
                Spatiu.AutoSize = true;
                panelParticipant.Controls.Add(Spatiu);

                //Label pentru afisarea scorului
                System.Windows.Forms.Label Scor = new System.Windows.Forms.Label();
                Scor.Text = String.Format("Puncte: " + participant.Scor.ToString());
                Scor.ForeColor = Color.LightGray;
                Scor.Font = new Font("Leelawadee", 10);
                Scor.AutoSize = true;
                Scor.Width = Nume.Width;
                Scor.Dock = DockStyle.Top;
                Scor.MaximumSize = new Size(Nume.Width, 0);
                Scor.Padding = new Padding(5);
                panelParticipant.Controls.Add(Scor);

                if (participant.Informatii != "")
                {
                    //Label pentru afisarea informatiilor aditionale, in cazul in care acestea exista.
                    System.Windows.Forms.Label Informatii = new System.Windows.Forms.Label();
                    Informatii.Text = String.Format($"Informatii: {participant.Informatii}");
                    Informatii.ForeColor = Color.LightGray;
                    Informatii.Font = new Font("Leelawadee", 10);
                    Informatii.AutoSize = true;
                    Informatii.Width = Nume.Width;
                    Informatii.Dock = DockStyle.Top;
                    Informatii.MaximumSize = new Size(panelInfo.Width, 0);
                    Informatii.Padding = new Padding(5);
                    panelParticipant.Controls.Add(Informatii);
                }

                //Label pentru afisarea varstei
                System.Windows.Forms.Label Varsta = new System.Windows.Forms.Label();
                Varsta.Text = String.Format($"Varsta: {participant.Varsta}");
                Varsta.ForeColor = Color.LightGray;
                Varsta.Font = new Font("Leelawadee", 10);
                Varsta.AutoSize = true;
                Varsta.Width = Nume.Width;
                Varsta.Dock = DockStyle.Top;
                Varsta.MaximumSize = new Size(panelInfo.Width, 0);
                Varsta.Padding = new Padding(5);
                panelParticipant.Controls.Add(Varsta);

                panelParticipant.Controls.Add(Nume);

                //Deplasarea panelului spre stanga si pregatirea terenului pentru slide.
                panelParticipant.Left = -panelParticipant.Width;
                speedMovingPanel = (panelParticipant.Left) / 3;
                panelInfo.Controls.Add(panelParticipant);
                movingPanel = panelParticipant;
                timerSlideInDetails.Start();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Eroare btInfo: " + ex.Message);
                lbError.Text = "S-a produs o eroare la accesarea datelor despre participantul ales.";
            }
        }

        private void btExclude_Click(object sender, EventArgs e)
        {
            //In urma apasarii butonului [Exclude], va aparea un messagebox pentru confirmare.
            //In cazul in care raspunstul este OK, atunci se va purcede la eliminarea participantului din baza de date.
            Form Messagebox = new MessageBox();
            int idParticipant = int.Parse((sender as Button).Tag.ToString());
            string Denumire = participanti.First(m => m.IdParticipant == idParticipant).Nume;
            Messagebox.Tag = String.Format($"Sunteti sigur ca doriti sa excludeti participantul {Denumire}?");
            Messagebox.ShowDialog();

            if (Messagebox.DialogResult == DialogResult.OK)
            {
                //Eliminarea participantului din baza de date
                try
                {
                    RemoveParticipant(idParticipant);
                    LoadData();
                    panelInfo.Controls.Clear();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    lbError.Text = "Ne pare rau, s-a produs o eroare, participantul nu a fost exclus.";
                }
            }
        }

        private void btSondaj_Click(object sender, EventArgs e)
        {
            //Acest event va declansat atunci cand utilizatorul va alege sa inceapa un sondaj
            //pe baza participantului ales.
            //Pentru inceput se verifca daca exists melodii in baza de date, dupa care se trece
            //nemijlocit la initializarea si ulterior desfasurarea sondajului.
            try
            {
                int nrMelodii = NrMelodii();
                if (nrMelodii == 0)
                {
                    lbError.Text = "Ne pare rau, nu exista melodii in baza de date pentru a incepe sondajul.";
                }
                else
                {
                    //Incepe sondajul
                    Panel parent = this.Parent as Panel;
                    parent.Tag = (sender as Button).Tag;
                    string Nume = participanti.First(p => p.IdParticipant == int.Parse(parent.Tag.ToString())).Nume;
                    SondajStartForm sondajStart = new SondajStartForm(Nume, int.Parse(parent.Tag.ToString()));
                    this.Close();

                    openChildForm(sondajStart, parent);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                lbError.Text = "Ne pare rau, s-a produs o eroare.";
            }
        }

        private void btVarsta18_Click(object sender, EventArgs e)
        {
            //Afiseaza doar participantii cu varsta sub 18 ani
            for (int i = 0; i < participanti.Count; i++)
            {
                if (participanti[i].Varsta > 18)
                {
                    participanti.RemoveAt(i);
                }
            }

            GenerateButtons(participanti, panelParticipantiButtons);
        }

        private void btnTop5_Click(object sender, EventArgs e)
        {
            //Afiseaza top 5 participanti, dupa punctele acumulate.
            //Lista participantilor deja este sortata dupa scor in ordine crescatoare. Pentru a 
            //ramane doar cu top 5 participanti, in lista trebuie sa ramana doar ultimii 5 participanti.

            if (participanti.Count > 5)
            {
                participanti.RemoveRange(0, participanti.Count - 5);
                GenerateButtons(participanti, panelParticipantiButtons);
            }
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
