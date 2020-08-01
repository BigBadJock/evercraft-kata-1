using FluentAssertions;
using EverCraft.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EverCraft.Core.Tests
{
    [TestClass]
    public class CharacterShould
    {
        [TestMethod]
        public void HaveDefaultNameAtCreation()
        {
            var character = new Character();
            character.Name.Should().Be("default");
        }

        [TestMethod]
        [DataRow("Bilbo")]
        [DataRow("Frodo")]
        [DataRow("Gimli")]
        public void SetAndGetName(string name)
        {
            var character = new Character();
            character.Name = name;

            character.Name.Should().Be(name);
        }

        [TestMethod]
        public void HaveDefaultAlignmentAtCreation()
        {
            var character = new Character();

            character.Alignment.Should().Be(Alignments.Neutral);
        }


        [TestMethod]
        [DataRow(Alignments.Evil)]
        [DataRow(Alignments.Neutral)]
        [DataRow(Alignments.Good)]
        public void SetAndGetAlignment(Alignments alignment)
        {
            var character = new Character();
            character.Alignment = alignment;

            character.Alignment.Should().Be(alignment);
        }

        [TestMethod]
        public void HaveDefaultArmourClassAtCreation()
        {
            var character = new Character();
            character.ArmourClass.Should().Be(10);

        }

        [TestMethod]
        [DataRow(5)]
        [DataRow(10)]
        [DataRow(20)]

        public void SetAndGetArmourClass(int armourClass)
        {
            var character = new Character();
            character.ArmourClass = armourClass;
            character.ArmourClass.Should().Be(armourClass);
        }
    }
}
