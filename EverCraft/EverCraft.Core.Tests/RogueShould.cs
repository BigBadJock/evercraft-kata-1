using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace EverCraft.Core.Tests
{
    [TestClass]
    public class RogueShould
    {

        [TestMethod]
        [DataRow(20, 20, true, 10, -8)]
        [DataRow(19, 20, true, 10, -5)]
        [DataRow(18, 20, true, 10, -5)]
        [DataRow(17, 20, true, 10, -2)]
        [DataRow(16, 20, true, 10, -2)]
        [DataRow(15, 20, true, 10, 1)]
        [DataRow(14, 20, true, 10, 1)]
        [DataRow(13, 20, true, 10, 4)]
        [DataRow(12, 20, true, 10, 4)]
        [DataRow(11, 20, true, 10, 7)]
        public void DoTripleDamageOnCriticalHits(int strength, int roll, bool expectedResult, int targetHitPoints, int targetExpectedHitPoints)
        {
            Rogue rogue = new Rogue();
            Character target = new Character();

            rogue.Strength = strength;
            target.HitPoints = targetHitPoints;
            bool result = rogue.Attack(roll, target);
            result.Should().Be(expectedResult);
            target.CurrentHitPoints.Should().Be(targetExpectedHitPoints);
        }

        [TestMethod]
        public void IgnoreTargetsPositiveDexterityModifierToArmourClass()
        {
            Rogue rogue = new Rogue();
            Character target = new Character();
            target.Dexterity = 20;

            target.ModifiedArmourClass.Should().Be(15);
            var result = rogue.Attack(11, target);

            result.Should().BeTrue();
        }

        [TestMethod]
        public void UsesDexterityModifierOnAttack()
        {
            Rogue rogue = new Rogue();
            Character target = new Character();
            rogue.Dexterity = 20;

            var result = rogue.Attack(6, target);

            result.Should().BeTrue();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void NotAllowAlignmentGood()
        {
            Rogue rogue = new Rogue();
            rogue.Alignment = Alignments.Good;
        }


    }
}
