using RPGHeroes.Heroes;
using RPGHeroes.Items;
using RPGHeroes.listOfHeroes;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGHeroes
{
    [ExcludeFromCodeCoverage]
    public class Program
    {
        static public void Main(String[] args)
        {
             Warrior warrior = new Warrior("Julius");
             warrior.Display();
             HeroAttributes hA = new HeroAttributes(10, 100, 10000);
            HeroAttributes hB = new HeroAttributes(33, 333, 3333);
            Armor a = new Armor("yessir",1, Slot.Body, ArmorType.Mail, hA);
            Armor b = new Armor("yessir", 1, Slot.Body, ArmorType.Mail, hB);
            warrior.EquipArmor(a);
            warrior.TotalAttributes();
            warrior.Display();
            warrior.TotalAttributes();

            warrior.TotalAttributes();

            warrior.TotalAttributes();

            warrior.Display();
            //warrior.Equipment.TryGetValue()
            /*
            
            warrior.Display();
            warrior.EquipArmor(b);
            warrior.Display();
            */


        }
    }
}