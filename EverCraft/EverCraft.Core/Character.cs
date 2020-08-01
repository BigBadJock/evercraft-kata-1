using System;

namespace EverCraft.Core
{
    public class Character
    {

        public string Name { get; set; } = "default";
        public Alignments Alignment { get; set; } = Alignments.Neutral;
        public int ArmourClass { get; set; } = 10;
        public int HitPoints { get; set; } = 5;
        public bool Alive { get; set; } = true;
        public object Attack(int roll, Character target)
        {
            var isHit = roll > target.ArmourClass;
            if(isHit)
            {
                target.ReceiveDamage(roll==20);
                return true;
            }
            return false;
        }
        private void ReceiveDamage(bool isCriticalHit)
        {
            int damage = isCriticalHit ? 2 : 1;
            
            if(this.HitPoints > 0) this.HitPoints -= damage;
            if (this.HitPoints <= 0) this.Alive = false;
        }
    }
}
