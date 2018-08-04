using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OffensiveFormation
{
    public class FormationRule
    {
        public string rule { get; set; }
        public List<FormationRuleParameter> parameters { get; set; }

        public FormationRule()
        {
            rule = "";
            parameters = new List<FormationRuleParameter>();
        }
    }
}
