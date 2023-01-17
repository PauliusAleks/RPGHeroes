using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGHeroes.Heroes
{
    public class HeroAttributes
    {
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Intelligence { get; set; }

        public HeroAttributes(int strength, int dexterity, int intelligence)
        {
            Strength = strength;
            Dexterity = dexterity;
            Intelligence = intelligence;
        }

        public void increaseHeroAttributes(HeroAttributes heroAttribute) //Increases heroe's atributes with given parameters in the method.
        {
            Strength += heroAttribute.Strength;
            Dexterity += heroAttribute.Dexterity;
            Intelligence += heroAttribute.Intelligence;
        }

    }
}
