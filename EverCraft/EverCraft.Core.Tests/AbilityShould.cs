using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace EverCraft.Core.Tests
{
    [TestClass]
    public class AbilityShould
    {

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [DataRow(0)]
        [DataRow(21)]
        public void BeWithinRange(int value)
        {
            var ability = new Ability();
            ability.Value = value;
        }

        [TestMethod]
        [DataRow(1, -5)]
        [DataRow(2, -4)]
        [DataRow(3, -4)]
        [DataRow(4, -3)]
        [DataRow(5, -3)]
        [DataRow(6, -2)]
        [DataRow(7, -2)]
        [DataRow(8, -1)]
        [DataRow(9, -1)]
        [DataRow(10, 0)]
        [DataRow(11, 0)]
        [DataRow(12, 1)]
        [DataRow(13, 1)]
        [DataRow(14, 2)]
        [DataRow(15, 2)]
        [DataRow(16, 3)]
        [DataRow(17, 3)]
        [DataRow(18, 4)]
        [DataRow(19, 4)]
        [DataRow(20, 5)]
        public void HaveSpecificModifierValues(int value, int modifier)
        {
            var ability = new Ability();
            ability.Value = value;

            ability.Modifier.Should().Be(modifier);

        }
    }
    
}
