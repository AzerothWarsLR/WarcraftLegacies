using MacroTools.FactionSystem;
using MacroTools.ObjectiveSystem.Objectives.FactionBased;
using MacroTools.ObjectiveSystem.Objectives.UnitBased;
using MacroTools.QuestSystem;

namespace WarcraftLegacies.Source.Quests.Warsong;

/// <summary>
/// Rohkan becomes available for training at the Warsong Altar.
/// </summary>
public sealed class QuestRokhan : QuestData
{
  private readonly unit _rokhan;

  public QuestRokhan(unit rokhan) : base("The Darkspear Champion",
    "Rumours tell of a Darkspear Champion in the area. Perhaps it could be convinced to join the Horde.",
    @"ReplaceableTextures\CommandButtons\BTNshadowhunterhd.blp")
  {
    AddObjective(new ObjectiveAnyUnitInRect(Regions.Chen, "Rohkan", false));
    AddObjective(new ObjectiveSelfExists());
    _rokhan = rokhan;

  }

  /// <inheritdoc/>
  protected override string RewardDescription => "The hero Rohkan is now trainable at the Altar";

  /// <inheritdoc/>
  protected override void OnFail(Faction completingFaction)
  {
    _rokhan.Dispose();
  }

  /// <inheritdoc/>
  protected override void OnComplete(Faction completingFaction)
  {
    _rokhan.Dispose();
    completingFaction.Player.SetTechResearched(UPGRADE_R037_QUEST_COMPLETED_THE_DARKSPEAR_CHAMPION_WARSONG, 1);
  }

  /// <inheritdoc/>
  protected override void OnAdd(Faction whichFaction)
  {
    whichFaction.ModObjectLimit(UPGRADE_R037_QUEST_COMPLETED_THE_DARKSPEAR_CHAMPION_WARSONG, Faction.Unlimited);
    _rokhan.IsInvulnerable = true;
  }
}
