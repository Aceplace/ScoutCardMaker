using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OffensiveFormation
{
    public class FormationRuleParameter
    {
        public string name { get; set; }
        public string value { get; set; }

        public FormationRuleParameter()
        {
            name = "";
            value = "";
        }

        public FormationRuleParameter(string parameterName, string value)
        {
            this.name = parameterName;
            this.value = value;
        }
    }
}
