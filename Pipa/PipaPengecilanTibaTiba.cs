using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;

namespace Project_X.Model
{
    class PipaPengecilanTibaTiba : DuaPipa
    {
        protected override double setKehilanganEnergi()
        {
            this.KehilanganEnergi = GetKoefisien() * base.KehilanganEnergi;
            this.KehilanganEnergi = Math.Round(KehilanganEnergi, 5);
            return this.KehilanganEnergi;
        }
        private double GetKoefisien()
        {
            double Kc = this.Diameter2 / this.Diameter;
            if (Kc >= 0 && Kc < 0.2)
                return 0.5;
            else if (Kc >= 0.2 && Kc < 0.4)
                return 0.45;
            else if (Kc >= 0.4 && Kc < 0.6)
                return 0.38;
            else if (Kc >= 0.6 && Kc < 0.8)
                return 0.28;
            else if (Kc >= 0.8 && Kc < 1.0)
                return 0.14;
            else return 0.0;
        }
        public override void resetWarna()
        {
            this.Color = Brushes.Violet;
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
