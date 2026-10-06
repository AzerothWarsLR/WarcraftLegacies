using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.Quests;
using WarcraftLegacies.Source.GameLogic.SouthKalimdorGuard;
using WarcraftLegacies.Source.Objectives.FactionBased;
using WarcraftLegacies.Source.Objectives.TurnBased;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions.TaurenTribes.Quests;

public sealed class QuestEarthmothersCradle : QuestData
{
  private readonly List<unit> _rescueUnits;

  public QuestEarthmothersCradle(Rectangle rescueRect) : base(
    "Earthmother's Cradle",
    "Tauren seers speak of a crater in the far south where the Earthmother's first gifts still grow wild, a cradle of primal life and restless elements. When the southern passes open, the Tribes will raise a camp within it, though the wilds of Southern Kalimdor beyond still teem with hostile creatures.",
    @"ReplaceableTextures\CommandButtons\BTNTaurenTotem.blp")
  {
    AddObjective(new ObjectiveTurn(SouthKalimdorGuardSystem.UnlockTurn));
    AddObjective(new ObjectiveSelfExists());
    _rescueUnits = rescueRect.PrepareUnitsForRescue(RescuePreparationMode.HideNonStructures);
  }

  public override string RewardFlavour =>
    "The Tribes have raised Earthmother's Cradle in the heart of Un'Goro, a new home where the land itself thrums with life.";

  protected override string RewardDescription =>
    "Gain control of Earthmother's Cradle, a new Tauren base in Un'Goro Crater";

  protected override void OnComplete(Faction completingFaction)
  {
    completingFaction.Player.RescueGroup(_rescueUnits);
  }

  protected override void OnFail(Faction failingFaction)
  {
    var rescuer = failingFaction.ScoreStatus == ScoreStatus.Defeated
      ? player.NeutralAggressive
      : failingFaction.Player;

    rescuer.RescueGroup(_rescueUnits);
  }
}
