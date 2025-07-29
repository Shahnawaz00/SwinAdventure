using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class Player : GameObject, IHaveInventory
    {
        //local variables
        // inventory of items of the player
        private Inventory _inventory;
        private Location _location;

        //comstructor
        public Player(string name, string desc) : base(new string[] {"me", "inventory"}, name, desc) 
        {
            _inventory = new Inventory();
        }
         
        //methods

        //locate method that returns a gameobject based on the id.
        // for now it only returns the player itself if any of the above identifiers are entereed
        // or returns items that exists in its inventory
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
            else if (_location != null)
            {
                return _location.Locate(id);
            }
            else return null;
        }

        public void Move(Path path)
        {
            _location = path.Destination;
        }
        //properties

        // override FullDescription property to include the player's name, and the shortdescription of themselves and their items in their inventory
        public override string FullDescription
        {
            get
            {
                return $"You are {Name}, {Description}.\nYou are carrying:\n{_inventory.ItemList}";
            }
        }

        public Inventory Inventory
        {
            get
            {
                return _inventory;
            }
        }
        public Location Location
        {
            get
            {
                return _location;
            }
            set
            {
                _location = value;
            }
        }
    }
}
