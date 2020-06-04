using System;
using System.Drawing;
using System.Windows.Forms;

namespace Melodii
{
    public class Reusable
    {
        //Afisarea sau ascunderea unui submeniu.
        public static void Toggle(Button parent, Panel panel)
        {
            //Afisarea / ascunderea submeniurilor
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
            //Deschiderea unei ferestre
            //Eliminam obiectele care au fost plasate anterior
            if(parent.Controls.Count>0)
                foreach(Form c in parent.Controls)
                {
                    c.Dispose();
                }

            //Inseram forma
            child.TopLevel = false;
            child.FormBorderStyle = FormBorderStyle.None;
            child.Dock = DockStyle.Fill;
            parent.Controls.Add(child);
            child.BringToFront();
            child.Show();
        }

        public static void tb_Enter(object sender, EventArgs e)
        {
            //Efectul de placeholder
            TextBox tb = sender as TextBox;
            if (tb.Tag.ToString() == tb.Text)
            {
                tb.Text = "";
                tb.ForeColor = Color.WhiteSmoke;
            }
        }

        public static void tb_Leave(object sender, EventArgs e)
        {
            //Efectul de placeholder
            TextBox tb = sender as TextBox;
            if (tb.Text.Trim() == "")
            {
                tb.Text = tb.Tag.ToString();
                tb.ForeColor = Color.Gray;
            }
        }

        public static void ScurtareDenumire(Button btn, int maxWidth)
        {
            //In cazul in care lungimea numelui este mai mare decat
            //lungimea butonului, atunci vom afisa doar literele care incap, urmate de 
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
    }
}
