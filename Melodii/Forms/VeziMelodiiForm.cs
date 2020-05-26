using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Melodii.Models;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Data.SqlClient;
using System.IO;

namespace Melodii.Forms
{
    public partial class VeziMelodiiForm : Form
    {
        private static List<Melodie> melodii = new List<Melodie>();
        bool formMinimized = false;

        public VeziMelodiiForm()
        {
            InitializeComponent();
            slidingBar.Left = -slidingBar.Width;
            speedSlidingBar = (label1.Left - slidingBar.Left) / 6;
            panelInfo.Left = panelMelodii.Right + 50;
            panelMelodii.Width = Width / 100 * 50;

            //Extragerea datelor din BD
            LoadData();

            // Pentru fiecare melodie va fi creat un buton care va contine informatii
            // privind Denumirea, Interpretul si numarul de puncte ale acesteia.
            GenerateButtons(melodii, panel1);
            timerSlidingBar.Start();
        }

        private  void GenerateButtons(List<Melodie> melodii, Panel parentPanel)
        {
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

            int lastMelodiiWidth = panelMelodii.Width;
            panelMelodii.Width = Width / 100 * 45;
            panelInfo.Left = panelMelodii.Right + 50;
            panelInfo.Width = this.Right - panelInfo.Left - 20;

            if (lastMelodiiWidth > panelMelodii.Width)
                formMinimized = true;
            else
                formMinimized = false;

            if(melodii.Count>0)
                foreach(Button btn in panel1.Controls)
                {
                    if (formMinimized)
                    {
                        //In cazul in care forma este minimizata, denumirea este scurtata.
                        ScurtareDenumire(btn, panelMelodii.Width);
                    }
                    else
                    {
                        // In cazul in care forma este maximizata, atunci verificam daca 
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

        private void ScurtareDenumire(Button btn, int maxWidth)
        {
            //In cazul in care lungimea numelui melodiei este mai mare decat
            //lungimea butonului, atunci vom afisa literele care incap, urmate de 
            //3 puncte de suspensie [...].
            //Exemplu, [Bine-i sade mesei mele imprejur cu nemurele] => [Bine-i sade mese mele...]
            Size size = TextRenderer.MeasureText(btn.Text, btn.Font);
            if (size.Width > maxWidth - maxWidth * 0.3)
            {
                while (size.Width > maxWidth - maxWidth * 0.3)
                {
                    btn.Text = btn.Text.Substring(0, btn.Text.Length - 1);
                    size = TextRenderer.MeasureText(btn.Text, btn.Font);
                }
                btn.Text += "...";
            }
        }

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
            exclude.Tag = String.Format("Sunteti sigur ca doriti sa excludeti melodia {0}?", Denumire.Text);
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

            if (melodie.Informatii != null)
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
            //In cazul in care raspunstul este OK, atunci se va purcede la eliminarea melodiei din baza de date.

            Form Messagebox = new MessageBox();
            Messagebox.Tag = (sender as Button).Tag;
            Messagebox.ShowDialog();
            if (Messagebox.DialogResult == DialogResult.OK)
            {
                //Exclude melodia
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

        private void LoadData()
        {
            //----------------------------< Extragerea datelor din BD >-------------------------
            
            //Stabilirea conexiunii
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + Directory.GetCurrentDirectory() + @"\Database.mdf;Integrated Security=True";
            SqlConnection Connection = new SqlConnection(connectionString);
            Connection.Open();

            //Crerea unui obiect de tip DataAdapter pentru conectarea DataSet-ului
            //cu baza de date.
            SqlDataAdapter daMelodii = new SqlDataAdapter("SELECT * FROM MELODII", Connection);
            DataSet dsMelodii = new DataSet("Melodii");
            daMelodii.Fill(dsMelodii, "Melodii");
            DataTable tblMelodii = dsMelodii.Tables["Melodii"];

            //Acum avem datele din tabela Melodii din baza de date in obiectul tblMelodii.
            //Trecem la popularea listei.
            melodii.Clear();

            foreach(DataRow drMelodie in tblMelodii.Rows)
            {
                melodii.Add(new Melodie
                {
                    IdMelodie = int.Parse(drMelodie["IdMelodie"].ToString()),
                    Denumire = drMelodie["Denumire"].ToString(),
                    Interpret = drMelodie["Interpret"].ToString(),
                    Puncte = int.Parse(drMelodie["Puncte"].ToString()),
                    Informatii = drMelodie["Informatii"].ToString()
                });
            }

            Connection.Close();

        }
    }
}
