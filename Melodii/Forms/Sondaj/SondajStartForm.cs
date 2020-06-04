using System;
using System.Windows.Forms;
using static Melodii.Reusable;

namespace Melodii.Forms.Sondaj
{
    public partial class SondajStartForm : Form
    {
        public SondajStartForm(string Nume, int ParticipantId)
        {
            InitializeComponent();
            lbAdresare.Text = String.Format($"Salutare, {Nume}!");
            lbAdresare.Left = this.Width / 2 - lbAdresare.Width / 2;
            label1.Left = this.Width / 2 - label1.Width / 2;
            btOk.Left = this.Width / 2 - btOk.Width / 2;
            btOk.Tag = ParticipantId;
            cbTop3.Left = this.Width / 2 - cbTop3.Width / 2;
        }

        private void btOk_Click(object sender, EventArgs e)
        {
            Panel parent = this.Parent as Panel;
            this.Close();
            openChildForm(new SondajForm(int.Parse((sender as Button).Tag.ToString()), cbTop3.Checked), parent);
        }
    }
}
