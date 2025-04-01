using MacroTools.UserInterface;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.FactionMechanics.Warsong
{
  public sealed class WarsongPillageChoice : IChoice
  {
    public Rectangle? Location { get; } // The geographical area affected by the choice
    public string Name { get; } // Display name for the choice
    public PillageChoiceType Type { get; } // Type of choice (Pillage or Subdue)
    public int GoldReward { get; } // Gold reward for this choice
    public int ExperienceReward { get; } // Experience reward for this choice

    public WarsongPillageChoice(PillageChoiceType type, string name, Rectangle? location, int goldReward, int experienceReward)
    {
      Type = type;
      Name = name;
      Location = location;
      GoldReward = goldReward;
      ExperienceReward = experienceReward;
    }
  }

  public enum PillageChoiceType
  {
    Subdue,
    Pillage
  }
}