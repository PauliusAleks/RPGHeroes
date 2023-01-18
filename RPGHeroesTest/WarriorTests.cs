using RPGHeroes.Exceptions;
using RPGHeroes.Heroes;
using RPGHeroes.Items;
using RPGHeroes.listOfHeroes;
using System;
using System.Text;
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
            Assert.Throws<InvalidArmorException>(() => warrior.EquipArmor(armor));
        }
        [Fact]
        public void CHeckIfArmorCanBeEquiped()
        {
            Warrior warrior = new Warrior("testWarrior");

            List<ArmorType> ExpectedValidArmorTypes = new List<ArmorType>() { ArmorType.Mail, ArmorType.Plate };
            List<ArmorType> ActualValidArmorTypes = warrior.ValidArmorTypes;
            Assert.Equal(ExpectedValidArmorTypes, ActualValidArmorTypes);
        }
        [Fact]
        public void CheckHero_TotalAttributes_NoArmor()
        {

            Warrior warrior = new Warrior("testWarrior");
            HeroAttributes expectedAttributes = new HeroAttributes(5, 2, 1);
            HeroAttributes actualAttributes = warrior.TotalAttributes();
            Assert.Equal(expectedAttributes.ToString(), actualAttributes.ToString());
        }
        [Fact]
        public void CheckHero_TotalAttributes_OnePieceArmor()
        {

            Warrior warrior = new Warrior("testWarrior");
            Armor headArmor = new Armor("headArmor", 1, Slot.Head, ArmorType.Plate, new HeroAttributes(1, 1, 1));
            warrior.EquipArmor(headArmor);
            HeroAttributes expectedAttributes = new HeroAttributes(6, 3, 2);
            HeroAttributes actualAttributes = warrior.TotalAttributes();
            Assert.Equal(expectedAttributes.ToString(), actualAttributes.ToString());
        }
        [Fact]
        public void CheckHero_TotalAttributes_TwoPieceArmor()
        {

            Warrior warrior = new Warrior("testWarrior");
            Armor headArmor = new Armor("headArmor", 1, Slot.Head, ArmorType.Plate, new HeroAttributes(1, 1, 1));
            Armor bodyArmor = new Armor("bodyArmor", 1, Slot.Body, ArmorType.Plate, new HeroAttributes(1, 1, 1));
            warrior.EquipArmor(headArmor);
            warrior.EquipArmor(bodyArmor);
            HeroAttributes expectedAttributes = new HeroAttributes(7, 4, 3);
            HeroAttributes actualAttributes = warrior.TotalAttributes();
            Assert.Equal(expectedAttributes.ToString(), actualAttributes.ToString());
        }

        [Fact]
        public void CheckHero_TotalAttributes_ReplacedPieceArmor()
        {

            Warrior warrior = new Warrior("testWarrior");
            Armor headArmor1 = new Armor("headArmor1", 1, Slot.Head, ArmorType.Plate, new HeroAttributes(1, 1, 1));
            Armor headArmor2 = new Armor("headArmor2", 1, Slot.Head, ArmorType.Plate, new HeroAttributes(3, 3, 3));
            warrior.EquipArmor(headArmor1);
            warrior.EquipArmor(headArmor2);
            HeroAttributes expectedAttributes = new HeroAttributes(9, 6, 5);
            HeroAttributes actualAttributes = warrior.TotalAttributes();
            Assert.Equal(expectedAttributes.ToString(), actualAttributes.ToString());
        }
        [Fact]
        public void CheckHero_Damage_NoWeapon()
        {

            Warrior warrior = new Warrior("testWarrior");
            double expectedDamage = 1 * (1 + 5 / 100.0);
            double actualDamage = warrior.Damage();
            Assert.Equal(expectedDamage, actualDamage);
        }

        [Fact]
        public void CheckHero_Damage_WithWeapon()
        {

            Warrior warrior = new Warrior("testWarrior");
            Weapon weapon = new Weapon("Weapon", 1, WeaponType.Sword, 11);
            warrior.EquipWeapon(weapon);
            double expectedDamage = 11 * (1 + 5 / 100.0);
            double actualDamage = warrior.Damage();
            Assert.Equal(expectedDamage, actualDamage);
        }
        [Fact]
        public void CheckHero_Damage_ReplacedWeapon()
        {

            Warrior warrior = new Warrior("testWarrior");
            Weapon weapon = new Weapon("Weapon", 1, WeaponType.Hammer, 11);
            warrior.EquipWeapon(weapon);
            Weapon weapon1 = new Weapon("Weapon1", 1, WeaponType.Axe, 15);
            warrior.EquipWeapon(weapon1);
            double expectedDamage = 15 * (1 + 5 / 100.0);
            double actualDamage = warrior.Damage();
            Assert.Equal(expectedDamage, actualDamage);
        }
        [Fact]
        public void CheckHero_Damage_WeaponAndThreePiecesOfArmor()
        {

            Warrior warrior = new Warrior("testWarrior");
            Weapon weapon = new Weapon("Weapon", 1, WeaponType.Axe, 11);
            Armor headArmor = new Armor("headArmor", 1, Slot.Head, ArmorType.Mail, new HeroAttributes(1, 1, 1));
            Armor bodyArmor = new Armor("bodyArmor", 1, Slot.Body, ArmorType.Plate, new HeroAttributes(2, 2, 2));
            Armor legsArmor = new Armor("bodyArmor", 1, Slot.Legs, ArmorType.Plate, new HeroAttributes(3, 3, 3));
            warrior.EquipWeapon(weapon);
            warrior.EquipArmor(headArmor);
            warrior.EquipArmor(bodyArmor);
            warrior.EquipArmor(legsArmor);
            warrior.EquipWeapon(weapon);
            double expectedDamage = 11 * (1 + 11 / 100.0);
            double actualDamage = warrior.Damage();
            Assert.Equal(expectedDamage, actualDamage);
        }
        [Fact]
        public void CheckHero_Display()
        {

            Warrior warrior = new Warrior("testWarrior");

            StringBuilder expectedString = new StringBuilder();
            expectedString.AppendLine("###################### Hero Description ######################");
            expectedString.AppendLine($"Name: testWarrior");
            expectedString.AppendLine($"Class: {HeroClass.Warrior}");
            expectedString.AppendLine($"Level: {1}");
            expectedString.AppendLine($"Total Strength: {5}");
            expectedString.AppendLine($"Total Dexterity: {2}");
            expectedString.AppendLine($"Total Intelligence: {1}");
            expectedString.AppendLine($"Damage: {1 * (1 + 5 / 100.0)}");
            Assert.Equal(expectedString.ToString(), warrior.Display());
        }
    }
}