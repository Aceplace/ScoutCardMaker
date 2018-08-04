using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OffensiveFormation
{
    public class FormationRuleParameter
    {
        public string ParameterName { get; set; }
        public string Value { get; set; }

        FormationRuleParameter()
        {
            ParameterName = "";
            Value = "";
        }

        FormationRuleParameter(string parameterName, string value)
        {
            ParameterName = parameterName;
            Value = value;
        }
    }
}
