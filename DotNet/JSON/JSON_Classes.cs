using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_DotNet.PythonInteraction;

namespace TP_DotNet
{
    
    public class JSON_Data
    {
        public List<Run> Runs { get; set; }

        public JSON_Data()
        {
            Runs = new List<Run>();
        }
    }

    public class Run
    {
        public string Datum { get; set; }
        public string Zeit { get; set; }
        public List<TriggerEvent> TriggerEvents { get; set; }
        public List<ReporterNachricht> Logs { get; set; }
        public ErignisZaehler Zaehler { get; set; }
        public string Running { get; set; }
        public string HadError { get; set; }

        public void Print()
        {
            Console.WriteLine("Run - " + Datum + " - " + Zeit);
            Console.WriteLine("Trigger bislang: " + TriggerEvents.Count);

            foreach (var triggerEvent in TriggerEvents)
            {
                triggerEvent.Print();
            }
        }

        public Run()
        {
            TriggerEvents = new List<TriggerEvent>();
            Logs = new List<ReporterNachricht>();
            Zaehler = new ErignisZaehler();
            Running = "True";
            HadError = "False";
            Datum = DateTime.UtcNow.Date.ToString().Split(' ')[0];
            Zeit = DateTime.UtcNow.TimeOfDay.ToString().Split('.')[0];
        }

    }


    public class ErignisZaehler
    {
        public string Erfolg { get; set; }
        public string Geltungszeitraum { get; set; }
        public string Verpasst { get; set; }
        public string Invalid { get; set; }

        public ErignisZaehler()
        {
            Erfolg = "0";
            Geltungszeitraum = "0";
            Verpasst = "0";
            Invalid = "0";
        }
    }

    public class TriggerEvent
    {
        public string EventCounter { get; set; }
        public string URL { get; set; }
        public string Datum { get; set; }
        public string Zeit { get; set; }
        public string Postfach { get; set; }
        public string AuftragsNr { get; set; }
        public string BA_ID { get; set; }
        public string Filter_ID { get; set; }
        public string VZ_Nr { get; set; }
        public string B_Nr { get; set; }
        public Ansprechpartner Ansprechpartner { get; set; }
        public Fahrzeugdaten Fahrzeugdaten { get; set; }
        public Partnerdaten Partnerdaten { get; set; }

        public void Print()
        {
            Console.WriteLine("------------------------");
            Console.WriteLine("Trigger " + EventCounter);
            Console.WriteLine("URL: " + URL);
            Console.WriteLine("Datum: " + Datum);
            Console.WriteLine("Zeit: " + Zeit);
            Console.WriteLine("Postfach: " + Postfach);
            Console.WriteLine("AuftragsNr: " + AuftragsNr);
            Console.WriteLine("BA_ID: " + BA_ID);
            Console.WriteLine("Filter_ID: " + Filter_ID);
            Console.WriteLine("VZ_Nr: " + VZ_Nr);
            Console.WriteLine("B_Nr: " + B_Nr);
            Ansprechpartner.Print();
            Fahrzeugdaten.Print();
            Partnerdaten.Print();
        }

    }

    public class Ansprechpartner
    {
        public string Name { get; set; }
        public string Tel { get; set; }
        public string PLZ { get; set; }
        public string Ort { get; set; }

        public void Print()
        {
            Console.WriteLine(Name + " " + Tel + " " + PLZ + " " + Ort);
        }
    }

    public class Fahrzeugdaten
    {
        public string Marke { get; set; }
        public string ModellJahr { get; set; }
        public string Verkaufstyp { get; set; }
        public string Verkaufstyp_Beschr { get; set; }
        public string Motor { get; set; }
        public string Getriebe { get; set; }
        public string AuslieferungsDatum { get; set; }
        public string FahrgestellNummer { get; set; }
        public string Laufleistung { get; set; }

        public void Print()
        {
            Console.WriteLine("Fahrzeugdaten:");
            Console.WriteLine("Marke " + Marke);
            Console.WriteLine("ModellJahr: " + ModellJahr);
            Console.WriteLine("Verkaufstyp: " + Verkaufstyp);
            Console.WriteLine("Verkaufstyp_Beschr: " + Verkaufstyp_Beschr);
            Console.WriteLine("Motor: " + Motor);
            Console.WriteLine("Getriebe: " + Getriebe);
            Console.WriteLine("AuslieferungsDatum: " + AuslieferungsDatum);
            Console.WriteLine("FahrgestellNummer: " + FahrgestellNummer);
            Console.WriteLine("Laufleistung: " + Laufleistung);
        }
    }

    public class Partnerdaten
    {
        public string Firma { get; set; }

        public void Print()
        {
            Console.WriteLine("Partnerdaten - Firma: " + Firma);
        }
    }
}


