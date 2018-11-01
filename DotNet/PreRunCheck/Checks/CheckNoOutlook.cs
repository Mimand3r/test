using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP_DotNet.PreRunCheck.Checks
{
    class CheckNoOutlook : IPreRunCheck
    {
        public bool Check()
        {
            if (Process.GetProcessesByName("Outlook").Length > 0)
            {
                return true;
            }
            else
                return false;
        }

        public void PerformAction_Unvalid()
        {
            MessageBox.Show("Du musst Outlook starten");
        }

        public void PerformAction_Valid()
        {
           // MessageBox.Show("Outlook gefunden");
        }
    }
}
