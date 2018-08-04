﻿using System;
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
        public PlacedPlayer Center { get; set; }
        public PlacedPlayer LeftGuard { get; set; }
        public PlacedPlayer LeftTackle { get; set; } 
        public PlacedPlayer RightGuard { get; set; } 
        public PlacedPlayer RightTackle { get; set; }
        public PlacedPlayer[] SkillPlayers { get; set; }
        public Direction StrongSide;

        public PlacedFormation()
        {
            Center = new PlacedPlayer();
            LeftGuard = new PlacedPlayer();
            LeftTackle = new PlacedPlayer();
            RightGuard = new PlacedPlayer();
            RightTackle = new PlacedPlayer();
            SkillPlayers = new PlacedPlayer[6];
            SkillPlayers[0] = new PlacedPlayer();
            SkillPlayers[1] = new PlacedPlayer();
            SkillPlayers[2] = new PlacedPlayer();
            SkillPlayers[3] = new PlacedPlayer();
            SkillPlayers[4] = new PlacedPlayer();
            SkillPlayers[5] = new PlacedPlayer();
            StrongSide = Direction.Right;
        }

        public PlacedPlayer GetStrongGuard()
        {
            return StrongSide == Direction.Right ? RightGuard : LeftGuard;
        }

        public PlacedPlayer GetStrongTackle()
        {
            return StrongSide == Direction.Right ? RightTackle : LeftTackle;
        }

        public PlacedPlayer GetWeakGuard()
        {
            return StrongSide == Direction.Right ? LeftGuard : RightGuard;
        }

        public PlacedPlayer GetWeakTackle()
        {
            return StrongSide == Direction.Right ? LeftTackle : RightTackle;
        }

        public PlacedPlayer GetNumberedSkillStrong(FlowDirection flowDirection, int number)
        {
            return StrongSide == Direction.Right ? 
                GetNumberedSkillDirectional(Direction.Right, flowDirection, number) : 
                GetNumberedSkillDirectional(Direction.Left, flowDirection, number);
        }

        public PlacedPlayer GetNumberedSkillWeak(FlowDirection flowDirection, int number)
        {
            return StrongSide == Direction.Left ?
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
                    result = SkillPlayers.OrderBy(placedPlayer => placedPlayer.Location.X)
                             .ThenBy(placedPlayer => placedPlayer.Location.Y);
                }
                else
                {
                    result = SkillPlayers.OrderByDescending(placedPlayer => placedPlayer.Location.X)
                        .ThenBy(placedPlayer => placedPlayer.Location.Y);
                }
                
            }
            else
            {
                if (direction == Direction.Left)
                {
                    result = SkillPlayers
                            .Where(placedPlayer => placedPlayer.Location.X < LeftTackle.Location.X)
                            .OrderByDescending(placedPlayer => placedPlayer.Location.X)
                            .ThenBy(placedPlayer => placedPlayer.Location.Y);
                }
                else
                {
                    result = SkillPlayers
                            .Where(placedPlayer => placedPlayer.Location.X > RightTackle.Location.X)
                            .OrderBy(placedPlayer => placedPlayer.Location.X)
                            .ThenBy(placedPlayer => placedPlayer.Location.Y);
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