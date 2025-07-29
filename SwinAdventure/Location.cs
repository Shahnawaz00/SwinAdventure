﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class Location : GameObject, IHaveInventory
    {
        //local variables
        private Inventory _inventory;
        private List<Path> _paths;

        //constructor
        public Location(string name, string desc) : base(new string[] {"room", "here"}, name, desc) 
        {
            _inventory = new Inventory();
            _paths = new List<Path>();
        }

        //methods
        public GameObject Locate(string id)
        {
            //identify itself
            if (AreYou(id))
            {
                return this;
            }
            //identify the items in its inventory
            else if (_inventory.HasItem(id))
            {
                return _inventory.Fetch(id);
            }
            //identify paths in this location
            else if (_paths.Count >= 1)
            {
                foreach (Path p in _paths)
                {
                    if (p.AreYou(id))
                    {
                        return p;
                    }
                }
                return null;
            }
            else return null;
        }

        public void AddPath(Path path)
        {
            _paths.Add(path);
        }

        //properties
        public string PathList
        {
            get
            {
                string pathList = "";

                if (_paths.Count > 0)
                {
                    for (int i = 0; i < _paths.Count; i++)
                    {
                        if (_paths.Count == 1)
                        {
                            pathList += $"{_paths[i].Name}";
                        }
                        else if (i == _paths.Count - 1)
                        {
                            pathList += $"and {_paths[i].Name}";
                        }
                        else
                        {
                            if (_paths.Count == 1)
                            {
                                pathList += $"{_paths[i].Name}, ";
                            }
                        }
                    }
                    return $"There are exists to the {pathList}.";
                }
                else
                {
                    return "There are no exits.";
                }

            }
        }
        public override string FullDescription
        {
            get
            {
                return $"You are in {Name}\n{Description}\n{PathList}\nIn this room you can see:\n{_inventory.ItemList}";
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
