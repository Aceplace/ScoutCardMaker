using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OffensiveFormation
{
    public interface IFormationPlacer
    {
        PlacedFormation ToPlacedFormation(Formation formation);
    }
}
