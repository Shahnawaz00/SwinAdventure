using SwinAdventure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSwinAdventure
{
    [TestFixture]
    public class TestLookCommand
    {
        LookCommand look;
        Player player;
        Bag bag;
        Item gem;
        Location location;

        [SetUp]
        public void Setup()
        {
            look = new LookCommand();
            player = new Player("shah", "the student");
            bag = new Bag(new string[] { "bag" }, "bag", "This is a bag");
            gem = new Item(new string[] { "gem" }, "a gem", "a bright red crystal");
            location = new Location("garden", "This is a garden");
        }

        // test looking at your own inventory
        [Test]
        public void TestLookAtMe()
        {
            string actual = look.Execute(player, new string[] { "look", "at", "inventory" });
            string expected = "You are shah, the student.\nYou are carrying:\n";

            Assert.That(actual, Is.EqualTo(expected));
        }

        // test looking at a gem
        [Test]
        public void TestLookAtGem()
        {
            player.Inventory.Put(gem);

            string actual = look.Execute(player, new string[] { "look", "at", "gem" });
            string expected = "a bright red crystal";

            Assert.That(actual, Is.EqualTo(expected));
        }

        //test looking at a non existent item in your inventory
        [Test]
        public void TestLookAtUnknown()
        {
            string actual = look.Execute(player, new string[] { "look", "at", "gem" });
            string expected = "I can't find the gem";

            Assert.That(actual, Is.EqualTo(expected));
        }

        // test looking at gem in your own inventory
        [Test]
        public void TestLookAtGemInMe()
        {
            player.Inventory.Put(gem);

            string actual = look.Execute(player, new string[] { "look", "at", "gem", "in", "inventory" });
            string expected = "a bright red crystal";

            Assert.That(actual, Is.EqualTo(expected));
        }

        //test looking at gem in your bag
        [Test]
        public void TestLookAtGemInBag()
        {
            bag.Inventory.Put(gem);
            player.Inventory.Put(bag);

            string actual = look.Execute(player, new string[] { "look", "at", "gem", "in", "bag" });
            string expected = "a bright red crystal";

            Assert.That(actual, Is.EqualTo(expected));
        }

        //test looking at gem in a bag that you dont have 
        [Test]
        public void TestLookAtGemInNoBag()
        {
            player.Inventory.Put(gem);

            string actual = look.Execute(player, new string[] { "look", "at", "gem", "in", "bag" });
            string expected = "I can't find the bag";

            Assert.That(actual, Is.EqualTo(expected));
        }

        // test looking at non existent item in your bag
        [Test]
        public void TestLookAtNoGemInBag()
        {
            player.Inventory.Put(bag);

            string actual = look.Execute(player, new string[] { "look", "at", "gem", "in", "bag" });
            string expected = "I can't find the gem";

            Assert.That(actual, Is.EqualTo(expected));
        }

        //test "look" to look at player's location
        [Test]
        public void TestPlayerLocation()
        {
            player.Location = location;
            string actual = look.Execute(player, new string[] { "look" });
            Assert.That(actual, Is.EqualTo(location.FullDescription));
        }

        //test error with invalid input

        //invalid look command
        [Test]
        public void TestInvalidLook()
        {
            string actual = look.Execute(player, new string[] { "find", "the", "gem" });
            string expected = "Error in look input";

            Assert.That(actual, Is.EqualTo(expected));
        }

        // invalid number of inputs
        [TestCaseSource(nameof(InvalidLengthTestCases))]
        public void TestInvalidLength(string[] toTest )
        {
            Assert.That(look.Execute(player, toTest), 
                Is.EqualTo("I don't know how to look like that"));
        } 
        private static IEnumerable<string[]> InvalidLengthTestCases()
        {
            yield return new string[] { "look","bag" };
            yield return new string[] { "look", "at", "gem", "in", "the", "bag" };
            yield return new string[] { "look", "at", "big", "bag" };
        }

        // invalid command for 2nd input "at"
        [Test]
        public void TestInvalidAt()
        {
            string actual = look.Execute(player, new string[] { "look", "in", "gem" });
            string expected = "What do you want to look at?";

            Assert.That(actual, Is.EqualTo(expected));
        }

        //invalid command for 4th input "in"
        [Test]
        public void TestInvalidIn()
        {
            string actual = look.Execute(player, new string[] { "look", "at", "gem", "at", "bag" });
            string expected = "What do you want to look in?";

            Assert.That(actual, Is.EqualTo(expected));
        }


    }
}
