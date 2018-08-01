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
        public Location PlacedLocation { get; set; } = new Location();

        public PlacedPlayer(int xPosition, int yPosition)
        {
            PlacedLocation.XPosition = xPosition;
            PlacedLocation.YPosition = yPosition;
        }

        public PlacedPlayer()
        {

        }

        public void SetLocation(int xPosition, int yPosition)
        {
            PlacedLocation.XPosition = xPosition;
            PlacedLocation.YPosition = yPosition;
        }
    }
}
