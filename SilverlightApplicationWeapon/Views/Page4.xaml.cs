using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Navigation;

namespace SilverlightApplicationWeapon.Views
{
    public partial class Page4 : Page
    {
        
        private Brush red;
        private Brush green;
        private System.Windows.Threading.DispatcherTimer tik_tok;
       
        public Page4()
        {
            InitializeComponent();
            red = new SolidColorBrush(Colors.Red);
            green = new SolidColorBrush(Colors.Green);
            InitTimer();


          
        }

        private void updateBuffer()
        {
            Canvas.SetLeft(playCanvas, player.DownloadProgressOffset * playCanvas.ActualWidth);
            bufferBar.Width = player.DownloadProgress * playCanvas.ActualWidth;
        }

        private void updatePlayBar()
        {
            if (player.NaturalDuration.TimeSpan != TimeSpan.Zero)
            {
                playBar.Width = player.Position.TotalMilliseconds /
                    player.NaturalDuration.TimeSpan.TotalMilliseconds * playCanvas.ActualWidth;

            }
        }

        private void InitTimer()
        {
            tik_tok = new System.Windows.Threading.DispatcherTimer();
            tik_tok.Interval = new TimeSpan(0, 0, 0, 0, 100);
            tik_tok.Tick += new EventHandler(Each_tick);
        }

        private void Each_tick(object sender, EventArgs e)
        {
            time.Text = player.Position.ToString(@"mm\:ss");
            updatePlayBar();
            updateBuffer();


        }

        // Выполняется, когда пользователь переходит на эту страницу.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
           
        }

        private void PlayOrPause_Click(object sender, RoutedEventArgs e)
        {
            if((PlayOrPause.Content.ToString()) == "Play"){
                player.Play();
                if (player.CanPause)
                PlayOrPause.Content = "Pause";

                tik_tok.Start();
            }
            else  {
                player.Pause();
                PlayOrPause.Content = "Play";
                tik_tok.Stop();
            }
            
        }

        private void Stop_Click(object sender, RoutedEventArgs e)
        {
            player.Stop();
            PlayOrPause.Content = "Play";
            tik_tok.Stop();
        }

        private void Mute_Click(object sender, RoutedEventArgs e)
        {
           
            if (player.IsMuted)
            {

                Mute.Background = green;
            }
            else {
               
                Mute.Background = red;
            
            }
            player.IsMuted = !player.IsMuted;
        }

        private void Slider_ValueChanged_1(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
          
        }

        private void playCanvas_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var position = e.GetPosition(playCanvas);
            var relativePosition = position.X / playCanvas.ActualWidth;
            player.Position = new TimeSpan((long)(player.NaturalDuration.TimeSpan.Ticks * relativePosition) );
        }

    

       




    }
}
