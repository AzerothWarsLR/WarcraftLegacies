using MacroTools.UserInterface;
using WCSharp.Shared.Data;


namespace WarcraftLegacies.Source.FactionMechanics.Warsong
{
    public sealed class WarsongPillageChoice : IChoice
    {

        public Rectangle? Location { get; } // The geographical area affected by the choice

        public string Name { get; } // Display name for the choice
        public PillageChoiceType Type { get; } // Type of choice (Pillage or Subdue)

        public WarsongPillageChoice(PillageChoiceType type, string name, Rectangle? location)
        {
            Type = type;
            Name = name;
            Location = location;
        }
    }
    
    public enum PillageChoiceType
    {
        Subdue,
        Pillage
    }
}