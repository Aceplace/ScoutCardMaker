using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using OffensiveFormation.PlacementRules;

namespace OffensiveFormation.Tests.PlacementRules
{
    public class InsidePlayerTests
    {
        public class PlaceMethod
        {
            public static IEnumerable<object[]> GetPlayersCorrectlyInsideOtherTestData()
            {
                yield return new object[] { new PlacedPlayer(5, 0), new PlacedPlayer(1, 1), 1, new Location(4, 1) };
                yield return new object[] { new PlacedPlayer(-5, 0), new PlacedPlayer(0, 0), 3, new Location(-2, 0) };
                yield return new object[] { new PlacedPlayer(15, 3), new PlacedPlayer(-4, 0), 5, new Location(10, 0) };
                yield return new object[] { new PlacedPlayer(-2, 7), new PlacedPlayer(5, 4), 2, new Location(0, 4) };
            }

            [Theory]
            [MemberData(nameof(GetPlayersCorrectlyInsideOtherTestData))]
            public void PlacesPlayerCorrectlyInsideOther(PlacedPlayer playerToBeInside, PlacedPlayer playerToPlace,
                                                            int distanceInside, Location expectedLocation)
            {
                IPlacementRule placementRule = new InsidePlayer(playerToBeInside, distanceInside);
                playerToPlace = placementRule.Place(playerToPlace);

                Assert.Equal<Location>(expectedLocation, playerToPlace.location);
            }

            [Fact]
            public void PlacingPlayerInsidePlayerInMiddleThrowsExceptionWithProperMessage()
            {
                PlacedPlayer playerToBeInside = new PlacedPlayer();
                PlacedPlayer playerToPlace = new PlacedPlayer(3, 3);

                IPlacementRule placementRule = new InsidePlayer(playerToBeInside, 1);
                PlacementException ex = Assert.Throws<PlacementException>(() => playerToPlace = placementRule.Place(playerToPlace));

                Assert.Equal("Can't place player inside another player who is in center of formation.", ex.Message);
            }

            [Fact]
            public void PlacingPlayerZeroUnitsInsideThrowsExceptionWithProperMessage()
            {
                PlacedPlayer playerToBeInside = new PlacedPlayer();
                PlacedPlayer playerToPlace = new PlacedPlayer(3, 3);

                IPlacementRule placementRule = new InsidePlayer(playerToBeInside, 0);
                PlacementException ex = Assert.Throws<PlacementException>(() => playerToPlace = placementRule.Place(playerToPlace));

                Assert.Equal("Can't place 0 units inside.", ex.Message);
            }

            [Fact]
            public void PlacingPlayerNegativeUnitsInsideThrowsExceptionWithProperMessage()
            {
                PlacedPlayer playerToBeInside = new PlacedPlayer();
                PlacedPlayer playerToPlace = new PlacedPlayer(3, 3);

                IPlacementRule placementRule = new InsidePlayer(playerToBeInside, -4);
                PlacementException ex = Assert.Throws<PlacementException>(() => playerToPlace = placementRule.Place(playerToPlace));

                Assert.Equal("Can't place player negative distance inside player.", ex.Message);
            }
        }
    }
}
