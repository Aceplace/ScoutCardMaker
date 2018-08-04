using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using OffensiveFormation.PlacementRules;

namespace OffensiveFormation.Tests.PlacementRules
{
    public class OutsidePlayerTests
    {
        public class PlaceMethod
        {
            public static IEnumerable<object[]> GetPlayersCorrectlyOutsideOtherTestData()
            {
                yield return new object[] { new PlacedPlayer(5, 0), new PlacedPlayer(1, 1), 1, new Location(6, 1) };
                yield return new object[] { new PlacedPlayer(-5, 0), new PlacedPlayer(0, 0), 3, new Location(-8, 0) };
                yield return new object[] { new PlacedPlayer(15, 3), new PlacedPlayer(-4, 0), 5, new Location(20, 0) };
                yield return new object[] { new PlacedPlayer(-2, 7), new PlacedPlayer(5, 4), 2, new Location(-4, 4) };
            }

            [Theory]
            [MemberData(nameof(GetPlayersCorrectlyOutsideOtherTestData))]
            public void PlacesPlayerCorrectlyOutsideOther(PlacedPlayer playerToBeOutside, PlacedPlayer playerToPlace, 
                                                            int distanceOutside,Location expectedLocation)
            {
                IPlacementRule placementRule = new OutsidePlayer(playerToBeOutside, distanceOutside);
                playerToPlace = placementRule.Place(playerToPlace);

                Assert.Equal<Location>(expectedLocation, playerToPlace.location);
            }     
            
            [Fact]
            public void PlacingPlayerOutsidePlayerInMiddleThrowsExceptionWithProperMessage()
            {
                PlacedPlayer playerToBeOutside = new PlacedPlayer();
                PlacedPlayer playerToPlace = new PlacedPlayer(3, 3);

                IPlacementRule placementRule = new OutsidePlayer(playerToBeOutside, 1);
                PlacementException ex = Assert.Throws<PlacementException>(() => playerToPlace = placementRule.Place(playerToPlace));

                Assert.Equal("Can't place player outside another player who is in center of formation.", ex.Message);
            }

            [Fact]
            public void PlacingPlayerZeroUnitsOutsideThrowsExceptionWithProperMessage()
            {
                PlacedPlayer playerToBeOutside = new PlacedPlayer();
                PlacedPlayer playerToPlace = new PlacedPlayer(3, 3);

                IPlacementRule placementRule = new OutsidePlayer(playerToBeOutside, 0);
                PlacementException ex = Assert.Throws<PlacementException>(() => playerToPlace = placementRule.Place(playerToPlace));

                Assert.Equal("Can't place 0 units outside.", ex.Message);
            }

            [Fact]
            public void PlacingPlayerNegativeUnitsOutsideThrowsExceptionWithProperMessage()
            {
                PlacedPlayer playerToBeOutside = new PlacedPlayer();
                PlacedPlayer playerToPlace = new PlacedPlayer(3, 3);

                IPlacementRule placementRule = new OutsidePlayer(playerToBeOutside, -4);
                PlacementException ex = Assert.Throws<PlacementException>(() => playerToPlace = placementRule.Place(playerToPlace));

                Assert.Equal("Can't place player negative distance outside player.", ex.Message);
            }
        }
    }
}
