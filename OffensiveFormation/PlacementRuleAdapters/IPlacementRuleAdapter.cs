using OffensiveFormation.PlacementRules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OffensiveFormation.PlacementRuleAdapters
{
    interface IPlacementRuleAdapter
    {
        IPlacementRule GetPlacementRule(FormationRule formationRule, PlacedFormation placedFormation);
    }
}
