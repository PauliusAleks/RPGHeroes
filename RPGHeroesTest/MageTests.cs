using RPGHeroes.Exceptions;
using RPGHeroes.Heroes;
using RPGHeroes.Items;
using RPGHeroes.listOfHeroes;
using System;
using System.Diagnostics.CodeAnalysis;

namespace RPGHeroesTests
{
    
    public class MageTests : IHeroSubClassesTest
    {
        [Fact]
        public void NewHero_ShouldReturnCorrectName()
        {
            Mage mage = new Mage("testMage");
            Mage mag1 = new Mage("bal");
            Warrior war = new Warrior("Fight");
            string expectedName = "testMage";
            string actualName = mage.Name;
            Assert.Equal(expectedName, actualName);
        }
        [Fact]
        public void NewHero_ShouldReturnCorrectLevel()
        {
            Mage mage = new Mage("testMage");
            int expectedLevel = 1;
            int actualLevel = mage.Level;
            Assert.Equal(expectedLevel, actualLevel);
        }
        [Fact]
        public void NewHero_ShouldReturnCorrectStrength()
        {
            Mage mage = new Mage("testMage");
            int expectedStrength = 1;
            int actualStrength = mage.HeroAttribute.Strength;                                     
            Assert.Equal(expectedStrength, actualStrength);
        }
        [Fact]
        public void NewHero_ShouldReturnCorrectDexterity()
        {
            Mage mage = new Mage("testMage");
            int expectedDexterity = 1;
            int actualDexterity = mage.HeroAttribute.Dexterity;
            Assert.Equal(expectedDexterity, actualDexterity);
        }
        [Fact]
        public void Hero_ShouldReturnCorrectIntelligence()
        {
            Mage mage = new Mage("testMage");
            int expectedIntelligence = 8;
            int actualIntelligence = mage.HeroAttribute.Intelligence;
            Assert.Equal(expectedIntelligence, actualIntelligence);
        }
        [Fact]
        public void Hero_AfterLevelUp_ShouldReturnCorrectLevel()
        {
            Mage mage = new Mage("testMage");
            mage.LevelUp();
            int expectedLevel = 2;
            int actualLevel = mage.Level;
            Assert.Equal(expectedLevel, actualLevel);
        }
        [Fact]
        public void Hero_AfterLevelUp_ShouldReturnCorrectStrength()
        {
            Mage mage = new Mage("testMage");
            mage.LevelUp();
            int expectedStrength = 2;
            int actualStrength = mage.HeroAttribute.Strength;
            Assert.Equal(expectedStrength, actualStrength);
        }
        [Fact]
        public void Hero_AfterLevelUp_ShouldReturnCorrectDexterity()
        {
            Mage mage = new Mage("testMage");
            mage.LevelUp();
            int expectedDexterity = 2;
            int actualDexterity = mage.HeroAttribute.Dexterity;
            Assert.Equal(expectedDexterity, actualDexterity);
        }
        [Fact]
        public void Hero_AfterLevelUp_ShouldReturnCorrectIntelligence()
        {
            Mage mage = new Mage("testMage");
            mage.LevelUp();
            int expectedIntelligence = 13;
            int actualIntelligence = mage.HeroAttribute.Intelligence;
            Assert.Equal(expectedIntelligence, actualIntelligence);
        }
        [Theory]
        [InlineData(WeaponType.Staff, 5)] //Throw Exception when less than required level
        [InlineData(WeaponType.Sword, 1)] //Throw Exception when invalid weapon type
        public void CheckIfInvalidWeaponExceptionIsThrown(WeaponType weaponType, int requiredLevel)
        {
            Mage mage = new Mage("testMage");
            Weapon weapon = new Weapon("Weapon", requiredLevel, weaponType, 6);
            Assert.Throws<InvalidWeaponException>(() => mage.EquipWeapon(weapon));
        }
        [Fact]
        public void CheckIfWeaponCanBeEquiped()
        {
            Mage mage = new Mage("testMage");
            List<WeaponType> expectedValidWeaponTypes = new List<WeaponType>() { WeaponType.Staff, WeaponType.Wand};
            List<WeaponType> actualValidWeaponTypes = mage.ValidWeaponTypes;
            Assert.Equal(expectedValidWeaponTypes, actualValidWeaponTypes);
        }
        [Theory]
        [InlineData(ArmorType.Cloth, 5)] //Throw Exception when less than required level
        [InlineData(ArmorType.Mail, 1)] //Throw Exception when invalid armor type
        public void CheckIfInvalidArmorExceptionIsThrown(ArmorType armorType,int requiredLevel)
        {
            Mage mage = new Mage("testMage");
            Armor armor = new Armor("Armor", requiredLevel,Slot.Body, armorType,new HeroAttributes(1,1,1));
            Assert.Throws<InvalidWeaponException>(() => mage.EquipArmor(armor));
        }
        [Fact]
        public void CHeckIfArmorCanBeEquiped()
        {
            Mage mage = new Mage("testMage");
            List<ArmorType> ExpectedValidArmorTypes = new List<ArmorType>() {ArmorType.Cloth};
            List<ArmorType> ActualValidArmorTypes = mage.ValidArmorTypes;
            Assert.Equal(ExpectedValidArmorTypes,ActualValidArmorTypes);

        }


    }
}