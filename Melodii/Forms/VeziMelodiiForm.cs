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

            melodii.Clear();
            panelMelodii.Width = Width / 100 * 50;

            panelInfo.Left = panelMelodii.Right + 50;
            
            melodii.Add(new Melodie { IdMelodie = 0, Denumire = "Gucci gang", Interpret = "Lil Pump", Puncte = 0 });
            melodii.Add(new Melodie { IdMelodie = 2, Informatii = "Melodia care a castigat 3 premii grammy in doar 4 ani.", Denumire = "Moonlight", Interpret = "XXXTentacion", Puncte = 0 });
            melodii.Add(new Melodie { IdMelodie = 3, Puncte = 34, Denumire = "Freeman", Interpret = "Miyagi"});

            GenerateButtons(melodii, panel1);
        }

        private  void GenerateButtons(List<Melodie> melodii, Panel parentPanel)
        {
            if(melodii !=null && melodii.Count > 0)
            {
                parentPanel.Controls.Clear();

                for (int i = 0; i < melodii.Count; i++)
                {
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

                    Size size = TextRenderer.MeasureText(btn.Text, btn.Font);
                    if (size.Width > parentPanel.Width - parentPanel.Width * 0.3)
                    {
                        while(size.Width > parentPanel.Width - parentPanel.Width * 0.3)
                        {
                            btn.Text = btn.Text.Substring(0, btn.Text.Length - 1);
                            size = TextRenderer.MeasureText(btn.Text, btn.Font);
                        }
                        btn.Text += "...";
                    }

                    System.Windows.Forms.Label lbPoints = new System.Windows.Forms.Label();
                    lbPoints.Text = melodii[i].Puncte.ToString();
                    lbPoints.AutoSize = false;
                    lbPoints.Dock = DockStyle.Right;
                    lbPoints.BackColor = Color.Transparent;
                    lbPoints.Font = new Font("Leelawadee", 10);
                    lbPoints.TextAlign = ContentAlignment.MiddleCenter;

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

        private void VeziMelodiiForm_Resize(object sender, EventArgs e)
        {
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
                        Size size = TextRenderer.MeasureText(btn.Text, btn.Font);

                        if (size.Width > panelMelodii.Width - panelMelodii.Width * 0.25)
                        {
                            while (size.Width > panelMelodii.Width - panelMelodii.Width * 0.25)
                            {
                                btn.Text = btn.Text.Substring(0, btn.Text.Length - 1);
                                size = TextRenderer.MeasureText(btn.Text, btn.Font);
                            }
                            btn.Text += "...";
                        }
                    }
                    else
                    {
                        string initialButtonText = melodii.First(x => x.IdMelodie == int.Parse(btn.Tag.ToString())).Denumire;
                        if (btn.Text.Length < initialButtonText.Length)
                        {
                            btn.Text = initialButtonText;

                            Size size = TextRenderer.MeasureText(btn.Text, btn.Font);
                            if (size.Width > panelMelodii.Width - panelMelodii.Width * 0.3)
                            {
                                while (size.Width > panelMelodii.Width - panelMelodii.Width * 0.3)
                                {
                                    btn.Text = btn.Text.Substring(0, btn.Text.Length - 1);
                                    size = TextRenderer.MeasureText(btn.Text, btn.Font);
                                }
                                btn.Text += "...";
                            }
                        }
                    }
                }
        }

        private void btInfo_Click(object sender, EventArgs e)
        {
            panelInfo.Controls.Clear();
            Panel panelMelody = new Panel();
            panelMelody.Width = panelInfo.Width;
            panelMelody.Height = panelInfo.Height;
            Melodie melodie = melodii.First(m => m.IdMelodie == int.Parse((sender as Button).Tag.ToString()));

            System.Windows.Forms.Label Denumire = new System.Windows.Forms.Label();
            Denumire.Text = melodie.Denumire;
            Denumire.Font = new Font("Leelawadee", 16);
            Denumire.AutoSize = true;
            Denumire.Width = panelInfo.Width;
            Denumire.Dock = DockStyle.Top;
            Denumire.MaximumSize = new Size(Denumire.Width, 0);

            System.Windows.Forms.Label Interpret = new System.Windows.Forms.Label();
            Interpret.Text = melodie.Interpret;
            Interpret.ForeColor = Color.LightGray;
            Interpret.Font = new Font("Leelawadee", 12);
            Interpret.AutoSize = true;
            Interpret.Width = Denumire.Width;
            Interpret.Dock = DockStyle.Top;
            Interpret.MaximumSize = new Size(Interpret.Width, 0);
            Interpret.Padding = new Padding(5);

            Button exclude = new Button();
            exclude.Padding = new Padding(10);
            exclude.Dock = DockStyle.Top;
            exclude.FlatStyle = FlatStyle.Flat;
            exclude.ForeColor = Color.WhiteSmoke;
            exclude.FlatAppearance.BorderSize = 0;
            exclude.Text = "Exclude melodia";
            exclude.AutoSize = true;
            exclude.Click += btExclude_Click;
            panelMelody.Controls.Add(exclude);

            System.Windows.Forms.Label Spatiu = new System.Windows.Forms.Label();
            Spatiu.Height = 50;
            Spatiu.Dock = DockStyle.Top;
            Spatiu.AutoSize = true;
            panelMelody.Controls.Add(Spatiu);

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
            Debug.WriteLine("Here");
        }

        private void btExclude_Click(object sender, EventArgs e)
        {
            Form Messagebox = new MessageBox();
            Messagebox.Tag = "Sunteti sigur ca doriti sa excludeti melodia Gucci Gang?";
            Messagebox.ShowDialog();
            if (Messagebox.DialogResult == DialogResult.OK)
            {
                //Exclude melodia
            }
        }

        #region TimerEvents
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
        #endregion

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


        
    }
}
