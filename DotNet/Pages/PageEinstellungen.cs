using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bunifu.Framework.UI;
using TP_DotNet.Helper;
using TP_DotNet.PythonInteraction;

namespace TP_DotNet.Pages
{
    public partial class PageEinstellungen : UserControl
    {
        bool jira_activated = false;

        public PageEinstellungen()
        {
            InitializeComponent();
        }

        private void Jira_Toggle(object sender, EventArgs e)
        {
            jira_activated = !jira_activated;


            jira_checkmark_checked.Visible = jira_activated;
            jira_checkmark_unchecked.Visible = !jira_activated;


        }

        public void ReadOldSettings()
        {
            var oldSetting = SettingsManager.GetInstance().RestoreSettingsFromLastSession();
            if (oldSetting != null)
            {
                // SettingsFile liegt vor - lese alte Werte
                username.Text = Encriptor.DecodeKey(oldSetting.Username);
                passwort.Text = Encriptor.DecodeKey(oldSetting.Passwort);
                interne_notiz.Text = oldSetting.InterneNotiz;
                ansprache.Text = oldSetting.Ansprache;
                geltungszeitraum.selectedIndex = GeltungszeitraumTextToID(oldSetting.Geltungszeitraum);
            }
            else
            {
                // Keine Settingsfile - registriere default Values
                username_OnValueChanged(null, null);
                passwort_OnValueChanged(null, null);
                interne_notiz_TextChanged(null,null);
                ansprache_TextChanged(null,null);
                geltungszeitraum_onItemSelected(null,null);
            }
        }

        private void username_OnValueChanged(object sender, EventArgs e)
        {
            var text = Encriptor.EncodeString(username.Text);
            SettingsManager.GetInstance().SchreibeSetting(text, SettingTypes.Username);

        }

        private void passwort_OnValueChanged(object sender, EventArgs e)
        {
            var text = Encriptor.EncodeString(passwort.Text);
            SettingsManager.GetInstance().SchreibeSetting(text, SettingTypes.Passwort);
        }

        private void interne_notiz_TextChanged(object sender, EventArgs e)
        {
            var text = interne_notiz.Text;
            SettingsManager.GetInstance().SchreibeSetting(text, SettingTypes.InterneNotiz);
        }

        private void ansprache_TextChanged(object sender, EventArgs e)
        {
            var text = ansprache.Text;
            text = text.Replace("\n", String.Empty);
            SettingsManager.GetInstance().SchreibeSetting(text, SettingTypes.Ansprache);
        }

        private void geltungszeitraum_onItemSelected(object sender, EventArgs e)
        {
            var index = geltungszeitraum.selectedIndex;
            string text = GeltungszeitraumIDtoText(index);
            SettingsManager.GetInstance().SchreibeSetting(text, SettingTypes.Geltungszeitraum);
        }

        private int GeltungszeitraumTextToID(string text)
        {
            switch (text)
            {
                case "0":
                    return 0;
                case "48":
                    return 1;
                case "24":
                    return 2;
                case "18":
                    return 3;
                case "12":
                    return 4;
                case "6":
                    return 5;
                default:
                    return 2;
            }
        }

        private string GeltungszeitraumIDtoText(int id)
        {
            switch (id)
            {
                case 0:
                    return "0";
                case 1:
                    return "48";
                case 2:
                    return "24";
                case 3:
                    return "18";
                case 4:
                    return "12";
                case 5:
                    return "6";
                default:
                    return "24";
            }
        }

     
    }
}
