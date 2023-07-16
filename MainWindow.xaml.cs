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
using System.Windows.Media.Animation;
using Microsoft.Win32;
using System.Windows.Threading;
using TagLib;
using System.IO;
using System.Windows.Media.Imaging;
using NAudio;
using NAudio.FileFormats;
using NAudio.FileFormats.Mp3;
using NAudio.Wave;


namespace WPF_music_player
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MediaPlayer mediaPlayer = new MediaPlayer();
        
        public MainWindow()
        {
            InitializeComponent();
            
            Open_File();
            
			DispatcherTimer timer = new DispatcherTimer();
			timer.Interval = TimeSpan.FromSeconds(1);
			timer.Tick += timer_Tick;
			timer.Start();
            //TODO criar o movimento da bola que representa a duração
            // StartMovingAnimation(); 
        }

        private void btnOpenAudioFile_Click(object sender, RoutedEventArgs e)
		{
            Open_File();
        }

        private void Open_File()
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.Filter = "MP3 files (*.mp3)|*.mp3|All files (*.*)|*.*";
            
			if(openFileDialog.ShowDialog() == true)

                try 
                {
                    mediaPlayer.Open(new Uri(openFileDialog.FileName));
                    BitmapImage bitmapImage = new BitmapImage();
                    bitmapImage.BeginInit();
                    bitmapImage.UriSource = new Uri(openFileDialog.FileName);
                    bitmapImage.EndInit();
                    songCover.Source = bitmapImage;
                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            
			mediaPlayer.Play();
            btnPlay.Visibility = Visibility.Collapsed;
            btnPause.Visibility = Visibility.Visible;

			DispatcherTimer timer = new DispatcherTimer();
			timer.Interval = TimeSpan.FromSeconds(1);
			timer.Tick += timer_Tick;
			timer.Start();
		}

        void timer_Tick(object sender, EventArgs e)
		{
			if(mediaPlayer.Source != null)
            {
                lblStatus.Content = String.Format("{0}", mediaPlayer.Position.ToString(@"mm\:ss"));
                lblDuration.Content = String.Format("{0}", mediaPlayer.NaturalDuration.TimeSpan.ToString(@"mm\:ss"));
            }
            else 
            {
                lblStatus.Content = "00:00";
            }
				
		}

        private void PlaySound(object sender, RoutedEventArgs e)
        {

            mediaPlayer.Play();
            btnPlay.Visibility = Visibility.Collapsed;
            btnPause.Visibility = Visibility.Visible;
        }

        private void StopSound(object sender, RoutedEventArgs e)
        {
            mediaPlayer.Pause();
            btnPlay.Visibility = Visibility.Visible;
            btnPause.Visibility = Visibility.Collapsed;
        }
    
        private void StartMovingAnimation() {

            DoubleAnimation animationX = new DoubleAnimation
            {
                From = 0,
                To = 200, // Punto final X
                Duration = TimeSpan.FromSeconds(5), // Duración de la animación en segundos
                FillBehavior = FillBehavior.Stop // Detiene la animación en su posición final
            };

            Storyboard.SetTarget(animationX, timeLapse);
            Storyboard.SetTargetProperty(animationX, new PropertyPath("(Grid.Margin).(Thickness.Left)"));


            Storyboard storyboard = new Storyboard();
            storyboard.Children.Add(animationX);

            storyboard.Begin();

        }

    }
}
