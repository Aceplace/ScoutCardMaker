using OffensiveFormation.PlacementRuleAdapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace OffensiveFormation.Tests.PlacementRuleAdapters
{
    public class BehindPlayerAdapterTests
    {
        public class GetPlacementRuleMethod
        {
            [Fact] 
            public void PassingWrongParameterNamesThrowsException_01()
            {
                FormationRule formationRule = new FormationRule();
                formationRule.parameters.Add(new FormationRuleParameter("nonrelevantTag", "nonrelevantValue"));
                BehindPlayerAdapter behindPlayerAdapter = new BehindPlayerAdapter();

                Assert.Throws<FormationException>(() => behindPlayerAdapter.GetPlacementRule(formationRule, new PlacedFormation()));
            }

            [Fact]
            public void PassingWrongParameterNamesThrowsException_02()
            {
                FormationRule formationRule = new FormationRule();
                formationRule.parameters.Add(new FormationRuleParameter("playerBehindTag", "RG"));
                BehindPlayerAdapter behindPlayerAdapter = new BehindPlayerAdapter();

                Assert.Throws<FormationException>(() => behindPlayerAdapter.GetPlacementRule(formationRule, new PlacedFormation()));
            }

            [Fact]
            public void PassingWrongParameterNamesThrowsException_03()
            {
                FormationRule formationRule = new FormationRule();
                formationRule.parameters.Add(new FormationRuleParameter("distanceBehind", "5"));
                BehindPlayerAdapter behindPlayerAdapter = new BehindPlayerAdapter();

                Assert.Throws<FormationException>(() => behindPlayerAdapter.GetPlacementRule(formationRule, new PlacedFormation()));
            }

            [Fact]
            public void PassingNonIntegerToDistanceBehindThrowsException()
            {
                FormationRule formationRule = new FormationRule();
                formationRule.parameters.Add(new FormationRuleParameter("playerBehindTag", "RG"));
                formationRule.parameters.Add(new FormationRuleParameter("distanceBehind", "NotAInt"));
                BehindPlayerAdapter behindPlayerAdapter = new BehindPlayerAdapter();

                Assert.Throws<FormatException>(() => behindPlayerAdapter.GetPlacementRule(formationRule, new PlacedFormation()));
            }

            [Fact]
            public void PassingNonexistentTagThrowsException()
            {
                FormationRule formationRule = new FormationRule();
                formationRule.parameters.Add(new FormationRuleParameter("playerBehindTag", "RG"));
                formationRule.parameters.Add(new FormationRuleParameter("distanceBehind", "12"));
                BehindPlayerAdapter behindPlayerAdapter = new BehindPlayerAdapter();

                Assert.Throws<PlacedFormationException>(() => behindPlayerAdapter.GetPlacementRule(formationRule, new PlacedFormation()));
            }

            [Fact]
            public void PassingGoodParametersInDoesntThrowException()
            {
                FormationRule formationRule = new FormationRule();
                formationRule.parameters.Add(new FormationRuleParameter("playerBehindTag", "RG"));
                formationRule.parameters.Add(new FormationRuleParameter("distanceBehind", "12"));
                BehindPlayerAdapter behindPlayerAdapter = new BehindPlayerAdapter();
                PlacedFormation placedFormation = new PlacedFormation();
                placedFormation.rightGuard.tag = "RG";

                behindPlayerAdapter.GetPlacementRule(formationRule, placedFormation);
            }


        }
    }
}
