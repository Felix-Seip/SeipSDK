using RuntimeFunctionParser.Classes.Parser;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Plotter2D
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Parser functionParser;
        public MainWindow()
        {
            InitializeComponent();
            functionParser = new Parser();
        }

        private void btnPlotFunction_Click(object sender, RoutedEventArgs e)
        {
            myCanvas.Children.Clear();
            Function func = functionParser.ParseFunction(txtFunctionInput.Text);
            List<Point> pointList = new List<Point>();
            for(double i = -50; i < 50; i+=0.25)
            {

                double y = func.Solve(i, 0);
                if(!Double.IsInfinity(y))
                {
                    pointList.Add(new Point(i * 30, y * 30));
                }
            }
            Plot(pointList);
        }

        private void Plot(List<Point> pointList)
        {
            for(int i = 1; i < pointList.Count; i++)
            {
                Line line = new Line();
                line.X2 = pointList[i - 1].X;
                line.Y2 = pointList[i - 1].Y;
                line.X1 = pointList[i].X;
                line.Y1 = pointList[i].Y;
                line.Stroke = Brushes.Red;

                myCanvas.Children.Add(line);

                myCanvas.Children.Add(new PointUI(pointList[i], 1, 1, 1, 5, 0, 0, 0));
            }
        }
    }
}
