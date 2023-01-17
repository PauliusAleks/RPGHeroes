using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGHeroes.Items
{
    public class Weapon : Item
    {
        public WeaponType WeaponType { get; set; }
        public int WeaponDamage { get; set; }

        public Weapon(string name, int requiredLevel,WeaponType weaponType, int weaponDamage) : base(name, ItemType.Weapon, requiredLevel)
        {
            Name = name;
            WeaponType = weaponType;
            Slot = Slot.Weapon;
            WeaponDamage = weaponDamage;
        }
    }
}
