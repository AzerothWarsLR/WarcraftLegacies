using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.LegendSystem;
using MacroTools.ObjectiveSystem.Objectives.LegendBased;
using MacroTools.QuestSystem;

namespace WarcraftLegacies.Source.Quests.Dalaran;

public sealed class QuestBlueDragons : QuestData
{
  private static readonly int _dragonId = FourCC("n0AC");
  private static readonly int _manadamId = FourCC("R00N");

  public QuestBlueDragons(Capital theNexus) : base("The Blue Dragonflight",
    "The Blue Dragons of Northrend are the wardens of magic on Azeroth. They might be convinced to willingly join the mages of Dalaran.",
    @"ReplaceableTextures\CommandButtons\BTNAzureDragon.blp")
  {
    AddObjective(new ObjectiveControlCapital(theNexus, false));
    ResearchId = UPGRADE_R00U_QUEST_COMPLETED_THE_BLUE_DRAGONFLIGHT_DALARAN;
  }

  /// <inheritdoc/>
  public override string RewardFlavour =>
    "The Nexus has been captured. The Blue Dragonflight fights for Dalaran.";

  /// <inheritdoc/>
  protected override string RewardDescription => "Learn to train Blue Dragons";

  /// <inheritdoc/>
  protected override void OnComplete(Faction completingFaction)
  {
    completingFaction.Player?.DisplayUnitTypeAcquired(_dragonId,
      "You can now train Blue Dragons from Military Quarters and the Nexus.");
  }

  /// <inheritdoc/>
  protected override void OnAdd(Faction whichFaction)
  {
    whichFaction.ModObjectLimit(_manadamId, Faction.Unlimited);
  }
}
