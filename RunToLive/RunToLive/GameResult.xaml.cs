/*
Contributors: Selin

*/
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
using System.Windows.Shapes;

namespace RunToLive
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class GameResults : Window
    {
        public GameResults(bool isDead,int[] stats,int totalPeople, int vaccinateDay, int superHuman)
        {
            
            InitializeComponent();
            if (isDead)
            {
                score.Content = "You Have Lost The Game!";
                score.Foreground = Brushes.Red;
                info_text.Text = "You have died before the infection has lost its effect.";
            }
            else
            {
                score.Content = "You Have Won The Game!";
                score.Foreground = Brushes.Green;
                info_text.Text = "You have survived since the infection has lost its effect\r\nVirus has been destroyed.";
            }
            stats_text.Text = "Percentage of people died:\r\n" +
                              "Number of people vaccinated:\r\n" +
                              "You survive in day:\r\n";

            stats_number.Text = (int)(((float)stats[3] / (float)totalPeople) * 100) + "\r\n" +
                                (stats[4]-superHuman) + "\r\n" +
                                (stats[5]) + "\r\n";

        }


        private void return_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow m = new MainWindow();
            m.Show();
        }

        private void txt_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
