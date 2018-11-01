using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TP_DotNet.Helper;

namespace TP_DotNet
{
    public partial class PageOutlook : UserControl
    {

        public PageOutlook()
        {
            InitializeComponent();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(VBACode.testerCode);
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(VBACode.GetMainCode("13"));
        }
    }
}
