using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EverCraft.Core
{
    public class Fighter: Character
    {
        public override int hitPointsPerLevel => 10;

        protected internal override int CalculateLevelAdjustment()
        {
            return this.Level;
        }
    }
}
