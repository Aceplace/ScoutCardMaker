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
    public class FormationPlacer
    {
        public PlacedFormation Place()
        {
            PlacedFormation placedFormation = new PlacedFormation();

            placedFormation.LeftGuard.SetLocation(-4, 0);
            placedFormation.RightGuard.SetLocation(4, 0);
            placedFormation.LeftTackle.SetLocation(-8, 0);
            placedFormation.RightTackle.SetLocation(8, 0);

            return placedFormation;
        }
    }
}
