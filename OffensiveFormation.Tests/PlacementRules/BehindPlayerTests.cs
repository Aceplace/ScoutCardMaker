using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using OffensiveFormation.PlacementRules;

namespace OffensiveFormation.Tests.PlacementRules
{
    public class BehindPlayerTests
    {
        public class PlaceMethod
        {
            [Fact]
            public void PlacesPlayerCorrectlyBehindOther_01()
            {
                PlacedPlayer playerToBeBehind = new PlacedPlayer();
                PlacedPlayer playerToPlace = new PlacedPlayer();
                Location expectedLocation = new Location(0, 1);

                IPlacementRule placementRule = new BehindPlayer(playerToBeBehind, 1);
                playerToPlace = placementRule.Place(playerToPlace);

                Assert.Equal<Location>(expectedLocation, playerToPlace.Location);
            }


            [Fact]
            public void PlacesPlayerCorrectlyBehindOther_02()
            {
                PlacedPlayer playerToBeBehind = new PlacedPlayer(7, 2);
                PlacedPlayer playerToPlace = new PlacedPlayer();
                Location expectedLocation = new Location(7, 5);

                IPlacementRule placementRule = new BehindPlayer(playerToBeBehind, 3);
                playerToPlace = placementRule.Place(playerToPlace);

                Assert.Equal<Location>(expectedLocation, playerToPlace.Location);
            }

            [Fact]
            public void PlacingPlayerZeroUnitsBehindThrowsExceptionWithProperMessage()
            {
                PlacedPlayer playerToBeBehind = new PlacedPlayer();
                PlacedPlayer playerToPlace = new PlacedPlayer();

                IPlacementRule placementRule = new BehindPlayer(playerToBeBehind, 0);
                PlacementException ex = Assert.Throws<PlacementException>(() => placementRule.Place(playerToPlace));

                Assert.Equal("Can't place 0 units behind.", ex.Message);
            }

            [Fact]
            public void PlacingPlayerNegativeUnitsBehindThrowsExceptionWithProperMessage()
            {
                PlacedPlayer playerToBeBehind = new PlacedPlayer();
                PlacedPlayer playerToPlace = new PlacedPlayer();

                IPlacementRule placementRule = new BehindPlayer(playerToBeBehind, -6);
                PlacementException ex = Assert.Throws<PlacementException>(() => placementRule.Place(playerToPlace));

                Assert.Equal("Can't place player negative units behind player.", ex.Message);
            }
        }
    }
}
