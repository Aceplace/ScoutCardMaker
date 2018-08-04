using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OffensiveFormation.PlacementRules;

namespace OffensiveFormation.PlacementRuleAdapters
{
    class BehindPlayerAdapter : IPlacementRuleAdapter
    {
        public IPlacementRule GetPlacementRule(FormationRule formationRule, PlacedFormation placedFormation)
        {
            return new BehindPlayer(new PlacedPlayer(), 10);
        }
    }
}
