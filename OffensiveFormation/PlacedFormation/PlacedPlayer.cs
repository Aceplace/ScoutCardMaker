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
        public Location location { get; set; } = new Location();

        public PlacedPlayer(int x, int y)
        {
            location.x = x;
            location.y = y;
        }

        public PlacedPlayer()
        {

        }

        public void SetLocation(int x, int y)
        {
            location.x = x;
            location.y = y;
        }
    }
}
