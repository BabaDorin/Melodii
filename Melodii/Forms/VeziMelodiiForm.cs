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
        private static Panel panelInformation;

        public VeziMelodiiForm()
        {
            InitializeComponent();

            melodii.Clear();
            panelMelodii.Width = Width / 100 * 50;

            panelInfo.Left = panelMelodii.Right + 50;
            
            melodii.Add(new Melodie { IdMelodie = 0, Denumire = "Gucci gang Gucci gang Gucci gang Gucci gang", Interpret = "Lil Pump", Puncte = 0 });
            melodii.Add(new Melodie { IdMelodie = 2, Informatii = "Este infoEste infoEste infoEste infoEste infoEste infoEste infoEste infoEste infoEste infoEste infoEste infoEste infoEste infoEste infoEste infoEste infoEste infoEste infoEste infoEste infoEste info", Denumire = "WWWWWWWWWWWWWWWWWWWWWWW", Interpret = "XXXTentacion", Puncte = 0 });
            melodii.Add(new Melodie { IdMelodie = 3, Denumire = "iiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiii", Interpret = "XXXTentacion", Puncte = 0 });

            panelInformation = panelInfo;
            GenerateButtons(melodii, panel1);
        }

        private static void GenerateButtons(List<Melodie> melodii, Panel parentPanel)
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

        private static void btInfo_Click(object sender, EventArgs e)
        {
            panelInformation.Controls.Clear();

            Panel panelMelody = new Panel();
            panelMelody.Dock = DockStyle.Fill;
            panelMelody.Margin = new Padding(10);
            Melodie melodie = melodii.First(m => m.IdMelodie == int.Parse((sender as Button).Tag.ToString()));

            System.Windows.Forms.Label Denumire = new System.Windows.Forms.Label();
            Denumire.Text = melodie.Denumire;
            Denumire.Font = new Font("Leelawadee", 14);
            Denumire.AutoSize = true;
            Denumire.Width = panelInformation.Width;
            Denumire.Dock = DockStyle.Top;
            Denumire.MaximumSize = new Size(Denumire.Width, 0);

            System.Windows.Forms.Label Interpret = new System.Windows.Forms.Label();
            Interpret.Text = String.Format($"Interpret: {melodie.Interpret}");
            Interpret.ForeColor = Color.LightGray;
            Interpret.Font = new Font("Leelawadee", 11);
            Interpret.AutoSize = true;
            Interpret.Width = Denumire.Width;
            Interpret.Dock = DockStyle.Top;
            Interpret.MaximumSize = new Size(Interpret.Width, 0);

            if (melodie.Informatii!=null)
            {
                System.Windows.Forms.Label Informatii = new System.Windows.Forms.Label();
                Informatii.Text = Interpret.Text = String.Format($"Informatii: {melodie.Informatii}");
                Informatii.ForeColor = Color.LightGray;
                Informatii.Font = new Font("Leelawadee", 11);
                Informatii.AutoSize = true;
                Informatii.Width = Denumire.Width;
                Informatii.Dock = DockStyle.Top;
                Informatii.MaximumSize = new Size(Informatii.Width, 0);

                panelMelody.Controls.Add(Informatii);
            }
            

            panelMelody.Controls.Add(Interpret);
            panelMelody.Controls.Add(Denumire);

            panelInformation.Controls.Add(panelMelody);
            Debug.WriteLine("Done, Button tag = " + (sender as Button).Tag.ToString());
        }
    }
}
