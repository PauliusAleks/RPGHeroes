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
    /// <summary>
    /// Abstract Hero parent class with required parameters, constructor and abstract methods.
    /// </summary>
    [ExcludeFromCodeCoverage] //- used to exclude this class from Code coverege testing tool.
    public abstract class Hero
    {
        public HeroClass HeroClass { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public HeroAttributes LevelAttributes { get; set; }
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
            Name = name;
            Level = 1;
        }
        public abstract void LevelUp();
        public abstract void EquipWeapon(Weapon weapon);
        public abstract void EquipArmor(Armor armor);
        public abstract HeroAttributes TotalAttributes();
        public abstract double Damage();

        /// <summary>
        /// Displays full info about the hero in a chosen format.
        /// </summary>
        /// <returns>A string with full info about the hero.</returns>
        public string Display()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("###################### Hero Description ######################");
            stringBuilder.AppendLine($"Name: {Name}");
            stringBuilder.AppendLine($"Class: {HeroClass}");
            stringBuilder.AppendLine($"Level: {Level}");
            stringBuilder.AppendLine($"Total Strength: {TotalAttributes().Strength}");
            stringBuilder.AppendLine($"Total Dexterity: {TotalAttributes().Dexterity}");
            stringBuilder.AppendLine($"Total Intelligence: {TotalAttributes().Intelligence}");
            stringBuilder.AppendLine($"Damage: {Damage()}");
            return stringBuilder.ToString();
        }
    }
}
