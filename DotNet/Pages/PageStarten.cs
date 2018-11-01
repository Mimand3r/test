using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Bunifu.Framework.UI;
using TP_DotNet.JSON;
using TP_DotNet.PreRunCheck;
using TP_DotNet.PreRunCheck.Checks;
using TP_DotNet.PreRunCheck.Checks_Async;
using TP_DotNet.PythonInteraction;

namespace TP_DotNet
{
    public partial class PageStarten : UserControl
    {
        Timer stopuhr;
        int sekundenCounter;
        private PictureBox waitingIcon;
        private List<FlowLayoutPanel> consoleItems = new List<FlowLayoutPanel>();
        private bool running = false;

        public PageStarten()
        {
            InitializeComponent();

            // Init ScrollingEffect for Console
            new EffectScrolling.EffectScrolling(Konsole);
        }

        private async void starten_button_Click(object sender, EventArgs e)
        {
            stoppen_button.Visible = true;

            // Clear Console

            foreach (var consoleItem in consoleItems)
            {
                if (consoleItem.InvokeRequired)
                    consoleItem.Invoke((MethodInvoker)delegate { consoleItem.Dispose(); });
                else
                    consoleItem.Dispose();

            }

            if (fehlermeldung.Visible) fehlermeldung.Visible = false;
            timer.Visible = true;
            meldung_aus.Visible = false;
            timer.Text = "0 Sekunden.";
            //PostMessageInConsole("Ticketprompter gestartet asdadsfasffas asfasfafsfas", ConsoleColor.Green);
            //PostMessageInConsole("Ticketprompter gestartet asdadsfasffas asfasfafsfas", ConsoleColor.Red, true);
            //PostMessageInConsole("Ticketprompter gestartet asdadsfasffas asfasfafsfas", ConsoleColor.Blue);

            // StopUhr
            stopuhr = new Timer {Interval = 1000};
            sekundenCounter = 0;
            stopuhr.Tick += SekundeVerstrichen;
            stopuhr.Start();

            #region PreRunChecks Sync

            //List<IPreRunCheck> preRunChecks = new List<IPreRunCheck>();

            //preRunChecks.Add(new CheckNoPassword());
            //preRunChecks.Add(new CheckNoOutlook());

            //foreach (var preRunCheck in preRunChecks)
            //{
            //    if (preRunCheck.Check())
            //        preRunCheck.PerformAction_Valid();
            //    else
            //    {
            //        preRunCheck.PerformAction_Unvalid();
            //        return;
            //    }
            //}

            #endregion

            #region PreRunChecks Async

            //var preRunChecksAsync = new List<IPreRunCheck_Async>();
            //preRunChecksAsync.Add(new CheckPythonInstallation());
            //preRunChecksAsync.Add(new CheckDissLoginData());
            ////preRunChecks_async.Add(new CheckPythonDependencies());
            //foreach (var preRunCheck in preRunChecksAsync)
            //{
            //    if (await preRunCheck.Check())
            //        preRunCheck.PerformAction_Valid();
            //    else
            //    {
            //        preRunCheck.PerformAction_Unvalid();
            //        return;
            //    }
            //}

            #endregion

            // Create JSON
            JsonCreator.CreateJson();

            // Execute Python
            var python = new ExecutePythonCore();
            Reporter.GetInstance().StarteReporter();
            Reporter.GetInstance().Bericht += NachrichtEingetroffen;
            ExecutePythonCore.getInstance().ExecutePython();

            // Zaehler
            resetZaehler();
            running = true;
        }

        public void stoppen_button_Click(object sender, EventArgs e)
        {
            stoppen_button.Invoke((MethodInvoker) delegate { stoppen_button.Visible = false; });
            timer.Invoke((MethodInvoker)delegate { timer.Visible = false; });
            meldung_aus.Invoke((MethodInvoker)delegate { meldung_aus.Visible = true; });


            // StopUhr
            if (stopuhr != null) { 
                stopuhr.Stop();
                stopuhr.Dispose();
            }

            // Kill Python Process
            if (running) { 
            ExecutePythonCore.getInstance().EndExecution();
            Reporter.GetInstance().Bericht -= NachrichtEingetroffen;
            Reporter.GetInstance().BeendeReporter();
            }
            running = false;


        }

