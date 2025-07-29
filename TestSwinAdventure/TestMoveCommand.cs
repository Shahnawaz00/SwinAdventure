using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Path = SwinAdventure.Path;

namespace TestSwinAdventure
{
    public class TestMoveCommand
    {
        MoveCommand move;
        Location location;
        Location destination;
        Path path;
        Player player;

        [SetUp]
        public void Setup()
        {
            move = new MoveCommand();
            location = new Location("a garden", "This is a garden");
            destination = new Location("a house", "This is a house");
            path = new Path(new string[] { "south" }, "south", "this is south", destination);
            player = new Player("shah", "the student");

            player.Location = location;
            location.AddPath(path);
        }

        [Test]
        public void TestMovePlayer()
        {
            Assert.That(player.Location, Is.SameAs(location));
            move.Execute(player, new string[] { "move", "south" });
            Assert.That(player.Location, Is.SameAs(destination));
        }

        [Test]
        public void TestInvalidMovePlayer()
        {
            Assert.That(player.Location, Is.SameAs(location));
            move.Execute(player, new string[] { "move", "north" });
            Assert.That(player.Location, Is.SameAs(location));
        }

        [TestCase("move")]
        [TestCase("head")]
        [TestCase("go")]
        [TestCase("leave")]
        public void TestIdentifiers(string toTest)
        {
            move.Execute(player, new string[] { toTest, "south" });
            Assert.That(player.Location, Is.SameAs(destination));
        }

        [Test]
        public void TestSuccessfulMoveOutput()
        {
            string actual = move.Execute(player, new string[] { "move", "south" });
            string expected = "You head south\nYou have arrived in a house";

            Assert.That(actual, Is.EqualTo(expected));
        }

        //errors

        [Test]
        public void TestIncorrectLength()
        {
            string actual = move.Execute(player, new string[] { "move", "at", "north" });
            string expected = "I don't know how to move like that";

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void TestInvalidCommand()
        {
            string actual = move.Execute(player, new string[] { "letsgo", "south" });
            string expected = "Error in move input";

            Assert.That(actual, Is.EqualTo(expected));

        }

        [Test]
        public void TestOnlyMoveInput()
        {
            string actual = move.Execute(player, new string[] { "move" });
            string expected = "Where do you want to move?";

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void TestInvalidDirection()
        {
            string actual = move.Execute(player, new string[] { "move", "north" });
            string expected = "Error in direction!";

            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}
