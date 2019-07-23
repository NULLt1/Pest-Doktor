using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataBank
{
    public class ItemEntity
    {
        public string _id;
        public string _name;
        public string _latinName;
        public string _description;
        public ItemEntity(string id, string name, string latinName, string description)
        {
            _id = id;
            _name = name;
            _latinName = latinName;
            _description = description;
        }
    }
}