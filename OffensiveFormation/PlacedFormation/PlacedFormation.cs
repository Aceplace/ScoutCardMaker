using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OffensiveFormation
{
    public enum FlowDirection
    {
        InsideOut, OutsideIn
    }

    public class PlacedFormation
    {
        public PlacedPlayer center { get; set; }
        public PlacedPlayer leftGuard { get; set; }
        public PlacedPlayer leftTackle { get; set; } 
        public PlacedPlayer rightGuard { get; set; } 
        public PlacedPlayer rightTackle { get; set; }
        public PlacedPlayer[] skillPlayers { get; set; }
        public Direction strongSide;

        public PlacedFormation()
        {
            center = new PlacedPlayer();
            leftGuard = new PlacedPlayer();
            leftTackle = new PlacedPlayer();
            rightGuard = new PlacedPlayer();
            rightTackle = new PlacedPlayer();
            skillPlayers = new PlacedPlayer[6];
            skillPlayers[0] = new PlacedPlayer();
            skillPlayers[1] = new PlacedPlayer();
            skillPlayers[2] = new PlacedPlayer();
            skillPlayers[3] = new PlacedPlayer();
            skillPlayers[4] = new PlacedPlayer();
            skillPlayers[5] = new PlacedPlayer();
            strongSide = Direction.Right;
        }

        public PlacedPlayer GetStrongGuard()
        {
            return strongSide == Direction.Right ? rightGuard : leftGuard;
        }

        public PlacedPlayer GetStrongTackle()
        {
            return strongSide == Direction.Right ? rightTackle : leftTackle;
        }

        public PlacedPlayer GetWeakGuard()
        {
            return strongSide == Direction.Right ? leftGuard : rightGuard;
        }

        public PlacedPlayer GetWeakTackle()
        {
            return strongSide == Direction.Right ? leftTackle : rightTackle;
        }

        public PlacedPlayer GetNumberedSkillStrong(FlowDirection flowDirection, int number)
        {
            return strongSide == Direction.Right ? 
                GetNumberedSkillDirectional(Direction.Right, flowDirection, number) : 
                GetNumberedSkillDirectional(Direction.Left, flowDirection, number);
        }

        public PlacedPlayer GetNumberedSkillWeak(FlowDirection flowDirection, int number)
        {
            return strongSide == Direction.Left ?
                GetNumberedSkillDirectional(Direction.Right, flowDirection, number):
                GetNumberedSkillDirectional(Direction.Left, flowDirection, number);
        }

        public PlacedPlayer GetNumberedSkillRight(FlowDirection flowDirection, int number)
        {
            return GetNumberedSkillDirectional(Direction.Right, flowDirection, number);
        }

        public PlacedPlayer GetNumberedSkillLeft(FlowDirection flowDirection, int number)
        {
            return GetNumberedSkillDirectional(Direction.Left, flowDirection, number);
        }

        private PlacedPlayer GetNumberedSkillDirectional(Direction direction, FlowDirection flowDirection, int number)
        {
            if (number < 0)
            {
                throw new PlacedFormationException("Can't get negative numbered skill player.");
            }
            if (number == 0)
            {
                throw new PlacedFormationException("Can't get 0 numbered skill player.");
            }
            if (number > 6)
            {
                throw new PlacedFormationException("Can't get numbers skill player larger then 6. There are only 6 skill players.");
            }

            IOrderedEnumerable<PlacedPlayer> result;
            if (flowDirection == FlowDirection.OutsideIn)
            {
                if (direction == Direction.Left)
                {
                    result = skillPlayers.OrderBy(placedPlayer => placedPlayer.location.x)
                             .ThenBy(placedPlayer => placedPlayer.location.y);
                }
                else
                {
                    result = skillPlayers.OrderByDescending(placedPlayer => placedPlayer.location.x)
                        .ThenBy(placedPlayer => placedPlayer.location.y);
                }
                
            }
            else
            {
                if (direction == Direction.Left)
                {
                    result = skillPlayers
                            .Where(placedPlayer => placedPlayer.location.x < leftTackle.location.x)
                            .OrderByDescending(placedPlayer => placedPlayer.location.x)
                            .ThenBy(placedPlayer => placedPlayer.location.y);
                }
                else
                {
                    result = skillPlayers
                            .Where(placedPlayer => placedPlayer.location.x > rightTackle.location.x)
                            .OrderBy(placedPlayer => placedPlayer.location.x)
                            .ThenBy(placedPlayer => placedPlayer.location.y);
                }
                
            }

            int i = 1;
            foreach (PlacedPlayer placedPlayer in result)
            {
                if (i == number)
                {
                    return placedPlayer;
                }
                i++;
            }
            throw new PlacedFormationException("Not enough skill players outside tackle.");
        }

    }
}
