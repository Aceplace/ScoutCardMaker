using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OffensiveFormation.PlacementRules
{
    public class ToLeftOf : IPlacementRule
    {
        private PlacedPlayer _PlayerToLeftOf;
        private int _DistanceToLeftOf;

        public ToLeftOf(PlacedPlayer playerToLeftOf, int distanceToLeftOf)
        {
            _PlayerToLeftOf = playerToLeftOf;
            _DistanceToLeftOf = distanceToLeftOf;
        }

        public PlacedPlayer Place(PlacedPlayer placedPlayer)
        {
            if (_DistanceToLeftOf == 0)
            {
                throw new PlacementException("Can't place 0 units to left of.");
            }
            if (_DistanceToLeftOf < 0)
            {
                throw new PlacementException("Can't place player negative distance to left of player.");
            }

            return new PlacedPlayer(
                _PlayerToLeftOf.Location.X - _DistanceToLeftOf,
                placedPlayer.Location.Y
                );

        }
    }
}
