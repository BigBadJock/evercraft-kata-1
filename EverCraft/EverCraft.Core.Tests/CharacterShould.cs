using FluentAssertions;
using EverCraft.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

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
            character.HitPoints.Should().Be(5);
            character.Alive.Should().Be(true);
            character.Strength.Value.Should().Be(10);
            character.Dexterity.Value.Should().Be(10);
            character.Constitution.Value.Should().Be(10);
            character.Wisdom.Value.Should().Be(10);
            character.Intelligence.Value.Should().Be(10);
            character.Charisma.Value.Should().Be(10);
        }

        [TestMethod]
        [DataRow("Frodo", Alignments.Good, 20, 5, 20, 9, 15, 14, 14, 17)]
        [DataRow("Boromir", Alignments.Neutral, 10, 10, 18, 14, 19, 12, 13, 16)]
        [DataRow("Gollum", Alignments.Evil, 5, 7, 10, 16, 16, 8, 12, 4)]
        public void SetAndGetBasicValues(string name, Alignments alignment, int armourClass, int hitPoints, int strength, int dexterity, int constitution, int wisdom, int intelligence, int charisma)
        {
            character.Name = name;
            character.Alignment = alignment;
            character.ArmourClass = armourClass;
            character.HitPoints = hitPoints;
            character.Strength = strength;
            character.Dexterity = dexterity;
            character.Constitution = constitution;
            character.Wisdom = wisdom;
            character.Intelligence = intelligence;
            character.Charisma = charisma;

            character.Name.Should().Be(name);
            character.Alignment.Should().Be(alignment);
            character.ArmourClass.Should().Be(armourClass);
            character.HitPoints.Should().Be(hitPoints);

            character.Strength.Value.Should().Be(strength);
            character.Dexterity.Value.Should().Be(dexterity);
            character.Constitution.Value.Should().Be(constitution);
            character.Wisdom.Value.Should().Be(wisdom);
            character.Intelligence.Value.Should().Be(intelligence);
            character.Charisma.Value.Should().Be(charisma);
        }


        [TestMethod]
        [DataRow(15, 5, true)]
        [DataRow(5, 10, false)]
        [DataRow(5, 5, false)]
        public void Attack(int roll, int opponentsArmourClass, bool expectedResult)
        {
            var target = new Character();
            target.ArmourClass = opponentsArmourClass;

            var result = character.Attack(roll, target);
            result.Should().Be(expectedResult);

        }

        [TestMethod]
        [DataRow(15, 5, 5, 4, true)]
        [DataRow(5, 10, 5, 5, true)]
        [DataRow(5, 5, 5, 5, true)]
        [DataRow(20, 5, 7, 5, true)]
        [DataRow(15, 5, 4, 3, true)]
        [DataRow(14, 5, 3, 2, true)]
        [DataRow(13, 5, 2, 1, true)]
        [DataRow(12, 5, 1, 0, false)]
        [DataRow(20, 5, 2, 0, false)]
        [DataRow(20, 5, 1, -1, false)]
        public void CausesDamageOnAttack(int roll, int opponentsArmourClass, int opponentsHitPoints, int expectedHitPoints, bool isAlive)
        {
            var target = new Character();
            target.ArmourClass = opponentsArmourClass;
            target.HitPoints = opponentsHitPoints;

            target.CurrentHitPoints.Should().Be(opponentsHitPoints);
            character.Attack(roll, target);
            target.CurrentHitPoints.Should().Be(expectedHitPoints);
            target.Alive.Should().Be(isAlive);
        }

        [TestMethod]
        public void GainExperiencePointsOnSuccessfulAttack()
        {
            var target = new Character();
            character.XP.Should().Be(0);

            var result = character.Attack(20, target);

            result.Should().BeTrue();
            character.XP.Should().Be(10);
        }

        [TestMethod]
        [DataRow(0, 1, 10, 1, 5, 5)]
        [DataRow(999, 1, 1009, 2,5, 10)]
        [DataRow(1999, 2, 2009, 3,10, 15)]
        [DataRow(2999, 3, 3009, 4,15, 20)]
        [DataRow(3999, 4, 4009, 5,20, 25)]
        [DataRow(4999, 5, 5009, 6,25, 30)]
        public void LevelUp(int currentXP, int currentLevel, int expectedXP, int expectedLevel, int hitPoints, int expectedHitPoints)
        {
            var target = new Character();
            character.XP = currentXP;
            character.HitPoints = hitPoints;

            character.Level.Should().Be(currentLevel);
            var result = character.Attack(20, target);

            result.Should().BeTrue();
            character.XP.Should().Be(expectedXP);
            character.Level.Should().Be(expectedLevel);
            character.HitPoints.Should().Be(expectedHitPoints);
        }

    }
}
