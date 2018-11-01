using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP_DotNet.PreRunCheck.Checks
{
    /// <summary>
    /// Testet ob User vergessen hat ein Passwort einzugeben
    /// </summary>
    class CheckNoPassword : IPreRunCheck
    {
        public bool Check()
        {
            
            if (UIRefs.DissUsername.text == "Name"
                || UIRefs.DissUsername.text == ""
                || UIRefs.DissPassword.text == "Passwort"
                || UIRefs.DissPassword.text == "")        
                return false;                

            return true;
        }

        public void PerformAction_Unvalid()
        {
            MessageBox.Show("Du hast vergessen Name oder Passwort einzugeben");
        }

        public void PerformAction_Valid()
        {
            //MessageBox.Show("Alles in Ordnung");
        }
    }
}
