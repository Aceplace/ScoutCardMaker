using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OffensiveFormation.PlacementRules
{
    public class OutsidePlayer : IPlacementRule
    {
        private PlacedPlayer _playerOutside;
        private int _distanceOutside;

        public OutsidePlayer(PlacedPlayer playerOutside, int distanceOutside)
        {
            _playerOutside = playerOutside;
            _distanceOutside = distanceOutside;
        }

        public PlacedPlayer Place(PlacedPlayer placedPlayer)
        {
            if (_distanceOutside == 0)
            {
                throw new PlacementException("Can't place 0 units outside.");
            }
            if (_distanceOutside < 0)
            {
                throw new PlacementException("Can't place player negative distance outside player.");
            }

            if (_playerOutside.location.x > 0)
            {
                return new PlacedPlayer(
                    _playerOutside.location.x + _distanceOutside, 
                    placedPlayer.location.y
                    );
            }
            else if (_playerOutside.location.x < 0)
            {
                return new PlacedPlayer(
                    _playerOutside.location.x - _distanceOutside,
                    placedPlayer.location.y
                    );
            }
            else
            {
                throw new PlacementException("Can't place player outside another player who is in center of formation.");
            }
        }
    }
}
