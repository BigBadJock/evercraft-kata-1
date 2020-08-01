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
        [DataRow("Frodo", Alignments.Good, 20)]
        [DataRow("Boromir", Alignments.Neutral, 10)]
        [DataRow("Gollum", Alignments.Evil, 5)]
        public void SetAndGetBasicValues(string name, Alignments alignment, int armourClass)
        {
            character.Name = name;
            character.Alignment = alignment;
            character.ArmourClass = armourClass;

            character.Name.Should().Be(name);
            character.Alignment.Should().Be(alignment);
            character.ArmourClass.Should().Be(armourClass);
        }

    }
}
