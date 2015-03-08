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
using System.IO;
using WMPLib;

namespace Avengers_Rush
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {
        string s = "skyyy.jpg";
        string r = "man1.png";
        public MainWindow()
        {
            InitializeComponent();
        }
        System.Media.SoundPlayer player = new System.Media.SoundPlayer();

        private void GameStart(object sender, RoutedEventArgs e)
        {
            player.Stop();
            GameWindow gw = new GameWindow(s, r);

            this.Close();
            gw.Show();





        }

        private void EnterStore(object sender, RoutedEventArgs e)
        {
            StoreWindow sw = new StoreWindow();
            this.Close();
            sw.Show();
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var path = System.IO.Path.Combine(
              System.IO.Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath)
             , "主畫面final.wav");
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(path);

            //player.Stream = Properties.Resources.主畫面_final;
            try
            {
                //player.Load(); 
                player.PlayLooping();
            }
            catch (System.IO.FileNotFoundException err)
            {
                MessageBox.Show("找不到音效檔" + err.FileName);
            }
            catch (InvalidOperationException err)
            {
                MessageBox.Show("播放發生錯誤：" + err.Message);
            }


        }

        private void Option(object sender, RoutedEventArgs e)
        {
            OptionWindow ow = new OptionWindow();
            ow.Owner = this;


            ow.ShowDialog();
            this.Hide();

            if (ow.DialogResult == true)
            {
                s = ow.place;
                r = ow.role;
            }
            this.Show();


        }

        private void count(object sender, RoutedEventArgs e)
        {
            Statistics haha = new Statistics();
            this.Close();
            haha.Show();

        }
    }
}
