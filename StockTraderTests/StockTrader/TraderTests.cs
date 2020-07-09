using System;
using NUnit.Framework;

namespace stockTrader
{
    [TestFixture]
    public class TraderTests
    {
        
        [Test] // Bid was lower than price, Buy() should return false.
        public void TestBidLowerThanPrice()
        {
            // Arrange
            // MockTrader returns 400.25 price by default


            // Act

            // Assert
        }

        [Test] // bid was equal or higher than price, Buy() should return true.
        public void TestBidHigherThanPrice()
        {
        }
    }
}