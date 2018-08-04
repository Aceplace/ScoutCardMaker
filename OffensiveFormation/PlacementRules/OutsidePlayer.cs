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

            if (_PlayerOutside.Location.X > 0)
            {
                return new PlacedPlayer(
                    _PlayerOutside.Location.X + _DistanceOutside, 
                    placedPlayer.Location.Y
                    );
            }
            else if (_PlayerOutside.Location.X < 0)
            {
                return new PlacedPlayer(
                    _PlayerOutside.Location.X - _DistanceOutside,
                    placedPlayer.Location.Y
                    );
            }
            else
            {
                throw new PlacementException("Can't place player outside another player who is in center of formation.");
            }
        }
    }
}
