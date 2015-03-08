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

namespace Avengers_Rush
{
    /// <summary>
    /// OptionWindow.xaml 的互動邏輯
    /// </summary>
    public partial class OptionWindow : Window
    {

        public string place;
        public string role;
        public OptionWindow()
        {
            InitializeComponent();


        }

        private void Confirm(object sender, RoutedEventArgs e)
        {

        

            if (sky.IsChecked == true)
                place = "skyyy.jpg";

            else if (universe.IsChecked == true)
                place = "universal.jpg";
            else if (grass.IsChecked == true)
                place = "grass.jpg";
            else if (dessert.IsChecked == true)
                place = "dessert.jpg";
        
            
            this.DialogResult = true;

            this.Close();




        }

        
        private void captain_America_Click(object sender, RoutedEventArgs e)
        {
            role = "man1.png";
        }

        private void Iron_Man_Click(object sender, RoutedEventArgs e)
        {
            role = "man2.png";
        }

        private void Hawkeye_Click(object sender, RoutedEventArgs e)
        {
            role = "man3.png";
        }

        private void BlackWidow_Click(object sender, RoutedEventArgs e)
        {
            role = "man4.png";
        }

        private void Hulk_Click(object sender, RoutedEventArgs e)
        {
            role = "man5.png";
        }

        private void Thor_Click(object sender, RoutedEventArgs e)
        {
            role = "man6.png";
        }

        private void Loki_Click(object sender, RoutedEventArgs e)
        {
            role = "man7.png";
        }


    }
}
