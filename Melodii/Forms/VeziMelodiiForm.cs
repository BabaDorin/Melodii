using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Melodii.Forms
{
    public partial class VeziMelodiiForm : Form
    {
        public VeziMelodiiForm()
        {
            InitializeComponent();
            panel1.AutoScroll = true;
            for (int i=0; i<100; i++)
            {
                Button btn = new Button();
                btn.Dock = DockStyle.Top;
                btn.Text = "cf sarakilor";
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.Height = 60;
                btn.TextAlign = ContentAlignment.MiddleLeft;

                panel1.Controls.Add(btn);
            }
        }
    }
}
