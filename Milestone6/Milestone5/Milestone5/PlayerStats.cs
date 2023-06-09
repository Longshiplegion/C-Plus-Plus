using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milestone5
{
   public class PlayerStats
    {
        public string Initials { get; set; }
        public string Difficulty { get; set; }
        public TimeSpan ElapsedTime { get; set; }

        public PlayerStats(string initials, string difficulty, TimeSpan elapsedTime)
        {
            Initials = initials;
            Difficulty = difficulty;
            ElapsedTime = elapsedTime;
        }

        public int CompareTo(PlayerStats other)
        {
            // Compare elapsed times for sorting
            return ElapsedTime.CompareTo(other.ElapsedTime);
        }
        public string DisplayString
        {
           get{ return $"{Initials} - {Difficulty} - {ElapsedTime}"; }
        }
    }
}
