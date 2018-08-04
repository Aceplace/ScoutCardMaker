using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OffensiveFormation.PlacementRules
{
    public class BehindPlayer : IPlacementRule
    {
        private PlacedPlayer _PlayerBehind;
        private int _DistanceBehind;

        public BehindPlayer(PlacedPlayer playerBehind, int distanceBehind)
        {
            _PlayerBehind = playerBehind;
            _DistanceBehind = distanceBehind;
        }

        public PlacedPlayer Place(PlacedPlayer placedPlayer)
        {
            if (_DistanceBehind == 0)
            {
                throw new PlacementException("Can't place 0 units behind.");
            }
            if (_DistanceBehind < 0)
            {
                throw new PlacementException("Can't place player negative units behind player.");
            }
            return new PlacedPlayer(
                _PlayerBehind.Location.X,
                _PlayerBehind.Location.Y + _DistanceBehind
                ); 
        }
    }
}
