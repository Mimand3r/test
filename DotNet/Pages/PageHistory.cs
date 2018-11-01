using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bunifu.Framework.UI;
using Newtonsoft.Json;
using TP_DotNet.JSON;
using TP_DotNet.PythonInteraction;

namespace TP_DotNet
{
    public partial class PageHistory : UserControl
    {

        private List<FlowLayoutPanel> consoleItems;

        public PageHistory()
        {
            InitializeComponent();
        }

        public void RefreshHistoryPage()
        {
            // Bestimme neue DropDownOptionen
      
                
                // Lade aktuelle JSON
                var jsonfile = JsonCreator.JsonPath();
                if (!File.Exists(jsonfile))
                {
                    KeineDurchlaeufe();
                    return;
                }

                string text = File.ReadAllText(jsonfile);
                JSON_Data inhalt = JsonConvert.DeserializeObject<JSON_Data>(text);

                if (inhalt.Runs.Count == 0)
                {
                    KeineDurchlaeufe();
                    return;
                }

                // Checke ob letzter Run noch läuft
                if (inhalt.Runs.Last().Running == "True")
                    inhalt.Runs.Remove(inhalt.Runs.Last());

                if (inhalt.Runs.Count == 0)
                {
                    KeineDurchlaeufe();
                    return;
                }

                // Mache für jeden Run ein DropdownEintrag
                string[] neueListe = new string[inhalt.Runs.Count];

                for (int i = 0; i < inhalt.Runs.Count; i++)
                {
                    var name = "Durchlauf vom: " + inhalt.Runs[i].Datum + " " + inhalt.Runs[i].Zeit;
                    // adde es nach hinten
                    neueListe[inhalt.Runs.Count - 1 - i] = name;
                }

                DurchlaufChooser.Items = neueListe;
                DurchlaufChooser.selectedIndex = 0;

                ShowData(inhalt.Runs.Last());

        }

        private void KeineDurchlaeufe()
        {
            string[] items = new string[1];
            items[0] = "Keine vergangenen Durchlaeufe";
            DurchlaufChooser.Items = items;
            DurchlaufChooser.selectedIndex = 0;
        }

        private void ShowData(Run selectedRun)
        {
            zaehler_erfolgreich.Text = selectedRun.Zaehler.Erfolg;
            zaehler_geltungszeitraum.Text = selectedRun.Zaehler.Geltungszeitraum;
            zaehler_verpasst.Text = selectedRun.Zaehler.Verpasst;
            zaehler_ungueltig.Text = selectedRun.Zaehler.Invalid;

            if (selectedRun.HadError == "True")
                fehlermeldung.Visible = true;

            // Alle LogDaten übertragen
            RefillConsole(selectedRun);

        }

        private void RefillConsole(Run selectedRun)
        {
            // Lösche Konsole wenn gefüllt
            if (consoleItems != null)
            {
                foreach (var item in consoleItems)
                {
                    if (item.InvokeRequired)
                        item.Invoke((MethodInvoker)delegate { item.Dispose(); });
                    else
                        item.Dispose();
                }
            }

            consoleItems = new List<FlowLayoutPanel>();

            foreach (var log in selectedRun.Logs)
            {
                CreateNewEntry(log);
            }

        }

        private void CreateNewEntry(ReporterNachricht e)
        {
            if (e.type == PyNachrichtenType.Info)
            {
                if (string.IsNullOrEmpty(e.reporterMessage)) return;

                if (e.messageId == "Listening")
                {
                    PostMessageInConsole(e.reporterMessage, ConsoleColor.Yellow, icon: Icon.Loading);
                    return;
                }


                if (e.messageId == "NeueEmail")
                {

                    PostMessageInConsole(e.reporterMessage, ConsoleColor.Blue, icon: Icon.Email);
                    return;
                }

                if (e.messageId == "ErrorEmail")
                {
                    PostMessageInConsole(e.reporterMessage, ConsoleColor.Blue, icon: Icon.ErrorEmail);
                    return;
                }

                if (e.messageId == "DissTicketErfolgreichErstellt")
                {
                    PostMessageInConsole(e.reporterMessage, ConsoleColor.Blue, icon: Icon.Erledigt);
                    return;
                }

                if (e.messageId == "ErstellungAbgebrochenFahrzeugNichtImGeltungszeitraum")
                {
                    PostMessageInConsole(e.reporterMessage, ConsoleColor.Blue, icon: Icon.Geltungszeitraum);
                    return;
                }

                if (e.messageId == "EmailAbgelaufen")
                {
                    PostMessageInConsole(e.reporterMessage, ConsoleColor.Blue, icon: Icon.Verpasst);
                    return;
                }



            }

            else if (e.type == PyNachrichtenType.Error)
            {
                if (string.IsNullOrEmpty(e.reporterMessage)) return;
                PostMessageInConsole(e.reporterMessage, ConsoleColor.Red, icon: Icon.Error);
                return;
            }

            PostMessageInConsole(e.reporterMessage, ConsoleColor.Green);
        }

