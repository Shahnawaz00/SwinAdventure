using NUnit.Framework.Internal;

namespace TestSwinAdventure 
{
    [TestFixture]
    public class TestIdentifiableObject
    {
        IdentifiableObject id;
        IdentifiableObject emptyId;

        [SetUp]
        public void SetUp()
        {
            id = new IdentifiableObject(new string[] { "SHAH", "shehraz" });
            emptyId = new IdentifiableObject(new string[] { });
        } 

        [Test]
        public void TestAreYou()
        {
            Assert.That(id.AreYou("shah"), Is.True);
        }

        [Test]
        public void TestNotAreYou()
        {
            Assert.That(id.AreYou("paul"), Is.False);
        }

        [Test]
        public void TestCaseSensitive()
        {
            Assert.That(id.AreYou("sHaH"), Is.True);
        }

        [Test]
        public void TestFirstId()
        {
            Assert.That(id.FirstId, Is.EqualTo("shah"));
        }

        [Test]
        public void TestFirstIdWithNoIds()
        {
            Assert.That(emptyId.FirstId, Is.EqualTo(""));
        }

        [Test]
        public void TestAddId()
        {
            id.AddIdentifier("jacob");
            Assert.That(id.AreYou("jacob"), Is.True);
        }

    }
}