using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CustomerManagement.Domain.Customers.Tests
{
    [TestClass]
    public class TagColorTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ShouldNotCreateTagColorWithoutValue()
        {
            new TagColor(id: Guid.Empty, name: "Black", colorValue: null);
        }

        [TestMethod]
        public void ShouldCreateValidTagColor()
        {
            new TagColor(id: Guid.Empty, name: "Black", colorValue: "000000");
        }
    }
}
