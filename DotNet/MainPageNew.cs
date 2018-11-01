using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP_DotNet
{
    public partial class MainPageNew : Form
    {



        #region PageManagment Variablen
        private PageKey current_page = PageKey.StartPage;
        private Dictionary<PageKey, PageRefs> pageReferences;
        private Color color_buttonNotSelected = Color.FromArgb(20, 28, 33);
        private Color color_hoverNotSelected = Color.FromArgb(17, 24, 28);
        private Color color_buttonSelected = Color.FromArgb(37, 49, 57);
        #endregion


        public MainPageNew()
        {
            InitializeComponent();

            #region Pagemanagment Referenzen Setup
            pageReferences = new Dictionary<PageKey, PageRefs>();

            var start_refs = new PageRefs(button_starten, pageStarten);
            pageReferences.Add(PageKey.StartPage, start_refs);

            var outlook_refs = new PageRefs(button_outlook, pageOutlook);
            pageReferences.Add(PageKey.OutlookSetupPage, outlook_refs);

            var history_refs = new PageRefs(button_vergangenheit, pageHistory);
            pageReferences.Add(PageKey.VergangenheitsPage, history_refs);

            var einstellungen_refs = new PageRefs(button_einstellungen, pageEinstellungen);
            pageReferences.Add(PageKey.EinstellungenPage, einstellungen_refs);

            #endregion
            
            // Update Settings from LastSession
            pageEinstellungen.ReadOldSettings();
        }



        #region Close and Minimize

        private void close_app(object sender, EventArgs e)
        {
            pageStarten.stoppen_button_Click(null, null);
            Application.Exit();
        }

        private void minimize_app(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        #endregion

        #region Icons Klick Methoden

        private void open_folder(string folderName)
        {
            // Construct Path
            var path = Path.GetDirectoryName(Application.ExecutablePath);
            path = Path.Combine(path ?? throw new InvalidOperationException(), @"..\..\..\Python\");
            path = Path.Combine(path, folderName);
            path = Path.GetFullPath(path);

            var startInfo = new ProcessStartInfo
            {
                Arguments = path,
                FileName = "explorer.exe",
            };

            Process.Start(startInfo);
        }

        private void open_excel_folder(object sender, EventArgs e)
        {
            open_folder("ExcelLogFiles");
        }

        private void icon_trigger_Click(object sender, EventArgs e)
        {
            open_folder(@"TriggerSection\neueTrigger");
        }

        private void icon_erledigt_click(object sender, EventArgs e)
        {
            open_folder(@"TriggerSection\erledigteTrigger");
        }

        private void icon_geltungszeitraum_click(object sender, EventArgs e)
        {
            open_folder(@"TriggerSection\außerhalbGeltungszeitraum");
        }

        private void icon_verpasst_click(object sender, EventArgs e)
        {
            open_folder(@"TriggerSection\verpassteTrigger");
        }

        private void icon_error_click(object sender, EventArgs e)
        {
            open_folder(@"TriggerSection\error");
        }

        private void icon_anleitung_click(object sender, EventArgs e)
        {
            open_folder(@"..\Anleitung");
        }

        #endregion

        #region PageManagment Methoden
        private void switch_page(PageKey newPage)
        {
            if (current_page == newPage) return;

         
            // Current Page
            //    Button Farbe auf default - onHover Farbe auf default onHover
            //    Button HoverCursor auf Hand stellen
            //    Page visibility = False


            pageReferences[current_page].button.Normalcolor = color_buttonNotSelected;
            pageReferences[current_page].button.OnHovercolor = color_hoverNotSelected;
            pageReferences[current_page].button.Cursor = Cursors.Hand;
            pageReferences[current_page].page.Visible = false;

            // New Page
            //    Button Farbe auf selected - onHover Farbe auf selected
            //    Button HoverCursor auf Pfeil stellen
            //    Page visibility = True

            pageReferences[newPage].button.Normalcolor = color_buttonSelected;
            pageReferences[newPage].button.OnHovercolor = color_buttonSelected;
            pageReferences[newPage].button.Cursor = Cursors.Arrow;
            pageReferences[newPage].page.Visible = true;


            current_page = newPage;

        }

  

        private void button_starten_Click(object sender, EventArgs e)
        {
            switch_page(PageKey.StartPage);
        }

        private void button_outlook_Click(object sender, EventArgs e)
        {
            switch_page(PageKey.OutlookSetupPage);
        }

        private void button_vergangenheit_Click(object sender, EventArgs e)
        {
            switch_page(PageKey.VergangenheitsPage);
            pageHistory.RefreshHistoryPage();
        }

        private void button_einstellungen_Click(object sender, EventArgs e)
        {
            switch_page(PageKey.EinstellungenPage);
        }
        #endregion
    }

}
