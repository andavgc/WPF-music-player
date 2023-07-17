using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace WPF_music_player
{
    public class SongList
    {
        private string[]? songs;
        private int currentIndex;

        private Song currentSong;
        string songDuration;

        public string[]? Songs { get => songs; set => songs = value; }
        public int CurrentIndex { get => currentIndex; set => currentIndex = value; }
        public Song CurrentSong { get => currentSong; set => currentSong = value; }

        
        public SongList(string filePath, MediaPlayer mediaPlayer) 
        {
            
            
            string? directoryPath = Path.GetDirectoryName(filePath);
            string title = System.IO.Path.GetFileName(filePath);

            if (directoryPath != null)
            {
                this.Songs = Directory.GetFiles(directoryPath, "*.mp3");
                currentIndex = Array.IndexOf(this.Songs, filePath);
            }

            var task = WaitForDuration(mediaPlayer);

            if (mediaPlayer.NaturalDuration.HasTimeSpan)
            {
            songDuration = mediaPlayer.NaturalDuration.TimeSpan.ToString((@"mm\:ss")) ?? "00:00";
            }
            else 
            {
                songDuration = "00:00";
            }

            currentSong = new Song(title, songDuration);
        }
        
        private async Task WaitForDuration(MediaPlayer mediaPlayer)
        {
            while (!mediaPlayer.NaturalDuration.HasTimeSpan || mediaPlayer.NaturalDuration.TimeSpan == TimeSpan.Zero)
            {
                await Task.Delay(1000);

                if (mediaPlayer.NaturalDuration.HasTimeSpan && mediaPlayer.NaturalDuration.TimeSpan != TimeSpan.Zero)
                {
                    break;
                }
            }

        }
    }
}