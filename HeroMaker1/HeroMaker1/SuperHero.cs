using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace HeroMaker1
{
    public class SuperHero
    {
        public string Name { get; set; }
        public List<string> Powers { get; set; }
        public string OfficeLocation { get; set; }
        public string PreferredTransportation { get; set; }
        public int Speed { get; set; }
        public int Stamina { get; set; }
        public int Strength { get; set; }
        public DateTime Birthday { get; set; }
        public DateTime SuperpowerDiscoveryDate { get; set; }
        public DateTime FatefulDate { get; set; }
        public int YearsOfExperience { get; set; }
        public Color CapeColor { get; set; }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Name: {Name}");
            sb.AppendLine($"Powers: {string.Join(", ", Powers)}");
            sb.AppendLine($"Office Locations: {string.Join(", ", OfficeLocation)}");
            sb.AppendLine($"Preferred Transportation: {PreferredTransportation}");
            sb.AppendLine($"Strength: {Strength}");
            sb.AppendLine($"Speed: {Speed}");
            sb.AppendLine($"Stamina: {Stamina}");
            sb.AppendLine($"Birthday: {Birthday.ToShortDateString()}");
            sb.AppendLine($"Superpower Discovery: {SuperpowerDiscoveryDate.ToShortDateString()}");
            sb.AppendLine($"Fateful Date: {FatefulDate.ToShortDateString()}");
            sb.AppendLine($"Years of Experience: {YearsOfExperience}");
            

            return sb.ToString();
        }
    }

}
