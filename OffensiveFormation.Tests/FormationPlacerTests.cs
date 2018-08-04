using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using OffensiveFormation;
using OffensiveFormation.PlacementRules;

namespace OffensiveFormation.Tests
{
    public class FormationPlacerTests
    {
        public class FakePlacementRuleFactory : IPlacementRuleFactory
        {
            public IPlacementRule GetPlacementRule(FormationRule formationRule, PlacedFormation placedFormation)
            {
                return new FakePlacementRule();
            }
        }
        
        public class FakePlacementRule : IPlacementRule
        {
            public PlacedPlayer Place(PlacedPlayer placedPlayer)
            {
                return new PlacedPlayer();
            }
        }

        public class ToPlacedFormation
        {
            Formation formation;
            FakePlacementRuleFactory fakePlacementRuleFactory;

            public ToPlacedFormation()
            {
                formation = new Formation();
                fakePlacementRuleFactory = new FakePlacementRuleFactory();
            }

            [Fact]
            public void PlacesLinemanInCorrectLocations()
            {
                FormationPlacer formationPlacer = new FormationPlacer(fakePlacementRuleFactory);
                Location expectedLocation = new Location(0, 0);

                PlacedFormation placedFormation = formationPlacer.ToPlacedFormation(formation);
                bool inExpectedLocation = placedFormation.center.location == expectedLocation;

                Assert.True(inExpectedLocation);
            }

            [Fact]
            public void PlacesGuardsInCorrectLocation()
            {
                FormationPlacer formationPlacer = new FormationPlacer(fakePlacementRuleFactory);
                Location expectedLeftGuardLocation = new Location(-4, 0);
                Location expectedRightGuardLocation = new Location(4, 0);

                PlacedFormation placedFormation = formationPlacer.ToPlacedFormation(formation);
                bool leftGuardInExpectedLocation = placedFormation.leftGuard.location == expectedLeftGuardLocation;
                bool rightGuardInExpectedLocation = placedFormation.rightGuard.location == expectedRightGuardLocation;

                Assert.True(leftGuardInExpectedLocation);
                Assert.True(rightGuardInExpectedLocation);
            }

            [Fact]
            public void PlacesTacklesInCorrectLocation()
            {
                FormationPlacer formationPlacer = new FormationPlacer(fakePlacementRuleFactory);
                Location expectedLeftTackleLocation = new Location(-8, 0);
                Location expectedRightTackleLocation = new Location(8, 0);

                PlacedFormation placedFormation = formationPlacer.ToPlacedFormation(formation);
                bool leftTackleInExpectedLocation = placedFormation.leftTackle.location == expectedLeftTackleLocation;
                bool rightTackleInExpectedLocation = placedFormation.rightTackle.location == expectedRightTackleLocation;

                Assert.True(leftTackleInExpectedLocation);
                Assert.True(rightTackleInExpectedLocation);
            }
        }
    }
}
