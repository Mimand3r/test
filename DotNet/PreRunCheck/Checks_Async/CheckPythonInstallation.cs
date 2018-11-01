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
    class CheckPythonInstallation : IPreRunCheck_Async
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

            // Wenn nach 4 Sekunden kein Erfolg da, so haben wir kein Python
            Timer timer = new Timer();
            timer.Interval = 4000;
            timer.Tick += (s, e) => {
                tcl.TrySetResult(false);
                timer.Stop();
                timer.Dispose();

            };
            timer.Start();

            p.OutputDataReceived += (sender, e) => {

                if (e.Data != null)
                if (e.Data.Length >= 16)
                if (e.Data.Substring(0, 16) == "test_erfolgreich")
                {
                        tcl.TrySetResult(true);
                        timer.Stop();
                        timer.Dispose();
                         
                }
            };
        
            p.Start();
            p.StandardInput.WriteLine("cd /D " + path);
            p.StandardInput.WriteLine("python -u test_pyInstalled.py");

            p.BeginOutputReadLine();

            return tcl.Task;

        }

        public void PerformAction_Unvalid()
        {
            MessageBox.Show("No Python");
        }

        public void PerformAction_Valid()
        {
           // MessageBox.Show("Python in Ordnung");
        }
    }
}
