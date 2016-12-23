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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfControl
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        Point position;
        bool isAnimBegin;
        RotateTransform rt, rt1;
        ThicknessAnimation tAn;
        public UserControl1()
        {
            InitializeComponent();
            isAnimBegin = false;
        }

        private void stopAnimations()
        {
            isAnimBegin = true;
            try
            {
                //Stop animations to modify size and location of the circle 
                rt.BeginAnimation(RotateTransform.AngleProperty, null);
                rt1.BeginAnimation(RotateTransform.AngleProperty, null);
                grid.BeginAnimation(Grid.MarginProperty, null);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void Grid_MouseMove(object sender, MouseEventArgs e)
        {
            double x = e.GetPosition(null).X - grid.Margin.Left - (grid.Width)/2;
            double y = grid.Margin.Top - e.GetPosition(null).Y + (grid.Height)/2;
            Console.WriteLine("X" + x);
            Console.WriteLine("Y" + y);
            if (x < 0)
            {
                if (y > 0)
                {
                    wrapperGrid.Cursor = Cursors.ScrollNW;
                    head.Fill = null;
                    head.Fill = Brushes.Black;
                }
                else if (y < 0)
                {
                    wrapperGrid.Cursor = Cursors.ScrollSW;
                    ImageBrush myBrush = new ImageBrush();
                    myBrush.ImageSource = new BitmapImage(new Uri("C:/Users/Nuri/Desktop/proje/RunToLive//WpfControl/WpfControl/WpfControl/icon/face.png"));
                    head.Fill = myBrush;
                }
                else
                {
                    wrapperGrid.Cursor = Cursors.ScrollW;
                    head.Fill = null;
                    head.Fill = Brushes.Black;
                }
            
            }
            else if (x > 0)
            {
                if (y > 0)
                {
                    wrapperGrid.Cursor = Cursors.ScrollNE;
                    head.Fill = null;
                    head.Fill = Brushes.Black;
                }
                else if (y < 0)
                {
                    wrapperGrid.Cursor = Cursors.ScrollSE;
                    ImageBrush myBrush = new ImageBrush();
                    myBrush.ImageSource = new BitmapImage(new Uri("C:/Users/Nuri/Desktop/proje/RunToLive//WpfControl/WpfControl/WpfControl/icon/face.png"));
                    head.Fill = myBrush;
                }
                else
                {
                    wrapperGrid.Cursor = Cursors.ScrollE;
                    head.Fill = null;
                    head.Fill = Brushes.Black;
                }
              
            }
            else if (x == 0 && y == 0)
            {
                wrapperGrid.Cursor = Cursors.ScrollAll;
                head.Fill = null;
                head.Fill = Brushes.Black;
            }
            else
            {
                if (y > 0)
                {
                    wrapperGrid.Cursor = Cursors.ScrollN;
                    head.Fill = null;
                    head.Fill = Brushes.Black;
                }
                else
                {
                    wrapperGrid.Cursor = Cursors.ScrollS;
                    head.Fill = null;
                    head.Fill = Brushes.Black;
                }
            }
        }

    

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (isAnimBegin)
            {
                stopAnimations();
            }
        

            position = e.GetPosition(null);
            var da = new DoubleAnimation(-34, 41, new Duration(new TimeSpan(0, 0, 1)));
            rt = new RotateTransform();
            rightArm.RenderTransform = rt;
            rightArm.RenderTransformOrigin = new Point(0.5, 0);

            leftLeg.RenderTransform = rt;
            leftLeg.RenderTransformOrigin = new Point(0.5, 0);


            da.AutoReverse = true;
            da.RepeatBehavior = new RepeatBehavior(2);
            rt.BeginAnimation(RotateTransform.AngleProperty, da);


            var da1 = new DoubleAnimation(41, -34, new Duration(new TimeSpan(0, 0, 1)));
            rt1 = new RotateTransform();
            leftArm.RenderTransform = rt1;
            leftArm.RenderTransformOrigin = new Point(0.5, 0);

            rigthLeg.RenderTransform = rt1;
            rigthLeg.RenderTransformOrigin = new Point(0.5, 0);


            da1.AutoReverse = true;
            da1.RepeatBehavior = new RepeatBehavior(2);
            rt1.BeginAnimation(RotateTransform.AngleProperty, da1);

            tAn = new ThicknessAnimation(grid.Margin, new Thickness(position.X, position.Y, 0, 0), new Duration(new TimeSpan(0, 0, 4)));
            grid.BeginAnimation(Grid.MarginProperty, tAn);




        }
    }
}


