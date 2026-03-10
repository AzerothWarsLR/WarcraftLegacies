using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.GameTime;
using MacroTools.Legends;
using MacroTools.Quests;
using WarcraftLegacies.Source.FactionMechanics.KulTiras;
using WarcraftLegacies.Source.Objectives.FactionBased;
using WarcraftLegacies.Source.Objectives.LegendBased;
using WarcraftLegacies.Source.Objectives.QuestBased;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Quests.KulTiras;

/// <summary>
/// Proudmoore capital ship starts locked. Take control of Kul Tiras to unlock it.
/// </summary>
public sealed class QuestUnlockShip : QuestData
{
  private readonly unit _proudmooreCapitalShip;
  private readonly List<unit> _rescueUnits;
  private bool _questProcessed;
  private bool _questCompleted;

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

    _proudmooreCapitalShip.Rescue(player.NeutralPassive);
    _proudmooreCapitalShip.SetPausedEx(true);
    _proudmooreCapitalShip.IsInvulnerable = true;
  }

  public override string RewardFlavour =>
      "The capital ship will set sail with the Kul'tiran navy army to Stranglethorn Vale.";

  protected override string RewardDescription =>
      "Unlock the Proudmoore capital ship and the buildings inside. Move all your non-worker units to Stranglethorn Vale.";

  protected override void OnComplete(Faction completingFaction)
  {
    if (_questProcessed)
    {
      return;
    }

    _questProcessed = true;
    _questCompleted = true;

    if (completingFaction.Player != null)
    {
      var dialogPresenter = new UnlockShipDialogPresenter(
          completingFaction.Player,
          _rescueUnits,
          _proudmooreCapitalShip
      );
      dialogPresenter.Run(completingFaction.Player);
    }
    else
    {
      _proudmooreCapitalShip.Rescue(player.NeutralAggressive);
    }

    _proudmooreCapitalShip.Rescue(player.NeutralPassive);
    _proudmooreCapitalShip.SetPausedEx(true);
    _proudmooreCapitalShip.IsInvulnerable = true;

    TryUnlockShip(completingFaction);
  }

  private void TryUnlockShip(Faction completingFaction)
  {
    const int unlockTurn = 11;

    if (!_questCompleted)
    {
      return;
    }

    if (GameTimeManager.Turn >= unlockTurn)
    {
      UnlockShipNow(completingFaction);
    }
    else
    {
      GameTimeManager.RegisterOnTurn(unlockTurn, () =>
      {
        if (_questCompleted)
        {
          UnlockShipNow(completingFaction);
        }
      });
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
    if (_questProcessed)
    {
      return;
    }

    _proudmooreCapitalShip.Dispose();
    _questProcessed = true;
  }
}
