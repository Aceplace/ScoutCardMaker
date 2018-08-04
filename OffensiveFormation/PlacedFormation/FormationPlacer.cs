using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OffensiveFormation
{
    /// <summary>
    /// Placed players into proper locations based off of formation rules.
    /// </summary>
    public class FormationPlacer : IFormationPlacer
    {
        IPlacementRuleFactory _placementRuleFactory;

        public FormationPlacer(IPlacementRuleFactory placementRuleFactory)
        {
            _placementRuleFactory = placementRuleFactory;
        }

        public PlacedFormation ToPlacedFormation(Formation formation)
        {
            PlacedFormation placedFormation = new PlacedFormation();

            placedFormation.leftGuard.SetLocation(-4, 0);
            placedFormation.rightGuard.SetLocation(4, 0);
            placedFormation.leftTackle.SetLocation(-8, 0);
            placedFormation.rightTackle.SetLocation(8, 0);

            return placedFormation;
        }

    }
}
