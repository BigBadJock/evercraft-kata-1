using System;
using System.ComponentModel.DataAnnotations;

namespace EverCraft.Core
{
    public class Character : ICharacter
    {
        public virtual int hitPointsPerLevel => 5;

        public virtual int criticalDamageMultiplier => 2;

        public virtual int baseDamage => 1;

        private int hitPoints;

        public Character()
        {
            this.HitPoints = 5;
            this.Constitution = 10;
        }


        public string Name { get; set; } = "default";
        public virtual Alignments Alignment { get; set; } = Alignments.Neutral;
        public int ArmourClass { get; set; } = 10;
        public virtual int ModifiedArmourClass => ArmourClass + Dexterity.Modifier;

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
            set
            {
                xp = value;
                LevelUp();
            }
        }


        public int Level { get; set; } = 1;

        public virtual bool Attack(int roll, Character target)
        {
            int adjustedRoll = AdjustRoll(roll);

            bool isHit = CheckHit(target, adjustedRoll);
            if (isHit)
            {
                target.ReceiveDamage(adjustedRoll >= 20, this);
                this.XP += 10;
                return true;
            }
            return false;
        }

        public int AdjustRoll(int roll)
        {
            int levelAdjustment = CalculateLevelAdjustment();
            int adjustedRoll = roll + levelAdjustment;
            return adjustedRoll;
        }

        protected virtual bool CheckHit(Character target, int adjustedRoll)
        {
            return (adjustedRoll + this.Strength.Modifier) > target.ModifiedArmourClass;
        }

        protected internal virtual int CalculateLevelAdjustment()
        {
            return (int)Math.Floor(this.Level / 2d);
        }

        private void LevelUp()
        {
            int newLevel = Math.Max((int)Math.Floor(XP / 1000d) + 1, 1);
            if (newLevel > this.Level)
            {
                this.Level = newLevel;
                this.HitPoints += hitPointsPerLevel;
            }
        }

        protected internal virtual void ReceiveDamage(bool isCriticalHit, ICharacter attacker)
        {
            int modifier = attacker.Strength.Modifier < 1 ? 0 : attacker.Strength.Modifier;

            int damage = attacker.baseDamage + modifier;
            if (attacker.GetType() == typeof(Paladin) && this.Alignment == Alignments.Evil)
            {
                damage += 2;
            }

            if (isCriticalHit)
            {
                var criticalDamageMultiplier = attacker.criticalDamageMultiplier;

                if (attacker.GetType() == typeof(Paladin) && this.Alignment == Alignments.Evil)
                {
                    criticalDamageMultiplier = 3;
                }
                damage = damage * criticalDamageMultiplier;
            }

            if (this.CurrentHitPoints > 0) this.CurrentHitPoints -= damage;
        }
    }
}
