using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Path = SwinAdventure.Path;

namespace TestSwinAdventure
{
    [TestFixture]
    public class TestPath
    {
        Path path;
        Location garden;

        [SetUp]
        public void Setup()
        {
            garden = new Location("a garden", "This is a garden");
            path = new Path(new string[] { "south", "s" }, "south", "this is south", garden);

        }
        [Test]
        public void TestPathIsIdentifiable()
        {
            Assert.That(path.AreYou("south"), Is.True);
            Assert.That(path.AreYou("s"), Is.True);
            Assert.That(path.AreYou("north"), Is.False);
        }

        [Test]
        public void TestFullDescription()
        {
            string actual = path.FullDescription;
            string expected = "At south lies a garden";

            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}
