using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32.SafeHandles;

namespace TP_DotNet.EffectScrolling
{
    class EffectScrolling
    {
        public ScrollableControl Panel { get; set; }
        public Size Size { get; set; }
        public Point Location { get; set; }

        public EffectScrolling(ScrollableControl panel)
        {
            Size = panel.Size;
            Location = panel.Location;
            Panel = panel;

            // Apply AutoScrollSettings
            Panel.HorizontalScroll.Maximum = 0;
            Panel.HorizontalScroll.Visible = false;
            Panel.VerticalScroll.Maximum = 0;
            Panel.VerticalScroll.Visible = false;
            Panel.AutoScroll = true;

            // Apply OnMouseklick Event

           // panel.MouseClick += PanelOnMouseClick;

        }

        private void PanelOnMouseClick(object sender, MouseEventArgs mouseEventArgs)
        {
            // Finde raus welche Hälfte des Panels geklicked wurde
            var haelfte = ErmittleHaelfte(mouseEventArgs.Location);

            if (mouseEventArgs.Button == MouseButtons.Right)
            {
                if (haelfte == Haelfte.ObereHaelfte)
                {
                    var c = new Control();
                    c.Parent = Panel;
                    c.Dock = DockStyle.Top;
                    Panel.ScrollControlIntoView(c);
                    c.Parent = null;
                    c.Dispose();

                }
                else if (haelfte == Haelfte.UntereHaelfte)
                {
                    // Springe ganz nach unten
                    var c = new Control();
                    c.Parent = Panel;
                    c.Dock = DockStyle.Bottom;
                    Panel.ScrollControlIntoView(c);
                    c.Parent = null;
                    //c.Dispose();

                    //Panel.VerticalScroll.Value = Panel.VerticalScroll.Maximum;
                    //Point bot = new Point(Panel.AutoScrollPosition.X, -Panel.AutoScrollPosition.Y+10);
                    //Panel.AutoScrollPosition = bot;
                }
            }

            else if(mouseEventArgs.Button == MouseButtons.Right)
            {
                
            }
        }

        private Haelfte ErmittleHaelfte(Point clickPunkt)
        {
            Console.WriteLine("Size");
            Console.WriteLine(Panel.Size.Height);
            Console.WriteLine("Location");
            Console.WriteLine(Panel.Location.Y);
            Console.WriteLine("Clickpunkt");
            Console.WriteLine(clickPunkt.Y);
            return clickPunkt.Y > Size.Height / 2 ? Haelfte.UntereHaelfte : Haelfte.ObereHaelfte;
        }
    }

    enum Haelfte
    {
        ObereHaelfte,
        UntereHaelfte
    }
}
