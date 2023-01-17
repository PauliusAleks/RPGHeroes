using RPGHeroes.Exceptions;
using RPGHeroes.Heroes;
using RPGHeroes.Items;
using RPGHeroes.listOfHeroes;
using System.ComponentModel;
using static System.Net.Mime.MediaTypeNames;

namespace RPGHeroesTests
{
    public class RangerTests : IHeroSubClassesTest
    {
        [Fact]
        public void NewHero_ShouldReturnCorrectName()
        {
            Ranger ranger = new Ranger("testRanger");
            string expectedName = "testRanger";
            string actualName = ranger.Name;
            Assert.Equal(expectedName, actualName);
        }
        [Fact]
        public void NewHero_ShouldReturnCorrectLevel()
        {
            Ranger ranger = new Ranger("testRanger");
            int expectedLevel = 1;
            int actualLevel = ranger.Level;
            Assert.Equal(expectedLevel, actualLevel);
        }
        [Fact]
        public void NewHero_ShouldReturnCorrectStrength()
        {
            Ranger ranger = new Ranger("testRanger");
            int expectedStrength = 1;
            int actualStrength = ranger.HeroAttribute.Strength;                                     
            Assert.Equal(expectedStrength, actualStrength);
        }
        [Fact]
        public void NewHero_ShouldReturnCorrectDexterity()
        {
            Ranger ranger = new Ranger("testRanger");
            int expectedDexterity = 7;
            int actualDexterity = ranger.HeroAttribute.Dexterity;
            Assert.Equal(expectedDexterity, actualDexterity);
        }
        [Fact]
        public void Hero_ShouldReturnCorrectIntelligence()
        {
            Ranger ranger = new Ranger("testRanger");
            int expectedIntelligence = 1;
            int actualIntelligence = ranger.HeroAttribute.Intelligence;
            Assert.Equal(expectedIntelligence, actualIntelligence);
        }
        [Fact]
        public void Hero_AfterLevelUp_ShouldReturnCorrectLevel()
        {
            Ranger ranger = new Ranger("testRanger");
            ranger.LevelUp();
            int expectedLevel = 2;
            int actualLevel = ranger.Level;
            Assert.Equal(expectedLevel, actualLevel);
        }
        [Fact]
        public void Hero_AfterLevelUp_ShouldReturnCorrectStrength()
        {
            Ranger ranger = new Ranger("testRanger");
            ranger.LevelUp();
            int expectedStrength = 2;
            int actualStrength = ranger.HeroAttribute.Strength;
            Assert.Equal(expectedStrength, actualStrength);
        }
        [Fact]
        public void Hero_AfterLevelUp_ShouldReturnCorrectDexterity()
        {
            Ranger ranger = new Ranger("testRanger");
            ranger.LevelUp();
            int expectedDexterity = 12;
            int actualDexterity = ranger.HeroAttribute.Dexterity;
            Assert.Equal(expectedDexterity, actualDexterity);
        }
        [Fact]
        public void Hero_AfterLevelUp_ShouldReturnCorrectIntelligence()
        {
            Ranger ranger = new Ranger("testRanger");
            ranger.LevelUp();
            int expectedIntelligence = 2;
            int actualIntelligence = ranger.HeroAttribute.Intelligence;
            Assert.Equal(expectedIntelligence, actualIntelligence);
        }

        [Theory]
        [InlineData(WeaponType.Bow,5)] //Throw Exception when less than required level
        [InlineData(WeaponType.Sword,1)] //Throw Exception when invalid weapon type
        public void CheckIfInvalidWeaponExceptionIsThrown(WeaponType weaponType,int requiredLevel)
        {
            Ranger ranger = new Ranger("testRanger");
            Weapon weapon = new Weapon("Weapon", requiredLevel, weaponType, 6);
            Assert.Throws<InvalidWeaponException>(() => ranger.EquipWeapon(weapon));
        }


        [Fact]
        public void CheckIfWeaponCanBeEquiped()
        {
            Ranger ranger = new Ranger("testRanger");
            List<WeaponType> expectedValidWeaponTypes= new List<WeaponType>() { WeaponType.Bow};
            List<WeaponType> actualValidWeaponTypes = ranger.ValidWeaponTypes;
            Assert.Equal(expectedValidWeaponTypes, actualValidWeaponTypes);
        }
        [Theory]
        [InlineData(ArmorType.Mail, 5)] //Throw Exception when less than required level
        [InlineData(ArmorType.Cloth, 1)] //Throw Exception when invalid armor type
        public void CheckIfInvalidArmorExceptionIsThrown(ArmorType armorType, int requiredLevel)
        {
            Ranger ranger = new Ranger("testRanger");
            Armor armor = new Armor("Armor", requiredLevel, Slot.Body, armorType, new HeroAttributes(1, 1, 1));
            Assert.Throws<InvalidWeaponException>(() => ranger.EquipArmor(armor));
        }
        [Fact]
        public void CHeckIfArmorCanBeEquiped()
        {
            Ranger ranger = new Ranger("testRanger");

            List<ArmorType> ExpectedValidArmorTypes = new List<ArmorType>() { ArmorType.Leather,ArmorType.Mail };
            List<ArmorType> ActualValidArmorTypes = ranger.ValidArmorTypes;
            Assert.Equal(ExpectedValidArmorTypes, ActualValidArmorTypes);
        }

       
    }
}