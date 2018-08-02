﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace OffensiveFormation.Tests
{
    public class PlacedFormationTests
    {
        #region lineman method tests
        public class GetStrongGuardMethod
        {
            [Fact]
            public void ReturnsRightGuardIfStrongSideIsRight()
            {
                PlacedFormation placedFormation = new PlacedFormation();
                PlacedPlayer expectedPlayer = placedFormation.RightGuard;
                placedFormation.StrongSide = Direction.Right;

                PlacedPlayer returnedPlayer = placedFormation.GetStrongGuard();
                bool samePlayer = ReferenceEquals(returnedPlayer, expectedPlayer);

                Assert.True(samePlayer);
            }

            [Fact]
            public void ReturnsLeftGuardIfStrongSideIsLeft()
            {
                PlacedFormation placedFormation = new PlacedFormation();
                PlacedPlayer expectedPlayer = placedFormation.LeftGuard;
                placedFormation.StrongSide = Direction.Left;

                PlacedPlayer returnedPlayer = placedFormation.GetStrongGuard();
                bool samePlayer = ReferenceEquals(returnedPlayer, expectedPlayer);

                Assert.True(samePlayer);
            }
        }

        public class GetWeakGuardMethod
        {
            [Fact]
            public void ReturnsRightGuardIfStrongSideIsLeft()
            {
                PlacedFormation placedFormation = new PlacedFormation();
                PlacedPlayer expectedPlayer = placedFormation.RightGuard;
                placedFormation.StrongSide = Direction.Left;

                PlacedPlayer returnedPlayer = placedFormation.GetWeakGuard();
                bool samePlayer = ReferenceEquals(returnedPlayer, expectedPlayer);

                Assert.True(samePlayer);
            }

            [Fact]
            public void ReturnsLeftGuardIfStrongSideIsRight()
            {
                PlacedFormation placedFormation = new PlacedFormation();
                PlacedPlayer expectedPlayer = placedFormation.LeftGuard;
                placedFormation.StrongSide = Direction.Right;

                PlacedPlayer returnedPlayer = placedFormation.GetWeakGuard();
                bool samePlayer = ReferenceEquals(returnedPlayer, expectedPlayer);

                Assert.True(samePlayer);
            }
        }

        public class GetStrongTackleMethod
        {
            [Fact]
            public void ReturnsRightTackleIfStrongSideIsRight()
            {
                PlacedFormation placedFormation = new PlacedFormation();
                PlacedPlayer expectedPlayer = placedFormation.RightTackle;
                placedFormation.StrongSide = Direction.Right;

                PlacedPlayer returnedPlayer = placedFormation.GetStrongTackle();
                bool samePlayer = ReferenceEquals(returnedPlayer, expectedPlayer);

                Assert.True(samePlayer);
            }

            [Fact]
            public void ReturnsLeftTackleIfStrongSideIsLeft()
            {
                PlacedFormation placedFormation = new PlacedFormation();
                PlacedPlayer expectedPlayer = placedFormation.LeftTackle;
                placedFormation.StrongSide = Direction.Left;

                PlacedPlayer returnedPlayer = placedFormation.GetStrongTackle();
                bool samePlayer = ReferenceEquals(returnedPlayer, expectedPlayer);

                Assert.True(samePlayer);
            }
        }

        public class GetWeakTackleMethod
        {
            [Fact]
            public void ReturnsRightTackleIfStrongSideIsLeft()
            {
                PlacedFormation placedFormation = new PlacedFormation();
                PlacedPlayer expectedPlayer = placedFormation.RightTackle;
                placedFormation.StrongSide = Direction.Left;

                PlacedPlayer returnedPlayer = placedFormation.GetWeakTackle();
                bool samePlayer = ReferenceEquals(returnedPlayer, expectedPlayer);

                Assert.True(samePlayer);
            }

            [Fact]
            public void ReturnsLeftTackleIfStrongSideIsRight()
            {
                PlacedFormation placedFormation = new PlacedFormation();
                PlacedPlayer expectedPlayer = placedFormation.LeftTackle;
                placedFormation.StrongSide = Direction.Right;

                PlacedPlayer returnedPlayer = placedFormation.GetWeakTackle();
                bool samePlayer = ReferenceEquals(returnedPlayer, expectedPlayer);

                Assert.True(samePlayer);
            }
        }
        #endregion 


        static class NumberedSkillPlayersPlacedFormationTestData
        {
            public static PlacedFormation[] testPlacedFormations;

            static NumberedSkillPlayersPlacedFormationTestData()
            {
                testPlacedFormations = new PlacedFormation[4];
                testPlacedFormations[0] = new PlacedFormation();
                testPlacedFormations[0].SkillPlayers[0].SetLocation(20, 5);
                testPlacedFormations[0].SkillPlayers[1].SetLocation(18, 10);
                testPlacedFormations[0].SkillPlayers[2].SetLocation(10, 5);
                testPlacedFormations[0].SkillPlayers[3].SetLocation(15, 4);
                testPlacedFormations[0].SkillPlayers[4].SetLocation(-5, 5);
                testPlacedFormations[0].SkillPlayers[5].SetLocation(0, 5);

                testPlacedFormations[1] = new PlacedFormation();
                testPlacedFormations[1].SkillPlayers[0].SetLocation(20, 5);
                testPlacedFormations[1].SkillPlayers[1].SetLocation(18, 10);
                testPlacedFormations[1].SkillPlayers[2].SetLocation(15, 5);
                testPlacedFormations[1].SkillPlayers[3].SetLocation(15, 4);
                testPlacedFormations[1].SkillPlayers[4].SetLocation(-5, 5);
                testPlacedFormations[1].SkillPlayers[5].SetLocation(0, 5);

                testPlacedFormations[2] = new PlacedFormation();
                testPlacedFormations[2].SkillPlayers[0].SetLocation(20, 5);
                testPlacedFormations[2].SkillPlayers[1].SetLocation(18, 10);
                testPlacedFormations[2].SkillPlayers[2].SetLocation(15, 4);
                testPlacedFormations[2].SkillPlayers[3].SetLocation(15, 5);
                testPlacedFormations[2].SkillPlayers[4].SetLocation(-5, 5);
                testPlacedFormations[2].SkillPlayers[5].SetLocation(0, 5);

                testPlacedFormations[3] = new PlacedFormation();
                testPlacedFormations[3].SkillPlayers[0].SetLocation(-20, 5);
                testPlacedFormations[3].SkillPlayers[1].SetLocation(10, 10);
                testPlacedFormations[3].SkillPlayers[2].SetLocation(5, 4);
                testPlacedFormations[3].SkillPlayers[3].SetLocation(-10, 5);
                testPlacedFormations[3].SkillPlayers[4].SetLocation(-5, 5);
                testPlacedFormations[3].SkillPlayers[5].SetLocation(-15, 5);
            }
        }


        public class GetNumberedSkillRightMethod
        {
            public static IEnumerable<object[]> GetsCorrectPlayerFromOutsideInTestData()
            {
                yield return new object[] { NumberedSkillPlayersPlacedFormationTestData.testPlacedFormations[0], 1, 0 };
                yield return new object[] { NumberedSkillPlayersPlacedFormationTestData.testPlacedFormations[0], 2, 1 };
                yield return new object[] { NumberedSkillPlayersPlacedFormationTestData.testPlacedFormations[0], 3, 3 };
                yield return new object[] { NumberedSkillPlayersPlacedFormationTestData.testPlacedFormations[0], 4, 2 };
                yield return new object[] { NumberedSkillPlayersPlacedFormationTestData.testPlacedFormations[0], 5, 5 };
                yield return new object[] { NumberedSkillPlayersPlacedFormationTestData.testPlacedFormations[0], 6, 4 };
                yield return new object[] { NumberedSkillPlayersPlacedFormationTestData.testPlacedFormations[1], 3, 3 };
                yield return new object[] { NumberedSkillPlayersPlacedFormationTestData.testPlacedFormations[2], 3, 2 };
                yield return new object[] { NumberedSkillPlayersPlacedFormationTestData.testPlacedFormations[2], 3, 2 };
                yield return new object[] { NumberedSkillPlayersPlacedFormationTestData.testPlacedFormations[3], 1, 1 };
                yield return new object[] { NumberedSkillPlayersPlacedFormationTestData.testPlacedFormations[3], 2, 2 };
                yield return new object[] { NumberedSkillPlayersPlacedFormationTestData.testPlacedFormations[3], 3, 4 };
                yield return new object[] { NumberedSkillPlayersPlacedFormationTestData.testPlacedFormations[3], 4, 3 };
                yield return new object[] { NumberedSkillPlayersPlacedFormationTestData.testPlacedFormations[3], 5, 5 };
                yield return new object[] { NumberedSkillPlayersPlacedFormationTestData.testPlacedFormations[3], 6, 0 };
            }

            [Theory]
            [MemberData(nameof(GetsCorrectPlayerFromOutsideInTestData))]
            public void GetsCorrectPlayerFromOutsideIn(PlacedFormation placedFormation, int number, int expectedPlayerIndex)
            {
                PlacedPlayer expectedPlayer = placedFormation.SkillPlayers[expectedPlayerIndex];

                PlacedPlayer returnedPlayer = placedFormation.GetNumberedSkillRight(FlowDirection.OutsideIn, number);
                bool samePlayer = ReferenceEquals(expectedPlayer, returnedPlayer);

                Assert.True(samePlayer);
            }

            [Fact]
            public void PassingNegativeValueThrowsExceptionWithProperMessage()
            {
                PlacedFormation placedFormation = new PlacedFormation();
                PlacedFormationException ex = Assert.Throws<PlacedFormationException>(() => placedFormation.GetNumberedSkillRight(FlowDirection.OutsideIn, -3));

                Assert.Equal("Can't get negative numbered skill player.", ex.Message);
            }

            [Fact]
            public void Passing0ThrowsExceptionWithProperMessage()
            {
                PlacedFormation placedFormation = new PlacedFormation();
                PlacedFormationException ex = Assert.Throws<PlacedFormationException>(() => placedFormation.GetNumberedSkillRight(FlowDirection.OutsideIn, 0));

                Assert.Equal("Can't get 0 numbered skill player.", ex.Message);
            }

            [Fact]
            public void PassingTooLargeAValueThrowsExceptionWithProperMessage()
            {
                PlacedFormation placedFormation = new PlacedFormation();
                PlacedFormationException ex = Assert.Throws<PlacedFormationException>(() => placedFormation.GetNumberedSkillRight(FlowDirection.OutsideIn, 7));

                Assert.Equal("Can't get numbers skill player larger then 6. There are only 6 skill players.", ex.Message);
            }
        }
    }
}
