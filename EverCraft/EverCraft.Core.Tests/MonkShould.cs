using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EverCraft.Core.Tests
{
    [TestClass]
    public class MonkShould
    {
        [TestMethod]
        [DataRow(0, 1, 10, 1, 5, 5)]
        [DataRow(999, 1, 1009, 2, 5, 11)]
        [DataRow(1999, 2, 2009, 3, 11, 17)]
        public void LevelUp(int currentXP, int currentLevel, int expectedXP, int expectedLevel, int hitPoints, int expectedHitPoints)
        {
            Monk Monk = new Monk();
            var target = new Character();
            Monk.XP = currentXP;
            Monk.HitPoints = hitPoints;

            Monk.Level.Should().Be(currentLevel);
            var result = Monk.Attack(20, target);

            result.Should().BeTrue();
            Monk.XP.Should().Be(expectedXP);
            Monk.Level.Should().Be(expectedLevel);
            Monk.HitPoints.Should().Be(expectedHitPoints);
        }


        [TestMethod]
        public void Cause3PointsOfDamage()
        {
            Monk monk = new Monk();
            var target = new Character();
            var result = monk.Attack(19, target);
            result.Should().BeTrue();
            target.CurrentHitPoints.Should().Be(2);
        }

        [TestMethod]
        [DataRow(1, 10, 10)]
        [DataRow(1, 20, 15)]
        [DataRow(20, 10, 15)]
        [DataRow(20, 20, 20)]
        public void AddPositiveWisdomModifierToArmourClass(int wisdom, int dexterity, int expected)
        {
            Monk monk = new Monk();
            monk.Wisdom = wisdom;
            monk.Dexterity = dexterity;
            monk.ModifiedArmourClass.Should().Be(expected);
        }

        [TestMethod]
        [DataRow(500, 1, 10, 10)]
        [DataRow(1500, 2, 9, 10)]
        [DataRow(1500, 2, 10, 11)]
        [DataRow(2500, 3, 8, 10)]
        [DataRow(2500, 3, 9, 11)]
        [DataRow(2500, 3, 10, 12)]
        [DataRow(3500, 4, 8, 10)]
        [DataRow(3500, 4, 9, 11)]
        [DataRow(4500, 5, 8, 11)]
        [DataRow(4500, 5, 9, 12)]
        public void IncreaseAttackRollEvery2ndAnd3rdLevel(int xp, int expectedLevel, int roll, int adjustedRoll)
        {
            Monk monk = new Monk();
            monk.XP = xp;
            monk.Level.Should().Be(expectedLevel);
            monk.AdjustRoll(roll).Should().Be(adjustedRoll);
        }
    }
}
