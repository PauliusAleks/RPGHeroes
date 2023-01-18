using RPGHeroes.Exceptions;
using RPGHeroes.Heroes;
using RPGHeroes.Items;
using RPGHeroes.listOfHeroes;
using System.ComponentModel;
using System.Text;
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
            Assert.Throws<InvalidArmorException>(() => ranger.EquipArmor(armor));
        }
        [Fact]
        public void CHeckIfArmorCanBeEquiped()
        {
            Ranger ranger = new Ranger("testRanger");

            List<ArmorType> ExpectedValidArmorTypes = new List<ArmorType>() { ArmorType.Leather,ArmorType.Mail };
            List<ArmorType> ActualValidArmorTypes = ranger.ValidArmorTypes;
            Assert.Equal(ExpectedValidArmorTypes, ActualValidArmorTypes);
        }
        [Fact]
        public void CheckHero_TotalAttributes_NoArmor()
        {
            Ranger ranger = new Ranger("testRanger");

            HeroAttributes expectedAttributes = new HeroAttributes(1, 7, 1);
            HeroAttributes actualAttributes = ranger.TotalAttributes();
            Assert.Equal(expectedAttributes.ToString(), actualAttributes.ToString());
        }
        [Fact]
        public void CheckHero_TotalAttributes_OnePieceArmor()
        {
            Ranger ranger = new Ranger("testRanger");

            Armor headArmor = new Armor("headArmor", 1, Slot.Head, ArmorType.Mail, new HeroAttributes(1, 1, 1));
            ranger.EquipArmor(headArmor);
            HeroAttributes expectedAttributes = new HeroAttributes(2, 8, 2);
            HeroAttributes actualAttributes = ranger.TotalAttributes();
            Assert.Equal(expectedAttributes.ToString(), actualAttributes.ToString());
        }
        [Fact]
        public void CheckHero_TotalAttributes_TwoPieceArmor()
        {
            Ranger ranger = new Ranger("testRanger");

            Armor headArmor = new Armor("headArmor", 1, Slot.Head, ArmorType.Mail, new HeroAttributes(1, 1, 1));
            Armor bodyArmor = new Armor("bodyArmor", 1, Slot.Body, ArmorType.Mail, new HeroAttributes(1, 1, 1));
            ranger.EquipArmor(headArmor);
            ranger.EquipArmor(bodyArmor);
            HeroAttributes expectedAttributes = new HeroAttributes(3, 9, 3);
            HeroAttributes actualAttributes = ranger.TotalAttributes();
            Assert.Equal(expectedAttributes.ToString(), actualAttributes.ToString());
        }

        [Fact]
        public void CheckHero_TotalAttributes_ReplacedPieceArmor()
        {
            Ranger ranger = new Ranger("testRanger");

            Armor headArmor1 = new Armor("headArmor1", 1, Slot.Head, ArmorType.Mail, new HeroAttributes(1, 1, 1));
            Armor headArmor2 = new Armor("headArmor2", 1, Slot.Head, ArmorType.Mail, new HeroAttributes(3, 3, 3));
            ranger.EquipArmor(headArmor1);
            ranger.EquipArmor(headArmor2);
            HeroAttributes expectedAttributes = new HeroAttributes(5, 9, 5);
            HeroAttributes actualAttributes = ranger.TotalAttributes();
            Assert.Equal(expectedAttributes.ToString(), actualAttributes.ToString());
        }
        [Fact]
        public void CheckHero_Damage_NoWeapon()
        {
            Ranger ranger = new Ranger("testRanger");

            double expectedDamage = 1 * (1 + 7 / 100.0);
            double actualDamage = ranger.Damage();
            Assert.Equal(expectedDamage, actualDamage);
        }

        [Fact]
        public void CheckHero_Damage_WithWeapon()
        {
            Ranger ranger = new Ranger("testRanger");

            Weapon weapon = new Weapon("Weapon", 1, WeaponType.Bow, 11);
            ranger.EquipWeapon(weapon);
            double expectedDamage = 11 * (1 + 7 / 100.0);
            double actualDamage = ranger.Damage();
            Assert.Equal(expectedDamage, actualDamage);
        }
        [Fact]
        public void CheckHero_Damage_ReplacedWeapon()
        {
            Ranger ranger = new Ranger("testRanger");

            Weapon weapon = new Weapon("Weapon", 1, WeaponType.Bow, 11);
            ranger.EquipWeapon(weapon);
            Weapon weapon1 = new Weapon("Weapon1", 1, WeaponType.Bow, 15);
            ranger.EquipWeapon(weapon1);
            double expectedDamage = 15 * (1 + 7 / 100.0);
            double actualDamage = ranger.Damage();
            Assert.Equal(expectedDamage, actualDamage);
        }
        [Fact]
        public void CheckHero_Damage_WeaponAndThreePiecesOfArmor()
        {
            Ranger ranger = new Ranger("testRanger");

            Weapon weapon = new Weapon("Weapon", 1, WeaponType.Bow, 11);
            Armor headArmor = new Armor("headArmor", 1, Slot.Head, ArmorType.Mail, new HeroAttributes(1, 1, 1));
            Armor bodyArmor = new Armor("bodyArmor", 1, Slot.Body, ArmorType.Mail, new HeroAttributes(2, 2, 2));
            Armor legsArmor = new Armor("bodyArmor", 1, Slot.Legs, ArmorType.Mail, new HeroAttributes(3, 3, 3));
            ranger.EquipWeapon(weapon);
            ranger.EquipArmor(headArmor);
            ranger.EquipArmor(bodyArmor);
            ranger.EquipArmor(legsArmor);
            ranger.EquipWeapon(weapon);
            double expectedDamage = 11 * (1 + 13 / 100.0);
            double actualDamage = ranger.Damage();
            Assert.Equal(expectedDamage, actualDamage);
        }
        [Fact]
        public void CheckHero_Display()
        {
            Ranger ranger = new Ranger("testRanger");


            StringBuilder expectedString = new StringBuilder();
            expectedString.AppendLine("###################### Hero Description ######################");
            expectedString.AppendLine($"Name: testRanger");
            expectedString.AppendLine($"Class: {HeroClass.Ranger}");
            expectedString.AppendLine($"Level: {1}");
            expectedString.AppendLine($"Total Strength: {1}");
            expectedString.AppendLine($"Total Dexterity: {7}");
            expectedString.AppendLine($"Total Intelligence: {1}");
            expectedString.AppendLine($"Damage: {1 * (1 + 7 / 100.0)}");
            Assert.Equal(expectedString.ToString(), ranger.Display());
        }


    }
}