using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using OffensiveFormation;

namespace OffensiveFormation.Tests
{
    public class LocationTests
    {
        public class ConstructorMethod
        {
            [Fact]
            public void DefaultProperlySetsXAndYPosition()
            {
                Location location = new Location();

                Assert.Equal(0, location.X);
                Assert.Equal(0, location.Y);
            }

            [Theory]
            [InlineData(3, 4)]
            [InlineData(-4, 7)]
            [InlineData(-12, 5)]
            public void ProperlySetsXAndYPosition(int givenX, int givenY)
            {
                Location location = new Location(givenX, givenY);

                Assert.Equal(givenX, location.X);
                Assert.Equal(givenY, location.Y);
            }
        }

        public class EqualsMethod
        {
            public static IEnumerable<object[]> GetEqualLocationsForTestData()
            {
                yield return new object[] { new Location(), new Location() };
                yield return new object[] { new Location(3, 4), new Location(3, 4) };
                yield return new object[] { new Location(-5, 7), new Location(-5, 7) };
                yield return new object[] { new Location(), new Location(0, 0) };
            }

            public static IEnumerable<object[]> GetNonEqualLocationsForTestData()
            {
                yield return new object[] { new Location(), new Location(1, 3) };
                yield return new object[] { new Location(-5, 7), new Location(-4, 10) };
                yield return new object[] { new Location(-5, 7), new Location(12, 2) };
                yield return new object[] { new Location(7, 2), new Location(-4, 5) };
            }

            [Theory]
            [MemberData(nameof(GetEqualLocationsForTestData))]
            public void EqualValuesGiveTrue(Location location1, Location location2)
            {
                bool equal = location1.Equals(location2);
                    
                Assert.True(equal);
            }

            [Theory]
            [MemberData(nameof(GetNonEqualLocationsForTestData))]
            public void NonEqualValuesGiveFalse(Location location1, Location location2)
            {
                bool equal = location1.Equals(location2);

                Assert.False(equal);
            }
        }
    }
}
