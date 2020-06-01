using System;
using System.Windows.Forms;

namespace Melodii.Forms
{
    public partial class MessageBox : Form
    {
        public MessageBox()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void MessageBox_Load(object sender, EventArgs e)
        {
            label1.Text = Tag.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            Close();
        }
    }
}
