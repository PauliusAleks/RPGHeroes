using RPGHeroes.Exceptions;
using RPGHeroes.Heroes;
using RPGHeroes.Items;
using RPGHeroes.listOfHeroes;
using System.Text;

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

        public void CheckHero_TotalAttributes_NoArmor()
        ;
        public void CheckHero_TotalAttributes_OnePieceArmor()
        ;
        public void CheckHero_TotalAttributes_TwoPieceArmor()
        ;
        public void CheckHero_TotalAttributes_ReplacedPieceArmor()
        ;
        public void CheckHero_Damage_NoWeapon()
        ;
        public void CheckHero_Damage_WithWeapon()
        ;
        public void CheckHero_Damage_ReplacedWeapon()
        ;
        public void CheckHero_Damage_WeaponAndThreePiecesOfArmor()
        ;
        public void CheckHero_Display()
        ;


    }
}
