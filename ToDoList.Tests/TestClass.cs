using System;
using NUnit.Framework;

namespace ToDoList.Tests
{
    [TestFixture]
    public class TestClass
    {
        public TestClass()
        {
        }

        [Test]
        public void TestMethod1()
        {
            Assert.That(1, Is.EqualTo(1));
        }
    }
}
