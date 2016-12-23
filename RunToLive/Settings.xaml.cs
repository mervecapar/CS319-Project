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
using System.IO;

namespace RunToLive
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Settings : Window
    {
        private bool isSoundOn = true;
        private int gameLevel = 2;
        private bool isMale = true;
        int[] lines = new int[2];
        System.Media.SoundPlayer player = new System.Media.SoundPlayer();

        public Settings()
        {
            InitializeComponent();
        }

        private void Soundoff_Checked(object sender, RoutedEventArgs e)
        {
            isSoundOn = false;
        }

        private void Easy_Checked(object sender, RoutedEventArgs e)
        {
            gameLevel = 1;
        }

        private void Medium_Checked(object sender, RoutedEventArgs e)
        {
            gameLevel = 2;
        }

        private void Hard_Checked(object sender, RoutedEventArgs e)
        {
            gameLevel = 3;
        }

        private void Female_Checked(object sender, RoutedEventArgs e)
        {
            isMale = false;
        }
        private void SoundOn_Checked(object sender, RoutedEventArgs e)
        {
            isSoundOn = true;
        }

        private void Male_Checked(object sender, RoutedEventArgs e)
        {
            isMale = true;
        }

        private void return_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void play_Click(object sender, RoutedEventArgs e)
        {

            PlayGame p = new PlayGame(gameLevel, lines[0], lines[1]);
            p.Show();
            this.Close();
        }
    }
}
