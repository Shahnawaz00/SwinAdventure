using SwinAdventure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TestSwinAdventure
{
    [TestFixture]
    public class TestBag
    {
        //initializing 2 bags and 2 items 
        Bag bag;
        Bag purse;
        Item sword;
        Item bat;

        [SetUp]
        public void Setup()
        {
            bag = new Bag(new string[] { "bag" }, "bag", "This is a good bag");
            purse = new Bag(new string[] { "purse" }, "purse", "This is a purse");
            
            sword = new Item(new string[] { "Sword" }, "a bronze sword", "This is a bronze sword");
            bat = new Item(new string[] { "Bat" }, "a hard bat", "This is a hard bat");

            // adding a bag inside another bag, and 1 items in each
            bag.Inventory.Put(purse);
            bag.Inventory.Put(sword);
            purse.Inventory.Put(bat);
        }

        [Test]
        public void TestLocateItems()
        {
            //test if it can locate an item inside it and it remains there
            Assert.That(bag.Locate("sword"), Is.SameAs(sword));
            Assert.That(bag.Inventory.HasItem("sword"), Is.True);
        }

        [Test]
        public void TestLocateItself()
        { 
            Assert.That(bag.Locate("bag"), Is.SameAs(bag));
        }

        [Test]
        public void TestLocateNothing()
        {
            Assert.That(bag.Locate("apron"), Is.SameAs(null));
        }
        
        [Test]
        public void TestFullDescription()
        {
            Assert.That(bag.FullDescription,
                Is.EqualTo("In the bag you can see:\npurse (purse)\na bronze sword (sword)\n"));
        }

        [Test]
        public void TestBagInBag()
        {
            //test is the bag can locate another bag inside it
            Assert.That(bag.Locate("purse"), Is.SameAs(purse));
            Assert.That(bag.Locate("sword"), Is.SameAs(sword));

            //test if it cannot locate an item inside the bag its storing
            Assert.That(bag.Locate("bat"), Is.SameAs(null));
        }
    }
}
