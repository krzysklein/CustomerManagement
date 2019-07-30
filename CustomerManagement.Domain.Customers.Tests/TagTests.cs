using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CustomerManagement.Domain.Customers.Tests
{
    [TestClass]
    public class TagTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ShouldNotCreateTagWithoutName()
        {
            new Tag(name: null, color: new TagColor(Guid.Empty, "Black", "000000"));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ShouldNotCreateTagWithoutColor()
        {
            new Tag(name: "TestTag", color: null);
        }

        [TestMethod]
        public void ShouldCreateValidTag()
        {
            var tag = new Tag(name: "TestTag", color: new TagColor(Guid.Empty, "Black", "000000"));
        }
    }
}
