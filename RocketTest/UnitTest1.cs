using NUnit.Framework;
using Rocket;

namespace RocketTest {
    public class Tests {
        [SetUp]
        public void Setup() {
        }

        [Test]
        public void Test1() {
            Assert.AreEqual(Test.add(1, 1), 2);
        }
    }
}