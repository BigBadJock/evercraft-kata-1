using System;

namespace EverCraft.Core
{
    public class Character
    {

        public string Name { get; set; } = "default";
        public Alignments Alignment { get; set; }
    }

    public enum Alignments
    {
        Evil = -1, 
        Neutral = 0,
        Good = 1
    }
}
