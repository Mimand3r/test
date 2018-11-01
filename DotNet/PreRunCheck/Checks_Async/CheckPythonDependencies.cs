//using System;
//using System.Collections.Generic;
//using System.Diagnostics;
//using System.IO;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;

//namespace TP_DotNet.PreRunCheck.Checks_Async
//{
//    class CheckPythonDependencies : IPreRunCheck_Async
//    {
//        Process p;

//        public Task<bool> Check()
//        {
//            // Construct Path
//            String path = Path.GetDirectoryName(Application.ExecutablePath);
//            path = Path.GetFullPath(Path.Combine(path, @"..\..\..\Python"));

//            var tcl = new TaskCompletionSource<bool>();

//            ProcessStartInfo procStartInfo = new ProcessStartInfo("cmd.exe");

//            procStartInfo.RedirectStandardInput = true;
//            procStartInfo.RedirectStandardOutput = true;
//            procStartInfo.RedirectStandardError = true;
//            procStartInfo.UseShellExecute = false;
//            procStartInfo.CreateNoWindow = true;

//            p = new Process
//            {
//                StartInfo = procStartInfo,
//                EnableRaisingEvents = true
//            };

//            p.OutputDataReceived += (sender, e) => {

//                Console.WriteLine(e.Data);
//                if (e.Data != null)
//                    if (e.Data.Length >= 16)
//                        if (e.Data.Substring(0, 16) == "test_erfolgreich")
//                        {
//                            tcl.TrySetResult(true);

//                        }
//            };

//            p.Start();
//            p.StandardInput.WriteLine("cd /D " + path);
//            p.StandardInput.WriteLine("python -u test_dep.py");

//            p.BeginOutputReadLine();

//            return tcl.Task;
//        }

//        public void PerformAction_Unvalid()
//        {
//            throw new NotImplementedException();
//        }

//        public void PerformAction_Valid()
//        {
//            throw new NotImplementedException();
//        }
//    }
//}
