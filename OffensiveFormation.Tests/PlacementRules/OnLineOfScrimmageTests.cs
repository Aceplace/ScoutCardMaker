using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using OffensiveFormation.PlacementRules;

namespace OffensiveFormation.Tests.PlacementRules
{
    public class OnLineOfScrimmageTests
    {
        public class PlaceMethod
        {
            [Theory]
            [InlineData(2, 5)]
            [InlineData(-4, 0)]
            [InlineData(-10, 2)]
            public void PlacesPlayerCorrectlyOnLine(int startingXPosition, int startingYPosition)
            {
                PlacedPlayer playerToPlace = new PlacedPlayer(startingXPosition, startingYPosition);
                Location expectedLocation = new Location(startingXPosition, 0);

                IPlacementRule placementRule = new OnLineOfScrimmage();
                playerToPlace = placementRule.Place(playerToPlace);

                Assert.Equal<Location>(expectedLocation, playerToPlace.Location);
            }
        }
    }
}
