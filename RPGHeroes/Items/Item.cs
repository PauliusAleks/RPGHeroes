using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGHeroes.Items
{
    public class Item
    {
        public string Name { get; set; }
        public ItemType ItemType { get; set; }
        public int RequiredLevel { get; set; }
        public Slot Slot { get; set; }

        public Item(String name, ItemType itemType, int requiredLevel)
        {
            Name = name;
            ItemType = itemType;
            RequiredLevel = requiredLevel;
        }
        public Item(String name, ItemType itemType, int requiredLevel, Slot slot) 
        {
            Name = name;
            ItemType= itemType;
            RequiredLevel= requiredLevel;
            Slot= slot;
        }
    }
}
