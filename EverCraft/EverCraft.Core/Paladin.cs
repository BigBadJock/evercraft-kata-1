using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EverCraft.Core
{
    public class Paladin : Character
    {
        public override int hitPointsPerLevel => 8;

        public int AdjustRoll(int roll, Character target)
        {
            int adjustedRoll = base.AdjustRoll(roll);
            if (target.Alignment == Alignments.Evil) adjustedRoll += 2;
            return adjustedRoll;
        }

        public override bool Attack(int roll, Character target)
        {
            int adjustedRoll = AdjustRoll(roll, target);

            bool isHit = CheckHit(target, adjustedRoll);
            if (isHit)
            {
                target.ReceiveDamage(adjustedRoll >= 20, this);
                this.XP += 10;
                return true;
            }
            return false;
        }

        protected internal override int CalculateLevelAdjustment()
        {
            return this.Level-1;
        }

        public override Alignments Alignment
        {
            get => base.Alignment;
            set
            {
                if (value != Alignments.Good) throw new ArgumentOutOfRangeException();
                base.Alignment = value;
            }
        }

    }
}
