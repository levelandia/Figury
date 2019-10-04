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
using System.Drawing;
using Figury.Shapes;

namespace Figury
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        
        private void addPoint()
        {
            Ellipse myEllipse = new Ellipse();
            SolidColorBrush mySolidColorBrush = new SolidColorBrush();
            mySolidColorBrush.Color = Color.FromRgb(255, 0, 0);
            myEllipse.Fill = mySolidColorBrush;
            myEllipse.StrokeThickness = 2;
            myEllipse.Stroke = Brushes.White;
            myEllipse.Width = 10;
            myEllipse.Height = 10;
            Point p = new Point(Mouse.GetPosition(paintSurface).X, Mouse.GetPosition(paintSurface).Y);
            Canvas.SetTop(myEllipse, p.Y - 5);
            Canvas.SetLeft(myEllipse, p.X - 5);
            paintSurface.Children.Add(myEllipse);
            figura.pointList.Add(p);
        }

        private void checkPeakCount()
        {
            if (figura is Okrag && figura.pointList.Count < 2)
                addPoint();
            else if (figura is Trojkat && figura.pointList.Count < 3)
                addPoint();
            else if (figura is Czworokat && figura.pointList.Count < 4)
                addPoint();
            else if (figura is Dowolne)
                addPoint();
        }

        private void Canvas_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (figura is null)
                MessageBox.Show("Wybierz figurę!.");
            else
            {
                checkPeakCount();
            }
        }

        #region malowanie figury
        private void drawShape_Click(object sender, RoutedEventArgs e)
        {
            if (figura is Okrag okrag && figura.pointList.Count == 2)
            {
                double length = Math.Sqrt(Math.Pow(okrag.pointList[1].X - okrag.pointList[0].X, 2) + Math.Pow(okrag.pointList[1].Y - okrag.pointList[0].Y, 2));
                Ellipse circle = new Ellipse();
                circle.StrokeThickness = 2;
                circle.Stroke = Brushes.Black;
                circle.Width = length * 2;
                circle.Height = length * 2;
                Canvas.SetTop(circle, okrag.pointList[0].Y - length);
                Canvas.SetLeft(circle, okrag.pointList[0].X - length);
                paintSurface.Children.Add(circle);

                areaBox.Text = okrag.Area().ToString();
                circumferenceBox.Text = okrag.Circumference().ToString();

            }
            else if (figura is Trojkat trojkat && figura.pointList.Count == 3)
            {
                Polygon pol = new Polygon();
                pol.StrokeThickness = 2;
                pol.Stroke = Brushes.Black;
                pol.Points = new PointCollection(trojkat.pointList);
                paintSurface.Children.Add(pol);

                areaBox.Text = trojkat.Area().ToString();
                circumferenceBox.Text = trojkat.Circumference().ToString();

            }
            else if (figura is Czworokat czworokat && figura.pointList.Count == 4)
            {
                czworokat.OrderPoints();
                Polygon pol = new Polygon();
                pol.StrokeThickness = 2;
                pol.Stroke = Brushes.Black;
                pol.Points = new PointCollection(czworokat.pointList);
                paintSurface.Children.Add(pol);
                
                areaBox.Text = czworokat.Area().ToString();
                circumferenceBox.Text = czworokat.Circumference().ToString();

            }
            else if (figura is Dowolne dowolna && figura.pointList.Count > 2)
            {
                dowolna.OrderPoints();
                Polygon pol = new Polygon();
                pol.StrokeThickness = 2;
                pol.Stroke = Brushes.Black;
                pol.Points = new PointCollection(dowolna.pointList);
                paintSurface.Children.Add(pol);

                areaBox.Text = dowolna.Area().ToString();
                circumferenceBox.Text = dowolna.Circumference().ToString();
            }
            else
            {
                MessageBox.Show("Wybierz figurę do namalowania lub zaznacz odowiednią liczbę punktów dla danej figury.");
            }
        }
        #endregion

        private void delateShape_Click(object sender, RoutedEventArgs e)
        {
            paintSurface.Children.Clear();
            checkExist(figura);
        }

        #region tworzenie IShape podczas wyboru figury
        Ksztalt figura;
        private void checkExist(Ksztalt s)
        {
            switch (s)
            {
                case null:
                    break;
                default:
                    s.Dispose();
                    break;
            }
        }

        private void rOkrag_Checked(object sender, RoutedEventArgs e)
        {
            checkExist(figura);
            figura = new Okrag();
        }

        private void rTrojkat_Checked(object sender, RoutedEventArgs e)
        {
            checkExist(figura);
            figura = new Trojkat();
        }

        private void rCzworokat_Checked(object sender, RoutedEventArgs e)
        {
            checkExist(figura);
            figura = new Czworokat();
        }

        private void rDowolny_Checked(object sender, RoutedEventArgs e)
        {
            checkExist(figura);
            figura = new Dowolne();
        }
        #endregion

        private void AreaBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
