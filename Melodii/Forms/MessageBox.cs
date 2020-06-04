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

        private void MessageBox_Load(object sender, EventArgs e)
        {
            //Mesajul ce urmeaza a fi afisat este stocat in proprietatea Tag a ferestrei
            label1.Text = Tag.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Butonul OK
            this.DialogResult = DialogResult.OK;
            Close();
        }
    }
}
