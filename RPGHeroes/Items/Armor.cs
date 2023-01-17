﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPGHeroes.Heroes;

namespace RPGHeroes.Items
{
    public class Armor : Item
    {
        public ArmorType ArmorType { get; set; }
        public HeroAttributes ArmorAttribute { get; set; }
        public Armor(string name, int requiredLevel,Slot slot, ArmorType armorType, HeroAttributes armorAttribute) : base(name, ItemType.Armor,requiredLevel,slot)
        { 
            Name= name;
            ArmorType = armorType;
            ArmorAttribute = armorAttribute;
        }
    }
}
