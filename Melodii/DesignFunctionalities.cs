using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Melodii
{
    public class DesignFunctionalities
    {
        //Afisarea sau ascunderea unui submeniu.
        public static void Toggle(Button parent, Panel panel)
        {
            if (panel.Visible)
            {
                panel.Hide();
                parent.BackColor = Color.FromArgb(11, 7, 10);
                parent.ForeColor = Color.WhiteSmoke;
            }
            else
            {
                panel.Visible = true;
                parent.BackColor = Color.FromArgb(255, 190, 0);
                parent.ForeColor = Color.FromArgb(11, 7, 10);
            }
                
        }

        public static void openChildForm(Form child, Panel parent)
        {
            //Eliminam obiectele care au fost plasate anterior
            if(parent.Controls.Count>0)
                foreach(Form c in parent.Controls)
                {
                    c.Close();
                }

            //Inseram forma
            child.TopLevel = false;
            child.FormBorderStyle = FormBorderStyle.None;
            child.Dock = DockStyle.Fill;
            parent.Controls.Add(child);
            child.BringToFront();
            child.Show();
        }
    }
}
