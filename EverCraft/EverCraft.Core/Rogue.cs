using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EverCraft.Core
{
    public class Rogue : Character
    {
        public override Alignments Alignment
        {
            get => base.Alignment;
            set
            {
                if (value == Alignments.Good) throw new ArgumentOutOfRangeException();
                base.Alignment = value;
            }
        }

        public override int criticalDamageMultiplier => 3;

        protected override bool CheckHit(Character target, int adjustedRoll)
        {
            return (adjustedRoll + this.Dexterity.Modifier) > target.ArmourClass;
        }
    }
}
