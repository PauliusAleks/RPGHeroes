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
    /// <summary>
    /// Child class of the Hero class.
    /// Setting Mage starting attributes and leveling attributes as given in the assignment description.
    /// Setting valid Mage weapon types and armor types as given in the assignment description.
    /// </summary>
    public class Ranger : Hero
    {
        HeroAttributes RangerLevelUp = new HeroAttributes(1, 5, 1);
        public Ranger(string name) : base(name)
        {
            HeroClass = HeroClass.Ranger;
            LevelAttributes = new HeroAttributes(1, 7, 1);
            ValidWeaponTypes = new List<WeaponType>() { WeaponType.Bow };
            ValidArmorTypes = new List<ArmorType>() { ArmorType.Leather, ArmorType.Mail };
        }

        /// <summary>
        /// Increments hero's level by one and hero's attributes with Mage's leveling attributes.
        /// </summary>
        public override void LevelUp()
        {
            Level++;
            LevelAttributes.increaseHeroAttributes(RangerLevelUp);
        }

        /// <summary>
        /// A method to equip a weapon.
        /// Checks if the hero can equip the weapon and if the hero's level is high enough.
        /// Removes the old weapon and equips the new weapon.
        /// If the hero cannot equip the weapon, an exception is thrown with the given message.
        /// </summary>
        /// <param name="weapon"></param>
        /// <exception cref="InvalidWeaponException"></exception>
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

        /// <summary>
        /// A method to equip a given weapon
        /// Checks if the hero can equip the weapon and if the hero's level is high enough.
        /// Removes the old armor in the correct slot and equips the given armor in the correct slot.
        /// If the hero cannot equip the armor, a proper exception is thrown.
        /// </summary>
        /// <param name="armor"></param>
        /// <exception cref="InvalidArmorException"></exception>
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

        /// <summary>
        /// A method to check total hero's attributes with current level and equipment.
        /// Checks hero's equipment and for each armor increases hero's attributes with each armor's attributes.
        /// </summary>
        /// <returns>Current total hero attributes</returns>
        public override HeroAttributes TotalAttributes()
        {
            HeroAttributes totalHeroAttributes = LevelAttributes;

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

        /// <summary>
        /// A method to check what damage a hero deal with current level and weapon.
        /// Checks what weapon hero is wearing.
        /// If a hero is wearing a weapon, uses it's damage, if not sets weapon's damage to 1.
        /// Checks hero's damaging attribute.
        /// Counts total damage as given in the assignment description.
        /// </summary>
        /// <returns>Current hero's damage</returns>
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
    }
}
