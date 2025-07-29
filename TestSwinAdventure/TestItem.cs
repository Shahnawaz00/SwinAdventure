﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSwinAdventure
{
    [TestFixture]
    public class TestItem
    {
        Item sword;

        [SetUp]
        public void Setup()
        {
            sword = new Item(new string[] { "Sword" }, "a bronze sword", "This is a bronze sword");
        }

        [Test]
        public void TestItemIsIdentifiable()
        {
            Assert.That(sword.AreYou("sword"), Is.True);
            Assert.That(sword.AreYou("knife"), Is.False);
        }

        [Test]
        public void TestShortDescription()
        {
            Assert.That(sword.ShortDescription, Is.EqualTo("a bronze sword (sword)"));
        }

        [Test]
        public void TestFullDescription()
        {
            Assert.That(sword.FullDescription, Is.EqualTo("This is a bronze sword"));
        }
    }
}
