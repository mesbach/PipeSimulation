using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using GDI.constanta;
using System.Windows.Media;

namespace Project_X.Model
{
    class PipaAngsurKecil : DuaPipa
    {
        public Double SudutPengecilan { get; set; }
        public PipaAngsurKecil()
        {
        }
        protected override double setKehilanganEnergi()
        {
            this.KehilanganEnergi = Math.Pow(getKoefisien(), 1) / (c.Gravity * (Math.Pow(this.KecepatanAliran2, 2) - Math.Pow(this.KecepatanAliran, 2)));
            this.KehilanganEnergi = Math.Round(KehilanganEnergi, 5);
            return KehilanganEnergi;
        }
        private double getKoefisien()
        {
            if (SudutPengecilan <= 10) return 0.078;
            else if (SudutPengecilan <= 20) return 0.31;
            else if (SudutPengecilan <= 40) return 0.39;
            else if (SudutPengecilan <= 50) return 0.60;
            else if (SudutPengecilan <= 60) return 0.72;
            else if (SudutPengecilan <= 75) return 0.72;
            else return 0.0;
        }
        public override void resetWarna()
        {
            this.Color = Brushes.Khaki;
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
