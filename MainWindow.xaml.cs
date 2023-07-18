using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Animation;
using Microsoft.Win32;
using System.Windows.Threading;

namespace WPF_music_player
{
    public partial class MainWindow : Window
    {
        private MediaPlayer mediaPlayer = new MediaPlayer();
        public SongList songList;

        
        public MainWindow()
        {   
            try
            {
                InitializeComponent();
                songList = Open_File();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex}");
            }
            
            
			DispatcherTimer timer = new DispatcherTimer();
			timer.Interval = TimeSpan.FromSeconds(1);
			timer.Tick += timer_Tick;
			timer.Start();
            
            // TODO criar o movimento da bola que representa a duração
            StartMovingAnimation(); 
        }

        private void btnOpenAudioFile_Click(object sender, RoutedEventArgs e)
		{
            songList = Open_File();
        }

        private SongList Open_File()
		{
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "MP3 files (*.mp3)|*.mp3|All files (*.*)|*.*";
                string fileName;

                if(openFileDialog.ShowDialog() == true)
                {
                    
                    songList = OpenSong(openFileDialog.FileName);

                    try 
                    {
                        BitmapImage bitmapImage = new BitmapImage(); //Define the image if it is one
                        bitmapImage.BeginInit();
                        bitmapImage.UriSource = new Uri(openFileDialog.FileName);
                        bitmapImage.EndInit();
                        songCover.Source = bitmapImage;
                        
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                    DispatcherTimer timer = new DispatcherTimer();
                    timer.Interval = TimeSpan.FromSeconds(1);
                    timer.Tick += timer_Tick;
                    timer.Start();

                    return songList;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex}");
            }

            return new SongList("", mediaPlayer);
            
		}

        private SongList OpenSong(string path)
        {
            mediaPlayer.Open(new Uri(path));
            SongList songList = new SongList(path, mediaPlayer);
            int index = songList.CurrentIndex;
            Song song = songList.CurrentSong;

            SongName.Content = song.Name;

            mediaPlayer.Play();
            btnPlay.Visibility = Visibility.Collapsed;
            btnPause.Visibility = Visibility.Visible;

            return songList;
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

        private string[] songs;
        private int currentIndex;
        private void NextSong(object sender, RoutedEventArgs e)
        {   
            try
            {
                songs = songList.Songs;
                
                if (songs == null || songs.Length == 0)
                    return;

                songList.CurrentIndex++;
                if (songList.CurrentIndex >= songs.Length)
                    songList.CurrentIndex = 0;
                
                string filePath = songs[songList.CurrentIndex];
                
                songList = OpenSong(filePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex}");
            }
        }

        private void PreviousSong(object sender, RoutedEventArgs e)
        {   
            try
            {
                
                songs = songList.Songs;
                
                if (songs == null || songs.Length == 0)
                    return;

                songList.CurrentIndex--;

                if (songList.CurrentIndex < 0)
                    songList.CurrentIndex = songs.Length-1;

                
                string filePath = songs[songList.CurrentIndex];
                songList = OpenSong(filePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex}");
            }
        }
        
        private void ChangeVolume(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            mediaPlayer.Volume = volumeSlider.Value;
        }
        
        private void StartMovingAnimation() {
            
            try 
            {
                DoubleAnimation animationX = new DoubleAnimation();
                animationX.Duration = TimeSpan.Parse(songList.CurrentSong.Duration);  // Duração da animação em segundos
                //animationX.From = Canvas.GetLeft(TimeLapse);     // Valor inicial da coordenada X
                animationX.To = 300;
            }
            catch (Exception ex) 
            {
                MessageBox.Show($"{ex}");
            }
        }
    }
}
