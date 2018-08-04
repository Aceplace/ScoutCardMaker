using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OffensiveFormation.PlacementRules;

namespace OffensiveFormation.PlacementRuleAdapters
{
    public class BehindPlayerAdapter : IPlacementRuleAdapter
    {
        public IPlacementRule GetPlacementRule(FormationRule formationRule, PlacedFormation placedFormation)
        {
            string behindTagParameter = formationRule.GetParameterValue("playerBehindTag");
            string distanceBehindString = formationRule.GetParameterValue("distanceBehind");
            int distanceBehind = int.Parse(distanceBehindString);

            PlacedPlayer playerBehind = placedFormation.GetPlayerByTag(behindTagParameter);

            return new BehindPlayer(playerBehind, distanceBehind);
        }
    }
}
