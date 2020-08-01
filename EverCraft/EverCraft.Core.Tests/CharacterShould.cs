using FluentAssertions;
using EverCraft.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EverCraft.Core.Tests
{
    [TestClass]
    public class CharacterShould
    {
        Character character;

        [TestInitialize]
        public void Initialize()
        {
            this.character = new Character();
        }

        [TestMethod]
        public void HaveDefaultsAtCreation()
        {
            character.Name.Should().Be("default");
            character.Alignment.Should().Be(Alignments.Neutral);
            character.ArmourClass.Should().Be(10);
        }


        [TestMethod]
        [DataRow("Bilbo")]
        [DataRow("Frodo")]
        [DataRow("Gimli")]
        public void SetAndGetName(string name)
        {
            character.Name = name;
            character.Name.Should().Be(name);
        }


        [TestMethod]
        [DataRow(Alignments.Evil)]
        [DataRow(Alignments.Neutral)]
        [DataRow(Alignments.Good)]
        public void SetAndGetAlignment(Alignments alignment)
        {
            character.Alignment = alignment;

            character.Alignment.Should().Be(alignment);
        }


        [TestMethod]
        [DataRow(5)]
        [DataRow(10)]
        [DataRow(20)]

        public void SetAndGetArmourClass(int armourClass)
        {
            character.ArmourClass = armourClass;
            character.ArmourClass.Should().Be(armourClass);
        }
    }
}
