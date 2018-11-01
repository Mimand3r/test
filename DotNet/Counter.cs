using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TP_DotNet.PreRunCheck;

namespace TP_DotNet
{
    public static class Counter
    {
        public static void Zaehle_hoch(Zaehler zaehler)
        {
            int count = 0;
            switch (zaehler)
            {
                case Zaehler.Erfolg:
                    
                    Int32.TryParse(UIRefs.CounterErfolg.Text, out count);
                    count += 1;
                    UIRefs.CounterErfolg.Invoke((MethodInvoker)delegate
                    {
                        UIRefs.CounterErfolg.Text = count.ToString();
                    });
                    break;
                case Zaehler.Ungueltig:
                    Int32.TryParse(UIRefs.CounterUngueltig.Text, out count);
                    count += 1;
                    UIRefs.CounterUngueltig.Invoke((MethodInvoker)delegate
                    {
                        UIRefs.CounterUngueltig.Text = count.ToString();
                    });
                    break;
                case Zaehler.Error:
                    Int32.TryParse(UIRefs.CounterError.Text, out count);
                    count += 1;
                    UIRefs.CounterError.Invoke((MethodInvoker)delegate
                    {
                        UIRefs.CounterError.Text = count.ToString();
                    });
                    break;
                default:
                    break;
            }
        }

    }

    public enum Zaehler
    {
        Erfolg,
        Ungueltig,
        Error
    }
}
