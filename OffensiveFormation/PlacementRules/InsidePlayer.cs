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

            if (_PlayerInside.Location.X > 0)
            {
                return new PlacedPlayer(
                    _PlayerInside.Location.X - _DistanceInside,
                    placedPlayer.Location.Y
                    );
            }
            else if (_PlayerInside.Location.X < 0)
            {
                return new PlacedPlayer(
                    _PlayerInside.Location.X + _DistanceInside,
                    placedPlayer.Location.Y
                    );
            }
            else
            {
                throw new PlacementException("Can't place player inside another player who is in center of formation.");
            }
        }
    }
}
