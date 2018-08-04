using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OffensiveFormation.PlacementRules
{
    public class ToLeftOf : IPlacementRule
    {
        private PlacedPlayer _playerToLeftOf;
        private int _distanceToLeftOf;

        public ToLeftOf(PlacedPlayer playerToLeftOf, int distanceToLeftOf)
        {
            _playerToLeftOf = playerToLeftOf;
            _distanceToLeftOf = distanceToLeftOf;
        }

        public PlacedPlayer Place(PlacedPlayer placedPlayer)
        {
            if (_distanceToLeftOf == 0)
            {
                throw new PlacementException("Can't place 0 units to left of.");
            }
            if (_distanceToLeftOf < 0)
            {
                throw new PlacementException("Can't place player negative distance to left of player.");
            }

            return new PlacedPlayer(
                _playerToLeftOf.location.x - _distanceToLeftOf,
                placedPlayer.location.y
                );

        }
    }
}
