using OffensiveFormation.PlacementRuleAdapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace OffensiveFormation.Tests.PlacementRuleAdapters
{
    public class RelativeToPlayerHorizontallyAdapterTests
    {
        [Fact]
        public void PassingWrongParameterNamesThrowsException_01()
        {
            FormationRule formationRule = new FormationRule();
            formationRule.parameters.Add(new FormationRuleParameter("nonrelevantTag", "nonrelevantValue"));
            RelativeToPlayerHorizontallyAdapter relativePlayerAdapter = new RelativeToPlayerHorizontallyAdapter();

            Assert.Throws<FormationException>(() => relativePlayerAdapter.GetPlacementRule(formationRule, new PlacedFormation()));
        }

        [Fact]
        public void PassingNonIntegerToDistanceBehindThrowsException()
        {
            FormationRule formationRule = new FormationRule();
            formationRule.parameters.Add(new FormationRuleParameter("playerRelative", "X"));
            formationRule.parameters.Add(new FormationRuleParameter("relativeType", "Inside"));
            formationRule.parameters.Add(new FormationRuleParameter("distance", "NotAInt"));
            RelativeToPlayerHorizontallyAdapter relativePlayerAdapter = new RelativeToPlayerHorizontallyAdapter();

            Assert.Throws<FormatException>(() => relativePlayerAdapter.GetPlacementRule(formationRule, new PlacedFormation()));
        }

        [Fact]
        public void PassingNonexistentTagThrowsException()
        {
            FormationRule formationRule = new FormationRule();
            formationRule.parameters.Add(new FormationRuleParameter("playerRelative", "X"));
            formationRule.parameters.Add(new FormationRuleParameter("relativeType", "Inside"));
            formationRule.parameters.Add(new FormationRuleParameter("distance", "7"));
            RelativeToPlayerHorizontallyAdapter relativePlayerAdapter = new RelativeToPlayerHorizontallyAdapter();

            Assert.Throws<PlacedFormationException>(() => relativePlayerAdapter.GetPlacementRule(formationRule, new PlacedFormation()));
        }

        [Fact]
        public void PassingGoodParametersInDoesntThrowException()
        {
            FormationRule formationRule = new FormationRule();
            formationRule.parameters.Add(new FormationRuleParameter("playerRelative", "X"));
            formationRule.parameters.Add(new FormationRuleParameter("relativeType", "Inside"));
            formationRule.parameters.Add(new FormationRuleParameter("distance", "7"));
            RelativeToPlayerHorizontallyAdapter relativePlayerAdapter = new RelativeToPlayerHorizontallyAdapter();
            PlacedFormation placedFormation = new PlacedFormation();
            placedFormation.skillPlayers[1].tag = "X";

            relativePlayerAdapter.GetPlacementRule(formationRule, placedFormation);
        }
    }
}
