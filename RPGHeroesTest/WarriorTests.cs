using RPGHeroes.Exceptions;
using RPGHeroes.Heroes;
using RPGHeroes.Items;
using RPGHeroes.listOfHeroes;
using System;
using static System.Net.Mime.MediaTypeNames;

namespace RPGHeroesTests
{
    public class WarriorTests : IHeroSubClassesTest
    {
        [Fact]
        public void NewHero_ShouldReturnCorrectName()
        {
            Warrior warrior = new Warrior("testWarrior");
            string expectedName = "testWarrior";
            string actualName = warrior.Name;
            Assert.Equal(expectedName, actualName);
        }
        [Fact]
        public void NewHero_ShouldReturnCorrectLevel()
        {
            Warrior warrior = new Warrior("testWarrior");
            int expectedLevel = 1;
            int actualLevel = warrior.Level;
            Assert.Equal(expectedLevel, actualLevel);
        }
        [Fact]
        public void NewHero_ShouldReturnCorrectStrength()
        {
            Warrior warrior = new Warrior("testWarrior");
            int expectedStrength = 5;
            int actualStrength = warrior.HeroAttribute.Strength;                                     
            Assert.Equal(expectedStrength, actualStrength);
        }
        [Fact]
        public void NewHero_ShouldReturnCorrectDexterity()
        {
            Warrior warrior = new Warrior("testWarrior");
            int expectedDexterity = 2;
            int actualDexterity = warrior.HeroAttribute.Dexterity;
            Assert.Equal(expectedDexterity, actualDexterity);
        }
        [Fact]
        public void Hero_ShouldReturnCorrectIntelligence()
        {
            Warrior warrior = new Warrior("testWarrior");
            int expectedIntelligence = 1;
            int actualIntelligence = warrior.HeroAttribute.Intelligence;
            Assert.Equal(expectedIntelligence, actualIntelligence);
        }
        [Fact]
        public void Hero_AfterLevelUp_ShouldReturnCorrectLevel()
        {
            Warrior warrior = new Warrior("testWarrior");
            warrior.LevelUp();
            int expectedLevel = 2;
            int actualLevel = warrior.Level;
            Assert.Equal(expectedLevel, actualLevel);
        }
        [Fact]
        public void Hero_AfterLevelUp_ShouldReturnCorrectStrength()
        {
            Warrior warrior = new Warrior("testWarrior");
            warrior.LevelUp();
            int expectedStrength = 8;
            int actualStrength = warrior.HeroAttribute.Strength;
            Assert.Equal(expectedStrength, actualStrength);
        }
        [Fact]
        public void Hero_AfterLevelUp_ShouldReturnCorrectDexterity()
        {
            Warrior warrior = new Warrior("testWarrior");
            warrior.LevelUp();
            int expectedDexterity = 4;
            int actualDexterity = warrior.HeroAttribute.Dexterity;
            Assert.Equal(expectedDexterity, actualDexterity);
        }
        [Fact]
        public void Hero_AfterLevelUp_ShouldReturnCorrectIntelligence()
        {
            Warrior warrior = new Warrior("testWarrior");
            warrior.LevelUp();
            int expectedIntelligence = 2;
            int actualIntelligence = warrior.HeroAttribute.Intelligence;
            Assert.Equal(expectedIntelligence, actualIntelligence);
        }
        [Theory]
        [InlineData(WeaponType.Sword, 5)] //Throw Exception when less than required level
        [InlineData(WeaponType.Bow, 1)] //Throw Exception when invalid weapon type
        public void CheckIfInvalidWeaponExceptionIsThrown(WeaponType weaponType, int requiredLevel)
        {
            Warrior warrior = new Warrior("testWarrior");
            Weapon weapon = new Weapon("Weapon", requiredLevel, weaponType, 6);
            Assert.Throws<InvalidWeaponException>(() => warrior.EquipWeapon(weapon));
        }
        [Fact]
        public void CheckIfWeaponCanBeEquiped()
        {
            Warrior warrior = new Warrior("testWarrior");
            List<WeaponType> expectedValidWeaponTypes = new List<WeaponType>() { WeaponType.Axe, WeaponType.Hammer, WeaponType.Sword };
            List<WeaponType> actualValidWeaponTypes = warrior.ValidWeaponTypes;
            Assert.Equal(expectedValidWeaponTypes, actualValidWeaponTypes);
        }
        [Theory]
        [InlineData(ArmorType.Mail, 5)] //Throw Exception when less than required level
        [InlineData(ArmorType.Cloth, 1)] //Throw Exception when invalid armor type
        public void CheckIfInvalidArmorExceptionIsThrown(ArmorType armorType, int requiredLevel)
        {
            Warrior warrior = new Warrior("testWarrior");
            Armor armor = new Armor("Armor", requiredLevel, Slot.Body, armorType, new HeroAttributes(1, 1, 1));
            Assert.Throws<InvalidWeaponException>(() => warrior.EquipArmor(armor));
        }
        [Fact]
        public void CHeckIfArmorCanBeEquiped()
        {
            Warrior warrior = new Warrior("testWarrior");

            List<ArmorType> ExpectedValidArmorTypes = new List<ArmorType>() { ArmorType.Mail, ArmorType.Plate };
            List<ArmorType> ActualValidArmorTypes = warrior.ValidArmorTypes;
            Assert.Equal(ExpectedValidArmorTypes, ActualValidArmorTypes);
        }
    }
}