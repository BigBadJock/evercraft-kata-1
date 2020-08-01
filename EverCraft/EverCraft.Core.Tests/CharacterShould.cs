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
        public void SetAndGetName()
        {
            var name = "Bilbo";
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
    }
}
