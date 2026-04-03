using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;

namespace Project_X.Model
{
    class PipaPembesaranTibaTiba : DuaPipa
    {
        protected override double setKehilanganEnergi()
        {
            this.KehilanganEnergi = getKoefisien() * base.KehilanganEnergi;
            this.KehilanganEnergi = Math.Round(KehilanganEnergi, 5);
            return KehilanganEnergi;
        }
        private double getKoefisien()
        { 
            return Math.Pow((LuasPenampang/LuasPenampang2)-1,2);
        }
        public override void resetWarna()
        {
            this.Color = Brushes.Brown;
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
