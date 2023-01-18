using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPGHeroes.Exceptions;
using RPGHeroes.Heroes;
using RPGHeroes.Items;

namespace RPGHeroes.listOfHeroes
{
    public class Mage : Hero
    {
        HeroAttributes MageLevelUp = new HeroAttributes(1, 1, 5);
        public Mage(string name) : base(name)
        {
            HeroClass = HeroClass.Mage;
            HeroAttribute = new HeroAttributes(1, 1, 8);
            ValidWeaponTypes = new List<WeaponType>(2) { WeaponType.Staff, WeaponType.Wand };
            ValidArmorTypes = new List<ArmorType>(1) { ArmorType.Cloth };
        }
        public override void LevelUp()
        {
            Level++;
            HeroAttribute.increaseHeroAttributes(MageLevelUp);
        }
        public override void EquipWeapon(Weapon weapon)
        {
            if (ValidWeaponTypes.Contains(weapon.WeaponType) && Level >= weapon.RequiredLevel)
            {
                Equipment.Remove(Slot.Weapon);
                Equipment.Add(Slot.Weapon, weapon);
            }
            else
            {
                throw new InvalidWeaponException("Your Hero cannot use this weapon!");                
            }          
        }
        public override void EquipArmor(Armor armor)
        {

            if (ValidArmorTypes.Contains(armor.ArmorType) && Level >= armor.RequiredLevel)
            {
                    Equipment.Remove(armor.Slot);
                    Equipment.Add(armor.Slot, armor);                
            }
            else
            {
                throw new InvalidArmorException("Your Hero cannot wear this Armor!");
            }

        }
        public override HeroAttributes TotalAttributes()
        {
            HeroAttributes totalHeroAttributes = HeroAttribute;
            foreach (var item in Equipment.Values)
            {
                if (item != null && item.ItemType == ItemType.Armor)
                {
                    Armor armor = (Armor)item;
                    totalHeroAttributes.increaseHeroAttributes(armor.ArmorAttribute);
                }
            }           
            return totalHeroAttributes;
        }
        public override double Damage()
        {
            Weapon weapon = (Weapon)Equipment[Slot.Weapon];
            int weaponDamage = 0;
            int mageDamagingAttribute = 0;
            double totalDamage = 0.0;
            if (weapon != null)
            {
                weaponDamage = weapon.WeaponDamage;
            }
            else
            {
                weaponDamage = 1;
            }
            mageDamagingAttribute = TotalAttributes().Intelligence;
            totalDamage = weaponDamage * (1 + mageDamagingAttribute / 100.0); ;
            return totalDamage;
        }
        public override string Display()
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
            //Console.WriteLine(stringBuilder.ToString());
        }
    }
}
