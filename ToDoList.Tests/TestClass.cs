using System;
using NUnit.Framework;
using ToDoList;

namespace ToDoList.Tests
{
    [TestFixture]
    public class TestClass
    {
       [Test]
        public void TestMethod()
        {
            IntPtr handle = IntPtr.Zero;
            var controller = new ViewController(handle);
            Assert.IsNotNull(controller);
        }
    }
}
