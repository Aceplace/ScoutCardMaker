using OffensiveFormation.PlacementRules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace OffensiveFormation.Tests.PlacementRules
{
    public class RelativeToPlayerHorizontallyTests
    {
        public class PlaceMethodPlacingRight
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
                IPlacementRule placementRule = new RelativeToPlayerHorizontally(playerToBeToRightOf, distanceToRight, RelativeType.Right);
                playerToPlace = placementRule.Place(playerToPlace);

                Assert.Equal<Location>(expectedLocation, playerToPlace.location);
            }

            [Fact]
            public void PlacingPlayerZeroUnitsToRightThrowsException()
            {
                PlacedPlayer playerToBeToRightOf = new PlacedPlayer();
                PlacedPlayer playerToPlace = new PlacedPlayer(3, 3);

                IPlacementRule placementRule = new RelativeToPlayerHorizontally(playerToBeToRightOf, 0, RelativeType.Right);
                PlacementException ex = Assert.Throws<PlacementException>(() => playerToPlace = placementRule.Place(playerToPlace));

                Assert.Equal("Can't place 0 units relative.", ex.Message);
            }

            [Fact]
            public void PlacingPlayerNegativeUnitsToRightOfThrowsException()
            {
                PlacedPlayer playerToBeToRightOf = new PlacedPlayer();
                PlacedPlayer playerToPlace = new PlacedPlayer();

                IPlacementRule placementRule = new RelativeToPlayerHorizontally(playerToBeToRightOf, -7, RelativeType.Right);
                PlacementException ex = Assert.Throws<PlacementException>(() => playerToPlace = placementRule.Place(playerToPlace));

                Assert.Equal("Can't place player negative distance relative.", ex.Message);
            }
        }

        public class PlaceMethodPlacingLeft
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
                    IPlacementRule placementRule = new RelativeToPlayerHorizontally(playerToBeToLeftOf, distanceToLeft, RelativeType.Left);
                    playerToPlace = placementRule.Place(playerToPlace);

                    Assert.Equal<Location>(expectedLocation, playerToPlace.location);
                }

                [Fact]
                public void PlacingPlayerZeroUnitsToLeftThrowsException()
                {
                    PlacedPlayer playerToBeToLeftOf = new PlacedPlayer();
                    PlacedPlayer playerToPlace = new PlacedPlayer(3, 3);

                    IPlacementRule placementRule = new RelativeToPlayerHorizontally(playerToBeToLeftOf, 0, RelativeType.Left);
                    PlacementException ex = Assert.Throws<PlacementException>(() => playerToPlace = placementRule.Place(playerToPlace));

                    Assert.Equal("Can't place 0 units relative.", ex.Message);
                }

                [Fact]
                public void PlacingPlayerNegativeUnitsToLeftOfThrowsException()
                {
                    PlacedPlayer playerToBeToLeftOf = new PlacedPlayer();
                    PlacedPlayer playerToPlace = new PlacedPlayer();

                    IPlacementRule placementRule = new RelativeToPlayerHorizontally(playerToBeToLeftOf, -7, RelativeType.Left);
                    PlacementException ex = Assert.Throws<PlacementException>(() => playerToPlace = placementRule.Place(playerToPlace));

                    Assert.Equal("Can't place player negative distance relative.", ex.Message);
                }
            }
        }

        public class PlaceMethodPlacingInside
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
                IPlacementRule placementRule = new RelativeToPlayerHorizontally(playerToBeInside, distanceInside, RelativeType.Inside);
                playerToPlace = placementRule.Place(playerToPlace);

                Assert.Equal<Location>(expectedLocation, playerToPlace.location);
            }

            [Fact]
            public void PlacingPlayerInsidePlayerInMiddleThrowsExceptionWithProperMessage()
            {
                PlacedPlayer playerToBeInside = new PlacedPlayer();
                PlacedPlayer playerToPlace = new PlacedPlayer(3, 3);

                IPlacementRule placementRule = new RelativeToPlayerHorizontally(playerToBeInside, 1, RelativeType.Inside);
                PlacementException ex = Assert.Throws<PlacementException>(() => playerToPlace = placementRule.Place(playerToPlace));

                Assert.Equal("Can't place player inside/outside another player who is in center of formation.", ex.Message);
            }

            [Fact]
            public void PlacingPlayerZeroUnitsInsideThrowsExceptionWithProperMessage()
            {
                PlacedPlayer playerToBeInside = new PlacedPlayer();
                PlacedPlayer playerToPlace = new PlacedPlayer(3, 3);

                IPlacementRule placementRule = new RelativeToPlayerHorizontally(playerToBeInside, 0, RelativeType.Inside);
                PlacementException ex = Assert.Throws<PlacementException>(() => playerToPlace = placementRule.Place(playerToPlace));

                Assert.Equal("Can't place 0 units relative.", ex.Message);
            }

            [Fact]
            public void PlacingPlayerNegativeUnitsInsideThrowsExceptionWithProperMessage()
            {
                PlacedPlayer playerToBeInside = new PlacedPlayer();
                PlacedPlayer playerToPlace = new PlacedPlayer(3, 3);

                IPlacementRule placementRule = new RelativeToPlayerHorizontally(playerToBeInside, -4, RelativeType.Inside);
                PlacementException ex = Assert.Throws<PlacementException>(() => playerToPlace = placementRule.Place(playerToPlace));

                Assert.Equal("Can't place player negative distance relative.", ex.Message);
            }
        }

        public class PlaceMethodPlacingOutside
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
                                                                int distanceOutside, Location expectedLocation)
                {
                    IPlacementRule placementRule = new RelativeToPlayerHorizontally(playerToBeOutside, distanceOutside, RelativeType.Outside);
                    playerToPlace = placementRule.Place(playerToPlace);

                    Assert.Equal<Location>(expectedLocation, playerToPlace.location);
                }

                [Fact]
                public void PlacingPlayerOutsidePlayerInMiddleThrowsExceptionWithProperMessage()
                {
                    PlacedPlayer playerToBeOutside = new PlacedPlayer();
                    PlacedPlayer playerToPlace = new PlacedPlayer(3, 3);

                    IPlacementRule placementRule = new RelativeToPlayerHorizontally(playerToBeOutside, 1, RelativeType.Outside);
                    PlacementException ex = Assert.Throws<PlacementException>(() => playerToPlace = placementRule.Place(playerToPlace));

                    Assert.Equal("Can't place player inside/outside another player who is in center of formation.", ex.Message);
                }

                [Fact]
                public void PlacingPlayerZeroUnitsOutsideThrowsExceptionWithProperMessage()
                {
                    PlacedPlayer playerToBeOutside = new PlacedPlayer();
                    PlacedPlayer playerToPlace = new PlacedPlayer(3, 3);

                    IPlacementRule placementRule = new RelativeToPlayerHorizontally(playerToBeOutside, 0, RelativeType.Outside);
                    PlacementException ex = Assert.Throws<PlacementException>(() => playerToPlace = placementRule.Place(playerToPlace));

                    Assert.Equal("Can't place 0 units relative.", ex.Message);
                }

                [Fact]
                public void PlacingPlayerNegativeUnitsOutsideThrowsExceptionWithProperMessage()
                {
                    PlacedPlayer playerToBeOutside = new PlacedPlayer();
                    PlacedPlayer playerToPlace = new PlacedPlayer(3, 3);

                    IPlacementRule placementRule = new RelativeToPlayerHorizontally(playerToBeOutside, -4, RelativeType.Outside);
                    PlacementException ex = Assert.Throws<PlacementException>(() => playerToPlace = placementRule.Place(playerToPlace));

                    Assert.Equal("Can't place player negative distance relative.", ex.Message);
                }
            }
        }
    }
}
