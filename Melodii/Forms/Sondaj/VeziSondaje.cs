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
using static Melodii.DesignFunctionalities;
using static Melodii.DB_Methods;
using System.Diagnostics;

namespace Melodii.Forms.Sondaj
{
    public partial class VeziSondaje : Form
    {
        private static List<Models.Sondaj> Sondaje = new List<Models.Sondaj>();
        bool formMinimized = true;

        public VeziSondaje()
        {
            InitializeComponent();

            //Pozitionarea elementelor vizuale
            slidingBar.Left = -slidingBar.Width;
            speedSlidingBar = (label1.Left - slidingBar.Left) / 6;

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
                GenerateButtons(Sondaje, panelSondajeButtons);
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
            //Va fi creat cate un buton pentru fiecare participant.

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
                    System.Windows.Forms.Label label = new System.Windows.Forms.Label();
                    label.Font = new Font("Leelawadee", 13);
                    label.ForeColor = Color.WhiteSmoke;
                    label.Dock = DockStyle.Fill;
                    label.TextAlign = ContentAlignment.TopCenter;
                    label.Text = "Nu exista sondaje spre afisare.";
                    label.Image = Properties.Resources.shrug;
                    label.ImageAlign = ContentAlignment.MiddleCenter;
                    panelSondajeButtons.Controls.Add(label);
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

            formMinimized = !formMinimized;

            if (Sondaje.Count > 0)
                foreach (Button btn in panelSondajeButtons.Controls)
                {
                    if (formMinimized)
                    {
                        //In cazul in care forma este minimizata, denumirea este scurtata.
                        ScurtareDenumire(btn, panelSondaje.Width);
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
                            ScurtareDenumire(btn, panelSondaje.Width);
                        }
                    }
                }
        }

        private void ScurtareDenumire(Button btn, int maxWidth)
        {
            //In cazul in care lungimea numelui este mai mare decat
            //lungimea butonului, atunci vom afisa literele care incap, urmate de 
            //3 puncte de suspensie [...].
            Size size = TextRenderer.MeasureText(btn.Text, btn.Font);
            if (size.Width > maxWidth - maxWidth * 0.35)
            {
                while (size.Width > maxWidth - maxWidth * 0.35)
                {
                    btn.Text = btn.Text.Substring(0, btn.Text.Length - 1);
                    size = TextRenderer.MeasureText(btn.Text, btn.Font);
                }
                btn.Text += "...";
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
