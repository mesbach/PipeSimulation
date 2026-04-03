using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace Project_X.Model
{
    internal class vertex
    {
        public List<vertex> Prev;
        public List<vertex> Next;
        public Point Posision;
        public Color Color;
        public Color TextColor;
        public Color lineColor;
        public int Thickness;
        public int Size;
        public string Id;
        public double ELEVASI;

        #region center
        public Point GetCenterPotition(){
            return new Point(Posision.X - Size / 2, Posision.Y - Size / 2);
        }
        private Point CenterOfEarliestTimePotition(){
            return new Point(Posision.X, Posision.Y - Size / 4 - Size / 8);
        }
        private Point CenterOfLatestTime(){
            return new Point(Posision.X, Posision.Y + Size / 4 - Size / 8);
        }
        #endregion

        public vertex(){
        }
        public vertex(Point pos){
            Posision = pos;
        }
        public void ResetWarna()
        {
            Size = 10;
            Color = Colors.Green;
            lineColor = Colors.Aqua;
            TextColor = Colors.Black;
        }
        public void setWarnaSelect()
        {
            Color = Colors.LightBlue;
            lineColor = Colors.Aqua;
            TextColor = Colors.Black;
            Size = 10;
        }

        public void Draw(UIElementCollection canvas)
        {
            Shape myShape = CreateEllipse(Size, Size, Posision.X, Posision.Y);
            try
            {
                canvas.Remove(myShape);
            }
            catch { }
            canvas.Add(myShape);
        }
        Ellipse CreateEllipse(double width, double height, double desiredCenterX, double desiredCenterY)
        {
            Ellipse ellipse = new Ellipse();
            ellipse.Width = width;
            ellipse.Height = height;
            double left = desiredCenterX - (width / 2);
            double top = desiredCenterY - (height / 2);
            SolidColorBrush warna = new SolidColorBrush();
            SolidColorBrush garis = new SolidColorBrush();
            garis.Color = lineColor;
            warna.Color = Color;
            ellipse.Fill = warna;
            ellipse.StrokeThickness = this.Thickness;
            ellipse.Stroke = garis;
            ellipse.Margin = new Thickness(left, top, 0, 0);
            return ellipse;
        }
    }
}
