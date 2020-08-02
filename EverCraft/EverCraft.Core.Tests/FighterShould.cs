using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EverCraft.Core.Tests
{

    [TestClass]
    public class FighterShould
    {

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
        [DataRow(0, 1, 10, 1, 5, 5)]
        [DataRow(999, 1, 1009, 2, 5, 15)]
        [DataRow(1999, 2, 2009, 3, 15, 25)]
        public void LevelUp(int currentXP, int currentLevel, int expectedXP, int expectedLevel, int hitPoints, int expectedHitPoints)
        {
            Fighter fighter = new Fighter();
            var target = new Character();
            fighter.XP = currentXP;
            fighter.HitPoints = hitPoints;

            fighter.Level.Should().Be(currentLevel);
            var result = fighter.Attack(20, target);

            result.Should().BeTrue();
            fighter.XP.Should().Be(expectedXP);
            fighter.Level.Should().Be(expectedLevel);
            fighter.HitPoints.Should().Be(expectedHitPoints);
        }

    }
}
