using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_DotNet.Helper;

namespace TP_DotNet.PythonInteraction
{
    /// <summary>
    /// Die Reporter Klasse übernimmt den Output in die Runtime Console, "berichtet" quasi was so beim PythonKern passiert.
    /// Sie wird ausschließlich von der ExecutePythonCore Klasse benutzt.
    /// 
    /// Sie bietet ein newMessage-Event zu dem die "Message Darsteller" subscriben können
    /// </summary>
    public class Reporter
    {
        // Singleton
        private static readonly Reporter Instance = new Reporter();
        public static Reporter GetInstance() => Instance;

        // Dienstleistung: Subscription Event
        public event EventHandler<ReporterNachricht> Bericht;

        private bool isRunning = false;

        // Dienstleistung: Reporter Starten
        public void StarteReporter()
        {
            ExecutePythonCore.getInstance().PythonNachrichtEvent += PythonMessage;
            isRunning = true;
            History.HistoryWriter.GetInstance().StartHistoryLogging();
        }

        // Dienstleistung: Reporter beenden
        public void BeendeReporter()
        {
            ExecutePythonCore.getInstance().PythonNachrichtEvent -= PythonMessage;
            isRunning = false;
            History.HistoryWriter.GetInstance().StopHistoryLogging();
        }

        // Dienstleistung: läufst du gerade?
        public bool IsRunning()
        {
            return isRunning;
        }

        private void PythonMessage(object sender, PythonNachricht e)
        {
            if (Bericht != null) {
                string formulierteMessage = KonsolenAuthor.GetInstance().ErzeugeUserNachricht(e.pyNachrichtenType, e.nachricht);
                Bericht(this, new ReporterNachricht(e.pyNachrichtenType, e.nachricht, formulierteMessage));
            }
                
        }
    }

    public class ReporterNachricht : EventArgs
    {
        public PyNachrichtenType type;
        public string messageId;
        public string reporterMessage;

        public ReporterNachricht(PyNachrichtenType t, string id, string message)
        {
            type = t;
            messageId = id;
            reporterMessage = message;
        }
    }


}
