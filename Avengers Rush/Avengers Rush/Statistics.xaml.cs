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
using Avengers_Rush.Properties;
namespace Avengers_Rush
{
    /// <summary>
    /// Statistics.xaml 的互動邏輯
    /// </summary>
    public partial class Statistics : Window
    {
        public string distance;
        public Statistics()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
