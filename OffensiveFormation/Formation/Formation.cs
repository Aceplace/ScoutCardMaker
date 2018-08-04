using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OffensiveFormation
{
    public class Formation
    {
        public Player Center { get; set; } = new Player();
        public Player RightGuard { get; set; } = new Player();
        public Player LeftGuard { get; set; } = new Player();
        public Player LeftTackle { get; set; } = new Player();
        public Player RightTackle { get; set; } = new Player();
        public Player[] SkillPlayers { get; set; } = new Player[6];
        public Direction StrongSide;

        public Formation()
        {
            Center.Tag = "C";
            RightGuard.Tag = "RG";
            RightTackle.Tag = "RT";
            LeftGuard.Tag = "LG";
            LeftTackle.Tag = "LT";
            for (int i = 0; i < SkillPlayers.Length; i++)
            {
                SkillPlayers[i] = new Player();
            }
            SkillPlayers[0].Tag = "0";
            SkillPlayers[1].Tag = "1";
            SkillPlayers[2].Tag = "2";
            SkillPlayers[3].Tag = "3";
            SkillPlayers[4].Tag = "4";
            SkillPlayers[5].Tag = "5";
        }

        public Formation(string skill1Tag, string skill2Tag, string skill3Tag, string skill4Tag, string skill5Tag, string skill6Tag)
        {
            Center.Tag = "C";
            RightGuard.Tag = "RG";
            RightTackle.Tag = "RT";
            LeftGuard.Tag = "LG";
            LeftTackle.Tag = "LT";
            for (int i = 0; i < SkillPlayers.Length; i++)
            {
                SkillPlayers[i] = new Player();
            }
            SkillPlayers[0].Tag = skill1Tag;
            SkillPlayers[1].Tag = skill2Tag;
            SkillPlayers[2].Tag = skill3Tag;
            SkillPlayers[3].Tag = skill4Tag;
            SkillPlayers[4].Tag = skill5Tag;
            SkillPlayers[5].Tag = skill6Tag;
        }
    }
}
