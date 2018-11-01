using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP_DotNet.Helper
{
    public static class VBACode
    {
        public static string testerCode =
            "Sub Finde_Postfach_ID()\n\nDim x As Integer\nDim objApp As Outlook.Application\nDim objNameSpace As Outlook.NameSpace\nSet objApp = Outlook.Application\nSet objNameSpace = objApp.GetNamespace(\"MAPI\")\n\n' Hier Bitte die zu Testende ID eingeben, beginnend bei 1\nx = 1\n\nOn Error Resume Next\n    MsgBox (objNameSpace.Folders(x))\n\nIf Err.Number <> 0 Then\n    MsgBox (\"ungueltiger Index\")\nEnd If\n\nEnd Sub\n\n";

        public static string GetMainCode(string id)
        {
            if (id == null) return null;

            // Ermittle Pfad zum TriggerOrdner
            var path = Path.GetDirectoryName(Application.ExecutablePath);
            path = Path.GetFullPath(Path.Combine(path, @"..\..\..\Python\TriggerSection\neueTrigger"));

            string ergebnis = "Private WithEvents Items As Outlook.Items\n\n";
            ergebnis += "Public Function TimeInMS() As String\n\t";
            ergebnis +=
                "TimeInMS = Strings.Format(Now, \"HH_nn_ss\") & \"_\" & Strings.Right(Strings.Format(Timer, \"#0.00\"), 2)\n";
            ergebnis += "End Function\n\n";
            ergebnis += "Private Sub Application_Startup()\n";
            ergebnis += "\tDim objApp As Outlook.Application\n";
            ergebnis += "\tDim objNameSpace As Outlook.NameSpace\n";
            ergebnis += "\tSet objApp = Outlook.Application\n";
            ergebnis += "\tSet objNameSpace = objApp.GetNamespace(\"MAPI\")\n";
            ergebnis += $"\tSet Items = objNameSpace.Folders({id}).Folders(\"Posteingang\").Items\n\n";
            ergebnis += "End Sub\n\n";
            ergebnis += "Private Sub Items_ItemAdd(ByVal objItem As Object)\n";
            ergebnis += "\tOn Error GoTo ShowError\n";
            ergebnis += "\tDim objMail As Outlook.MailItem\n\n";
            ergebnis += "\tIf TypeName(objItem) = \"MailItem\" Then\n";
            ergebnis += "\t\tSet objMail = objItem\n";
            ergebnis += "\t\tDim path As String\n";
            ergebnis += $"\t\tpath = \"{path}\" & TimeInMS() & \".msg\"\n";
            ergebnis += "\t\tobjMail.SaveAs path, olMSG\n\n";
            ergebnis += "\tEnd If\n\n";
            ergebnis += "\tExit Sub\n\n";
            ergebnis += "ShowError:\n";
            ergebnis += "\tMsgBox Err.Number & \" - \" & Err.Description\n\n";
            ergebnis += "End Sub";

            return ergebnis;
        }
    }
}
