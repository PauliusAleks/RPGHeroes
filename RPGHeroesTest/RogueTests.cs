using RPGHeroes.Exceptions;
using RPGHeroes.Heroes;
using RPGHeroes.Items;
using RPGHeroes.listOfHeroes;
using System;
using System.Text;
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
            Assert.Throws<InvalidArmorException>(() => rogue.EquipArmor(armor));
        }
        [Fact]
        public void CHeckIfArmorCanBeEquiped()
        {
            Rogue rogue = new Rogue("testRogue");

            List<ArmorType> ExpectedValidArmorTypes = new List<ArmorType>() { ArmorType.Leather,ArmorType.Mail };
            List<ArmorType> ActualValidArmorTypes = rogue.ValidArmorTypes;
            Assert.Equal(ExpectedValidArmorTypes, ActualValidArmorTypes);
        }
        [Fact]
        public void CheckHero_TotalAttributes_NoArmor()
        {
            Rogue rogue = new Rogue("testRogue");

            HeroAttributes expectedAttributes = new HeroAttributes(2, 6, 1);
            HeroAttributes actualAttributes = rogue.TotalAttributes();
            Assert.Equal(expectedAttributes.ToString(), actualAttributes.ToString());
        }
        [Fact]
        public void CheckHero_TotalAttributes_OnePieceArmor()
        {
            Rogue rogue = new Rogue("testRogue");

            Armor headArmor = new Armor("headArmor", 1, Slot.Head, ArmorType.Leather, new HeroAttributes(1, 1, 1));
            rogue.EquipArmor(headArmor);
            HeroAttributes expectedAttributes = new HeroAttributes(3, 7, 2);
            HeroAttributes actualAttributes = rogue.TotalAttributes();
            Assert.Equal(expectedAttributes.ToString(), actualAttributes.ToString());
        }
        [Fact]
        public void CheckHero_TotalAttributes_TwoPieceArmor()
        {
            Rogue rogue = new Rogue("testRogue");

            Armor headArmor = new Armor("headArmor", 1, Slot.Head, ArmorType.Leather, new HeroAttributes(1, 1, 1));
            Armor bodyArmor = new Armor("bodyArmor", 1, Slot.Body, ArmorType.Mail, new HeroAttributes(1, 1, 1));
            rogue.EquipArmor(headArmor);
            rogue.EquipArmor(bodyArmor);
            HeroAttributes expectedAttributes = new HeroAttributes(4, 8, 3);
            HeroAttributes actualAttributes = rogue.TotalAttributes();
            Assert.Equal(expectedAttributes.ToString(), actualAttributes.ToString());
        }

        [Fact]
        public void CheckHero_TotalAttributes_ReplacedPieceArmor()
        {
            Rogue rogue = new Rogue("testRogue");

            Armor headArmor1 = new Armor("headArmor1", 1, Slot.Head, ArmorType.Leather, new HeroAttributes(1, 1, 1));
            Armor headArmor2 = new Armor("headArmor2", 1, Slot.Head, ArmorType.Mail, new HeroAttributes(3, 3, 3));
            rogue.EquipArmor(headArmor1);
            rogue.EquipArmor(headArmor2);
            HeroAttributes expectedAttributes = new HeroAttributes(6, 10, 5);
            HeroAttributes actualAttributes = rogue.TotalAttributes();
            Assert.Equal(expectedAttributes.ToString(), actualAttributes.ToString());
        }
        [Fact]
        public void CheckHero_Damage_NoWeapon()
        {
            Rogue rogue = new Rogue("testRogue");
            double expectedDamage = 1 * (1 + 6 / 100.0);
            double actualDamage = rogue.Damage();
            Assert.Equal(expectedDamage, actualDamage);
        }

        [Fact]
        public void CheckHero_Damage_WithWeapon()
        {
            Rogue rogue = new Rogue("testRogue");

            Weapon weapon = new Weapon("Weapon", 1, WeaponType.Dagger, 11);
            rogue.EquipWeapon(weapon);
            double expectedDamage = 11 * (1 + 6 / 100.0);
            double actualDamage = rogue.Damage();
            Assert.Equal(expectedDamage, actualDamage);
        }
        [Fact]
        public void CheckHero_Damage_ReplacedWeapon()
        {
            Rogue rogue = new Rogue("testRogue");

            Weapon weapon = new Weapon("Weapon", 1, WeaponType.Sword, 11);
            rogue.EquipWeapon(weapon);
            Weapon weapon1 = new Weapon("Weapon1", 1, WeaponType.Dagger, 15);
            rogue.EquipWeapon(weapon1);
            double expectedDamage = 15 * (1 + 6 / 100.0);
            double actualDamage = rogue.Damage();
            Assert.Equal(expectedDamage, actualDamage);
        }
        [Fact]
        public void CheckHero_Damage_WeaponAndThreePiecesOfArmor()
        {
            Rogue rogue = new Rogue("testRogue");

            Weapon weapon = new Weapon("Weapon", 1, WeaponType.Sword, 11);
            Armor headArmor = new Armor("headArmor", 1, Slot.Head, ArmorType.Leather, new HeroAttributes(1, 1, 1));
            Armor bodyArmor = new Armor("bodyArmor", 1, Slot.Body, ArmorType.Mail, new HeroAttributes(2, 2, 2));
            Armor legsArmor = new Armor("bodyArmor", 1, Slot.Legs, ArmorType.Leather, new HeroAttributes(3, 3, 3));
            rogue.EquipWeapon(weapon);
            rogue.EquipArmor(headArmor);
            rogue.EquipArmor(bodyArmor);
            rogue.EquipArmor(legsArmor);
            rogue.EquipWeapon(weapon);
            double expectedDamage = 11 * (1 + 12 / 100.0);
            double actualDamage = rogue.Damage();
            Assert.Equal(expectedDamage, actualDamage);
        }
        [Fact]
        public void CheckHero_Display()
        {
            Rogue rogue = new Rogue("testRogue");
            StringBuilder expectedString = new StringBuilder();
            expectedString.AppendLine("###################### Hero Description ######################");
            expectedString.AppendLine($"Name: testRogue");
            expectedString.AppendLine($"Class: {HeroClass.Rogue}");
            expectedString.AppendLine($"Level: {1}");
            expectedString.AppendLine($"Total Strength: {2}");
            expectedString.AppendLine($"Total Dexterity: {6}");
            expectedString.AppendLine($"Total Intelligence: {1}");
            expectedString.AppendLine($"Damage: {1 * (1 + 6 / 100.0)}");
            Assert.Equal(expectedString.ToString(), rogue.Display());
        }
    }
}