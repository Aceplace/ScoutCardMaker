using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OffensiveFormation
{
    public class Player
    {
        public string tag { get; set; }
        public FormationRule rule { get; set; }

        public Player()
        {
            tag = "";
            rule = new FormationRule();
        }
    }
}
