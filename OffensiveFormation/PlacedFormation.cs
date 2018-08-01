using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OffensiveFormation
{
    public class PlacedFormation
    {
        public PlacedPlayer Center { get; set; } = new PlacedPlayer();
        public PlacedPlayer LeftGuard { get; set; } = new PlacedPlayer();
        public PlacedPlayer LeftTackle { get; set; } = new PlacedPlayer();
        public PlacedPlayer RightGuard { get; set; } = new PlacedPlayer();
        public PlacedPlayer RightTackle { get; set; } = new PlacedPlayer();
    }
}
