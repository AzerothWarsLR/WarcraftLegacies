using System.Collections.Generic;
using MacroTools.ControlPoints;
using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.Quests;
using MacroTools.Utils;
using WarcraftLegacies.Source.Objectives.FactionBased;
using WarcraftLegacies.Source.Objectives.LegendBased;
using WarcraftLegacies.Source.Objectives.QuestBased;
using WarcraftLegacies.Source.Objectives.TimeBased;
using WarcraftLegacies.Source.Setup;
using WarcraftLegacies.Source.Setup.Legends;

namespace WarcraftLegacies.Source.Quests.Naga;

/// <summary>
/// Bring <see cref="LegendIllidan.Illidan"/> to <see cref="LegendFelHorde.BlackTemple"/> to gain control of it.
/// </summary>
public sealed class QuestBlackTemple : QuestData
{
  private readonly List<unit> _rescueUnits;

  /// <summary>
  /// Initializes a new instance of the <see cref="QuestBlackTemple"/> class.
  /// </summary>
  public QuestBlackTemple(QuestData prerequisite) : base("Return to Outland",
    "Illidan's servants in Outland have been left to their own devices for too long; he must return swiftly if he is to prepare them for the coming war.",
    @"ReplaceableTextures\CommandButtons\BTNWarpPortal.blp")
  {
    var questCompleteObjective = new ObjectiveQuestComplete(prerequisite)
    {
      Progress = QuestProgress.Undiscovered,
      ShowsInQuestLog = false,
      ShowsInPopups = false
    };

    AddObjective(questCompleteObjective);
    AddObjective(new ObjectiveLegendInRect(AllLegends.Naga.Illidan, Regions.IllidanBlackTempleUnlock, "Black Temple"));
    AddObjective(new ObjectiveExpire(660, Title));
    AddObjective(new ObjectiveSelfExists());
    ResearchId = UPGRADE_R09Y_QUEST_COMPLETED_RETURN_TO_OUTLAND;
    _rescueUnits = Regions.IllidanBlackTempleUnlock.PrepareUnitsForRescue(RescuePreparationMode.HideNonStructures);
    Knowledge = 5;
  }

  /// <inheritdoc />
  public override string RewardFlavour => "Illidan returns triumphant to Black Temple, the seat of his power. The orcs and demons of Outland hail his coming.";

  /// <inheritdoc />
  protected override string RewardDescription => "Gain control of the Black Temple, learn to train Lady Vashj from the Altar of the Betrayer, and abandon your base in the Broken Isles";

  /// <inheritdoc />
  protected override void OnComplete(Faction completingFaction)
  {
    completingFaction.Player.RescueGroup(_rescueUnits);

    if (completingFaction.Player == null)
    {
      return;
    }

    completingFaction.Player.PlayMusicThematic("IllidansTheme");
    AbandonBrokenIsles(completingFaction.Player);
    var illidan = AllLegends.Naga.Illidan.Unit;
    if (illidan != null)
    {
      completingFaction.Player.RepositionCamera(illidan.X, illidan.Y);
    }
  }

  /// <inheritdoc />
  protected override void OnFail(Faction completingFaction)
  {
    var rescuer = completingFaction.ScoreStatus == ScoreStatus.Defeated
      ? player.NeutralAggressive
      : completingFaction.Player;

    rescuer.RescueGroup(_rescueUnits);
  }

  private static void AbandonBrokenIsles(player completingPlayer)
  {
    foreach (var unit in GlobalGroup.EnumUnitsOfPlayer(completingPlayer))
    {
      if (unit.UnitType == UNIT_N0D9_SLIPSTREAM_PORTAL_STORMWIND_KHADGAR)
      {
        unit.Kill();
      }

      if (Regions.IllidanBlackTempleUnlock.Contains(unit.X, unit.Y))
      {
        continue;
      }

      if (unit.IsControlPoint())
      {
        unit.SetOwner(player.NeutralAggressive);
        continue;
      }

      if (unit.IsABuilding)
      {
        completingPlayer.Gold += unit.GoldCostOf(unit.UnitType);
        unit.Dispose();
        continue;
      }

      unit.SetPosition(Regions.IllidanBlackTempleUnlock.Center.X, Regions.IllidanBlackTempleUnlock.Center.Y);
    }
  }
}
