using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class Bag : Item, IHaveInventory
    {
        //local variables
        private Inventory _inventory;

        //constructor
        public Bag(string[] ids, string name, string desc):base(ids, name, desc)
        {
            _inventory = new Inventory();
        }

        //methods
        public GameObject Locate(string id)
        {
            if (AreYou(id))
            {
                return this;
            }
            else if (_inventory.HasItem(id))
            {
                return _inventory.Fetch(id);
            }
            else return null;
        }

        //properties
        public override string FullDescription
        {
            get
            {
                return $"In the {Name} you can see:\n" + _inventory.ItemList;
            }
        }

        public Inventory Inventory
        {
            get
            {
                return _inventory;
            }
        }
    }
}