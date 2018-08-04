using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OffensiveFormation
{
    public class Formation
    {
        public Player center { get; set; } = new Player();
        public Player rightGuard { get; set; } = new Player();
        public Player leftGuard { get; set; } = new Player();
        public Player leftTackle { get; set; } = new Player();
        public Player rightTackle { get; set; } = new Player();
        public Player[] skillPlayers { get; set; } = new Player[6];
        public Direction strongSide;

        public Formation()
        {
            center.tag = "C";
            rightGuard.tag = "RG";
            rightTackle.tag = "RT";
            leftGuard.tag = "LG";
            leftTackle.tag = "LT";
            for (int i = 0; i < skillPlayers.Length; i++)
            {
                skillPlayers[i] = new Player();
            }
            skillPlayers[0].tag = "0";
            skillPlayers[1].tag = "1";
            skillPlayers[2].tag = "2";
            skillPlayers[3].tag = "3";
            skillPlayers[4].tag = "4";
            skillPlayers[5].tag = "5";
        }

        public Formation(string skill1Tag, string skill2Tag, string skill3Tag, string skill4Tag, string skill5Tag, string skill6Tag)
        {
            center.tag = "C";
            rightGuard.tag = "RG";
            rightTackle.tag = "RT";
            leftGuard.tag = "LG";
            leftTackle.tag = "LT";
            for (int i = 0; i < skillPlayers.Length; i++)
            {
                skillPlayers[i] = new Player();
            }
            skillPlayers[0].tag = skill1Tag;
            skillPlayers[1].tag = skill2Tag;
            skillPlayers[2].tag = skill3Tag;
            skillPlayers[3].tag = skill4Tag;
            skillPlayers[4].tag = skill5Tag;
            skillPlayers[5].tag = skill6Tag;
        }
    }
}
