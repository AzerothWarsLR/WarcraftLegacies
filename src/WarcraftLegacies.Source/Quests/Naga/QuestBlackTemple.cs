using System.Collections.Generic;
using System.Linq;
using MacroTools.ControlPoints;
using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.Quests;
using MacroTools.Utils;
using WarcraftLegacies.Source.Objectives.FactionBased;
using WarcraftLegacies.Source.Objectives.LegendBased;
using WarcraftLegacies.Source.Objectives.QuestBased;
using WarcraftLegacies.Source.Objectives.TurnBased;
using WarcraftLegacies.Source.Setup;
using WarcraftLegacies.Source.Setup.Legends;

namespace WarcraftLegacies.Source.Quests.Naga;

/// <summary>
/// Bring <see cref="LegendIllidan.Illidan"/> to <see cref="LegendFelHorde.BlackTemple"/> to gain control of it.
/// </summary>
public sealed class QuestBlackTemple : QuestData
{
  private readonly List<unit> _rescueUnits;
  private List<UnitPlacement>? _originalBrokenIslesUnitPlacements;

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
    AddObjective(new ObjectiveExpire(11, Title));
    AddObjective(new ObjectiveSelfExists());
    ResearchId = UPGRADE_R09Y_QUEST_COMPLETED_RETURN_TO_OUTLAND;
    _rescueUnits = Regions.IllidanBlackTempleUnlock.PrepareUnitsForRescue(RescuePreparationMode.HideNonStructures);
    Knowledge = 10;
  }

  /// <inheritdoc />
  public override string RewardFlavour => "Illidan returns triumphant to Black Temple, the seat of his power. The orcs and demons of Outland hail his coming.";

  /// <inheritdoc />
  protected override string RewardDescription => "Gain control of the Black Temple, learn to train Lady Vashj from the Altar of the Betrayer, abandon your base in the Broken Isles, and Illidan learns to cast Portal to Black Temple";

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

    RespawnBrokenIslesCreeps();
    _originalBrokenIslesUnitPlacements?.Clear();
    _originalBrokenIslesUnitPlacements = null;
  }

  /// <inheritdoc />
  protected override void OnFail(Faction completingFaction)
  {
    var rescuer = completingFaction.ScoreStatus == ScoreStatus.Defeated
      ? player.NeutralAggressive
      : completingFaction.Player;

    rescuer.RescueGroup(_rescueUnits);

    _originalBrokenIslesUnitPlacements?.Clear();
    _originalBrokenIslesUnitPlacements = null;
  }

  /// <inheritdoc />
  protected override void OnAdd(Faction whichFaction)
  {
    SaveBrokenIslesCreeps();
  }

  private void SaveBrokenIslesCreeps()
  {
    if (_originalBrokenIslesUnitPlacements is not null)
    {
      return;
    }

    var originalCreeps = GlobalGroup.EnumUnitsInRect(Regions.BrokenIslesA);
    originalCreeps.AddRange(GlobalGroup.EnumUnitsInRect(Regions.BrokenIslesB));

    _originalBrokenIslesUnitPlacements = new List<UnitPlacement>();
    foreach (var unit in originalCreeps.Where(x => x.Owner == player.NeutralAggressive && !x.IsControlPoint()))
    {
      _originalBrokenIslesUnitPlacements.Add(new UnitPlacement
      {
        UnitType = unit.UnitType,
        X = unit.X,
        Y = unit.Y,
        Facing = unit.Facing
      });
    }
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

      if (!unit.IsRemovable())
      {
        unit.SetOwner(player.NeutralAggressive);
        continue;
      }

      unit.SetPosition(Regions.IllidanBlackTempleUnlock.Center.X, Regions.IllidanBlackTempleUnlock.Center.Y);

      if (unit.IsABuilding || unit.IsUnitBoat())
      {
        completingPlayer.Gold += unit.GoldCostOf(unit.UnitType);
        unit.Dispose();
      }
    }
  }

  private void RespawnBrokenIslesCreeps()
  {
    if (_originalBrokenIslesUnitPlacements is null)
    {
      return;
    }

    foreach (var unitPlacement in _originalBrokenIslesUnitPlacements)
    {
      unit.Create(player.NeutralAggressive, unitPlacement.UnitType, unitPlacement.X, unitPlacement.Y, unitPlacement.Facing);
    }
  }

  private sealed class UnitPlacement
  {
    public required int UnitType { get; init; }

    public required float X { get; init; }

    public required float Y { get; init; }

    public required float Facing { get; init; }
  }
}
