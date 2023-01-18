using RPGHeroes.Exceptions;
using RPGHeroes.Heroes;
using RPGHeroes.Items;
using RPGHeroes.listOfHeroes;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Reflection.Emit;
using System.Text;
using System.Xml.Linq;

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
            Assert.Throws<InvalidArmorException>(() => mage.EquipArmor(armor));
        }
        [Fact]
        public void CHeckIfArmorCanBeEquiped()
        {
            Mage mage = new Mage("testMage");
            List<ArmorType> ExpectedValidArmorTypes = new List<ArmorType>() {ArmorType.Cloth};
            List<ArmorType> ActualValidArmorTypes = mage.ValidArmorTypes;
            Assert.Equal(ExpectedValidArmorTypes,ActualValidArmorTypes);

        }

        [Fact]
        public void CheckHero_TotalAttributes_NoArmor()
        {
            Mage mage = new Mage("testMage");
            HeroAttributes expectedAttributes = new HeroAttributes(1,1,8);
            HeroAttributes actualAttributes = mage.TotalAttributes();
            Assert.Equal(expectedAttributes.ToString(), actualAttributes.ToString());
        }
        [Fact]
        public void CheckHero_TotalAttributes_OnePieceArmor()
        {
            Mage mage = new Mage("testMage");
            Armor headArmor = new Armor("headArmor", 1, Slot.Head, ArmorType.Cloth, new HeroAttributes(1, 1, 1));
            mage.EquipArmor(headArmor);
            HeroAttributes expectedAttributes = new HeroAttributes(2, 2, 9);
            HeroAttributes actualAttributes = mage.TotalAttributes();
            Assert.Equal(expectedAttributes.ToString(), actualAttributes.ToString());
        }
        [Fact]
        public void CheckHero_TotalAttributes_TwoPieceArmor()
        {
            Mage mage = new Mage("testMage");
            Armor headArmor = new Armor("headArmor", 1, Slot.Head, ArmorType.Cloth, new HeroAttributes(1, 1, 1));
            Armor bodyArmor = new Armor("bodyArmor", 1, Slot.Body, ArmorType.Cloth, new HeroAttributes(1, 1, 1));
            mage.EquipArmor(headArmor);
            mage.EquipArmor(bodyArmor);
            HeroAttributes expectedAttributes = new HeroAttributes(3, 3, 10);
            HeroAttributes actualAttributes = mage.TotalAttributes();
            Assert.Equal(expectedAttributes.ToString(), actualAttributes.ToString());
        }
        
        [Fact]
        public void CheckHero_TotalAttributes_ReplacedPieceArmor()
        {
            Mage mage = new Mage("testMage");
            Armor headArmor1 = new Armor("headArmor1", 1, Slot.Head, ArmorType.Cloth, new HeroAttributes(1, 1, 1));
            Armor headArmor2 = new Armor("headArmor2", 1, Slot.Head, ArmorType.Cloth, new HeroAttributes(3, 3, 3));
            mage.EquipArmor(headArmor1);
            mage.EquipArmor(headArmor2);
            HeroAttributes expectedAttributes = new HeroAttributes(4, 4, 12);
            HeroAttributes actualAttributes = mage.TotalAttributes();
            Assert.Equal(expectedAttributes.ToString(), actualAttributes.ToString());
        }
        [Fact]
        public void CheckHero_Damage_NoWeapon()
        {
            Mage mage = new Mage("testMage");
            double expectedDamage = 1*(1+8 / 100.0);
            double actualDamage = mage.Damage();
            Assert.Equal(expectedDamage, actualDamage);
        }
        
        [Fact]
        public void CheckHero_Damage_WithWeapon()
        {
            Mage mage = new Mage("testMage");
            Weapon weapon = new Weapon("Weapon", 1, WeaponType.Wand, 11);
            mage.EquipWeapon(weapon);
            double expectedDamage = 11 * (1 + 8 / 100.0);
            double actualDamage = mage.Damage();
            Assert.Equal(expectedDamage, actualDamage);
        }
        [Fact]
        public void CheckHero_Damage_ReplacedWeapon()
        {
            Mage mage = new Mage("testMage");
            Weapon weapon = new Weapon("Weapon", 1, WeaponType.Wand, 11);
            mage.EquipWeapon(weapon);
            Weapon weapon1 = new Weapon("Weapon1", 1, WeaponType.Staff, 15);
            mage.EquipWeapon(weapon1);
            double expectedDamage = 15 * (1 + 8 / 100.0);
            double actualDamage = mage.Damage();
            Assert.Equal(expectedDamage, actualDamage);
        }
        [Fact]
        public void CheckHero_Damage_WeaponAndThreePiecesOfArmor()
        {
            Mage mage = new Mage("testMage");
            Weapon weapon = new Weapon("Weapon", 1, WeaponType.Wand, 11);
            Armor headArmor = new Armor("headArmor", 1, Slot.Head, ArmorType.Cloth, new HeroAttributes(1, 1, 1));
            Armor bodyArmor = new Armor("bodyArmor", 1, Slot.Body, ArmorType.Cloth, new HeroAttributes(2, 2, 2));
            Armor legsArmor = new Armor("bodyArmor", 1, Slot.Legs, ArmorType.Cloth, new HeroAttributes(3, 3, 3));
            mage.EquipWeapon(weapon);
            mage.EquipArmor(headArmor);
            mage.EquipArmor(bodyArmor);
            mage.EquipArmor(legsArmor);
            mage.EquipWeapon(weapon);
            double expectedDamage = 11 * (1 + 14 / 100.0);
            double actualDamage = mage.Damage();
            Assert.Equal(expectedDamage, actualDamage);
        }
        [Fact]
        public void CheckHero_Display()
        {
            Mage mage = new Mage("testMage");

            StringBuilder expectedString = new StringBuilder();
            expectedString.AppendLine("###################### Hero Description ######################");
            expectedString.AppendLine($"Name: testMage");
            expectedString.AppendLine($"Class: {HeroClass.Mage}");
            expectedString.AppendLine($"Level: {1}");
            expectedString.AppendLine($"Total Strength: {1}");
            expectedString.AppendLine($"Total Dexterity: {1}");
            expectedString.AppendLine($"Total Intelligence: {8}");
            expectedString.AppendLine($"Damage: {1 * (1 + 8 / 100.0)}");
            Assert.Equal(expectedString.ToString(), mage.Display());
        }
        

    }
}