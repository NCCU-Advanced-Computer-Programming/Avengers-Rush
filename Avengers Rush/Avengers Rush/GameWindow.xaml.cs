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
using System.Windows.Shapes;
using System.Windows.Threading;
using WMPLib;

namespace Avengers_Rush
{
    
    

    
    /// <summary>
    /// GameWindow.xaml 的互動邏輯
    /// </summary>
    public partial class GameWindow : Window
    {

        internal DispatcherTimer timer = new DispatcherTimer();
        internal DispatcherTimer money = new DispatcherTimer();
        int time = 0, distance = 0, difficulty = 0; 
        //int bossPosition;
        System.Windows.Media.MediaPlayer player = new System.Windows.Media.MediaPlayer();
        string place;
        //string role;

        public GameWindow(string s,string r)
        {
            InitializeComponent();
            BitmapImage bi3 = new BitmapImage();
            bi3.BeginInit();
            //bi3.UriSource = new Uri("man1.png", UriKind.Relative);
            bi3.UriSource = new Uri(s, UriKind.Relative);
            bi3.EndInit();
            background.Stretch = Stretch.Fill;
            /*background.Source = "man1.png";*/background.Source = bi3;
            if (s == "universal.jpg")
                distanceLabel.Foreground = Brushes.White;
            place = s;

            BitmapImage bi4 = new BitmapImage();
            bi4.BeginInit();
            bi4.UriSource = new Uri(r, UriKind.Relative);
            bi4.EndInit();
            image.Stretch = Stretch.Fill;
            /*background.Source = "man1.png";*/
            image.Source = bi4;

            timer.Tick += new EventHandler(timer1_Tick);
            timer.Interval = new TimeSpan(100000);

            money.Tick += new EventHandler(money_Tick);
            money.Interval = new TimeSpan(10000000);

        }
        int total = 0;
        private void money_Tick(object sender, EventArgs e)
        {

            distance++;

            distanceLabel.Content = "Time: " + distance.ToString();
            
            Image myImage3 = new Image();
            Random r = new Random(Guid.NewGuid().GetHashCode());

            //if (distance < 40 || distance >= 70)
                difficulty++;
            if (r.Next() % 1000 > 800 - difficulty * 30 )//else if (r.Next() % 1000 > 800 - difficulty * 30 && (distance < 35 || distance >= 70))
            {

                BitmapImage bi3 = new BitmapImage();
                bi3.BeginInit();
                switch (r.Next() % 3)
                    {
                        case 0:
                            bi3.UriSource = new Uri("Resources/meteor1.png", UriKind.Relative);
                            myImage3.Width = 155;
                            myImage3.Height = 155;
                            break;
                        case 1:
                            bi3.UriSource = new Uri("Resources/meteor2.png", UriKind.Relative);
                            myImage3.Width = 156;
                            myImage3.Height = 155;
                            break;
                        case 2:
                            bi3.UriSource = new Uri("Resources/meteor3.png", UriKind.Relative);
                            myImage3.Width = 156;
                            myImage3.Height = 165;
                            break;
                        /*case 3:
                            bi3.UriSource = new Uri("180px-151Mew.png", UriKind.Relative);
                            myImage3.Width = 151;
                            myImage3.Height = 155;
                            break;
                        case 4:
                            bi3.UriSource = new Uri("180px-201Unown.png", UriKind.Relative);
                            myImage3.Width = 155;
                            myImage3.Height = 155;
                            break;*/
                        default:
                            MessageBox.Show("ERROR");
                            break;
                    }
                bi3.Rotation = Rotation.Rotate90;
                bi3.EndInit();
                myImage3.Stretch = Stretch.Fill;
                myImage3.Source = bi3;
                
                Canvas.SetLeft(myImage3, 700);
                Canvas.SetTop(myImage3, r.Next() % 3 * 220 + 50);




                player.Pause();
                canvas.Children.Add(myImage3);

                player.Play();

                total++;
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {


            time++;
            background.Margin = new Thickness(background.Margin.Left - 0.5, background.Margin.Top, 0, 0);
            for (int i = 2; i < total + 2; i++)
            {

                /*if (distance < 40 || distance >= 70)
                {*/
                    //Canvas.SetTop(canvas.Children[i], Canvas.GetTop(canvas.Children[i]) - 6 + difficulty / 7);
                    Canvas.SetLeft(canvas.Children[i], Canvas.GetLeft(canvas.Children[i]) -3 - difficulty / 7);
                




                    if (Canvas.GetLeft(image) + 70 > Canvas.GetLeft(canvas.Children[i]) && Canvas.GetLeft(canvas.Children[i]) > 30)
                        if ((Canvas.GetTop(image) + image.Height >= Canvas.GetTop(canvas.Children[i]) && Canvas.GetTop(image) + image.Height <= Canvas.GetTop(canvas.Children[i]) + 155) || (Canvas.GetTop(image) >= Canvas.GetTop(canvas.Children[i]) && Canvas.GetTop(image) <= Canvas.GetTop(canvas.Children[i]) + 155))
                        {
                            player.Stop();
                            money.Stop();
                            timer.Stop();
                            MessageBox.Show("飛行時間：" + distance + "秒");

                            MainWindow mw = new MainWindow();
                            this.Close();
                            mw.Show();

                        }
                }




        }



        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {


            if (e.Key.Equals(Key.Left))
            {
                if (Canvas.GetTop(image) >= 100)
                Canvas.SetTop(image, Canvas.GetTop(image) - 220);

            }
            else if (e.Key.Equals(Key.Right))
            {
                if (Canvas.GetTop(image) < 450)
                Canvas.SetTop(image, Canvas.GetTop(image) + 220);

            }
            }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
            player.Open(new Uri("18.wav", UriKind.Relative));
            player.Play();

            timer.Start();
            money.Start();
        }
    }
    
}

