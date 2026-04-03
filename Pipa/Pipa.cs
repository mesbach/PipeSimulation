using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using GDI.constanta;
using System.Windows.Media;
using Petzold.Media2D;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace Project_X.Model
{
    class Pipa
    {
        #region property;
        public vertex Start;
        public vertex Destination;
        public int Thickness ;
        public Brush Color;
        public Brush LineColor;
        public string Nama;

        #region local property
        public double Diameter { get; set; }
        public double Debit { get; set; }
        public double LuasPenampang { get; set; }
        public double KecepatanAliran { get; set; }
        public double KehilanganEnergi { get; set; }
        public double Elevasi { get; set; }
        public double ElevasiSebelumnya { get; set; }
        #endregion local property
        #endregion
        public Pipa()
        { 
        
        }
        #region fungsi
        protected double setLuasPenampang()
        {
            this.LuasPenampang = Math.PI * this.Diameter * this.Diameter / 4;
            LuasPenampang = Math.Round(LuasPenampang, 5);
            return LuasPenampang;
        }
        protected double setKecepatanAliran()
        {
            this.KecepatanAliran = Debit / LuasPenampang;
            this.KecepatanAliran = Math.Round(KecepatanAliran, 5);
            return KecepatanAliran;
        }
        protected virtual double setKehilanganEnergi()
        {
            this.KehilanganEnergi = this.KecepatanAliran * this.KecepatanAliran / (2 * c.Gravity);
            this.KehilanganEnergi = Math.Round(KehilanganEnergi, 5);
            return KehilanganEnergi;
        }
        protected virtual double setElevasiMukaAir()
        {
            this.Elevasi = this.ElevasiSebelumnya - this.KehilanganEnergi;
            return Elevasi;
        }
        public virtual void compute()
        {
            setLuasPenampang();
            setKecepatanAliran();
            setKehilanganEnergi();
            setElevasiMukaAir();
        }
        #endregion 

        #region draw()
        public Point Center()
        {
            Point center = new Point();
            if (Start.Posision.X > Destination.Posision.X)
                center.X = ((Start.Posision.X - Destination.Posision.X) / 2) + Destination.Posision.X;
            else
                center.X = ((Destination.Posision.X - Start.Posision.X) / 2) + Start.Posision.X;
            if (Start.Posision.Y > Destination.Posision.Y)
                center.Y = ((Start.Posision.Y - Destination.Posision.Y) / 2) + Destination.Posision.Y;
            else
                center.Y = ((Destination.Posision.Y - Start.Posision.Y) / 2) + Start.Posision.Y;
            return center;
        }
        private Point centerOfPoint(Point a)
        {
            return new Point(a.X + Destination.Size / 2, a.Y + Destination.Size / 2);
        }

        private Point getPointEdge(Point source, Point dest)
        {
            source = centerOfPoint(source);
            dest = centerOfPoint(dest);
            double gradienX = source.X / dest.X;
            double gradienY = source.Y / dest.Y;
            int basicX = Math.Abs((int)source.X - (int)dest.X);
            int basicY = Math.Abs((int)source.Y - (int)dest.Y);
            return new Point();
        }
        Ellipse CreateEllipse(double width, double height, double desiredCenterX, double desiredCenterY)
        {
            Ellipse ellipse = new Ellipse();
            ellipse.Width = width;
            ellipse.Height = height;
            double left = desiredCenterX - (width / 2);
            double top = desiredCenterY - (height / 2);
            ellipse.Fill = Color;
            ellipse.StrokeThickness = this.Thickness;
            ellipse.Stroke = LineColor;
            ellipse.Margin = new Thickness(left, top, 0, 0);
            return ellipse;
        }
        public void Draw(UIElementCollection canvas)
        {
            ArrowLine baru = new ArrowLine();
            baru.Stroke = this.Color;
            baru.StrokeThickness = Thickness;
            baru.X1 = Start.Posision.X;
            baru.X2 = Destination.Posision.X;
            baru.Y1 = Start.Posision.Y;
            baru.Y2 = Destination.Posision.Y;
            Ellipse tengah = CreateEllipse(10, 10, Center().X, Center().Y);
            canvas.Add(tengah);
            canvas.Add(baru);
        }
        public virtual void resetWarna()
        {}
        public virtual void selectWarna()
        {}
        #endregion
    }
}
