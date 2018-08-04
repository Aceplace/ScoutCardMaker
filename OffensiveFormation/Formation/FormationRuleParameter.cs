using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OffensiveFormation
{
    public class FormationRuleParameter
    {
        public string parameterName { get; set; }
        public string value { get; set; }

        FormationRuleParameter()
        {
            parameterName = "";
            value = "";
        }

        FormationRuleParameter(string parameterName, string value)
        {
            this.parameterName = parameterName;
            this.value = value;
        }
    }
}
