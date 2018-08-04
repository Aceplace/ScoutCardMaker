using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OffensiveFormation.PlacementRules
{
    public class ToRightOf : IPlacementRule
    {
        private PlacedPlayer _PlayerToRightOf;
        private int _DistanceToRightOf;

        public ToRightOf(PlacedPlayer playerToRightOf, int distanceToRightOf)
        {
            _PlayerToRightOf = playerToRightOf;
            _DistanceToRightOf = distanceToRightOf;
        }

        public PlacedPlayer Place(PlacedPlayer placedPlayer)
        {
            if (_DistanceToRightOf == 0)
            {
                throw new PlacementException("Can't place 0 units to right of.");
            }
            if (_DistanceToRightOf < 0)
            {
                throw new PlacementException("Can't place player negative distance to right of player.");
            }

            return new PlacedPlayer(
                _PlayerToRightOf.Location.X + _DistanceToRightOf,
                placedPlayer.Location.Y
                );

        }
    }
}
