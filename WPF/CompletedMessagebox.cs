using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extender.WPF
{
    public static class CompletedMessagebox
    {
        public static void Show(bool success)
        {
            if(success)
                System.Windows.Forms.MessageBox.Show("Operation completed successfully");
            else
                System.Windows.Forms.MessageBox.Show("Operation failed.");
        }

        public static void Show()
        {
            Show(true);
        }
    }
}
