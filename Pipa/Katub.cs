using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project_X.Model
{
    class Katub : Pipa
    {
        public Dictionary<string, double> Koefisien = new Dictionary<string, double>();
        public String NamaKatub;
        public int Presentase { get; set;}

        public Katub() {
            LoadKeofisien();
        }
        private void LoadKeofisien()
        {
            Koefisien.Add("Gabe Valves", 0.15);
            Koefisien.Add("Globe Valves", 10.0);
            Koefisien.Add("Check Valves Swing", 2.5);
            Koefisien.Add("Check Valves Ball", 70.0);
            Koefisien.Add("Check Valves Lift", 12.0);
            Koefisien.Add("Rotary Valves", 10.0);
        }
        protected override double setElevasiMukaAir()
        {
            return base.setElevasiMukaAir();
        }
    }
}
