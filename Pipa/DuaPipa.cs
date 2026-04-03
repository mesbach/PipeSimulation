using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GDI.constanta;

namespace Project_X.Model
{
    class DuaPipa : Pipa
    {
        public double Diameter2 { get; set; }
        public double LuasPenampang2 { get; set; }
        public double KecepatanAliran2{get;set;}

        public override void compute()
        {
            setLuasPenampang2();
            setKecepatanAliran2();
            base.compute();
        }
        
        protected virtual double setLuasPenampang2()
        {
            this.LuasPenampang2 = Math.PI * this.Diameter2 * this.Diameter2 / 4;
            LuasPenampang2 = Math.Round(LuasPenampang2, 5);
            return LuasPenampang2;
        }
        protected virtual double setKecepatanAliran2()
        {
            this.KecepatanAliran2 = Debit / LuasPenampang2;
            this.KecepatanAliran2 = Math.Round(KecepatanAliran2, 5);
            return KecepatanAliran2;
        }
    }
}
