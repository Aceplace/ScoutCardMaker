using OffensiveFormation.PlacementRules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OffensiveFormation
{
    public interface IPlacementRuleFactory
    {
        IPlacementRule GetPlacementRule(FormationRule formationRule, PlacedFormation placedFormation);
    }
}
