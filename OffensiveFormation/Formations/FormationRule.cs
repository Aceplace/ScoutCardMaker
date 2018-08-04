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


        /// <exception cref="FormationException"></exception>
        public string GetParameterValue(string parameterName)
        {
            foreach (FormationRuleParameter parameter in parameters)
            {
                if (parameter.name == parameterName)
                {
                    return parameter.value;
                }
            }
            throw new FormationException($"The parameter {parameterName} doesn't exist for the formation rule {rule}");
        }
    }
}
