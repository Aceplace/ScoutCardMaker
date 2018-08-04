using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OffensiveFormation
{
    /// <summary>
    /// Holds location data for a player that has been placed by the formation.
    /// </summary>
    public class PlacedPlayer
    {
        public Location Location { get; set; } = new Location();

        public PlacedPlayer(int x, int y)
        {
            Location.X = x;
            Location.Y = y;
        }

        public PlacedPlayer()
        {

        }

        public void SetLocation(int x, int y)
        {
            Location.X = x;
            Location.Y = y;
        }
    }
}
