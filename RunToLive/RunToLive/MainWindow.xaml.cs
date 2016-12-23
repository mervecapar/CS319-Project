/*
Contributors: Selin, Merve

*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

namespace RunToLive
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

        private void Game_Click(object sender, RoutedEventArgs e)
        {
            Settings s = new Settings();
            s.Show();
            this.Close();
        }
        private void Credits_Click(object sender, RoutedEventArgs e)
        {
            TextViewer cr = new TextViewer();
            cr.setTitle("Credits");
            cr.Title = "Credits";
            cr.setText("Contributers : \n Merve Çapar \n Mehmet Nuri Yumuşak \n Ege Yosunkaya \n Selin Özdaş");
            cr.Show();
            this.Close();
            
        }

        private void Help_Click(object sender, RoutedEventArgs e)
        {
            TextViewer cr = new TextViewer();
            cr.Title = "Help";
            cr.setTitle("Help");
            //reads file and converts it to string format

            string text = System.IO.File.ReadAllText(@"C:\Users\\Nuri\Desktop\proje\RunToLive\RunToLive\items\Help.txt");
            cr.setText(text);
            cr.Show();
            this.Close();

        }
 
    }
}
