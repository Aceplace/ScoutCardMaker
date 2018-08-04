using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace OffensiveFormation.Tests.Formations
{
    public class FormationRuleTests
    {
        public class GetParameterValueMethod
        {
            [Fact]
            public void GetNonexistantParameterThrowsExceptionWithProperMessage()
            {
                FormationRule formationRule = new FormationRule();
                formationRule.rule = "Rule";

                FormationException ex = Assert.Throws<FormationException>(() => formationRule.GetParameterValue("Nonexistent"));

                Assert.Equal("The parameter Nonexistent doesn't exist for the formation rule Rule", ex.Message);
            }

            [Fact]
            public void GetsProperValueFromParameter()
            {
                FormationRule formationRule = new FormationRule();
                formationRule.parameters.Add(new FormationRuleParameter("Parameter", "Value"));
                string expectedValue = "Value";

                string parameterValue = formationRule.GetParameterValue("Parameter");

                Assert.Equal(expectedValue, parameterValue);
            }
        }
    }
}
