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
            return new PlacedPlayer(
                _PlayerBehind.PlacedLocation.XPosition,
                _PlayerBehind.PlacedLocation.YPosition + _DistanceBehind
                ); 
        }
    }
}