        private void NachrichtEingetroffen(object sender, ReporterNachricht e)
        {

            if (e.type == PyNachrichtenType.Info)
            {
                if (string.IsNullOrEmpty(e.reporterMessage)) return;

                if (e.messageId == "Listening")
                {
                    PostMessageInConsole(e.reporterMessage, ConsoleColor.Yellow, icon:Icon.Loading);
                    return;
                }


                if (e.messageId == "NeueEmail")
                {

                    PostMessageInConsole(e.reporterMessage, ConsoleColor.Blue, icon: Icon.Email, ExtraPadding:false);
                    return;
                }

                if (e.messageId == "ErrorEmail")
                {
                    PostMessageInConsole(e.reporterMessage, ConsoleColor.Blue, icon: Icon.ErrorEmail);
                    raiseZaehler(CounterType.Ungueltig);
                    return;
                }

                if (e.messageId == "DissTicketErfolgreichErstellt")
                {
                    PostMessageInConsole(e.reporterMessage, ConsoleColor.Blue, icon: Icon.Erledigt);
                    raiseZaehler(CounterType.Erfolgreich);
                    return;
                }

                if (e.messageId == "ErstellungAbgebrochenFahrzeugNichtImGeltungszeitraum")
                {
                    PostMessageInConsole(e.reporterMessage, ConsoleColor.Blue, icon: Icon.Geltungszeitraum);
                    raiseZaehler(CounterType.Geltungszeitraum);
                    return;
                }

                if (e.messageId == "EmailAbgelaufen")
                {
                    PostMessageInConsole(e.reporterMessage, ConsoleColor.Blue, icon: Icon.Verpasst);
                    raiseZaehler(CounterType.Verpasst);
                    return;
                }



            }

            else if (e.type == PyNachrichtenType.Error)
            {
                if (string.IsNullOrEmpty(e.reporterMessage)) return;

                stoppen_button_Click(null,null);
                fehlermeldung.Invoke((MethodInvoker)delegate { fehlermeldung.Visible = true; });

                PostMessageInConsole(e.reporterMessage, ConsoleColor.Red, icon:Icon.Error);
                return;
            }

            PostMessageInConsole(e.reporterMessage, ConsoleColor.Green);
        }

        private void SekundeVerstrichen(object sender, EventArgs e)
        {
            sekundenCounter += 1;

            // Wandle um in sek,min,stu,tage

            int sekunden = sekundenCounter % 60;
            int minutenCounter = (int)Math.Floor(sekundenCounter / 60.0);
            int minuten = minutenCounter % 60;
            int stundenCounter = (int)Math.Floor(minutenCounter / 60.0);
            int stunden = stundenCounter % 24;
            int tage = (int)Math.Floor(stundenCounter / 24.0);

            // Schreibe in String
            string output;
            if (tage > 0)
            {
                output = $"{tage} Tagen. {stunden} Stunden. {minuten} Minuten. {sekunden} Sekunden.";
            }

            else if (stunden > 0)
            {
                output = $"{stunden} Stunden. {minuten} Minuten. {sekunden} Sekunden.";
            }

            else if (minuten > 0)
            {
                output = $"{minuten} Minuten. {sekunden} Sekunden.";
            }

            else
            {
                output = $"{sekunden} Sekunden.";
            }

            //Schreibe in Label
            timer.Text = output;


        }

        public void PostMessageInConsole(string message, ConsoleColor textcolor, bool ExtraPadding = false, Icon icon = Icon.Info)
        {

            // HardCoded Textfarben
            Color color = new Color();
            switch (textcolor)
            {
                case ConsoleColor.Green:
                    color = Color.FromArgb(56,127,64);
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

            if (Konsole.InvokeRequired) {
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
            if (waitingIcon != null)
            {
                waitingIcon.Enabled = false;
                waitingIcon = null;
            }


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
                waitingIcon = picture;

            // Text Label 

            BunifuCustomLabel newLabel = new BunifuCustomLabel();
            newLabel.Text = message;
            newLabel.ForeColor = color;
            newLabel.MaximumSize = new Size(300,0);
            newLabel.AutoSize = true;
            newLabel.Parent = linePanel;
            double d = imageSize / 2 - newLabel.Size.Height * 0.42;
            newLabel.Margin = new Padding(10,(int)Math.Floor(d), 0, 0);
           
        }

        // Zaehler
        int[] zaehler_array = new int[4];

        private void resetZaehler()
        {
            for (int i = 0; i < 4; i++)
            {
                zaehler_array[i] = 0;
            }
            redrawCounters();
        }

        private void raiseZaehler(CounterType type)
        {
            zaehler_array[(int)type] += 1;
            redrawCounters();
        }

        private void redrawCounters()
        {
            zaehler_erfolgreich.Invoke((MethodInvoker) delegate
                {
                    zaehler_erfolgreich.Text = zaehler_array[0].ToString();
                });
            zaehler_geltungszeitraum.Invoke((MethodInvoker)delegate
            {
                zaehler_geltungszeitraum.Text = zaehler_array[1].ToString();
            });
            zaehler_verpasst.Invoke((MethodInvoker)delegate
            {
                zaehler_verpasst.Text = zaehler_array[2].ToString();
            });
            zaehler_ungueltig.Invoke((MethodInvoker)delegate
            {
                zaehler_ungueltig.Text = zaehler_array[3].ToString();
            });

        }

    }

    public enum ConsoleColor
    {
        Green,
        Blue,
        Red,
        Yellow
    }

    public enum Icon
    {
        Info,
        Email,
        Loading,
        Error,
        Erledigt,
        Geltungszeitraum,
        Verpasst,
        ErrorEmail
    }

    public enum CounterType
    {
        Erfolgreich,
        Geltungszeitraum,
        Verpasst,
        Ungueltig
    }
}
