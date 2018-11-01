using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP_DotNet.PythonInteraction
{
    /// <summary>
    /// Die Settings aus der .Net UI müssen an Python übertragen werden. Dies geschieht über schreiben in eine
    /// SettingsFile. 
    /// Der Settingsmanager übernimmt diese Aufgabe. Er bietet 2 Dienstleistungen.
    /// Zum einen: Schreibe eine Setting into File.
    /// Zum anderen: Restore alle Settings von der letzten Session.
    /// </summary>
    class SettingsManager
    {
        // Singleton
        private static readonly SettingsManager Instance = new SettingsManager();

        public static SettingsManager GetInstance() => Instance;

        private Setting setting = new Setting();

        private const string Path = @"../../settings.txt";

        // Dienstleistung 1 - schreibe Setting zu File
        public void SchreibeSetting(string value, SettingTypes type)
        {
            // File doesnt exist? -> Create new
            CreateSettingsFileIfNonExistant();
            // passe dein internes Bild an
            switch (type)
            {
                case SettingTypes.Username:
                    setting.Username = value;
                    break;
                case SettingTypes.Passwort:
                    setting.Passwort = value;
                    break;
                case SettingTypes.InterneNotiz:
                    setting.InterneNotiz = value;
                    break;
                case SettingTypes.Ansprache:
                    setting.Ansprache = value;
                    break;
                case SettingTypes.Geltungszeitraum:
                    setting.Geltungszeitraum = value;
                    break;
                case SettingTypes.JiraAktiviert:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);

            }
            // schreibe Line into File
            var lines = File.ReadAllLines(Path);

            var oldLine = lines[(int) type].Split(':');
            var newline = oldLine[0] + ":" + value;

            lines[(int) type] = newline;
            File.WriteAllLines(Path, lines);


        }

        // Dienstleistung 2 - schreibe Setting zu File
        public Setting RestoreSettingsFromLastSession()
        {
            // File doesnt exist? -> Create new, return empty setting
            if (!CreateSettingsFileIfNonExistant()) return null;

            // lese alle values in internes Bild ein
            var lines = File.ReadAllLines(Path);
            setting.Username = lines[0].Split(':')[1];
            setting.Passwort = lines[1].Split(':')[1];
            setting.InterneNotiz = lines[2].Split(':')[1];
            setting.Ansprache = lines[3].Split(':')[1];
            setting.Geltungszeitraum = lines[4].Split(':')[1];

            // returne internes Bild
            return setting;
        }



        private bool CreateSettingsFileIfNonExistant()
        {
            if (File.Exists(Path)) return true;
            var lines = new string[6];
            lines[0] = "Username:";
            lines[1] = "Passwort:";
            lines[2] = "InterneNotiz:";
            lines[3] = "Ansprache:";
            lines[4] = "Geltungszeitraum:";
            lines[5] = "JiraAktiviert:";
            File.WriteAllLines(Path, lines);
            return false;
        }




    }


    public class Setting
    {
        public string Username = "";
        public string Passwort = "";
        public string InterneNotiz = "";
        public string Ansprache = "";
        public string Geltungszeitraum = "";
        public bool JiraAktiviert = false;
    }

    public enum SettingTypes
    {
        Username,
        Passwort,
        InterneNotiz,
        Ansprache,
        Geltungszeitraum,
        JiraAktiviert,

    }
}
