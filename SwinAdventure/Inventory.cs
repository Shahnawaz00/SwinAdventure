using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class Inventory
    {
        //local variables
        // collection of items
        private List<Item> _items;

        //constructor 
        public Inventory() 
        {
            _items = new List<Item>();
        }

        //methods

        // check if the collection has the specific item using AreYou method inherited from IdentifiableObject
        public bool HasItem(string id)
        {
            return _items.Any(item => item.AreYou(id));
        }

        // add item to collection
        public void Put(Item itm)
        {
            _items.Add(itm);
        }

        // Take item by removing it from the collection and returning it 
        public Item Take(string id)
        {
            Item itm = this.Fetch(id);

            if (itm != null)
            {
                _items.Remove(itm);
            }

            return itm;
        }
   
        // find the specific item and return it (collection is not modified)
        public Item Fetch(string id)
        {
            foreach (Item itm in _items)
            {
                if (itm.AreYou(id))
                {
                    return itm;
                }
            }
            return null;
        }

        // properties

        //itemlist returns a string of all the short descriptions of the items in the collection
        public string ItemList
        {
            get
            {
                string itemList = "";

                foreach (Item itm in _items)
                {
                    itemList += $"{itm.ShortDescription}\n";
                }
                return itemList;
            }
        }
    }
}
