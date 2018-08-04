using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OffensiveFormation.PlacementRules;

namespace OffensiveFormation.PlacementRuleAdapters
{
    public class RelativeToPlayerHorizontallyAdapter : IPlacementRuleAdapter
    {
        public IPlacementRule GetPlacementRule(FormationRule formationRule, PlacedFormation placedFormation)
        {
            string relativeTypeString = formationRule.GetParameterValue("relativeType");
            string playerRelativeString = formationRule.GetParameterValue("playerRelative");
            string distanceString = formationRule.GetParameterValue("distance");

            RelativeType relativeType;
            switch (relativeTypeString)
            {
                case "Left":
                    relativeType = RelativeType.Left;
                    break;
                case "Right":
                    relativeType = RelativeType.Right;
                    break;
                case "Inside":
                    relativeType = RelativeType.Inside;
                    break;
                case "Outside":
                    relativeType = RelativeType.Outside;
                    break;
                default:
                    throw new FormationException("Relative type must be Left/Right/Inside/Outside.");
            }
            int distance = int.Parse(distanceString);
            PlacedPlayer playerRelative = placedFormation.GetPlayerByTag(playerRelativeString);

            return new RelativeToPlayerHorizontally(playerRelative, distance, relativeType);
        }
    }
}
