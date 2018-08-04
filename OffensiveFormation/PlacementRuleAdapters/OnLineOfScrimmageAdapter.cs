using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OffensiveFormation.PlacementRules;

namespace OffensiveFormation.PlacementRuleAdapters
{
    public class OnLineOfScrimmageAdapter : IPlacementRuleAdapter
    {
        public IPlacementRule GetPlacementRule(FormationRule formationRule, PlacedFormation placedFormation)
        {
            return new OnLineOfScrimmage();
        }
    }
}
