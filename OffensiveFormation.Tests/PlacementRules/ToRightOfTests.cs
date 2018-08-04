using OffensiveFormation.PlacementRules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace OffensiveFormation.Tests.PlacementRules
{
    public class ToRightOfTests
    {
        public class PlaceMethod
        {
            public static IEnumerable<object[]> GetPlayersCorrectlyToRightTestData()
            {
                yield return new object[] { new PlacedPlayer(5, 0), new PlacedPlayer(1, 1), 1, new Location(6, 1) };
                yield return new object[] { new PlacedPlayer(-5, 0), new PlacedPlayer(0, 0), 3, new Location(-2, 0) };
                yield return new object[] { new PlacedPlayer(15, 3), new PlacedPlayer(-4, 0), 5, new Location(20, 0) };
                yield return new object[] { new PlacedPlayer(-2, 7), new PlacedPlayer(5, 4), 2, new Location(0, 4) };
            }

            [Theory]
            [MemberData(nameof(GetPlayersCorrectlyToRightTestData))]
            public void PlacesPlayerCorrectlyToRightOfOther(PlacedPlayer playerToBeToRightOf, PlacedPlayer playerToPlace,
                                                            int distanceToRight, Location expectedLocation)
            {
                IPlacementRule placementRule = new ToRightOf(playerToBeToRightOf, distanceToRight);
                playerToPlace = placementRule.Place(playerToPlace);

                Assert.Equal<Location>(expectedLocation, playerToPlace.Location);
            }

            [Fact]
            public void PlacingPlayerZeroUnitsToRightThrowsExceptionWithProperMessage()
            {
                PlacedPlayer playerToBeToRightOf = new PlacedPlayer();
                PlacedPlayer playerToPlace = new PlacedPlayer(3, 3);

                IPlacementRule placementRule = new ToRightOf(playerToBeToRightOf, 0);
                PlacementException ex = Assert.Throws<PlacementException>(() => playerToPlace = placementRule.Place(playerToPlace));

                Assert.Equal("Can't place 0 units to right of.", ex.Message);
            }

            [Fact]
            public void PlacingPlayerNegativeUnitsToRightOfThrowsExceptionWithProperMessage()
            {
                PlacedPlayer playerToBeToRightOf = new PlacedPlayer();
                PlacedPlayer playerToPlace = new PlacedPlayer();

                IPlacementRule placementRule = new ToRightOf(playerToBeToRightOf, -7);
                PlacementException ex = Assert.Throws<PlacementException>(() => playerToPlace = placementRule.Place(playerToPlace));

                Assert.Equal("Can't place player negative distance to right of player.", ex.Message);
            }
        }
    }
}
