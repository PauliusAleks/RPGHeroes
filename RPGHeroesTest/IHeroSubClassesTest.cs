using RPGHeroes.Exceptions;
using RPGHeroes.Heroes;
using RPGHeroes.Items;
using RPGHeroes.listOfHeroes;

namespace RPGHeroesTests
{
    public interface IHeroSubClassesTest
    {

       
        public void NewHero_ShouldReturnCorrectName();
       
        public void NewHero_ShouldReturnCorrectLevel();
        
        public void NewHero_ShouldReturnCorrectStrength();
        
        public void NewHero_ShouldReturnCorrectDexterity();
        
        public void Hero_ShouldReturnCorrectIntelligence();
        
        public void Hero_AfterLevelUp_ShouldReturnCorrectLevel();
        
        public void Hero_AfterLevelUp_ShouldReturnCorrectStrength();
        
        public void Hero_AfterLevelUp_ShouldReturnCorrectDexterity();
        
        public void Hero_AfterLevelUp_ShouldReturnCorrectIntelligence();
        
        public void CheckIfInvalidWeaponExceptionIsThrown(WeaponType weaponType, int requiredLevel);
        
        public void CheckIfWeaponCanBeEquiped();
        
        public void CheckIfInvalidArmorExceptionIsThrown(ArmorType armorType, int requiredLevel);
        
        public void CHeckIfArmorCanBeEquiped();




    }
}
