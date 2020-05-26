using Melodii.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Melodii.Forms
{
    public partial class VeziParticipantiForm : Form
    {
        private static List<Participant> participanti = new List<Participant>();
        bool formMinimized = false;
        public VeziParticipantiForm()
        {
            InitializeComponent();
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
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + Directory.GetCurrentDirectory() + @"\Database.mdf;Integrated Security=True";
            SqlConnection Connection = new SqlConnection(connectionString);

            try
            {
                //----------------------------< Extragerea datelor din BD >-------------------------

                //Stabilirea conexiunii
                Connection.Open();

                //Crerea unui obiect de tip DataAdapter pentru conectarea DataSet-ului
                //cu baza de date.
                SqlDataAdapter daParticipanti = new SqlDataAdapter("SELECT * FROM PARTICIPANTI", Connection);
                DataSet dsParticipanti = new DataSet("Participanti");
                daParticipanti.Fill(dsParticipanti, "Participanti");
                DataTable tblParticipanti = dsParticipanti.Tables["Participanti"];

                //Acum avem datele din tabela Melodii din baza de date in obiectul tblMelodii.
                //Trecem la popularea listei.

                participanti.Clear();
                foreach (DataRow drParticipant in tblParticipanti.Rows)
                {
                    participanti.Add(new Participant
                    {
                        IdParticipant = int.Parse(drParticipant["IdParticipant"].ToString()),
                        Nume = drParticipant["Nume"].ToString(),
                        Scor = int.Parse(drParticipant["Scor"].ToString()),
                        Informatii = drParticipant["Informatii"].ToString()
                    });
                }

                //Sortarea listei participantilor
                participanti.Sort((x, y) => x.Scor.CompareTo(y.Scor));

                // Pentru fiecare melodie va fi creat un buton care va contine informatii
                // privind Denumirea, Interpretul si numarul de puncte ale acesteia.
                GenerateButtons(participanti, panelParticipantiButtons);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                lbError.Text = "Ne pare rau, s-a produs o eroare la incarcarea datelor.";
            }
            finally
            {
                if (Connection.State == ConnectionState.Open)
                    Connection.Close();
            }

        }

        #region DesignMethods
        private void GenerateButtons(List<Participant> participanti, Panel parentPanel)
        {
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
            // melodiilor, si cel pentru afisarea informatiei despre fiecare melodie in parte.
            //
            // 2) Vom re-analiza modul in care este afisat numele melodiei
            // Daca fereastra a fost marita, atunci denumirea va contine mai multe litere ca urmare
            // a maririi lungimii butoanelor, in caz contrar, denumirea va fi scurtata.

            int lastMelodiiWidth = panelParticipanti.Width;
            panelParticipanti.Width = Width / 100 * 45;
            panelInfo.Left = panelParticipanti.Right + 50;
            panelInfo.Width = this.Right - panelInfo.Left - 20;

            if (lastMelodiiWidth > panelParticipanti.Width)
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
        #endregion

        #region ButtonEvents
        private void btInfo_Click(object sender, EventArgs e)
        {
            // Evenimentul declansat de catre un click pe butonul destinat unei melodii.
            // Acesta va crea un nou panel in care va introduce toate datele disponibile
            // despre melodia aleasa.

            panelInfo.Controls.Clear();
            Panel panelParticipant = new Panel();
            panelParticipant.Width = panelInfo.Width;
            panelParticipant.Height = panelInfo.Height;

            // Id-ul melodiei se afla in propritatea [Tag] a butonului, drept urmare
            Participant participant = participanti.First(m => m.IdParticipant == int.Parse((sender as Button).Tag.ToString()));

            //Label pentru denumire
            System.Windows.Forms.Label Denumire = new System.Windows.Forms.Label();
            Denumire.Text = participant.Nume;
            Denumire.Font = new Font("Leelawadee", 16);
            Denumire.AutoSize = true;
            Denumire.Width = panelInfo.Width;
            Denumire.Dock = DockStyle.Top;
            Denumire.MaximumSize = new Size(Denumire.Width, 0);

            //Label pentru butonul de excludere a melodiei
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
            Scor.Width = Denumire.Width;
            Scor.Dock = DockStyle.Top;
            Scor.MaximumSize = new Size(Denumire.Width, 0);
            Scor.Padding = new Padding(5);
            panelParticipant.Controls.Add(Scor);

            if (participant.Informatii != null)
            {
                //Label pentru afisarea informatiilor aditionale, in cazul in care acestea exista.
                System.Windows.Forms.Label Informatii = new System.Windows.Forms.Label();
                Informatii.Text = String.Format($"Informatii: {participant.Informatii}");
                Informatii.ForeColor = Color.LightGray;
                Informatii.Font = new Font("Leelawadee", 10);
                Informatii.AutoSize = true;
                Informatii.Width = Denumire.Width;
                Informatii.Dock = DockStyle.Top;
                Informatii.MaximumSize = new Size(panelInfo.Width, 0);
                Informatii.Padding = new Padding(5);
                panelParticipant.Controls.Add(Informatii);
            }

            panelParticipant.Controls.Add(Denumire);

            //Deplasarea panelului spre stanga si pregatirea terenului pentru slide.
            panelParticipant.Left = -panelParticipant.Width;
            speedMovingPanel = (panelParticipant.Left) / 3;
            panelInfo.Controls.Add(panelParticipant);
            movingPanel = panelParticipant;
            timerSlideInDetails.Start();
        }

        private void btExclude_Click(object sender, EventArgs e)
        {
            //In urma apasarii butonului [Exclude], va aparea un messagebox pentru confirmare.
            //In cazul in care raspunstul este OK, atunci se va purcede la eliminarea melodiei din baza de date.
            Form Messagebox = new MessageBox();
            int idParticipant = int.Parse((sender as Button).Tag.ToString());
            string Denumire = participanti.First(m => m.IdParticipant == idParticipant).Nume;
            Messagebox.Tag = String.Format("Sunteti sigur ca doriti sa excludeti melodia {0}?", Denumire);
            Messagebox.ShowDialog();

            if (Messagebox.DialogResult == DialogResult.OK)
            {
                //Eliminarea participantului din baza de date
                string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + Directory.GetCurrentDirectory() + @"\Database.mdf;Integrated Security=True";
                SqlConnection Connection = new SqlConnection(connectionString);
                try
                {
                    SqlCommand sqlcDelete = new SqlCommand("DELETE FROM PARTICIPANTI WHERE IDPARTICIPANT = @IdParticipant", Connection);
                    SqlParameter parIdParticipant = new SqlParameter("@IdParticipant", idParticipant);
                    sqlcDelete.Parameters.Add(parIdParticipant);

                    Connection.Open();
                    sqlcDelete.ExecuteNonQuery();
                    Connection.Close();
                    LoadData();
                    panelInfo.Controls.Clear();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    lbError.Text = "Ne pare rau, s-a produs o eroare, participantul nu a fost exclus.";
                }
                finally
                {
                    if (Connection.State == ConnectionState.Open)
                        Connection.Close();
                }
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
