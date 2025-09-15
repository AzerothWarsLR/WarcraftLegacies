using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.LegendSystem;
using MacroTools.ObjectiveSystem.Objectives.FactionBased;
using MacroTools.ObjectiveSystem.Objectives.LegendBased;
using MacroTools.ObjectiveSystem.Objectives.QuestBased;
using MacroTools.QuestSystem;
using WarcraftLegacies.Source.FactionMechanics.KulTiras;
using WCSharp.Shared.Data;
using static War3Api.Blizzard;

namespace WarcraftLegacies.Source.Quests.KulTiras
{
  /// <summary>
  /// Proudmoore capital ship starts locked. Take control of Kul Tiras to unlock it.
  /// </summary>
  public sealed class QuestUnlockShip : QuestData
  {
    private readonly unit _proudmooreCapitalShip;
    private readonly List<unit> _rescueUnits;
    private bool _questProcessed; // New field to prevent repeated execution

    /// <summary>
    /// Initializes a new instance of the <see cref="QuestUnlockShip"/> class.
    /// </summary>
    /// <param name="rescueRect">All units in this area will be made neutral, then rescued when the quest is completed.</param>
    /// <param name="proudmooreCapitalShip">Starts invulnerable and unusable and will be made usable and vulnerable when the quest is completed.</param>
    /// <param name="daelinProudmoore">Must be controlled to complete the quest.</param>
    /// <param name="prerequisite">Needs to be completed first.</param>
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
    }

    /// <inheritdoc/>
    public override string RewardFlavour => "The capital ship will set sail with the Kul'tiran navy army to Stranglethorn Vale.";

    /// <inheritdoc/>
    protected override string RewardDescription =>
      "Unlock the Proudmoore capital ship and the buildings inside. Move all your non-worker units to Stranglethorn Vale.";

    /// <inheritdoc/>
    /// <inheritdoc/>
    protected override void OnComplete(Faction completingFaction)
    {
      if (_questProcessed)
        return; 

      _questProcessed = true; 
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
        Player(bj_PLAYER_NEUTRAL_VICTIM).RescueGroup(_rescueUnits);
        _proudmooreCapitalShip.Rescue(Player(PLAYER_NEUTRAL_AGGRESSIVE));
      }
      
      EnsureShipIsUnlocked(completingFaction);
    }
    
    private void EnsureShipIsUnlocked(Faction completingFaction)
    {
      if (completingFaction.Player != null)
      {
        _proudmooreCapitalShip.Rescue(completingFaction.Player);
      }
      else
      {
        _proudmooreCapitalShip.Rescue(Player(PLAYER_NEUTRAL_AGGRESSIVE));
      }

      BlzPauseUnitEx(_proudmooreCapitalShip, false);
    }
    
    /// <inheritdoc/>
    protected override void OnFail(Faction completingFaction)
    {
      if (_questProcessed)
        return; 

      RemoveUnit(_proudmooreCapitalShip);
      _questProcessed = true; 
    }
  }
}