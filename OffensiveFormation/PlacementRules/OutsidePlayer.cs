using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OffensiveFormation.PlacementRules
{
    public class OutsidePlayer : IPlacementRule
    {
        private PlacedPlayer _PlayerOutside;
        private int _DistanceOutside;

        public OutsidePlayer(PlacedPlayer playerOutside, int distanceOutside)
        {
            _PlayerOutside = playerOutside;
            _DistanceOutside = distanceOutside;
        }

        public PlacedPlayer Place(PlacedPlayer placedPlayer)
        {
            if (_DistanceOutside == 0)
            {
                throw new PlacementException("Can't place 0 units outside.");
            }
            if (_DistanceOutside < 0)
            {
                throw new PlacementException("Can't place player negative distance outside player.");
            }

            if (_PlayerOutside.PlacedLocation.XPosition > 0)
            {
                return new PlacedPlayer(
                    _PlayerOutside.PlacedLocation.XPosition + _DistanceOutside, 
                    placedPlayer.PlacedLocation.YPosition
                    );
            }
            else if (_PlayerOutside.PlacedLocation.XPosition < 0)
            {
                return new PlacedPlayer(
                    _PlayerOutside.PlacedLocation.XPosition - _DistanceOutside,
                    placedPlayer.PlacedLocation.YPosition
                    );
            }
            else
            {
                throw new PlacementException("Can't place player outside another player who is in center of formation.");
            }
        }
    }
}
