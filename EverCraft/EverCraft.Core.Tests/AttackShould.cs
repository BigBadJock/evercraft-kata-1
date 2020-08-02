using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EverCraft.Core.Tests
{
    [TestClass]
    public class AttackShould
    {
        public Character character { get; set; }
        public Character target { get; set; }

        [TestInitialize]
        public void Initialize()
        {
            character = new Character();
            target = new Character();
        }


        [TestMethod]
        [DataRow(1, 16, true)]
        [DataRow(1, 15, false)]
        [DataRow(20, 6, true)]
        [DataRow(20, 5, false)]
        public void UseStrengthModifierInAttackSuccess(int strength, int roll, bool expectedResult)
        {
            character.Strength = strength;
            bool result = character.Attack(roll, target);
            result.Should().Be(expectedResult);
        }

        [TestMethod]
        [DataRow(1, 16, true, 10, 9)]
        [DataRow(1, 15, false, 10, 10)]
        [DataRow(20, 6, true, 10, 4)]
        [DataRow(20, 5, false, 10, 10)]
        [DataRow(19, 19, true, 10, 5)]
        [DataRow(18, 19, true, 10, 5)]
        [DataRow(17, 19, true, 10, 6)]
        [DataRow(16, 19, true, 10, 6)]
        [DataRow(15, 19, true, 10, 7)]
        [DataRow(14, 19, true, 10, 7)]
        [DataRow(13, 19, true, 10, 8)]
        [DataRow(12, 19, true, 10, 8)]
        [DataRow(11, 19, true, 10, 9)]
        public void UseStrengthModifierInAttackHitPoints(int strength, int roll, bool expectedResult, int targetHitPoints, int targetExpectedHitPoints)
        {
            character.Strength = strength;
            target.HitPoints = targetHitPoints;
            bool result = character.Attack(roll, target);
            result.Should().Be(expectedResult);
            target.CurrentHitPoints.Should().Be(targetExpectedHitPoints);

        }

        [TestMethod]
        [DataRow(20, 20, true, 10, -2)]
        [DataRow(19, 20, true, 10, 0)]
        [DataRow(18, 20, true, 10, 0)]
        [DataRow(17, 20, true, 10, 2)]
        [DataRow(16, 20, true, 10, 2)]
        [DataRow(15, 20, true, 10, 4)]
        [DataRow(14, 20, true, 10, 4)]
        [DataRow(13, 20, true, 10, 6)]
        [DataRow(12, 20, true, 10, 6)]
        [DataRow(11, 20, true, 10, 8)]
        public void UseDoubleStrengthModifierInCriticalAttackHitPoints(int strength, int roll, bool expectedResult, int targetHitPoints, int targetExpectedHitPoints)
        {
            character.Strength = strength;
            target.HitPoints = targetHitPoints;
            bool result = character.Attack(roll, target);
            result.Should().Be(expectedResult);
            target.CurrentHitPoints.Should().Be(targetExpectedHitPoints);

        }

        [TestMethod]
        [DataRow(1, 5, false)]
        [DataRow(1, 6, true)]
        [DataRow(1, 10, true)]
        [DataRow(8, 10, true)]
        [DataRow(9, 10, true)]
        [DataRow(10, 10, false)]
        [DataRow(11, 10, false)]
        [DataRow(15, 20, true)]
        [DataRow(16, 20, true)]
        public void UseDexterityModifierWithArmourClass(int dexterity, int roll, bool expectedHit)
        {
            this.target.Dexterity = dexterity;
            var result=this.character.Attack(roll, target);
            result.Should().Be(expectedHit);
        }

        [TestMethod]
        [DataRow(1, 5)]
        [DataRow(9,9)]
        [DataRow(10,10)]
        [DataRow(11,10)]
        [DataRow(12, 11)]
        [DataRow(14, 12)]
        [DataRow(17, 13)]
        public void AdjustArmourClassByDexterityModifier(int dexterity, int expected)
        {
            character.Dexterity = dexterity;
            character.ModifiedArmourClass.Should().Be(expected);
        }

        [TestMethod]
        [DataRow(1, 1)]
        [DataRow(2, 1)]
        [DataRow(9, 4)]
        [DataRow(10, 5)]
        [DataRow(11, 5)]
        [DataRow(13, 6)]
        [DataRow(15, 7)]
        [DataRow(20, 10)]
        public void UseHitPointsModifiedByConstitution(int constitution, int expected)
        {
            character.Constitution = constitution;
            character.CurrentHitPoints.Should().Be(expected);
        }


        [TestMethod]
        [DataRow(500, 9, false)]
        [DataRow(1500, 9, false)]
        [DataRow(2500, 9, false)]
        [DataRow(3500, 9, true)]
        [DataRow(3500, 8, false)]
        [DataRow(5500, 8, true)]
        public void IncreaseAttackRollByLevel(int xp, int roll, bool expectedResult)
        {
            character.XP = xp;
            bool result = character.Attack(roll, target);
            result.Should().Be(expectedResult);
        }

    }
}
