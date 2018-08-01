using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OffensiveFormation.PlacementRules
{
    public class OnLineOfScrimmage : IPlacementRule
    {
        public PlacedPlayer Place(PlacedPlayer placedPlayer)
        {
            return new PlacedPlayer(placedPlayer.PlacedLocation.XPosition, 0);
        }
    }
}
