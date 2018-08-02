using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OffensiveFormation.PlacementRules
{
    public interface IPlacementRule
    {
        PlacedPlayer Place(PlacedPlayer placedPlayer);
    }
}
