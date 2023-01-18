using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGHeroes.Heroes
{
    /// <summary>
    /// A class for required hero attributes.
    /// </summary>
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

        /// <summary>
        /// Increases heroe's atributes with the given parameter.
        /// </summary>
        /// <param name="LevelAttributes"></param>
        public void increaseHeroAttributes(HeroAttributes LevelAttributes)
        {
            Strength += LevelAttributes.Strength;
            Dexterity += LevelAttributes.Dexterity;
            Intelligence += LevelAttributes.Intelligence;
        }
    }
}
