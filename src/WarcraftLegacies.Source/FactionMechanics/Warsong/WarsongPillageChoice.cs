using WCSharp.Shared.Data;
using MacroTools.UserInterface;

namespace WarcraftLegacies.Source.FactionMechanics.Warsong
{
  public sealed class WarsongPillageChoice : IChoice
  {
    public Rectangle Location { get; }
    public string Name { get; }
    public PillageChoiceType Type { get; }
    public int GoldReward { get; }
    public int ExperienceReward { get; }
    public int ResearchReward { get; }
    public int? ArtifactRewardItemType { get; }
    public UnitUpgrade UnitUpgrade { get; } // Supports unit-specific upgrades

    public WarsongPillageChoice(
      PillageChoiceType type,
      string name,
      Rectangle location,
      int goldReward,
      int experienceReward,
      int researchReward = 0,
      int? artifactRewardItemType = null,
      UnitUpgrade unitUpgrade = null
    )
    {
      Type = type;
      Name = name;
      Location = location;
      GoldReward = goldReward;
      ExperienceReward = experienceReward;
      ResearchReward = researchReward;
      ArtifactRewardItemType = artifactRewardItemType;
      UnitUpgrade = unitUpgrade;
    }
  }

  public enum PillageChoiceType
  {
    Subdue,
    Pillage
  }

  public class UnitUpgrade
  {
    public int RemoveUnit { get; }
    public int AddUnit { get; }

    public UnitUpgrade(int removeUnit, int addUnit)
    {
      RemoveUnit = removeUnit;
      AddUnit = addUnit;
    }
  }
}