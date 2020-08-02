using System;
using System.ComponentModel.DataAnnotations;

namespace EverCraft.Core
{
    public class Character
    {
        private int hitPoints;

        public Character()
        {
            this.HitPoints = 5;
            this.Constitution = 10;
        }


        public string Name { get; set; } = "default";
        public Alignments Alignment { get; set; } = Alignments.Neutral;
        public int ArmourClass { get; set; } = 10;
        public int ModifiedArmourClass => ArmourClass + Dexterity.Modifier;

        public int HitPoints
        {
            get { return hitPoints; }
            set
            {
                hitPoints = value;
                currentHitPoints = Math.Max(1, hitPoints + Constitution.Modifier);
            }
        }

        private int currentHitPoints;

        public int CurrentHitPoints
        {
            get { return currentHitPoints; }
            set { currentHitPoints = value; }
        }


        public bool Alive => this.CurrentHitPoints > 0;


        public Ability Strength { get; set; } = 10;
        public Ability Dexterity { get; set; } = 10;

        private Ability constitution;

        public Ability Constitution
        {
            get { return constitution; }
            set
            {
                constitution = value;
                currentHitPoints = Math.Max(1, hitPoints + Constitution.Modifier);
            }
        }

        public Ability Wisdom { get; set; } = 10;
        public Ability Intelligence { get; set; } = 10;
        public Ability Charisma { get; set; } = 10;

        private int xp;

        public int XP
        {
            get { return xp; }
            set { xp = value;
                LevelUp();
            }
        }


        public int Level { get; set; } = 1;

        public bool Attack(int roll, Character target)
        {
            int levelAdjustment = (int)Math.Floor(this.Level / 2d);
            int adjustedRoll = roll + levelAdjustment;

            var isHit = (adjustedRoll + this.Strength.Modifier) > target.ModifiedArmourClass;
            if (isHit)
            {
                target.ReceiveDamage(adjustedRoll >= 20, this.Strength.Modifier);
                this.XP += 10;
                return true;
            }
            return false;
        }

        private void LevelUp()
        {
            int newLevel = Math.Max((int)Math.Floor(XP / 1000d) + 1, 1);
            if(newLevel > this.Level)
            {
                this.Level = newLevel;
                this.HitPoints += 5;
            }
    }

        private void ReceiveDamage(bool isCriticalHit, int attackersStrengthModifier)
        {
            int modifier = attackersStrengthModifier < 1 ? 0 : attackersStrengthModifier;

            int damage = 1 + modifier;
            if (isCriticalHit)
            {
                damage = damage * 2;
            }

            if (this.CurrentHitPoints > 0) this.CurrentHitPoints -= damage;
        }
    }
}
