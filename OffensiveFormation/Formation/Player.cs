using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OffensiveFormation
{
    public class Player
    {
        public string Tag { get; set; }
        public FormationRule Rule { get; set; }

        public Player()
        {
            Tag = "";
            Rule = new FormationRule();
        }
    }
}
