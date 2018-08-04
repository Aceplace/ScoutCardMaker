using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OffensiveFormation.PlacementRules
{
    public class ToRightOf : IPlacementRule
    {
        private PlacedPlayer _playerToRightOf;
        private int _distanceToRightOf;

        public ToRightOf(PlacedPlayer playerToRightOf, int distanceToRightOf)
        {
            _playerToRightOf = playerToRightOf;
            _distanceToRightOf = distanceToRightOf;
        }

        public PlacedPlayer Place(PlacedPlayer placedPlayer)
        {
            if (_distanceToRightOf == 0)
            {
                throw new PlacementException("Can't place 0 units to right of.");
            }
            if (_distanceToRightOf < 0)
            {
                throw new PlacementException("Can't place player negative distance to right of player.");
            }

            return new PlacedPlayer(
                _playerToRightOf.location.x + _distanceToRightOf,
                placedPlayer.location.y
                );

        }
    }
}
