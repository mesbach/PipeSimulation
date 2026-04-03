using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project_X.Model
{
    class banPipa
    {
        public double diameter;
        public double diameter2;
        public double debit;
        public double radius;
        public double sudutPengecilan;
        public double sudutPembesaran;
        public void reset()
        {
            diameter = -999;
            diameter2 = -999;
            debit = -999;
            radius = -999;
            sudutPembesaran = -999;
            sudutPengecilan = -999;
        }
    }
}
