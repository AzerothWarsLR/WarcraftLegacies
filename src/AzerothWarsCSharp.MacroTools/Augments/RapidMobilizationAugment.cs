using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.Powers;
using static War3Api.Common;

namespace AzerothWarsCSharp.MacroTools.Augments
{
  public sealed class RapidMobilizationAugment : Augment
  {
    private readonly float _chance;

    public RapidMobilizationAugment(float percentageChance)
    {
      _chance = percentageChance;
      IconName = "Footman";
      Name = "Rapid Mobilization";
      Description = $"When you train a unit, you have a {percentageChance}% of instantly training an additional copy for free.";
    }

    public override float GetWeight(player whichPlayer)
    {
      return 1;
    }

    public override void OnAdd(Faction whichFaction)
    {
      whichFaction.AddPower(new RapidMobilization(_chance)
      {
        IconName = IconName,
        Name = Name
      });
    }
  }
}