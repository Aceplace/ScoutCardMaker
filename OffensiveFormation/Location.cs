using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OffensiveFormation
{
    public class Location
    {
        public int XPosition { get; set; }
        public int YPosition { get; set; }

        public Location()
        {
            XPosition = 0;
            YPosition = 0;
        }

        public Location(int xPosition, int yPosition)
        {
            XPosition = xPosition;
            YPosition = yPosition;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Location otherLocation = (Location)obj;
            return XPosition == otherLocation.XPosition && YPosition == otherLocation.YPosition;
        }

        public static bool operator ==(Location location1, Location location2)
        {
            if (ReferenceEquals(location1, null))
            {
                return ReferenceEquals(location2, null);
            }
            return location1.Equals(location2);
        }

        public static bool operator !=(Location location1, Location location2)
        {
            if (ReferenceEquals(location1, null))
            {
                return !ReferenceEquals(location2, null);
            }
            return !location1.Equals(location2);
        }
    }
}
