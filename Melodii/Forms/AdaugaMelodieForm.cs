using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Melodii.Forms
{
    public partial class AdaugaMelodieForm : Form
    {
        private static int speed = 15;
        private static bool slideIn = true;
        public AdaugaMelodieForm()
        {
            InitializeComponent();
            label2.Left = -label2.Width;
            speed = (label1.Left - label2.Left) / 6;
        }

        public void SlideBar()
        {
            //Bara va aparea din stanga si se va deplasa pana va ajunge sub label1. Viteza acestuia se va miscora
            //treptat odata ce se aproprie de label1 si se va opri atunci cand label1.left == label2.left.
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (slideIn)
            {
                //Bara vine
                if (label2.Left >= label1.Left)
                {
                    timer1.Stop();
                }
                else
                {
                    label2.Left += speed;
                    speed = (label1.Left - label2.Left) / 6;
                    if (speed < 1) speed = 1;
                }
            }
            else
            {
                //bara pleaca
                if (label2.Left <= this.Width)
                {
                    label2.Left += speed;
                    speed += label2.Left / 20;
                }
                else
                {
                    timer1.Stop();
                    Debug.WriteLine("Got here");
                    label2.Dispose();
                    slideIn = true;
                }
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            slideIn = false;
            timer1.Start();
        }
    }
}
