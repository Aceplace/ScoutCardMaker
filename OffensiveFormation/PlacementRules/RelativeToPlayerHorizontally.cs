using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OffensiveFormation.PlacementRules
{
    public enum RelativeType
    {
        Left, Right, Inside, Outside
    }

    public class RelativeToPlayerHorizontally : IPlacementRule
    {
        private PlacedPlayer _playerRelative;
        private int _distance;
        private RelativeType _relativeType;

        public RelativeToPlayerHorizontally(PlacedPlayer playerRelative, int distance, RelativeType relativeType)
        {
            _playerRelative = playerRelative;
            _distance = distance;
            _relativeType = relativeType;
        }

        public PlacedPlayer Place(PlacedPlayer placedPlayer)
        {
            if (_distance == 0)
            {
                throw new PlacementException("Can't place 0 units relative.");
            }
            if (_distance < 0)
            {
                throw new PlacementException("Can't place player negative distance relative.");
            }

            int offset = GetRelativeOffset();
            return new PlacedPlayer(
                    _playerRelative.location.x + offset,
                    placedPlayer.location.y
                    );
            
        }

        public int GetRelativeOffset()
        {
            if (_relativeType == RelativeType.Right 
                || (_relativeType == RelativeType.Outside && _playerRelative.location.x > 0)
                || (_relativeType == RelativeType.Inside && _playerRelative.location.x < 0)
                )
            {
                return _distance;
            }
            if (_relativeType == RelativeType.Left
                || (_relativeType == RelativeType.Inside && _playerRelative.location.x > 0)
                || (_relativeType == RelativeType.Outside && _playerRelative.location.x < 0)
                )
            {
                return -(_distance);
            }           
            throw new PlacementException("Can't place player inside/outside another player who is in center of formation.");          
        }
    }
}
