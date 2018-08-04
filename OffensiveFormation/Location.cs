using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OffensiveFormation
{
    public class Location
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Location()
        {
            X = 0;
            Y = 0;
        }

        public Location(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Location otherLocation = (Location)obj;
            return X == otherLocation.X && Y == otherLocation.Y;
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
