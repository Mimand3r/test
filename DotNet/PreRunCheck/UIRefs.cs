using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bunifu.Framework.UI;


namespace TP_DotNet.PreRunCheck
{
    /// <summary>
    /// Abstrakte fully static attribut class.
    /// 
    /// Hällt globale Referenzen zu UI Objekten
    /// </summary>
    public abstract class UIRefs
    {
        public static BunifuTextbox DissUsername = null;
        public static BunifuTextbox DissPassword = null;

        public static BunifuDropdown GeltungsZeitraum = null;

        public static BunifuCustomLabel CounterErfolg = null;
        public static BunifuCustomLabel CounterUngueltig = null;
        public static BunifuCustomLabel CounterError = null;

    }
}
