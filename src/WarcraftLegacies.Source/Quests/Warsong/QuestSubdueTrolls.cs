using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.ObjectiveSystem.Objectives.ControlPointBased;
using MacroTools.ObjectiveSystem.Objectives.FactionBased;
using MacroTools.QuestSystem;
using WCSharp.Shared.Data;
using System;
using WarcraftLegacies.Source.FactionMechanics.Warsong;
using MacroTools.LegendSystem;

namespace WarcraftLegacies.Source.Quests.Warsong
{
  public sealed class QuestSubdueTrolls : QuestData
  {
    private readonly List<unit> _rescueUnits;
    private readonly LegendaryHero _grom;
    
    private int PillageGoldReward { get; set; }
    private int PillageExperienceReward { get; set; }

    public QuestSubdueTrolls(Rectangle rescueRect, LegendaryHero grom)
      : base(
        "To Break or Bind",
        "The Darkspear Trolls, fierce and cunning warriors, dwell in Echo Isles. It is time we forced their hand.",
        @"ReplaceableTextures\CommandButtons\BTNDarkTrollShadowPriest.blp")
    {
      _grom = grom;
      AddObjective(new ObjectiveControlPoint(Constants.UNIT_N02V_ECHO_ISLES));
      AddObjective(new ObjectiveSelfExists());

      _rescueUnits = rescueRect.PrepareUnitsForRescue(RescuePreparationMode.HideNonStructures);

      // Set default values for the rewards as a fallback
      PillageGoldReward = 500;
      PillageExperienceReward = 2000;
    }

    /// <inheritdoc/>
    public override string RewardFlavour =>
      "The Darkspear Trolls have been brought to heel.";

    /// <inheritdoc/>
    protected override string RewardDescription =>
      $"Control of Echo Isles and the ability to train {GetObjectName(UNIT_OTBK_AXE_THROWER_WARSONG)} and {GetObjectName(UNIT_NOGN_WARLOCK_WARSONG)} from the {GetObjectName(UNIT_O006_SPIRE_WARSONG_MAGIC)} or gain {PillageGoldReward} gold and {PillageExperienceReward} XP for Grom.";

    /// <inheritdoc/>
    protected override void OnComplete(Faction completingFaction)
    {
      if (completingFaction == null || completingFaction.Player == null)
      {
        Console.WriteLine("Invalid faction or player; cannot complete the quest.");
        return;
      }

      PresentPillageDialogs(completingFaction);
    }

    /// <summary>
    /// Handles the logic related to presenting Subdue or Pillage dialogs.
    /// </summary>
    private void PresentPillageDialogs(Faction completingFaction)
    {
      var gromUnit = _grom?.Unit;
      if (gromUnit == null)
      {
        Console.WriteLine("Without Grom's leadership, the Trolls are scattered in chaos and their riches lost.");
        return;
      }

      PillageGoldReward = 500;
      PillageExperienceReward = 2000;

      new WarsongPillageDialogPresenter(
        gromUnit,
        new WarsongPillageChoice(PillageChoiceType.Pillage, "Pillage Echo Isles", Regions.EchoUnlock, PillageGoldReward,
          PillageExperienceReward), // Custom rewards
        new WarsongPillageChoice(PillageChoiceType.Subdue, "Subdue the Trolls", Regions.EchoUnlock, 0, 0) 
      ).Run(completingFaction.Player);
    }

    /// <inheritdoc />
    protected override void OnFail(Faction completingFaction)
    {
      completingFaction.Player?.RescueGroup(_rescueUnits);
    }
  }
}