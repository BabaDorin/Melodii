using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Melodii.Models;
using static Melodii.Reusable;
using static Melodii.DB_Methods;
using System.Diagnostics;

namespace Melodii.Forms.Sondaj
{
    public partial class VeziSondajeForm : Form
    {
        private static List<Models.Sondaj> Sondaje = new List<Models.Sondaj>();
        bool formMinimized = true;

        public VeziSondajeForm()
        {
            InitializeComponent();

            //Pozitionarea elementelor vizuale
            slidingBar.Left = -slidingBar.Width;
            speedSlidingBar = (label1.Left - slidingBar.Left) / 6;
            panelInfo.Left = panelList.Right + 50;
            panelList.Width = Width / 100 * 50;

            //Extragerea datelor din BD
            LoadData();

            timerSlidingBar.Start();
        }

        private void LoadData()
        {
            //Extragerea sondajelor din baza de date.
            try
            {
                LoadSondaje(ref Sondaje);

                // Pentru fiecare sondaj va fi creat un buton care va contine informatii
                // privind Numele participantului, data, scorul final.
                GenerateButtons(Sondaje, panelListButtons);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                lbError.Text = "Ne pare rau, s-a produs o eroare la incarcarea datelor.";
            }
        }

        #region DesignMethods
        private void GenerateButtons(List<Models.Sondaj> sondaje, Panel parentPanel)
        {
            //Va fi creat cate un buton pentru fiecare sondaj.

            parentPanel.Controls.Clear();
            try
            {
                if (sondaje != null && sondaje.Count > 0)
                {
                    parentPanel.Controls.Clear();

                    for (int i = 0; i < sondaje.Count; i++)
                    {
                        //Butonul propriu zis.
                        //Proprietatea Text va contine numele participantului
                        //Proprietatea Tag va contine ID-ul sondajului
                        Button btn = new Button();
                        btn.Dock = DockStyle.Top;
                        btn.Text = sondaje[i].NumeParticipant;
                        btn.Tag = sondaje[i].IdSondaj;
                        btn.FlatStyle = FlatStyle.Flat;
                        btn.FlatAppearance.BorderSize = 0;
                        btn.Height = 60;
                        btn.TextAlign = ContentAlignment.MiddleLeft;
                        btn.Font = new Font("Leelawadee", 13);
                        btn.Click += btInfo_Click;

                        //Label pentru afisarea scorului final al sondajului.
                        System.Windows.Forms.Label lbScor = new System.Windows.Forms.Label();
                        lbScor.Text = sondaje[i].ScorFinal.ToString();
                        lbScor.AutoSize = false;
                        lbScor.Dock = DockStyle.Right;
                        lbScor.BackColor = Color.Transparent;
                        lbScor.Font = new Font("Leelawadee", 10);
                        lbScor.TextAlign = ContentAlignment.MiddleCenter;

                        //Label pentru afisarea datei
                        System.Windows.Forms.Label lbData = new System.Windows.Forms.Label();
                        lbData.Text = sondaje[i].Data.ToString("MMM dd yyyy");
                        lbData.ForeColor = Color.LightGray;
                        lbData.BackColor = Color.Transparent;
                        lbData.Dock = DockStyle.Bottom;
                        lbData.Font = new Font("Leelawadee", 10);

                        btn.Controls.Add(lbData);
                        btn.Controls.Add(lbScor);

                        parentPanel.Controls.Add(btn);
                    }
                }
                else
                {
                    //In cazul in care nu exista sondaje, afisam un mesaj corespunzator.
                    System.Windows.Forms.Label label = new System.Windows.Forms.Label();
                    label.Font = new Font("Leelawadee", 13);
                    label.ForeColor = Color.WhiteSmoke;
                    label.Dock = DockStyle.Fill;
                    label.TextAlign = ContentAlignment.TopCenter;
                    label.Text = "Nu exista sondaje spre afisare.";
                    label.Image = Properties.Resources.shrug;
                    label.ImageAlign = ContentAlignment.MiddleCenter;
                    panelListButtons.Controls.Add(label);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                lbError.Text = "S-a produs o eroare la incarcarea datelor. Incercati din nou.";
            }
        }

        private void VeziSondajeForm_Resize(object sender, EventArgs e)
        {
            // In cazul in care are loc redimensionarea ferestrei:
            //
            // 1) Vom modifica pozitia si dimensiunile celor 2 panele, cel pentru afisarea listei
            // sondajelor, si cel pentru afisarea informatiei despre fiecare sondaj in parte.
            //
            // 2) Vom re-analiza modul in care este afisat numele participantului
            // Daca fereastra a fost marita, atunci denumirea va contine mai multe litere ca urmare
            // a maririi lungimii butoanelor, in caz contrar, denumirea va fi scurtata.

            panelList.Width = Width / 100 * 45;
            panelList.Height = this.Height - panelList.Top - 50;
            panelInfo.Left = panelList.Right + 50;
            panelInfo.Width = this.Right - panelInfo.Left - 20;
            formMinimized = !formMinimized;

            if (Sondaje.Count > 0)
                foreach (Button btn in panelListButtons.Controls)
                {
                    if (formMinimized)
                    {
                        //In cazul in care forma este minimizata, denumirea este scurtata.
                        ScurtareDenumire(btn, panelList.Width);
                    }
                    else
                    {
                        // In cazul in care forma este maximizata, atunci verificam daca 
                        // denumirea care este afisata este scurtata. In caz afirmativ,
                        // marim numarul de caractere ce vor fi afisate.
                        string initialButtonText = Sondaje.First(x => x.IdSondaj == int.Parse(btn.Tag.ToString())).NumeParticipant;
                        if (btn.Text.Length < initialButtonText.Length)
                        {
                            btn.Text = initialButtonText;
                            ScurtareDenumire(btn, panelList.Width);
                        }
                    }
                }
        }
        #endregion

        #region ButtonEvents
        private void btInfo_Click(object sender, EventArgs e)
        {
            // Evenimentul declansat de catre un click pe butonul destinat unui sondaj
            // Acesta va crea un nou panel in care va introduce toate datele disponibile
            // despre sondajul respectiv.

            panelInfo.Controls.Clear();
            Panel panelSondaj = new Panel();
            panelSondaj.Width = panelInfo.Width;
            panelSondaj.Height = panelInfo.Height;

            // Id-ul sondajului se afla in propritatea [Tag] a butonului, drept urmare
            Models.Sondaj sondaj = Sondaje.First(m => m.IdSondaj == int.Parse((sender as Button).Tag.ToString()));

            //Label pentru Numele participantului
            System.Windows.Forms.Label Nume = new System.Windows.Forms.Label();
            Nume.Text = sondaj.NumeParticipant;
            Nume.Font = new Font("Leelawadee", 16);
            Nume.AutoSize = true;
            Nume.Width = panelInfo.Width;
            Nume.Dock = DockStyle.Top;
            Nume.MaximumSize = new Size(Nume.Width, 0);

            //Label pentru Data
            System.Windows.Forms.Label Data = new System.Windows.Forms.Label();
            Data.Text = sondaj.Data.ToString("MMM dd yyyy   HH:mm");
            Data.ForeColor = Color.LightGray;
            Data.Font = new Font("Leelawadee", 12);
            Data.AutoSize = true;
            Data.Width = Nume.Width;
            Data.Dock = DockStyle.Top;
            Data.MaximumSize = new Size(Data.Width, 0);
            Data.Padding = new Padding(5);

            //Butonul de afisare a voturilor.
            Button voturi = new Button();
            voturi.Padding = new Padding(10);
            voturi.Dock = DockStyle.Top;
            voturi.FlatStyle = FlatStyle.Flat;
            voturi.ForeColor = Color.WhiteSmoke;
            voturi.FlatAppearance.BorderSize = 0;
            voturi.Text = "Vezi voturile";
            voturi.AutoSize = true;
            voturi.Click += btVoturi_Click;
            voturi.Tag = sondaj.IdSondaj;
            panelSondaj.Controls.Add(voturi);

            System.Windows.Forms.Label Spatiu = new System.Windows.Forms.Label();
            Spatiu.Height = 50;
            Spatiu.Dock = DockStyle.Top;
            Spatiu.AutoSize = true;
            panelSondaj.Controls.Add(Spatiu);

            //Label pentru afisarea punctelor
            System.Windows.Forms.Label ScorFinal = new System.Windows.Forms.Label();
            ScorFinal.Text = String.Format("Puncte: " + sondaj.ScorFinal.ToString());
            ScorFinal.ForeColor = Color.LightGray;
            ScorFinal.Font = new Font("Leelawadee", 10);
            ScorFinal.AutoSize = true;
            ScorFinal.Width = Nume.Width;
            ScorFinal.Dock = DockStyle.Top;
            ScorFinal.MaximumSize = new Size(Data.Width, 0);
            ScorFinal.Padding = new Padding(5);
            panelSondaj.Controls.Add(ScorFinal);

            panelSondaj.Controls.Add(Data);
            panelSondaj.Controls.Add(Nume);

            //Deplasarea panelului spre stanga si pregatirea terenului pentru slide.
            panelSondaj.Left = -panelSondaj.Width;
            speedMovingPanel = (panelSondaj.Left) / 3;
            panelInfo.Controls.Add(panelSondaj);
            movingPanel = panelSondaj;
            timerSlideInDetails.Start();
        }

        private void btVoturi_Click(object sender, EventArgs e)
        {
            //--------------< Afiseaza toate voturile disponibile din cadrul sondajului ales >----------------------
            try
            {
                //Extragerea voturilor
                List<Vot> voturi = new List<Vot>();
                LoadVoturi(ref voturi, (int)(sender as Button).Tag);

                Panel parent = (sender as Button).Parent as Panel;
                //Eliminam panoul precedent in care au fost afisate voturile (In cazul in care exista).
                if (parent.Controls.Count > 5)
                {
                    parent.Controls[parent.Controls.Count - 1].Dispose();
                }

                //Vom construi un panel asemanator cu cel folosit pentru afisarea sondajelor
                Panel panelVoturi = new Panel();
                panelVoturi.Tag = "PanelVoturi";
                panelVoturi.Width = parent.Width;
                panelVoturi.Height = parent.Height - (sender as Button).Top - 50;
                panelVoturi.Left = 0;
                panelVoturi.Top = (sender as Button).Top + 50;

                //Bara din stanga
                Label lbBarLeft = new Label();
                lbBarLeft.BackColor = Color.WhiteSmoke;
                lbBarLeft.Dock = DockStyle.Left;
                lbBarLeft.Width = 1;

                //Bara de jos
                Label lbBarBottom = new Label();
                lbBarBottom.BackColor = Color.WhiteSmoke;
                lbBarBottom.Dock = DockStyle.Bottom;
                lbBarBottom.Height = 1;

                panelVoturi.Controls.Add(lbBarLeft);
                panelVoturi.Controls.Add(lbBarBottom);

                //Inserarea voturilor
                Panel panelVoturiList = new Panel();
                panelVoturiList.Dock = DockStyle.Fill;
                panelVoturiList.AutoScroll = true;
                if (voturi.Count == 0)
                {
                    Label lbEmpty = new Label();
                    lbEmpty.Font = new Font("Leelawadee", 13);
                    lbEmpty.Text = "  N-au fost gasite voturi spre afisare";
                    lbEmpty.Dock = DockStyle.Top;
                    panelVoturiList.Controls.Add(lbEmpty);
                }
                else
                {
                    for (int i = 0; i < voturi.Count; i++)
                    {
                        Panel vot = new Panel();
                        vot.AutoSize = true;
                        vot.Dock = DockStyle.Top;

                        Label lbDenumire = new Label();
                        lbDenumire.Font = new Font("Leelawadee", 13);
                        lbDenumire.Text = voturi[i].DenumireMelodie;
                        lbDenumire.Dock = DockStyle.Top;
                        lbDenumire.ForeColor = Color.WhiteSmoke;
                        lbDenumire.TextAlign = ContentAlignment.MiddleCenter;

                        Label lbPozitie = new Label();
                        lbPozitie.Font = new Font("Leelawadee", 10);
                        lbPozitie.Text = String.Format($"Pozitia in TOP: {voturi[i].PozitieTop}      Pozitia indicata: {voturi[i].PozitiaIndicata}");
                        lbPozitie.Dock = DockStyle.Top;
                        lbPozitie.ForeColor = Color.LightGray;
                        lbPozitie.TextAlign = ContentAlignment.MiddleCenter;

                        Label lbScor = new Label();
                        lbScor.Font = new Font("Leelawadee", 10);
                        lbScor.Text = String.Format($"Scor vot: {voturi[i].ScorVot}");
                        lbScor.Dock = DockStyle.Top;
                        lbScor.ForeColor = Color.LightGray;
                        lbScor.TextAlign = ContentAlignment.MiddleCenter;

                        Label spatiere = new Label();
                        spatiere.Height = 30;
                        spatiere.Dock = DockStyle.Top;

                        vot.Controls.Add(lbScor);
                        vot.Controls.Add(lbPozitie);
                        vot.Controls.Add(lbDenumire);
                        vot.Controls.Add(spatiere);
                        panelVoturiList.Controls.Add(vot);
                    }
                }

                //Label pentru nota informativa
                Label lbNota = new Label();
                lbNota.Font = new Font("Leelawadee", 10);
                lbNota.ForeColor = Color.Gray;
                lbNota.Text = "*Nota: Voturile pentru melodiile eliminate din baza de date au fost la fel eliminate.";
                lbNota.MaximumSize = new Size(panelInfo.Width, 100);
                lbNota.AutoSize = true;
                lbNota.Padding = new Padding(10);
                lbNota.Dock = DockStyle.Bottom;

                panelVoturi.Controls.Add(panelVoturiList);
                panelVoturi.Controls.Add(lbNota);
                parent.Controls.Add(panelVoturi);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Eroare btVoturi: " + ex.Message);
                lbError.Text = "S-a produs o eroare la incarcarea voturilor";
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
