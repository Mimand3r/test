using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP_DotNet.PreRunCheck.Checks_Async
{
    class CheckDissLoginData : IPreRunCheck_Async
    {
        Process p;

        public Task<bool> Check()
        {

            // Construct Path
            String path = Path.GetDirectoryName(Application.ExecutablePath);
            path = Path.GetFullPath(Path.Combine(path, @"..\..\..\Python"));

            var tcl = new TaskCompletionSource<bool>();

            ProcessStartInfo procStartInfo = new ProcessStartInfo("cmd.exe");

            procStartInfo.RedirectStandardInput = true;
            procStartInfo.RedirectStandardOutput = true;
            procStartInfo.RedirectStandardError = true;
            procStartInfo.UseShellExecute = false;
            procStartInfo.CreateNoWindow = true;

            p = new Process
            {
                StartInfo = procStartInfo,
                EnableRaisingEvents = true
            };


            p.OutputDataReceived += (sender, e) => {

                if (e.Data == null) return;

                if (e.Data.Contains("Bestanden"))
                {
                        tcl.TrySetResult(true);
                         
                }
                else if (e.Data.Contains("Durchgefallen"))
                {
                        tcl.TrySetResult(false);
                }
            };
        
            p.Start();
            p.StandardInput.WriteLine("cd /D " + path);
            p.StandardInput.WriteLine("python -u testDissLogin.py");

            p.BeginOutputReadLine();

            return tcl.Task;

        }

        public void PerformAction_Unvalid()
        {
            MessageBox.Show("Ungültige LoginDaten");
        }

        public void PerformAction_Valid()
        {
           // MessageBox.Show("Python in Ordnung");
        }
    }
}
