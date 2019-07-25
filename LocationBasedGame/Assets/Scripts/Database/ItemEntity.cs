using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
// 0t1
namespace DatabaseN
{
    public class ItemEntity
    {
        public string id;
        public string name;
        public string latinName;
        public string description;

        public ItemEntity(string id, string name, string latinName, string description)
        {
            this.id = id;
            this.name = name;
            this.latinName = latinName;
            this.description = description;
        }
    }
}