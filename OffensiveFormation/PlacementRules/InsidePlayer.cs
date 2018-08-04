using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OffensiveFormation.PlacementRules
{
    public class InsidePlayer : IPlacementRule
    {
        private PlacedPlayer _playerInside;
        private int _distanceInside;

        public InsidePlayer(PlacedPlayer playerInside, int distanceInside)
        {
            _playerInside = playerInside;
            _distanceInside = distanceInside;
        }

        public PlacedPlayer Place(PlacedPlayer placedPlayer)
        {
            if (_distanceInside == 0)
            {
                throw new PlacementException("Can't place 0 units inside.");
            }
            if (_distanceInside < 0)
            {
                throw new PlacementException("Can't place player negative distance inside player.");
            }

            if (_playerInside.location.x > 0)
            {
                return new PlacedPlayer(
                    _playerInside.location.x - _distanceInside,
                    placedPlayer.location.y
                    );
            }
            else if (_playerInside.location.x < 0)
            {
                return new PlacedPlayer(
                    _playerInside.location.x + _distanceInside,
                    placedPlayer.location.y
                    );
            }
            else
            {
                throw new PlacementException("Can't place player inside another player who is in center of formation.");
            }
        }
    }
}
