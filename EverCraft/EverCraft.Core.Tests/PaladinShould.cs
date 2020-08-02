using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace EverCraft.Core.Tests
{
    [TestClass]
    public class PaladinShould
    {
        [TestMethod]
        [DataRow(999, 1, 2, 5, 13)]
        [DataRow(1999, 2, 3, 13, 21)]
        [DataRow(2999, 3, 4, 21, 29)]
        public void IncreaseHitPointsBy8PerLevel(int xp, int currentlevel, int newLevel, int currentHitPoints, int newHitPoints)
        {
            Paladin paladin = new Paladin();
            paladin.XP = xp;
            paladin.Level.Should().Be(currentlevel);
            paladin.HitPoints = currentHitPoints;

            Character target = new Character();
            var result = paladin.Attack(20, target);
            result.Should().BeTrue();

            paladin.Level.Should().Be(newLevel);
            paladin.HitPoints.Should().Be(newHitPoints);
        }

        [TestMethod]
        [DataRow(10, 12, Alignments.Evil)]
        [DataRow(10, 10, Alignments.Neutral)]
        [DataRow(10, 10, Alignments.Good)]
        public void Add2ToAttackRollWhenTargetIsEvil(int roll, int adjustedRoll, Alignments alignment)
        {
            Paladin paladin = new Paladin();
            Character target = new Character();
            target.Alignment = alignment;

            paladin.AdjustRoll(roll, target).Should().Be(adjustedRoll);
        }

        [TestMethod]
        [DataRow(10, 12, Alignments.Evil, 2)]
        [DataRow(12, 10, Alignments.Neutral, 4)]
        [DataRow(12, 10, Alignments.Good, 4)]
        public void Add2ToDamagehenTargetIsEvil(int roll, int adjustedRoll, Alignments alignment, int expectedHitPoints)
        {
            Paladin paladin = new Paladin();
            Character target = new Character();
            target.Alignment = alignment;

            paladin.Attack(roll, target);
            target.CurrentHitPoints.Should().Be(expectedHitPoints);
        }

        [TestMethod]
        [DataRow(Alignments.Evil, -4)]
        [DataRow(Alignments.Neutral, 3)]
        [DataRow(Alignments.Good, 3)]
        public void DoTripleDamageToEvilCharactesrOnCriticalHit(Alignments alignment, int expectedHitPoints)
        {
            Paladin paladin = new Paladin();
            Character target = new Character();
            target.Alignment = alignment;

            paladin.Attack(20, target);

            target.CurrentHitPoints.Should().Be(expectedHitPoints);
        }

        [TestMethod]
        [DataRow(500, 9, false)]
        [DataRow(1500, 9, true)]
        [DataRow(2500, 9, true)]
        [DataRow(3500, 9, true)]
        [DataRow(3500, 8, true)]
        [DataRow(5500, 8, true)]
        public void IncreaseAttackRollByLevel(int xp, int roll, bool expectedResult)
        {
            Fighter fighter = new Fighter();
            Character target = new Character();
            fighter.XP = xp;
            bool result = fighter.Attack(roll, target);
            result.Should().Be(expectedResult);
        }

        [TestMethod]
        [DataRow(Alignments.Evil)]
        [DataRow(Alignments.Neutral)]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void OnlyAllowAlignmentGood(Alignments alignment)
        {
            Paladin paladin = new Paladin();
            paladin.Alignment = alignment;
        }

    }
}
