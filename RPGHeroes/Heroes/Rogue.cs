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

    public class Rogue : Hero
    {
        HeroAttributes RogueLevelUp = new HeroAttributes(1, 4, 1);
        public Rogue(string name) : base(name)
        {
            HeroClass= HeroClass.Rogue;
            HeroAttribute = new HeroAttributes(2, 6, 1);
            ValidWeaponTypes = new List<WeaponType>() { WeaponType.Dagger, WeaponType.Sword };
            ValidArmorTypes = new List<ArmorType>() { ArmorType.Leather, ArmorType.Mail };
        }
        public override void LevelUp()
        {
            
            Level++;
            HeroAttribute.increaseHeroAttributes(RogueLevelUp);
        }
        public override void EquipWeapon(Weapon weapon)
        {
            
            
                if (ValidWeaponTypes.Contains(weapon.WeaponType) && Level >= weapon.RequiredLevel )
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
               // HeroAttribute.increaseHeroAttributes(armor.ArmorAttribute);
            }
            else
            {
                throw new InvalidWeaponException("Your Hero cannot wear this Armor!");

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
            int rogueDamagingAttribute = 0;
            double totalDamage = 0;
            if(weapon != null)
            {
                weaponDamage = weapon.WeaponDamage;
                rogueDamagingAttribute = TotalAttributes().Dexterity;
            } else
            {
                weaponDamage = 1;
            }
            totalDamage = weaponDamage * (1 + rogueDamagingAttribute / 100);
            return totalDamage;
        }

        public override void Display()
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
            Console.WriteLine(stringBuilder.ToString());
        }

    }
}
