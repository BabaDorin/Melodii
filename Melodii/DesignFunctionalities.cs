using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Melodii
{
    public class DesignFunctionalities
    {
        //Afisarea sau ascunderea unui submeniu.
        public static void Toggle(Panel panel)
        {
            if (panel.Visible)
                panel.Hide();
            else
                panel.Visible = true;
        }
    }
}
