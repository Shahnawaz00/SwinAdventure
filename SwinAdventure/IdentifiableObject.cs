﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class IdentifiableObject
    {
        List<string> _identifiers = new List<string>();

        public IdentifiableObject(string[] idents)
        {
            foreach (string id in idents)
            {
                AddIdentifier(id);
            }
        }

        public bool AreYou(string id)
        {
            foreach (string identifier in _identifiers)
            {
                if (id.ToLower() == identifier)
                {
                    return true;
                } 
            }
            return false;
        }

        public string FirstId
        {
            get
            {
                if (_identifiers.Count == 0)
                {
                    return "";
                }
                else
                {
                    return _identifiers.First();
                }
            }
        }

        public void AddIdentifier(string id) 
        { 
            _identifiers.Add(id.ToLower());
        }
    }
}
