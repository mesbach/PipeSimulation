using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Water_Flow_Simulation_v1.Pipa
{
    public class BeanTable
    {
        string diameter;

        public string Diameter
        {
            get { return diameter; }
            set { diameter = value; }
        }
        string debit;

        public string Debit
        {
            get { return debit; }
            set { debit = value; }
        }
        string luas_penampang;

        public string Luas_Penampang
        {
            get { return luas_penampang; }
            set { luas_penampang = value; }
        }
        string kecepatan_aliran;

        public string Kecepatan_Aliran
        {
            get { return kecepatan_aliran; }
            set { kecepatan_aliran = value; }
        }
        string kehilangan_energi;

        public string Kehilangan_Energi
        {
            get { return kehilangan_energi; }
            set { kehilangan_energi = value; }
        }
        string elevasi;

        public string Elevasi
        {
            get { return elevasi; }
            set { elevasi = value; }
        }

    }
}
