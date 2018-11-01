using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using Newtonsoft.Json;
using System.Windows.Forms;
using TP_DotNet.PreRunCheck;

namespace TP_DotNet.PythonInteraction
{   
    /// <summary>
    /// Bietet die ExecutePython Methode an.
    /// Diese ist in der Lage den PythonCore - Ticketersteller zu executen.
    /// Parameter für NoDiss oder NoJira werden auch unterstützt.
    /// 
    /// Diese Klasse hällt auch die AntwortListener Methode.
    /// Alle Python Outputs laufen hier dann durch
    /// 
    /// </summary>
    public class ExecutePythonCore
    {
        // Singleton
        private static ExecutePythonCore Instance = new ExecutePythonCore();
        public static ExecutePythonCore getInstance() => Instance;


        private Process cmdProcess;

        // Bietet Subscription Service
        public event EventHandler<PythonNachricht> PythonNachrichtEvent;

        // Dienstleistung: Starte Python
        public void ExecutePython()
        {
            var path = Path.GetDirectoryName(Application.ExecutablePath);
            path = Path.GetFullPath(Path.Combine(path, @"..\..\..\Python"));
            string jsonfile = Path.GetFullPath(Path.Combine(path, "runData.json"));

            ProcessStartInfo procStartInfo = new ProcessStartInfo("cmd.exe");

            procStartInfo.RedirectStandardInput = true;
            procStartInfo.RedirectStandardOutput = true;
            procStartInfo.RedirectStandardError = true;
            procStartInfo.UseShellExecute = false;
            procStartInfo.CreateNoWindow = true;
            cmdProcess = new Process
            {
                StartInfo = procStartInfo,
                EnableRaisingEvents = true
            };
            cmdProcess.OutputDataReceived += outputDataReceivedEventHandler;
            cmdProcess.Start();
            cmdProcess.StandardInput.WriteLine("cd /D " + path);
            cmdProcess.StandardInput.WriteLine("python -u TicketPrompter.py ");
            //cmdProcess.StandardInput.WriteLine("python -u TesteBotschaften.py ");
            cmdProcess.BeginOutputReadLine();


            // Sende bin gestartet Event
            PythonNachrichtEvent?.Invoke(this, new PythonNachricht(PyNachrichtenType.Started, ""));


        }

        // Dienstleistung: beende Python
        public void EndExecution()
        {
            if (cmdProcess != null)
            {
                cmdProcess.OutputDataReceived -= outputDataReceivedEventHandler;

                //Close cmd
                cmdProcess.Kill();
                //Close All Python Processes
                Process.GetProcesses()
                    .Where(x => x.ProcessName.ToLower()
                        .StartsWith("python"))
                    .ToList()
                    .ForEach(x => x.Kill());

                // Sende gestoppt Event
                PythonNachrichtEvent?.Invoke(this, new PythonNachricht(PyNachrichtenType.Stopped, ""));
            }


        }

        private void outputDataReceivedEventHandler(object sender, DataReceivedEventArgs e)
        {

            if (string.IsNullOrEmpty(e.Data)) return;

            string text = e.Data;
            string[] elemente = text.Split('.');
            string type = elemente[0];
            string message = "";
            if (elemente.Length > 1)
                message = elemente[1];

            PyNachrichtenType type_abbild = PyNachrichtenType.Info;
            switch (type)
            {
                case "Info":
                    type_abbild = PyNachrichtenType.Info;
                    break;
                case "Error":
                    type_abbild = PyNachrichtenType.Error;
                    break;
            }

            // Sende Nachricht eingetroffen Event
            PythonNachrichtEvent?.Invoke(this, new PythonNachricht(type_abbild, message));
        }

    }

    public class PythonNachricht : EventArgs
    {
        public PyNachrichtenType pyNachrichtenType;
        public string nachricht;

        public PythonNachricht(PyNachrichtenType type, string message)
        {
            pyNachrichtenType = type;
            nachricht = message;
        }
    }

    public enum PyNachrichtenType
    {
        Info,
        Error,
        Started,
        Stopped,
    }

}
