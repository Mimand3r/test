using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using TP_DotNet.JSON;
using TP_DotNet.PythonInteraction;

namespace TP_DotNet.History
{
    class HistoryWriter
    {
        // Singleton
        private static readonly HistoryWriter Instance = new HistoryWriter();
        public static HistoryWriter GetInstance() => Instance;


        // Dienstleistung - Starte HistoryWriter
        public void StartHistoryLogging()
        {
            Reporter.GetInstance().Bericht += OnBericht;
        }

        // Dienstleistung - Stoppe HistoryWriter
        public void StopHistoryLogging()
        {
            Reporter.GetInstance().Bericht -= OnBericht;

            // Prüfe ob natürliches Ende oder ErrorEnde & Logge in JSON

                // Lade aktuelle JSON
                var jsonfile = JsonCreator.JsonPath();
            if (!File.Exists(jsonfile)) return;

                string text = File.ReadAllText(jsonfile);
                JSON_Data inhalt = JsonConvert.DeserializeObject<JSON_Data>(text);
                
                var lastLogType = inhalt.Runs.Last().Logs.Last().type;
                if (lastLogType == PyNachrichtenType.Error)
                {
                    inhalt.Runs.Last().HadError = "True";
                }
                inhalt.Runs.Last().Running = "False";

            // Prüfe ob letzter Run Trigger hat
            if (inhalt.Runs.Last().TriggerEvents.Count == 0)
            {
                inhalt.Runs.Remove(inhalt.Runs.Last());
            }

                // Schribe zurück in JSON
                File.WriteAllText(jsonfile, JsonConvert.SerializeObject(inhalt));
        }

       
        private void OnBericht(object sender, ReporterNachricht reporterNachricht)
        {
            if (String.IsNullOrEmpty(reporterNachricht.reporterMessage)) return;

            // Lade aktuelle JSON
            var jsonfile = JsonCreator.JsonPath();
            string text = File.ReadAllText(jsonfile);
            JSON_Data inhalt = JsonConvert.DeserializeObject<JSON_Data>(text);
            // Adde den Bericht zur Json
            inhalt.Runs.Last().Logs.Add(reporterNachricht);

            // Prüfe ob Zähler Erhöhung nötig
            if (reporterNachricht.messageId == "DissTicketErfolgreichErstellt")
                inhalt.Runs.Last().Zaehler.Erfolg = (int.Parse(inhalt.Runs.Last().Zaehler.Erfolg) + 1).ToString();
            else if (reporterNachricht.messageId == "ErstellungAbgebrochenFahrzeugNichtImGeltungszeitraum")
                inhalt.Runs.Last().Zaehler.Geltungszeitraum = (int.Parse(inhalt.Runs.Last().Zaehler.Geltungszeitraum) + 1).ToString();
            else if (reporterNachricht.messageId == "EmailAbgelaufen")
                inhalt.Runs.Last().Zaehler.Verpasst = (int.Parse(inhalt.Runs.Last().Zaehler.Verpasst) + 1).ToString();
            else if (reporterNachricht.messageId == "ErrorEmail")
                inhalt.Runs.Last().Zaehler.Invalid = (int.Parse(inhalt.Runs.Last().Zaehler.Invalid) + 1).ToString();

            // Schribe zurück in JSON
            File.WriteAllText(jsonfile, JsonConvert.SerializeObject(inhalt));

        }


    }
}
