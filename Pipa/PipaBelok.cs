using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;

namespace Project_X.Model
{
    class PipaBelok : Pipa
    {
        public int Radius { get; set; }

        private double getKoefisien()
        {
            double Kb = Radius / Diameter;
            if (Kb <= 1) return 0.35;
            else if (Kb <= 2) return 0.19;
            else if (Kb <= 4) return 0.17;
            else if (Kb <= 6) return 0.22;
            else if (Kb <= 10) return 0.32;
            else if (Kb <= 16) return 0.38;
            else if (Kb <= 20) return 0.42;
            else return 1;
        }
        protected override double setKehilanganEnergi()
        {
            this.KehilanganEnergi = getKoefisien()* base.setKehilanganEnergi();
            this.KehilanganEnergi = Math.Round(KehilanganEnergi, 5);
            return KehilanganEnergi;
        }
        public override void resetWarna()
        {
            this.Color = Brushes.Navy;
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
