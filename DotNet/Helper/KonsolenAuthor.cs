using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_DotNet.PythonInteraction;

namespace TP_DotNet.Helper
{   
    /// <summary>
    /// uebernimmt den Schreibprozess fuer den Reporter. 
    /// Formuliert genauen Wortlaut der KonsolenNachrichten. 
    /// </summary>
    public class KonsolenAuthor
    {
        // Singleton
        private static readonly KonsolenAuthor Instance = new KonsolenAuthor();
        public static KonsolenAuthor GetInstance() => Instance;

        // Dienstleistung: Erzeuge UserNachricht
        public string ErzeugeUserNachricht(PyNachrichtenType type, string id)
        {
            

            if (type == PyNachrichtenType.Started)
            {
                return "Ticketprompter wird gestartet - " + DateTime.Now.ToString("dd.MM.yy - HH:mm:ss");
            }

            else if (type == PyNachrichtenType.Stopped)
            {
                return "Ticketprompter gestoppt - " + DateTime.Now.ToString("dd.MM.yy - HH:mm:ss");
            }

            else if (type == PyNachrichtenType.Info)
            {
                switch (id)
                {
                    case "SettingsGelesen":
                        return "Alle Einstellungen erfolgreich an Python uebertragen";
                    case "ExcelSkelettErstellt":
                        return "Neue ExcelDatei fuer spaetere TicketInformationen angelegt";
                    case "ExcelDateiGefunden":
                        return "Passende ExcelDatei gefunden. Hier werden zukuenftige TicketInformationen abgelegt";
                    case "JsonSkelettErstellt":
                        return "Json";
                    case "AlleOrdnerAngelegt":
                        return "";
                    case "Listening":
                        return "Ticketprompter ist bereit und wartet auf neue Email";
                    case "NeueEmail":
                        return "Neue Email ist eingetroffen - " + DateTime.Now.ToString("dd.MM.yy - HH:mm:ss");
                    case "EmailGelesen":
                        return "Email - Inhalt wird gelesen";
                    case "ErrorEmail":
                        return "Email erledigt\nKein Ticket erstellt - Email hatte unbekannte Struktur";
                    case "DissTicketErstellungGestartet":
                        return "LoginProzess Diss gestartet";
                    case "ErstellungAbgebrochenFahrzeugNichtImGeltungszeitraum":
                        return "Email erledigt\nKein Ticket erstellt - Fahrzeug nicht im Geltungszeitraum";
                    case "DissTicketErfolgreichErstellt":
                        return "Email erledigt\nEs wurde erfolgreich ein Diss Ticket erstellt";
                    case "InformationenInExcelGeschrieben":
                        return "Alle gesammelten Informationen aus EMail und DissPortal in ExcelDatei abgelegt";
                    case "InformationenInJsonGeschrieben":
                        return "";
                    case "FakeDissTicket":
                        return "DeveloperMode ist aktiviert. Fake Diss Ticket erstellt.";
                    case "EmailAbgelaufen":
                        return "Email erledigt\nKein Ticket erstellt - Der Ticket ausloesen Button wurde nicht gefunden. Vermutlich war die Email älter als 20 Minuten";
                    default:
                        break;
                }
            }
            else if (type == PyNachrichtenType.Error)
            {
                switch (id)
                {
                    case "SettingsFileZugriff":
                        return "Es gab einen Fehler beim Zugriff auf die SettingsFile. " +
                            "Versuchen Sie folgendes: In den Ordner DotNet gehen. Die Datei settings.txt loeschen. Dann den Ticketprompter neustarten";
                    case "SettingsFileInhalt":
                        return "Es gab einen Fehler beim Lesen der SettingsFile. " +
                            "Versuchen Sie folgendes: In den Ordner DotNet gehen. Die Datei settings.txt loeschen. Dann den Ticketprompter neustarten"; ;
                    case "ErstellungExcelDatei":
                        return "Es gab einen Fehler beim Erstellen der Excel Datei. Der Code hierzu befindet sich in der Datei Excel.py";
                    case "ErstellungJsonDatei":
                        return "Es gab einen Fehler beim Erstellen der Json Datei. Der Code hierzu befindet sich in der Datei JSON.py";
                    case "DissLogin":
                        return "Es gab ein Problem im Diss LoginProzess";
                    case "DissWebsiteZugriff":
                        return "Es konnte nicht auf die DissWebsite navigiert werden. Pruefen Sie ihre Internetverbindung. Testen Sie auch ob manuelle Navigation zu Diss moeglich ist.";
                    case "DissFeldBeobachtungAusloesenButton":
                        return "Nach dem DissLogin erschein ein Button mit der Aufschrift 'Feldbeobachtung Ausloesen'. Dieser Button konnte nicht anvisiert werden. " +
                            "Pruefen Sie Bitte ob die Html sich veraendert hat. Den Code finden Sie in der Datei Diss.py";
                    case "DissAnspracheTextfeld":
                        return "Auf Diss gibt es ein Textfeld 'Ansprache'. Dieses Textfeld konnte nicht anvisiert werden. " +
                            "Pruefen Sie Bitte ob die Html sich veraendert hat. Den Code finden Sie in der Datei Diss.py";
                    case "DissInterneNotizTextfeld":
                        return "Auf Diss gibt es ein Textfeld 'interne Notiz'. Dieses Textfeld konnte nicht anvisiert werden. " +
                            "Pruefen Sie Bitte ob die Html sich veraendert hat. Den Code finden Sie in der Datei Diss.py";
                    case "DissLesenVonInformationenAuslieferungsdatum":
                        return "Auf Diss gibt es eine InfoBox 'Auslieferungsdatum'. Diese Infobox konnte nicht anvisiert werden. " +
                            "Pruefen Sie Bitte ob die Html sich veraendert hat. Den Code finden Sie in der Datei Diss.py";
                    case "DissLesenVonInformationenMarke":
                        return "Auf Diss gibt es eine InfoBox 'Marke'. Diese Infobox konnte nicht anvisiert werden. " +
                            "Pruefen Sie Bitte ob die Html sich veraendert hat. Den Code finden Sie in der Datei Diss.py";
                    case "DissLesenVonInformationenModelljahr":
                        return "Auf Diss gibt es eine InfoBox 'Modelljahr'. Diese Infobox konnte nicht anvisiert werden. " +
                            "Pruefen Sie Bitte ob die Html sich veraendert hat. Den Code finden Sie in der Datei Diss.py";
                    case "DissLesenVonInformationenVerkaufstyp":
                        return "Auf Diss gibt es eine InfoBox 'Verkaufstyp'. Diese Infobox konnte nicht anvisiert werden. " +
                            "Pruefen Sie Bitte ob die Html sich veraendert hat. Den Code finden Sie in der Datei Diss.py";
                    case "DissLesenVonInformationenVerkaufstypBeschreibung":
                        return "Auf Diss gibt es eine InfoBox 'Verkaufstyp-Beschreibung'. Diese Infobox konnte nicht anvisiert werden. " +
                            "Pruefen Sie Bitte ob die Html sich veraendert hat. Den Code finden Sie in der Datei Diss.py";
                    case "DissLesenVonInformationenMotor":
                        return "Auf Diss gibt es eine InfoBox 'Motor'. Diese Infobox konnte nicht anvisiert werden. " +
                           "Pruefen Sie Bitte ob die Html sich veraendert hat. Den Code finden Sie in der Datei Diss.py";
                    case "DissLesenVonInformationenGetriebe":
                        return "Auf Diss gibt es eine InfoBox 'Getriebe'. Diese Infobox konnte nicht anvisiert werden. " +
                            "Pruefen Sie Bitte ob die Html sich veraendert hat. Den Code finden Sie in der Datei Diss.py";
                    case "DissLesenVonInformationenFahrgestellnummer":
                        return "Auf Diss gibt es eine InfoBox 'FahrgestellNummer'. Diese Infobox konnte nicht anvisiert werden. " +
                           "Pruefen Sie Bitte ob die Html sich veraendert hat. Den Code finden Sie in der Datei Diss.py";
                    case "DissLesenVonInformationenLaufleistung":
                        return "Auf Diss gibt es eine InfoBox 'Laufleistung'. Diese Infobox konnte nicht anvisiert werden. " +
                           "Pruefen Sie Bitte ob die Html sich veraendert hat. Den Code finden Sie in der Datei Diss.py";
                    case "DissLesenVonInformationenPartnerdaten":
                        return "Auf Diss gibt es eine InfoBox 'Partnerdaten'. Diese Infobox konnte nicht anvisiert werden. " +
                           "Pruefen Sie Bitte ob die Html sich veraendert hat. Den Code finden Sie in der Datei Diss.py";
                    case "DissLesenVonInformationenBeanstandung":
                        return "Auf Diss gibt es eine InfoBox 'Beanstandung'. Diese Infobox konnte nicht anvisiert werden. " +
                           "Pruefen Sie Bitte ob die Html sich veraendert hat. Den Code finden Sie in der Datei Diss.py";
                    case "DissLesenVonInformationenKundencodierung":
                        return "Auf Diss gibt es eine InfoBox 'KundenKodierung'. Diese Infobox konnte nicht anvisiert werden. " +
                           "Pruefen Sie Bitte ob die Html sich veraendert hat. Den Code finden Sie in der Datei Diss.py";
                    case "DissLesenVonInformationenWerkstattkodierung":
                        return "Auf Diss gibt es eine InfoBox 'WerkstattKodierung'. Diese Infobox konnte nicht anvisiert werden. " +
                           "Pruefen Sie Bitte ob die Html sich veraendert hat. Den Code finden Sie in der Datei Diss.py";
                    case "DissGeltungscheck":
                        return "Es gab ein Problem beim testen des Geltungszeitraums. Versuchen sie den Geltungszeitraum auf unbegrenzt einzustellen. " +
                            "Wenn Sie dringend den Geltungszeitraum brauchen, muessen Sie den Fehler in den Dateien Diss.py und CheckeGeltungszeitraum.py finden";
                    case "DissTicketErstellenButton":
                        return "Der letzte Schritt auf Diss ist das klicken des Buttons mit der Aufschrift 'Ticket erstellen'. Dieser Button konnte nicht anvisiert werden " +
                           "Pruefen Sie Bitte ob die Html sich veraendert hat. Den Code finden Sie in der Datei Diss.py";
                    case "ExcelZeileSchreiben":
                        return "Es gab ein Problem beim Schreiben in die ExcelDatei. Haben Sie zufaellig die ExcelDatei manuell geoeffnet? " +
                            "Die Excel Datei darf waehrend der Ticketprompter laeuft weder geoeffnet, noch geloescht werden!";
                    case "JsonZeileSchreiben":
                        return "Es gab ein Problem beim Schreiben in die Json Datei.";
                    case "DissUserIDButton":
                        return "Es gab ein Problem beim Diss LoginProzess.\nGanz am Anfang gibt es einen Button 'Anmeldung mit Global User ID'. Dieser wurde nicht gefunden.\nPruefen Sie Bitte ob die Html sich veraendert hat. Den Code finden Sie in der Datei Diss.py";
                    case "DissUserNameTextfeld":
                        return "Es gab ein Problem beim Diss LoginProzess.\nDas Textfeld für den Login - Usernamen wurde nicht gefunden.\nPruefen Sie Bitte ob die Html sich veraendert hat. Den Code finden Sie in der Datei Diss.py";
                    case "DissPasswortTextfeld":
                        return "Es gab ein Problem beim Diss LoginProzess.\nDas Textfeld für das Passwort wurde nicht gefunden.\nPruefen Sie Bitte ob die Html sich veraendert hat. Den Code finden Sie in der Datei Diss.py";
                    default:
                        break;
                }
            }
            return null;
        }


    }
}
