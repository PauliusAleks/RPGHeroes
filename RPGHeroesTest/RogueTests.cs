using RPGHeroes.Exceptions;
using RPGHeroes.Heroes;
using RPGHeroes.Items;
using RPGHeroes.listOfHeroes;
using System;
using static System.Net.Mime.MediaTypeNames;

namespace RPGHeroesTests
{
    public class RogueTests : IHeroSubClassesTest
    {
        [Fact]
        public void NewHero_ShouldReturnCorrectName()
        {
            Rogue rogue = new Rogue("testRogue");
            string expectedName = "testRogue";
            string actualName = rogue.Name;
            Assert.Equal(expectedName, actualName);
        }
        [Fact]
        public void NewHero_ShouldReturnCorrectLevel()
        {
            Rogue rogue = new Rogue("testRogue");
            int expectedLevel = 1;
            int actualLevel = rogue.Level;
            Assert.Equal(expectedLevel, actualLevel);
        }
        [Fact]
        public void NewHero_ShouldReturnCorrectStrength()
        {
            Rogue rogue = new Rogue("testRogue");
            int expectedStrength = 2;
            int actualStrength = rogue.HeroAttribute.Strength;                                     
            Assert.Equal(expectedStrength, actualStrength);
        }
        [Fact]
        public void NewHero_ShouldReturnCorrectDexterity()
        {
            Rogue rogue = new Rogue("testRogue");
            int expectedDexterity = 6;
            int actualDexterity = rogue.HeroAttribute.Dexterity;
            Assert.Equal(expectedDexterity, actualDexterity);
        }
        [Fact]
        public void Hero_ShouldReturnCorrectIntelligence()
        {
            Rogue rogue = new Rogue("testRogue");
            int expectedIntelligence = 1;
            int actualIntelligence = rogue.HeroAttribute.Intelligence;
            Assert.Equal(expectedIntelligence, actualIntelligence);
        }
        [Fact]
        public void Hero_AfterLevelUp_ShouldReturnCorrectLevel()
        {
            Rogue rogue = new Rogue("testRogue");
            rogue.LevelUp();
            int expectedLevel = 2;
            int actualLevel = rogue.Level;
            Assert.Equal(expectedLevel, actualLevel);
        }
        [Fact]
        public void Hero_AfterLevelUp_ShouldReturnCorrectStrength()
        {
            Rogue rogue = new Rogue("testRogue");
            int expectedStrength = 3;
            rogue.LevelUp();
            int actualStrength = rogue.HeroAttribute.Strength;
            Assert.Equal(expectedStrength, actualStrength);
        }
        [Fact]
        public void Hero_AfterLevelUp_ShouldReturnCorrectDexterity()
        {
            Rogue rogue = new Rogue("testRogue");
            int expectedDexterity = 10;
            rogue.LevelUp();
            int actualDexterity = rogue.HeroAttribute.Dexterity;
            Assert.Equal(expectedDexterity, actualDexterity);
        }
        [Fact]
        public void Hero_AfterLevelUp_ShouldReturnCorrectIntelligence()
        {
            Rogue rogue = new Rogue("testRogue");
            int expectedIntelligence = 2;
            rogue.LevelUp();
            int actualIntelligence = rogue.HeroAttribute.Intelligence;
            Assert.Equal(expectedIntelligence, actualIntelligence);
        }
        [Theory]
        [InlineData(WeaponType.Dagger, 5)] //Throw Exception when less than required level
        [InlineData(WeaponType.Bow, 1)] //Throw Exception when invalid weapon type
        public void CheckIfInvalidWeaponExceptionIsThrown(WeaponType weaponType, int requiredLevel)
        {
            Rogue rogue = new Rogue("testRogue");
            Weapon weapon = new Weapon("Weapon", requiredLevel, weaponType, 6);
            Assert.Throws<InvalidWeaponException>(() => rogue.EquipWeapon(weapon));
        }
        [Fact]
        public void CheckIfWeaponCanBeEquiped()
        {
            Rogue rogue = new Rogue("testRogue");

            List<WeaponType> expectedValidWeaponTypes = new List<WeaponType>() { WeaponType.Dagger, WeaponType.Sword };
            List<WeaponType> actualValidWeaponTypes = rogue.ValidWeaponTypes;
            Assert.Equal(expectedValidWeaponTypes, actualValidWeaponTypes);
        }
        [Theory]
        [InlineData(ArmorType.Leather, 5)] //Throw Exception when less than required level
        [InlineData(ArmorType.Cloth, 1)] //Throw Exception when invalid armor type
        public void CheckIfInvalidArmorExceptionIsThrown(ArmorType armorType, int requiredLevel)
        {
            Rogue rogue = new Rogue("testRogue");

            Armor armor = new Armor("Armor", requiredLevel, Slot.Body, armorType, new HeroAttributes(1, 1, 1));
            Assert.Throws<InvalidWeaponException>(() => rogue.EquipArmor(armor));
        }
        [Fact]
        public void CHeckIfArmorCanBeEquiped()
        {
            Rogue rogue = new Rogue("testRogue");

            List<ArmorType> ExpectedValidArmorTypes = new List<ArmorType>() { ArmorType.Leather,ArmorType.Mail };
            List<ArmorType> ActualValidArmorTypes = rogue.ValidArmorTypes;
            Assert.Equal(ExpectedValidArmorTypes, ActualValidArmorTypes);
        }
    }
}