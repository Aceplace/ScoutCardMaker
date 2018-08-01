using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace OffensiveFormation.Tests
{
    public class PlacedPlayerTests
    {
        public class ConstructorMethod
        {
            [Fact]
            public void DefaultConstructorCorrectlyPlacesPlayer()
            {
                PlacedPlayer placedPlayer = new PlacedPlayer();
                Location expectedLocation = new Location(0, 0);

                Assert.Equal(expectedLocation, placedPlayer.PlacedLocation);
            }

            [Fact]
            public void OverrideConstructorCorrectlyPlacesPlayer_01()
            {
                PlacedPlayer placedPlayer = new PlacedPlayer(7, -5);
                Location expectedLocation = new Location(7, -5);

                Assert.Equal(expectedLocation, placedPlayer.PlacedLocation);
            }
        }
    }
}
