using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGHeroes.Items
{
    /// <summary>
    /// A child weapon class of Item class
    /// Inherits constructor without slot parameter, because there is only one slot for weapons.
    /// By default sets item type to weapon
    /// </summary>
    public class Weapon : Item
    {
        public WeaponType WeaponType { get; set; }
        public int WeaponDamage { get; set; }
        public Weapon(string name, int requiredLevel, WeaponType weaponType, int weaponDamage) : base(name, ItemType.Weapon, requiredLevel)
        {
            Name = name;
            WeaponType = weaponType;
            Slot = Slot.Weapon;
            WeaponDamage = weaponDamage;
        }
    }
}
