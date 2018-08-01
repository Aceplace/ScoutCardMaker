using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using OffensiveFormation;

namespace OffensiveFormation.Tests
{
    public class FormationPlacerTester
    {
        public class PlaceMethod
        {
            [Fact]
            public void PlacesLinemanInCorrectLocations()
            {
                FormationPlacer formationPlacer = new FormationPlacer();
                Location expectedLocation = new Location(0, 0);

                PlacedFormation placedFormation = formationPlacer.Place();
                bool inExpectedLocation = placedFormation.Center.PlacedLocation == expectedLocation;

                Assert.True(inExpectedLocation);
            }

            [Fact]
            public void PlacesGuardsInCorrectLocation()
            {
                FormationPlacer formationPlacer = new FormationPlacer();
                Location expectedLeftGuardLocation = new Location(-4, 0);
                Location expectedRightGuardLocation = new Location(4, 0);

                PlacedFormation placedFormation = formationPlacer.Place();
                bool leftGuardInExpectedLocation = placedFormation.LeftGuard.PlacedLocation == expectedLeftGuardLocation;
                bool rightGuardInExpectedLocation = placedFormation.RightGuard.PlacedLocation == expectedRightGuardLocation;

                Assert.True(leftGuardInExpectedLocation);
                Assert.True(rightGuardInExpectedLocation);
            }

            [Fact]
            public void PlacesTacklesInCorrectLocation()
            {
                FormationPlacer formationPlacer = new FormationPlacer();
                Location expectedLeftTackleLocation = new Location(-8, 0);
                Location expectedRightTackleLocation = new Location(8, 0);

                PlacedFormation placedFormation = formationPlacer.Place();
                bool leftTackleInExpectedLocation = placedFormation.LeftTackle.PlacedLocation == expectedLeftTackleLocation;
                bool rightTackleInExpectedLocation = placedFormation.RightTackle.PlacedLocation == expectedRightTackleLocation;

                Assert.True(leftTackleInExpectedLocation);
                Assert.True(rightTackleInExpectedLocation);
            }
        }
    }
}
