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
using TP_DotNet.PreRunCheck;
using TP_DotNet.PreRunCheck.Checks;
using TP_DotNet.PreRunCheck.Checks_Async;
using Bunifu.Framework.UI;
using TP_DotNet.PythonInteraction;

namespace TP_DotNet
{
    public partial class MainPage : Form
    {
        Bitmap email_bild; 
        Bitmap email_bild_open;

        public MainPage()
        {
            InitializeComponent();

            //Init Refs as static Properties
            UIRefs.DissUsername = DissUsername;
            UIRefs.DissPassword = DissPassword;
            UIRefs.GeltungsZeitraum = geltungszeitraum;
            UIRefs.CounterErfolg = counter_erfolg;
            UIRefs.CounterUngueltig = counter_ungueltig;
            UIRefs.CounterError = counter_error;
       
            // Dies wird gebraucht für at Runtime Bildwechsel bei klick on Email Symbol
            String path = Path.GetDirectoryName(Application.ExecutablePath);
            path = Path.GetFullPath(Path.Combine(path, @"..\..\assets\Icons\"));
            email_bild = new Bitmap(path + "icon_email.png");
            email_bild_open = new Bitmap(path + "icon_emailOpen.png");

            

            //Subscribe to Reporter Event
          //  Reporter.Bericht += NeueNachricht;

        }

        //private void NeueNachricht(object sender, NachrichtEventArgs e)
        //{
        //    temploggers.Invoke((MethodInvoker)delegate
        //    {
        //        temploggers.Text = e.Nachricht;
        //    });
                 
        //}

        private void CloseButton_Click(object sender, EventArgs e)
        {
            //if (p != null) p.Close();
            System.Windows.Forms.Application.Exit();
           // Reporter.Bericht -= NeueNachricht;
        }

        private void Minimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
            CloseNewForm(sender, e);
        }


        private async void RunButton_Click(object sender, EventArgs e)
        {
            SetRunningMode(true);
#region PreRunChecks

            List<IPreRunCheck> preRunChecks = new List<IPreRunCheck>();

            preRunChecks.Add(new CheckNoPassword());
            preRunChecks.Add(new CheckNoOutlook());

            foreach (var preRunCheck in preRunChecks)
            {
                if (preRunCheck.Check())
                    preRunCheck.PerformAction_Valid();
                else
                {
                    preRunCheck.PerformAction_Unvalid();
                    SetRunningMode(false);
                    return;
                }
            }

#endregion

#region PreRunChecks async

            var preRunChecks_async = new List<IPreRunCheck_Async>();
            preRunChecks_async.Add(new CheckPythonInstallation());
            preRunChecks_async.Add(new CheckDissLoginData());
            //preRunChecks_async.Add(new CheckPythonDependencies());
            foreach (var preRunCheck in preRunChecks_async)
            {
                if (await preRunCheck.Check())
                    preRunCheck.PerformAction_Valid();
                else
                {
                    preRunCheck.PerformAction_Unvalid();
                    SetRunningMode(false);
                    return;
                }
            }

#endregion





          

        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            // if (p != null) p.Close();
            SetRunningMode(false);
            temploggers.Text = "Ticketprompter ist aus";
        }

        private void ResultFolder_Click(object sender, EventArgs e)
        {
            // Construct Path
            String path = Path.GetDirectoryName(Application.ExecutablePath);
            path = Path.GetFullPath(Path.Combine(path, @"..\..\..\Python\ExcelLogFiles"));

            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                Arguments = path,
                FileName = "explorer.exe",
            };

            Process.Start(startInfo);

        }

        TriggerFolders newForm;
        private void MainEmailButton_Click(object sender, EventArgs e)
        {

            if (newForm == null)
            {

                EmailButton.Image = email_bild_open;

                newForm = new TriggerFolders();

                //Calc Location
                int x = this.DesktopLocation.X + EmailButton.Location.X;
                int y = this.DesktopLocation.Y + EmailButton.Location.Y;
                x += EmailButton.Width;
                x += 8; // const margin
                y += EmailButton.Height / 2 - newForm.Height / 2;

                newForm.Location = new Point(x, y);
                newForm.ShowInTaskbar = false;
                newForm.Show();
            }
            else
                CloseNewForm(sender, e);
        }

        private void CloseNewForm(object sender, EventArgs e)
        {
            if (newForm != null)
            {
                newForm.Close();
                newForm.Dispose();
                newForm = null;
                EmailButton.Image = email_bild;
            }
        }

        private void _CloseNewForm(object sender, MouseEventArgs e)
        {
            if (newForm != null)
            {
                newForm.Close();
                newForm.Dispose();
                newForm = null;
                EmailButton.Image = email_bild;
            }
        }

        private void Tooltipp_ExcelIcon(object sender, EventArgs e)
        {
            var resultToolTip = new ToolTip();
            resultToolTip.ToolTipIcon = ToolTipIcon.None;
            resultToolTip.IsBalloon = true;
            resultToolTip.ShowAlways = true;
            resultToolTip.ToolTipTitle = "Excel Log Files";
            resultToolTip.AutoPopDelay = 10000;

            resultToolTip.SetToolTip(ResultFolder, "Gehe zu den Excel Log Files. \nHier werden Informationen zu den erstellten Tickets gesammelt.");
        }

        private void SetRunningMode(bool running)
        {
            DissUsername.Enabled = !running;
            DissPassword.Enabled = !running;
            geltungszeitraum.Enabled = !running;
            RunButton.Visible = !running;
            StopButton.Visible = running;
        }
                                          
               
    }
}




