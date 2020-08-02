using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EverCraft.Core
{
    public class Monk : Character
    {
        public override int hitPointsPerLevel => 6;
        public override int baseDamage => 3;

        public override int ModifiedArmourClass => ArmourClass + Dexterity.Modifier + (Wisdom.Modifier > 0 ? Wisdom.Modifier : 0);

        protected internal override int CalculateLevelAdjustment()
        {

            int increase = 0;
            int step = 1;
            for(int i = 1; i <= this.Level; i++)
            {
                switch (step)
                {
                    case 1:
                        increase += 0;
                        break;
                    case 2:
                        increase += 1;
                        break;
                    case 3:
                        increase += 1;
                        break;
                }
                step++;
                if (step == 4) step = 1;
            }

            return increase;
        }

    }
}
