using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OffensiveFormation
{
    public class FormationRule
    {
        public string Rule { get; set; }
        public List<FormationRuleParameter> Parameters { get; set; }

        public FormationRule()
        {
            Rule = "";
            Parameters = new List<FormationRuleParameter>();
        }
    }
}
