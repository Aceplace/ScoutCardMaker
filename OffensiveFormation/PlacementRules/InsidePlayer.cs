using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OffensiveFormation.PlacementRules
{
    public class InsidePlayer : IPlacementRule
    {
        private PlacedPlayer _PlayerInside;
        private int _DistanceInside;

        public InsidePlayer(PlacedPlayer playerInside, int distanceInside)
        {
            _PlayerInside = playerInside;
            _DistanceInside = distanceInside;
        }

        public PlacedPlayer Place(PlacedPlayer placedPlayer)
        {
            if (_DistanceInside == 0)
            {
                throw new PlacementException("Can't place 0 units inside.");
            }
            if (_DistanceInside < 0)
            {
                throw new PlacementException("Can't place player negative distance inside player.");
            }

            if (_PlayerInside.PlacedLocation.XPosition > 0)
            {
                return new PlacedPlayer(
                    _PlayerInside.PlacedLocation.XPosition - _DistanceInside,
                    placedPlayer.PlacedLocation.YPosition
                    );
            }
            else if (_PlayerInside.PlacedLocation.XPosition < 0)
            {
                return new PlacedPlayer(
                    _PlayerInside.PlacedLocation.XPosition + _DistanceInside,
                    placedPlayer.PlacedLocation.YPosition
                    );
            }
            else
            {
                throw new PlacementException("Can't place player inside another player who is in center of formation.");
            }
        }
    }
}