        public void PostMessageInConsole(string message, ConsoleColor textcolor, bool ExtraPadding = false, Icon icon = Icon.Info)
        {

            // HardCoded Textfarben
            Color color = new Color();
            switch (textcolor)
            {
                case ConsoleColor.Green:
                    color = Color.FromArgb(56, 127, 64);
                    break;
                case ConsoleColor.Blue:
                    color = Color.FromArgb(47, 126, 131);
                    break;
                case ConsoleColor.Red:
                    color = Color.FromArgb(145, 52, 52);
                    break;
                case ConsoleColor.Yellow:
                    color = Color.FromArgb(145, 141, 42);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(textcolor), textcolor, null);
            }

            // New Line

            if (Konsole.InvokeRequired)
            {
                Konsole.Invoke((MethodInvoker)delegate
                {
                    CreateNewLine(message, color, ExtraPadding, icon);
                });

            }
            else
            {
                CreateNewLine(message, color, ExtraPadding, icon);
            }
        }

        private void CreateNewLine(string message, Color color, bool ExtraPadding, Icon icon)
        {
           


            string path = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
            path = Path.GetFullPath(Path.Combine(path, @"..\..\assets\Icons_new\"));
            Image iconImage = Image.FromFile(path + "infoIcon.png"); ;
            int imageSize = 20;
            int padding = 8;
            switch (icon)
            {
                case Icon.Info:
                    iconImage = Image.FromFile(path + "infoIcon.png");
                    break;
                case Icon.Email:
                    iconImage = Image.FromFile(path + "email.png");
                    imageSize = 25;
                    padding = 7;
                    break;
                case Icon.Loading:
                    iconImage = Image.FromFile(path + "loading_icon.gif");
                    break;
                case Icon.Error:
                    iconImage = Image.FromFile(path + "error.png");
                    imageSize = 28;
                    padding = 5;
                    break;
                case Icon.Erledigt:
                    iconImage = Image.FromFile(path + "erledigt.png");
                    imageSize = 28;
                    padding = 5;
                    break;
                case Icon.Geltungszeitraum:
                    iconImage = Image.FromFile(path + "geltungszeitraum.png");
                    imageSize = 25;
                    padding = 5;
                    break;
                case Icon.Verpasst:
                    iconImage = Image.FromFile(path + "verpasst.png");
                    imageSize = 28;
                    padding = 7;
                    break;
                case Icon.ErrorEmail:
                    iconImage = Image.FromFile(path + "erroremail.png");
                    imageSize = 28;
                    padding = 5;
                    break;
            }

            // Erzeuge Horizontales FlowLayoutPanel für neue Line

            FlowLayoutPanel linePanel = new FlowLayoutPanel();
            linePanel.FlowDirection = FlowDirection.LeftToRight;
            linePanel.Padding = ExtraPadding ? new Padding(padding, 16, 0, 0) : new Padding(padding, 0, 0, 0);
            linePanel.AutoSize = true;
            linePanel.Parent = Konsole;
            consoleItems.Add(linePanel);// registriere in Liste 

            // Bild ist erstes Kind von LinePanel

            PictureBox picture = new PictureBox
            {
                Image = iconImage,
                Size = new Size(imageSize, imageSize),
                SizeMode = PictureBoxSizeMode.Zoom,
                Parent = linePanel
            };

            if (icon == Icon.Loading)
                picture.Enabled = false;

            // Text Label 

            BunifuCustomLabel newLabel = new BunifuCustomLabel();
            newLabel.Text = message;
            newLabel.ForeColor = color;
            newLabel.MaximumSize = new Size(300, 0);
            newLabel.AutoSize = true;
            newLabel.Parent = linePanel;
            double d = imageSize / 2 - newLabel.Size.Height * 0.42;
            newLabel.Margin = new Padding(10, (int)Math.Floor(d), 0, 0);

        }
    }
}
