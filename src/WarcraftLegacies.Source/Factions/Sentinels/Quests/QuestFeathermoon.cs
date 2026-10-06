using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.Legends;
using MacroTools.Localization;
using MacroTools.Quests;
using WarcraftLegacies.Source.GameLogic.SouthKalimdorGuard;
using WarcraftLegacies.Source.Objectives.FactionBased;
using WarcraftLegacies.Source.Objectives.TurnBased;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions.Sentinels.Quests;

public sealed class QuestFeathermoon : QuestData
{
  private List<unit> _rescueUnits;
  private readonly Capital _feathermoon;

  public QuestFeathermoon(Capital feathermoon, Rectangle rescueRect)
    : base(
      "Shores of Feathermoon",
      "Feathermoon Stronghold has held out alone in the far south, cut off from the rest of the Sentinels. When the southern passes open, we can reach it once more, though the wilds of Southern Kalimdor beyond its walls still teem with hostile creatures.",
      @"ReplaceableTextures\CommandButtons\BTNBearDen.blp")
  {
    _feathermoon = feathermoon;

    AddObjective(new ObjectiveTurn(SouthKalimdorGuardSystem.UnlockTurn));
    AddObjective(new ObjectiveSelfExists());
    ResearchId = UPGRADE_R06M_QUEST_COMPLETED_SHORES_OF_FEATHERMOON;
    _rescueUnits = rescueRect.PrepareUnitsForRescue(RescuePreparationMode.HideNonStructures);
  }

  public override string RewardFlavour =>
    "The Sentinels have relieved Feathermoon Stronghold, and its defenders rally to them once more. Maiev Shadowsong now joins their efforts.";

  protected override string RewardDescription => Loc.Format(
    "Learn to train Maiev Shadowsong from the {altar} and gain control of Feathermoon Stronghold and the survivors hiding there.",
    ("{altar}", GetObjectName(UNIT_E00R_ALTAR_OF_WATCHERS_SENTINELS_ALTAR)));

  protected override void OnAdd(Faction whichFaction)
  {
    _rescueUnits = Regions.FeathermoonUnlock.PrepareUnitsForRescue(RescuePreparationMode.HideNonStructures);
  }

  protected override void OnComplete(Faction completingFaction)
  {
    completingFaction.Player.RescueGroup(_rescueUnits);

    foreach (var unit in _rescueUnits)
    {
      unit.SetPausedEx(false);
    }

    if (_feathermoon.Unit != null && _feathermoon.Unit.Alive)
    {
      _feathermoon.Unit.SetLifePercent(100);
      _feathermoon.Unit.Rescue(completingFaction.Player ?? player.NeutralAggressive);
    }
  }

  protected override void OnFail(Faction failingFaction)
  {
    var rescuer = failingFaction.ScoreStatus == ScoreStatus.Defeated
      ? player.NeutralAggressive
      : failingFaction.Player;

    rescuer.RescueGroup(_rescueUnits);

    foreach (var unit in _rescueUnits)
    {
      unit.SetPausedEx(false);
    }

    if (_feathermoon.Unit != null && _feathermoon.Unit.Alive)
    {
      _feathermoon.Unit.SetLifePercent(100);
      _feathermoon.Unit.Rescue(player.NeutralAggressive);
    }
  }
}
