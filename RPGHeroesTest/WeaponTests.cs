using RPGHeroes.Heroes;
using RPGHeroes.Items;
using RPGHeroes.listOfHeroes;

namespace RPGHeroesTests
{
    public class WeaponTests
    {
        [Fact]
        public void NewWeapon_ShouldReturnCorrectName()
        {
            Weapon weapon = new Weapon("Strong Test Bow",10,WeaponType.Bow,100);
            string expectedName = "Strong Test Bow";
            string actualName = weapon.Name;
            Assert.Equal(expectedName, actualName);
            
        }
        [Fact]
        public void NewWeapon_ShouldReturnCorrectRequiredLevel()
        {
            Weapon weapon = new Weapon("Strong Test Bow", 10, WeaponType.Bow, 100);
            int expectedReuiredLevel = 10;
            int actualRequiredLevel = weapon.RequiredLevel;
            Assert.Equal(expectedReuiredLevel, actualRequiredLevel);

        }
        [Fact]
        public void NewWeapon_ShouldReturnCorrectWeaponType()
        {
            Weapon weapon = new Weapon("Strong Test Bow", 10, WeaponType.Bow, 100);
            WeaponType expectedWeaponType = WeaponType.Bow;
            WeaponType actualWeaponType = weapon.WeaponType;
            Assert.Equal(expectedWeaponType, actualWeaponType);

        }
        [Fact]
        public void NewWeapon_ShouldReturnCorrectDamage()
        {
            Weapon weapon = new Weapon("Strong Test Bow", 10, WeaponType.Bow, 100);
            int expectedWeaponDamage = 100;
            int actualWeaponDamage = weapon.WeaponDamage;
            Assert.Equal(expectedWeaponDamage, actualWeaponDamage);

        }
    }
}
