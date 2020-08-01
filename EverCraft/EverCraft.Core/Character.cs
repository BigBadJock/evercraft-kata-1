using System;

namespace EverCraft.Core
{
    public class Character
    {

        public string Name { get; set; } = "default";
        public Alignments Alignment { get; set; } = Alignments.Neutral;
        public object ArmourClass { get; set; } = 10;
    }
}
