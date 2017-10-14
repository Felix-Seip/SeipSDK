using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Plotter2D
{
    /// <summary>
    /// Interaction logic for MyCanvas.xaml
    /// </summary>
    public partial class MyCanvas : Canvas
    {

        protected override Size ArrangeOverride(Size arrangeSize)
        {
            Point middle = new Point(arrangeSize.Width / 2, arrangeSize.Height / 2);

            double x = 0.0, y = 0.0;
            foreach (UIElement element in base.InternalChildren)
            {
                if (element == null)
                    continue;

                element.RenderTransform = new MatrixTransform(1, 0, 0, -1, 0, 0);
                element.Arrange(new Rect(new Point(middle.X + x, middle.Y + y), element.DesiredSize));
            }
            return arrangeSize;
        }

        protected override Size MeasureOverride(Size constraint)
        {
            Size availableSize = new Size(double.PositiveInfinity, double.PositiveInfinity);
            foreach (UIElement element in base.InternalChildren)
            {
                if (element != null)
                {
                    element.Measure(availableSize);
                }
            }
            return new Size();
        }

        public MyCanvas()
        {
            InitializeComponent();
        }
    }
}
