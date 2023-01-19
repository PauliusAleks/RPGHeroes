using RPGHeroes.Heroes;
using RPGHeroes.Items;
using RPGHeroes.listOfHeroes;

namespace RPGHeroesTests
{
    /// <summary>
    /// All required tests to test armor class.
    /// </summary>
    public class ArmorTests
    {
        [Fact]
        public void NewWArmor_ShouldReturnCorrectName()
        {
            Armor armor = new Armor("Test armor", 15, Slot.Body, ArmorType.Leather, new HeroAttributes(10, 20, 30));
            string expectedName = "Test armor";
            string actualName = armor.Name;
            Assert.Equal(expectedName, actualName);
        }
        [Fact]
        public void NewArmor_ShouldReturnCorrectRequiredLevel()
        {
            Armor armor = new Armor("Test armor", 15, Slot.Body, ArmorType.Leather, new HeroAttributes(10, 20, 30));
            int expectedReuiredLevel = 15;
            int actualRequiredLevel = armor.RequiredLevel;
            Assert.Equal(expectedReuiredLevel, actualRequiredLevel);
        }
        [Fact]
        public void NewArmor_ShouldReturnCorrectSlot()
        {
            Armor armor = new Armor("Test armor", 15, Slot.Body, ArmorType.Leather, new HeroAttributes(10, 20, 30));
            Slot expectedSlot = Slot.Body;
            Slot actualSlot = armor.Slot;
            Assert.Equal(expectedSlot, actualSlot);
        }
        [Fact]
        public void NewArmor_ShouldReturnCorrectWeaponType()
        {
            Armor armor = new Armor("Test armor", 15, Slot.Body, ArmorType.Leather, new HeroAttributes(10, 20, 30));
            ArmorType expectedArmorType = ArmorType.Leather;
            ArmorType actualArmorType = armor.ArmorType;
            Assert.Equal(expectedArmorType, actualArmorType);
        }
        [Fact]
        public void NewWArmor_ShouldReturnCorrectStrengthAttribute()
        {
            Armor armor = new Armor("Test armor", 15, Slot.Body, ArmorType.Leather, new HeroAttributes(10, 20, 30));
            int expectedStrenthAttribute = 10;
            int actualStrenthAttribute = armor.ArmorAttribute.Strength;
            Assert.Equal(expectedStrenthAttribute, actualStrenthAttribute);
        }
        [Fact]
        public void NewWArmor_ShouldReturnCorrectDexterityAttribute()
        {
            Armor armor = new Armor("Test armor", 15, Slot.Body, ArmorType.Leather, new HeroAttributes(10, 20, 30));
            int expectedDexterityAttribute = 20;
            int actualDexterityAttribute = armor.ArmorAttribute.Dexterity;
            Assert.Equal(expectedDexterityAttribute, actualDexterityAttribute);
        }
        [Fact]
        public void NewWArmor_ShouldReturnCorrectIntelligenceAttribute()
        {
            Armor armor = new Armor("Test armor", 15, Slot.Body, ArmorType.Leather, new HeroAttributes(10, 20, 30));
            int expectedIntelligenceAttribute = 30;
            int actualIntelligenceAttribute = armor.ArmorAttribute.Intelligence;
            Assert.Equal(expectedIntelligenceAttribute, actualIntelligenceAttribute);
        }
    }
}
