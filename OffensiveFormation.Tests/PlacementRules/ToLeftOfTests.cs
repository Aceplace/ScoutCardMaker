using OffensiveFormation.PlacementRules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace OffensiveFormation.Tests.PlacementRules
{
    public class ToLeftOfTests
    {
        public class PlaceMethod
        {
            public static IEnumerable<object[]> GetPlayersCorrectlyToLeftTestData()
            {
                yield return new object[] { new PlacedPlayer(5, 0), new PlacedPlayer(1, 1), 1, new Location(4, 1) };
                yield return new object[] { new PlacedPlayer(-5, 0), new PlacedPlayer(0, 0), 3, new Location(-8, 0) };
                yield return new object[] { new PlacedPlayer(15, 3), new PlacedPlayer(-4, 0), 5, new Location(10, 0) };
                yield return new object[] { new PlacedPlayer(-2, 7), new PlacedPlayer(5, 4), 2, new Location(-4, 4) };
            }

            [Theory]
            [MemberData(nameof(GetPlayersCorrectlyToLeftTestData))]
            public void PlacesPlayerCorrectlyToLeftOfOther(PlacedPlayer playerToBeToLeftOf, PlacedPlayer playerToPlace,
                                                            int distanceToLeft, Location expectedLocation)
            {
                IPlacementRule placementRule = new ToLeftOf(playerToBeToLeftOf, distanceToLeft);
                playerToPlace = placementRule.Place(playerToPlace);

                Assert.Equal<Location>(expectedLocation, playerToPlace.location);
            }

            [Fact]
            public void PlacingPlayerZeroUnitsToLeftThrowsExceptionWithProperMessage()
            {
                PlacedPlayer playerToBeToLeftOf = new PlacedPlayer();
                PlacedPlayer playerToPlace = new PlacedPlayer(3, 3);

                IPlacementRule placementRule = new ToLeftOf(playerToBeToLeftOf, 0);
                PlacementException ex = Assert.Throws<PlacementException>(() => playerToPlace = placementRule.Place(playerToPlace));

                Assert.Equal("Can't place 0 units to left of.", ex.Message);
            }

            [Fact]
            public void PlacingPlayerNegativeUnitsToLeftOfThrowsExceptionWithProperMessage()
            {
                PlacedPlayer playerToBeToLeftOf = new PlacedPlayer();
                PlacedPlayer playerToPlace = new PlacedPlayer();

                IPlacementRule placementRule = new ToLeftOf(playerToBeToLeftOf, -7);
                PlacementException ex = Assert.Throws<PlacementException>(() => playerToPlace = placementRule.Place(playerToPlace));

                Assert.Equal("Can't place player negative distance to left of player.", ex.Message);
            }
        }
    }
}
