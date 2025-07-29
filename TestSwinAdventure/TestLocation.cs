using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Path = SwinAdventure.Path;

namespace TestSwinAdventure
{
    [TestFixture]
    public class TestLocation
    {
        //initialize variables
        Location location;
        Location destination;
        Path path;
        Player player;
        Item sword;

        [SetUp]
        public void Setup ()
        {
            
            location = new Location ("a garden", "This is a garden");
            destination = new Location("a house", "This is a house");
            path = new Path(new string[] { "south" }, "south", "this is south", destination);
            player = new Player("shah", "the student");
            sword = new Item(new string[] { "Sword" }, "a bronze sword", "This is a bronze sword");

            // add item to location, and set player's location
            location.Inventory.Put(sword);
            player.Location = location;
        }

        // test if location can identify itself
        [Test]  
        public void TestIdentifyLocation ()
        {
            Assert.That(location.Locate("room"), Is.SameAs(location));
        }

        //test if location can identify an item in its inventory
        [Test]
        public void TestIdentifyItemsInLocation ()
        {
            Assert.That(location.Locate("sword"), Is.SameAs(sword));
        }

        // test that player can locate an item in its location
        [Test]
        public void TestIdentifyItemsInPlayerLocation()
        {
            Assert.That(player.Locate("sword"), Is.SameAs(sword));
        }

        //test that location can locate its paths
        [Test]
        public void TestIdentifyPath()
        {
            location.AddPath(path);
            Assert.That(player.Locate("south"), Is.SameAs(path));
        }

        //test location's full description
        [Test]
        public void TestLocationFullDescription()
        {
            string actual = location.FullDescription;
            string expected = "You are in a garden\nThis is a garden\nThere are no exits.\nIn this room you can see:\na bronze sword (sword)\n";

            Assert.That (actual, Is.EqualTo(expected));
        }

        [Test]
        public void TestLocationFullDescriptionWithPath()
        {
            location.AddPath(path);
            string actual = location.FullDescription;
            string expected = "You are in a garden\nThis is a garden\nThere are exists to the south.\nIn this room you can see:\na bronze sword (sword)\n";

            Assert.That(actual, Is.EqualTo(expected));
        }

    }
}
