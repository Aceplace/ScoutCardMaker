using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OffensiveFormation.PlacementRules
{
    public class BehindPlayer : IPlacementRule
    {
        private PlacedPlayer _playerBehind;
        private int _distanceBehind;

        public BehindPlayer(PlacedPlayer playerBehind, int distanceBehind)
        {
            _playerBehind = playerBehind;
            _distanceBehind = distanceBehind;
        }

        public PlacedPlayer Place(PlacedPlayer placedPlayer)
        {
            if (_distanceBehind == 0)
            {
                throw new PlacementException("Can't place 0 units behind.");
            }
            if (_distanceBehind < 0)
            {
                throw new PlacementException("Can't place player negative units behind player.");
            }
            return new PlacedPlayer(
                _playerBehind.location.x,
                _playerBehind.location.y + _distanceBehind
                ); 
        }
    }
}
