using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bunifu.Framework.UI;
using System.Windows.Forms;

namespace TP_DotNet
{

    public enum PageKey
    {
        StartPage,
        OutlookSetupPage,
        VergangenheitsPage,
        EinstellungenPage
    }

    // Ein PageRef Objekt hat Referenzen zum Button und der Page
    public class PageRefs
    {
        public BunifuFlatButton button;
        public UserControl page;

        public PageRefs(BunifuFlatButton _button, UserControl _page)
        {
            button = _button;
            page = _page;
        }
    }
}
