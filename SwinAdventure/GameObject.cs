﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public abstract class GameObject : IdentifiableObject
    {
        //local variables
        private string _name;
        private string _description;

        //constructor 
        public GameObject(string[] ids, string name, string desc) : base(ids) 
        {
            _name = name;
            _description = desc;
        }

        public string Name
        {
            get
            {
                return _name;
            }
        }

        public string Description
        {
            get
            {
                return _description;
            }
        }
        public string ShortDescription
        {
            get
            {
                return $"{Name} ({FirstId})";
            }
        }
        public virtual string FullDescription
        {
            get
            {
                return _description;
            }
        }

    }
}
