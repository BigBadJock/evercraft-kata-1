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
            character.HitPoints.Should().Be(5);
            character.Alive.Should().Be(true);
        }

        [TestMethod]
        [DataRow("Frodo", Alignments.Good, 20, 5)]
        [DataRow("Boromir", Alignments.Neutral, 10, 10)]
        [DataRow("Gollum", Alignments.Evil, 5, 7)]
        public void SetAndGetBasicValues(string name, Alignments alignment, int armourClass, int hitPoints)
        {
            character.Name = name;
            character.Alignment = alignment;
            character.ArmourClass = armourClass;
            character.HitPoints = hitPoints;

            character.Name.Should().Be(name);
            character.Alignment.Should().Be(alignment);
            character.ArmourClass.Should().Be(armourClass);
            character.HitPoints.Should().Be(hitPoints);
        }

        [TestMethod]
        [DataRow(15,5, true)]
        [DataRow(5,10, false)]
        [DataRow(5,5, false)]
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
        [DataRow(15,5,4,3, true)]
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
            character.Attack(roll, target);
            target.HitPoints.Should().Be(expectedHitPoints);
            target.Alive.Should().Be(isAlive);

        }

    }
}
