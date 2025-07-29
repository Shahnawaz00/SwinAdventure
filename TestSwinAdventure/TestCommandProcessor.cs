using NUnit.Framework.Internal;
using Path = SwinAdventure.Path;

namespace TestSwinAdventure
{
    [TestFixture]
    public class TestCommandProcessor
    {
        CommandProcessor command = new CommandProcessor();
        Player player;
        //for look command
        Item gem;

        // for move command
        Location location;
        Location destination;
        Path path;

        [SetUp]
        public void SetUp()
        {
            player = new Player("shah", "the student");

           
            gem = new Item(new string[] { "gem" }, "a gem", "a bright red crystal");
            player.Inventory.Put(gem);

            location = new Location("a garden", "This is a garden");
            destination = new Location("a house", "This is a house");
            path = new Path(new string[] { "south" }, "south", "this is south", destination);

            player.Location = location;
            location.AddPath(path);
        }

        [Test]
        public void TestExecuteLook()
        {
            string actual = command.Execute(player, new string[] { "look", "at", "gem" });
            string expected = "a bright red crystal";

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void TestExecuteMove()
        {
            Assert.That(player.Location, Is.SameAs(location));
            command.Execute(player, new string[] { "move", "south" });
            Assert.That(player.Location, Is.SameAs(destination));
        }


    }
}