using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Plotter2D
{
    public class PointUI : Shape
    {
        public Point NodeLocation { get; private set; }
        public Geometry ClipShape { get; private set; }

        private Random randomColor = new Random();
        protected override Geometry DefiningGeometry
        {
            get
            {
                return ClipShape;
            }
        }

        public PointUI(Point p, double width, double height, double radius, double phi, int r, int g, int b)
        {
            ClipShape = new EllipseGeometry(new System.Windows.Point(p.X, p.Y), width, height);
            Stroke = new SolidColorBrush(Color.FromArgb(255, (byte)((radius * r) * phi / 2), /*(byte)(radius/5 * 100)*/(byte)g, (byte)(0.5 / radius * b)));
            StrokeThickness = 1;
        }

    }
}
