using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;

namespace Project_X.Model
{
    class PipaLurus : Pipa
    {
        public override void resetWarna()
        {
            this.Color = Brushes.Pink;
            this.LineColor = Brushes.Plum;
            this.Thickness = 2;
        }
        public override void selectWarna()
        {
            this.Color = Brushes.Orange;
            this.LineColor = Brushes.YellowGreen;
            this.Thickness = 2;
        }

    }
}
