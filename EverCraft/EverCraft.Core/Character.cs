using System;

namespace EverCraft.Core
{
    public class Character
    {

        public string Name { get; set; } = "default";
        public Alignments Alignment { get; set; } = Alignments.Neutral;
        public int ArmourClass { get; set; } = 10;
        public int HitPoints { get; set; } = 5;

        public object Attack(int roll, Character target)
        {
            return (roll > target.ArmourClass);
        }
    }
}
