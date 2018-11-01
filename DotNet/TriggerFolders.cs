using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP_DotNet
{
    public partial class TriggerFolders : Form
    {
        public TriggerFolders()
        {
            InitializeComponent();
        }

        private void Tooltip_WorkingDir(object sender, EventArgs e)
        {
            var resultToolTip = new ToolTip();
            resultToolTip.ToolTipIcon = ToolTipIcon.None;
            resultToolTip.IsBalloon = true;
            resultToolTip.ShowAlways = true;
            resultToolTip.UseAnimation = true;
            resultToolTip.AutoPopDelay = 32767;

            resultToolTip.ToolTipTitle = "Unbearbeitete Emails";
            resultToolTip.SetToolTip(Button_WorkingDir, "Dieser Ordner wird von Outlook gefüllt, und löst ein Ticket aus. Hier liegen noch nicht bearbeitete Emails." +
                "\nWenn Outlook läuft ohne das der TicketPrompter läuft, so wird sich der Ordner mit der Zeit füllen.\nSobald der Ticketprompter läuft wird dieser Ordner geleert.");
        
    }

        private void WorkingDirClicked(object sender, EventArgs e)
        {
            // Construct Path
            String path = Path.GetDirectoryName(Application.ExecutablePath);
            path = Path.GetFullPath(Path.Combine(path, @"..\..\..\Python\TriggerSection\neueTrigger"));

            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                Arguments = path,
                FileName = "explorer.exe",
            };

            Process.Start(startInfo);
        }

        private void ErledigteEmailsClicked(object sender, EventArgs e)
        {
            // Construct Path
            String path = Path.GetDirectoryName(Application.ExecutablePath);
            path = Path.GetFullPath(Path.Combine(path, @"..\..\..\Python\TriggerSection\erledigteTrigger"));

            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                Arguments = path,
                FileName = "explorer.exe",
            };

            Process.Start(startInfo);
        }

        private void TooltipErledigteEmails(object sender, EventArgs e)
        {
            var resultToolTip = new ToolTip();
            resultToolTip.ToolTipIcon = ToolTipIcon.None;
            resultToolTip.IsBalloon = true;
            resultToolTip.ShowAlways = true;
            resultToolTip.UseAnimation = true;
            resultToolTip.AutoPopDelay = 32767;

            resultToolTip.ToolTipTitle = "Erledigte Emails";
            resultToolTip.SetToolTip(Button_ErledigteEmails, "Für all diese Emails wurde erfolgreich " +
                "ein Ticket erstellt.");
        }

        private void MissedTriggersClick(object sender, EventArgs e)
        {
            // Construct Path
            String path = Path.GetDirectoryName(Application.ExecutablePath);
            path = Path.GetFullPath(Path.Combine(path, @"..\..\..\Python\TriggerSection\verpassteTrigger"));

            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                Arguments = path,
                FileName = "explorer.exe",
            };

            Process.Start(startInfo);
        }

        private void MissedTriggersTooltip(object sender, EventArgs e)
        {
            var resultToolTip = new ToolTip();
            resultToolTip.ToolTipIcon = ToolTipIcon.None;
            resultToolTip.IsBalloon = true;
            resultToolTip.ShowAlways = true;
            resultToolTip.UseAnimation = true;
            resultToolTip.AutoPopDelay = 32767;

            resultToolTip.ToolTipTitle = "Verpasste Emails";
            resultToolTip.SetToolTip(Button_MissedTriggers, "Der Ticketprompter war offline als diese Emails " +
                "eingetroffen sind.\nAls der TicketPrompter wieder angemacht wurde, waren diese Emails älter " +
                "als 20 Minuten. Daher wurde kein Ticket erstellt.");
        }

        private void GelZeitraumClicked(object sender, EventArgs e)
        {
            // Construct Path
            String path = Path.GetDirectoryName(Application.ExecutablePath);
            path = Path.GetFullPath(Path.Combine(path, @"..\..\..\Python\TriggerSection\außerhalbGeltungszeitraum"));

            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                Arguments = path,
                FileName = "explorer.exe",
            };

            Process.Start(startInfo);
        }

        private void GelZeitraumTooltip(object sender, EventArgs e)
        {
            var resultToolTip = new ToolTip();
            resultToolTip.ToolTipIcon = ToolTipIcon.None;
            resultToolTip.IsBalloon = true;
            resultToolTip.ShowAlways = true;
            resultToolTip.UseAnimation = true;
            resultToolTip.AutoPopDelay = 32767;

            resultToolTip.ToolTipTitle = "Fahrzeug außerhalb des Geltungszeitraums";
            resultToolTip.SetToolTip(Button_Geltungszeitraum, "Für diese Emails wurde kein Ticket erstellt, da " +
                "der Geltungszeitraum von 2 Jahren abgelaufen war.");
        }

        private void ErrorEmailsClicked(object sender, EventArgs e)
        {
            // Construct Path
            String path = Path.GetDirectoryName(Application.ExecutablePath);
            path = Path.GetFullPath(Path.Combine(path, @"..\..\..\Python\TriggerSection\error"));

            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                Arguments = path,
                FileName = "explorer.exe",
            };

            Process.Start(startInfo);
        }

        private void ErrorEmailsTooltip(object sender, EventArgs e)
        {
            var resultToolTip = new ToolTip();
            resultToolTip.ToolTipIcon = ToolTipIcon.None;
            resultToolTip.IsBalloon = true;
            resultToolTip.ShowAlways = true;
            resultToolTip.UseAnimation = true;
            resultToolTip.AutoPopDelay = 32767;

            resultToolTip.ToolTipTitle = "Error Emails";
            resultToolTip.SetToolTip(ErrorEmailButton, "Email hatte unerwarteten Inhalt. \nFür diese Emails wurde kein Ticket erstellt");
        }
    }
}
