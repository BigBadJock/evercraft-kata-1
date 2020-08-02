namespace EverCraft.Core
{
    public interface ICharacter
    {
        Alignments Alignment { get; set; }
        bool Alive { get; }
        int ArmourClass { get; set; }
        int baseDamage { get; }
        Ability Charisma { get; set; }
        Ability Constitution { get; set; }
        int criticalDamageMultiplier { get; }
        int CurrentHitPoints { get; set; }
        Ability Dexterity { get; set; }
        int HitPoints { get; set; }
        int hitPointsPerLevel { get; }
        Ability Intelligence { get; set; }
        int Level { get; set; }
        int ModifiedArmourClass { get; }
        string Name { get; set; }
        Ability Strength { get; set; }
        Ability Wisdom { get; set; }
        int XP { get; set; }

        bool Attack(int roll, Character target);
    }
}