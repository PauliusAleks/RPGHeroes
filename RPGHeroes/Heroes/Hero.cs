using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using RPGHeroes.listOfHeroes;
using RPGHeroes.Items;
using System.Diagnostics.CodeAnalysis;

namespace RPGHeroes.Heroes
{
    [ExcludeFromCodeCoverage]
    public abstract class Hero
    {
        public HeroClass HeroClass { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public HeroAttributes HeroAttribute { get; set; }
        public Dictionary<Slot, Item> Equipment = new Dictionary<Slot, Item>() 
        {
            { Slot.Weapon, null},
            { Slot.Head, null},
            { Slot.Body, null},
            { Slot.Legs, null},
        };
        public List<WeaponType> ValidWeaponTypes { get; set; }
        public List<ArmorType> ValidArmorTypes { get; set; }

        public Hero(String name)
        {
            Name =  name;
            Level = 1;
        }

        public abstract void LevelUp();

        public abstract void EquipWeapon(Weapon weapon);

        public abstract void EquipArmor(Armor armor);

        public abstract HeroAttributes TotalAttributes();

        public abstract double Damage();

        public abstract string Display();
    }
}
