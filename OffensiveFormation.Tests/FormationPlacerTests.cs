using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using OffensiveFormation;

namespace OffensiveFormation.Tests
{
    public class FormationPlacerTests
    {
        public class PlaceMethod
        {
            [Fact]
            public void PlacesLinemanInCorrectLocations()
            {
                FormationPlacer formationPlacer = new FormationPlacer();
                Location expectedLocation = new Location(0, 0);

                PlacedFormation placedFormation = formationPlacer.Place();
                bool inExpectedLocation = placedFormation.Center.Location == expectedLocation;

                Assert.True(inExpectedLocation);
            }

            [Fact]
            public void PlacesGuardsInCorrectLocation()
            {
                FormationPlacer formationPlacer = new FormationPlacer();
                Location expectedLeftGuardLocation = new Location(-4, 0);
                Location expectedRightGuardLocation = new Location(4, 0);

                PlacedFormation placedFormation = formationPlacer.Place();
                bool leftGuardInExpectedLocation = placedFormation.LeftGuard.Location == expectedLeftGuardLocation;
                bool rightGuardInExpectedLocation = placedFormation.RightGuard.Location == expectedRightGuardLocation;

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
                bool leftTackleInExpectedLocation = placedFormation.LeftTackle.Location == expectedLeftTackleLocation;
                bool rightTackleInExpectedLocation = placedFormation.RightTackle.Location == expectedRightTackleLocation;

                Assert.True(leftTackleInExpectedLocation);
                Assert.True(rightTackleInExpectedLocation);
            }
        }
    }
}
