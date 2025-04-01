using WCSharp.Shared.Data;
using MacroTools.UserInterface;

namespace WarcraftLegacies.Source.FactionMechanics.Warsong
{
  // This class now fully implements IChoice
  public sealed class WarsongPillageChoice : IChoice
  {
    public Rectangle Location { get; } // The geographical area affected by the choice
    public string Name { get; } // The display name (required by IChoice)
    public PillageChoiceType Type { get; } // The type of choice (Pillage or Subdue)
    public int GoldReward { get; } // The amount of gold rewarded
    public int ExperienceReward { get; } // The amount of experience rewarded
    public int ResearchReward { get; } // The research reward granted

    public WarsongPillageChoice(
      PillageChoiceType type,
      string name,
      Rectangle location,
      int goldReward,
      int experienceReward,
      int researchReward = 0)
    {
      Type = type;
      Name = name;
      Location = location;
      GoldReward = goldReward;
      ExperienceReward = experienceReward;
      ResearchReward = researchReward;
    }

    // This method implements the Execute behavior from IChoice
    public void Execute()
    {
      // Here, you can define what happens when the choice is executed
      // For example, logging or performing default behavior
    }
  }

  public enum PillageChoiceType
  {
    Subdue,
    Pillage
  }
}