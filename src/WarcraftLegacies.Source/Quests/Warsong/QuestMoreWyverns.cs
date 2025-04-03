using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.LegendSystem;
using MacroTools.ObjectiveSystem.Objectives.UnitBased;
using MacroTools.QuestSystem;


namespace WarcraftLegacies.Source.Quests.Warsong
{
  public sealed class QuestMoreWyverns : QuestData
  {
    private const int LimitChange = 2;
    
    private static readonly int UnittypeId = Constants.UNIT_OWYV_WIND_RIDER_WARSONG;

    public QuestMoreWyverns(Legend cthun, Legend nzoth) : base("Dominion of the Skies",
      "The Old Gods C'Thun and N'Zoth threaten the Horde from their ancient lairs. Eliminate these eldritch horrors and assert dominance over Kalimdor's skies.",
      @"ReplaceableTextures\CommandButtons\BTNWyvernRider.blp")
    {
      AddObjective(new ObjectiveKillUnit(cthun.Unit));
      AddObjective(new ObjectiveKillUnit(nzoth.Unit));
    }
    
    /// <inheritdoc/>
    public override string RewardFlavour =>
      "With the Old Gods driven from Azeroth, the skies themselves recognize the Warsong's rightful dominance. Your Wyvern riders rally eagerly, inspired by your victory.";

    /// <inheritdoc/>
    protected override string RewardDescription =>
      $"Learn to train {LimitChange} additional {GetObjectName(UnittypeId)}s";

    /// <inheritdoc/>
    protected override void OnComplete(Faction completingFaction)
    {
      completingFaction.ModObjectLimit(UnittypeId, LimitChange);
      completingFaction.DisplayUnitLimit(UnittypeId);
    }
  }
}