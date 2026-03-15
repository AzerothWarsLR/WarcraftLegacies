using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.GameTime;
using MacroTools.Legends;
using MacroTools.Quests;
using WarcraftLegacies.Source.Factions.Kultiras.Mechanics;
using WarcraftLegacies.Source.Objectives.FactionBased;
using WarcraftLegacies.Source.Objectives.LegendBased;
using WarcraftLegacies.Source.Objectives.QuestBased;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions.Kultiras.Quests;

/// <summary>
/// Proudmoore capital ship starts locked. Take control of Kul Tiras to unlock it.
/// </summary>
public sealed class QuestUnlockShip : QuestData
{
  private readonly unit _proudmooreCapitalShip;
  private readonly List<unit> _rescueUnits;

  /// <summary>
  /// Initializes a new instance of the <see cref="QuestUnlockShip"/> class.
  /// </summary>
  public QuestUnlockShip(Rectangle rescueRect, unit proudmooreCapitalShip, LegendaryHero daelinProudmoore,
    QuestData prerequisite) : base("Stranglethorn Expedition",
    "The Stranglethorn vale is still infested with trolls and pirates. If peace is to be brought back to the South Alliance, it needs to be purged",
    @"ReplaceableTextures\CommandButtons\BTNGalleonIcon.blp")
  {
    AddObjective(new ObjectiveQuestComplete(prerequisite));
    AddObjective(new ObjectiveControlLegend(daelinProudmoore, false));
    AddObjective(new ObjectiveSelfExists());

    _proudmooreCapitalShip = proudmooreCapitalShip;
    _rescueUnits = rescueRect.PrepareUnitsForRescue(RescuePreparationMode.HideNonStructures);

    _proudmooreCapitalShip.Owner = player.NeutralPassive;
    _proudmooreCapitalShip.SetPausedEx(true);
    _proudmooreCapitalShip.IsInvulnerable = true;
  }

  public override string RewardFlavour =>
    "The capital ship will set sail with the Kul'tiran navy army to Stranglethorn Vale.";

  protected override string RewardDescription =>
    "Unlock the Proudmoore capital ship and the buildings inside on turn 11. Move all your non-worker units to Stranglethorn Vale.";

  protected override void OnComplete(Faction completingFaction)
  {
    if (completingFaction.Player != null)
    {
      var dialogPresenter = new UnlockShipDialogPresenter(
        completingFaction.Player,
        _rescueUnits,
        _proudmooreCapitalShip
      );
      dialogPresenter.Run(completingFaction.Player);
    }

    TryUnlockShip(completingFaction);
  }

  private void TryUnlockShip(Faction completingFaction)
  {
    const int unlockTurn = 11;

    if (GameTimeManager.Turn >= unlockTurn)
    {
      UnlockShipNow(completingFaction);
    }
    else
    {
      GameTimeManager.RegisterOnTurn(unlockTurn, () => UnlockShipNow(completingFaction));
    }
  }

  private void UnlockShipNow(Faction completingFaction)
  {
    var owner = completingFaction.Player ?? player.NeutralAggressive;

    if (completingFaction.Player != null)
    {
      completingFaction.Player.RescueGroup(_rescueUnits);
    }
    else
    {
      player.NeutralVictim.RescueGroup(_rescueUnits);
    }

    _proudmooreCapitalShip.Rescue(owner);
    _proudmooreCapitalShip.SetPausedEx(false);
    _proudmooreCapitalShip.IsInvulnerable = false;
  }

  protected override void OnFail(Faction completingFaction)
  {
    _proudmooreCapitalShip.Dispose();
  }
}
