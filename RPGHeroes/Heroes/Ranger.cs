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

    public class Ranger : Hero
    {
        HeroAttributes RangerLevelUp = new HeroAttributes(1, 5, 1);
        public Ranger(string name) : base(name)
        {
            HeroClass= HeroClass.Ranger;
            HeroAttribute = new HeroAttributes(1, 7, 1);
            ValidWeaponTypes = new List<WeaponType>() { WeaponType.Bow };
            ValidArmorTypes = new List<ArmorType>() { ArmorType.Leather, ArmorType.Mail };
        }
        public override void LevelUp()
        {
            Level++;
            HeroAttribute.increaseHeroAttributes(RangerLevelUp);
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
                    //HeroAttribute.increaseHeroAttributes(armor.ArmorAttribute);

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
            int rangerDamagingAttribute = 0;
            double totalDamage = 0.0;
            if (weapon != null)
            {
                weaponDamage = weapon.WeaponDamage;
            }
            else
            {
                weaponDamage = 1;
            }
            rangerDamagingAttribute = TotalAttributes().Dexterity;
            totalDamage = weaponDamage * (1 + rangerDamagingAttribute / 100.0);
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
