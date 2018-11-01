//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;
//using Bunifu.Framework.UI;
//using TP_DotNet.PythonInteraction;

//namespace TP_DotNet.Console
//{
//    public class ConsoleLogger
//    {
//        // Singleton
//        public static ConsoleLogger GetInstance { get; } = new ConsoleLogger();

//        // Dienstleistung - Schreibe Bericht in Konsole deiner Wahl
//        public void SchreibeBerichtInKonsole(FlowLayoutPanel konsole, ReporterNachricht nachricht, BunifuCustomLabel[] zaehler = null, PictureBox fehlermeldung = null)
//        {
//            if (nachricht.type == PyNachrichtenType.Started || nachricht.type == PyNachrichtenType.Stopped)
//            {
//                var currentTimeAndDate = DateTime.Now.ToString("dd.MM.yy - HH:mm:ss");
//                var message = nachricht.reporterMessage + " - " + currentTimeAndDate;
//                PostMessageInConsole(message, ConsoleColor.Green);
//            }

//            else if (nachricht.type == PyNachrichtenType.Info)
//            {
//                if (string.IsNullOrEmpty(nachricht.reporterMessage)) return;

//                if (nachricht.messageId == "Listening")
//                {
//                    PostMessageInConsole(nachricht.reporterMessage, ConsoleColor.Yellow, icon: Icon.Loading);
//                    return;
//                }


//                if (nachricht.messageId == "NeueEmail")
//                {
//                    var currentTimeAndDate = DateTime.Now.ToString("dd.MM.yy - HH:mm:ss");
//                    var message = nachricht.reporterMessage + " - " + currentTimeAndDate;
//                    PostMessageInConsole(message, ConsoleColor.Blue, icon: Icon.Email);
//                    return;
//                }

//                if (nachricht.messageId == "ErrorEmail")
//                {
//                    PostMessageInConsole(nachricht.reporterMessage, ConsoleColor.Blue, icon: Icon.ErrorEmail);
//                    raiseZaehler(CounterType.Ungueltig);
//                    return;
//                }

//                if (nachricht.messageId == "DissTicketErfolgreichErstellt")
//                {
//                    PostMessageInConsole(nachricht.reporterMessage, ConsoleColor.Blue, icon: Icon.Erledigt);
//                    raiseZaehler(CounterType.Erfolgreich);
//                    return;
//                }

//                if (nachricht.messageId == "ErstellungAbgebrochenFahrzeugNichtImGeltungszeitraum")
//                {
//                    PostMessageInConsole(nachricht.reporterMessage, ConsoleColor.Blue, icon: Icon.Geltungszeitraum);
//                    raiseZaehler(CounterType.Geltungszeitraum);
//                    return;
//                }

//                if (nachricht.messageId == "EmailAbgelaufen")
//                {
//                    PostMessageInConsole(nachricht.reporterMessage, ConsoleColor.Blue, icon: Icon.Verpasst);
//                    raiseZaehler(CounterType.Verpasst);
//                    return;
//                }

//                PostMessageInConsole(nachricht.reporterMessage, ConsoleColor.Green);

//            }

//            else if (nachricht.type == PyNachrichtenType.Error)
//            {
//                if (string.IsNullOrEmpty(nachricht.reporterMessage)) return;

//                //stoppen_button_Click(null,null);
//                fehlermeldung?.Invoke((MethodInvoker) delegate { fehlermeldung.Visible = true; });

//                PostMessageInConsole(nachricht.reporterMessage, ConsoleColor.Red, icon: Icon.Error);
//            }
//        }

//        private void PostMessageInConsole(string message, ConsoleColor green, Icon icon = Icon.Info)
//        {
//            throw new NotImplementedException();
//        }

//        private void raiseZaehler(CounterType counter)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}
