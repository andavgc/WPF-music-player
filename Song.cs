using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WPF_music_player
{
    public class Song
    {
        private string name;
        private string duration;

        public string Name { get => name; set => name = value; }  

        public string Duration { get => duration; set => duration = value; } 

         public Song(string name, string duration) => 
                (this.name, this.duration) = (name,duration);
    }
}