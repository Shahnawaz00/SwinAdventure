using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSwinAdventure
{
    [TestFixture]
    public class TestInventory
    {
        Inventory inventory;
        Item sword;
        Item bat;

        [SetUp]
        public void Setup()
        {
            inventory = new Inventory();
            sword = new Item(new string[] { "Sword" }, "a bronze sword", "This is a bronze sword");
            bat = new Item(new string[] { "Bat" }, "a hard bat", "This is a hard bat");
            inventory.Put(sword);
            inventory.Put(bat);
        }

        [Test]
        public void TestHasItem() 
        {
            Assert.That(inventory.HasItem("sword"), Is.True);
            Assert.That(inventory.HasItem("knife"), Is.False);
        }

        [Test]
        public void TestFetch()
        {
            Assert.That(inventory.Fetch("sword"), Is.SameAs(sword));
            Assert.That(inventory.HasItem("sword"), Is.True);
        }

        [Test]
        public void TestTake()
        {
            Assert.That(inventory.Take("sword"), Is.SameAs(sword));
            Assert.That(inventory.HasItem("sword"), Is.False);
        }

        [Test]
        public void TestItemList()
        {
            Assert.That(inventory.ItemList, Is.EqualTo("a bronze sword (sword)\na hard bat (bat)\n"));
        }
    }
}
