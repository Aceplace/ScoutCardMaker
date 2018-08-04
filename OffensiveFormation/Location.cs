using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OffensiveFormation
{
    public class Location
    {
        public int x { get; set; }
        public int y { get; set; }

        public Location()
        {
            x = 0;
            y = 0;
        }

        public Location(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Location otherLocation = (Location)obj;
            return x == otherLocation.x && y == otherLocation.y;
        }

        public static bool operator ==(Location location1, Location location2)
        {
            if (location1 is null)
            {
                return location2 is null;
            }
            return location1.Equals(location2);
        }

        public static bool operator !=(Location location1, Location location2)
        {
            if (location1 is null)
            {
                return !(location2 is null);
            }
            return !location1.Equals(location2);
        }
    }
}
