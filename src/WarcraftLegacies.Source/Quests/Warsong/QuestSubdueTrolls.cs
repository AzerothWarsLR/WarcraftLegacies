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
using MacroTools.ObjectiveSystem.Objectives.LegendBased;
using WarcraftLegacies.Source.Setup.Legends;

namespace WarcraftLegacies.Source.Quests.Warsong
{
  public sealed class QuestSubdueTrolls : QuestData
  {
    private readonly List<unit> _rescueUnits;
    private readonly LegendaryHero _grom;

    private int PillageGoldReward { get; set; }
    private int PillageExperienceReward { get; set; }
    private const int SubdueResearchReward = Constants.UPGRADE_R00K_SUBDUE_THE_DARKSPEAR_TROLLS;
    private const int PillageResearchReward = Constants.UPGRADE_R01E_QUEST_COMPLETED_TO_BREAK_OR_BIND;

    private const int UNIT_O071_ORC_HEADHUNTER_WARSONG = Constants.UNIT_O071_ORC_HEADHUNTER_WARSONG;
    private const int UNIT_OTBK_AXE_THROWER_WARSONG = Constants.UNIT_OTBK_AXE_THROWER_WARSONG;

    public QuestSubdueTrolls(Rectangle rescueRect, LegendWarsong legendWarsong, LegendaryHero grom)
      : base(
        "To Break or Bind",
        "The Darkspear Trolls, fierce and cunning warriors, dwell in Echo Isles. It is time we forced their hand.",
        @"ReplaceableTextures\CommandButtons\BTNDarkTrollShadowPriest.blp")
    {
      _grom = grom;
      AddObjective(new ObjectiveControlPoint(Constants.UNIT_N02V_ECHO_ISLES));
      AddObjective(new ObjectiveControlLegend(legendWarsong.GromHellscream, true));
      AddObjective(new ObjectiveSelfExists());

      _rescueUnits = rescueRect.PrepareUnitsForRescue(RescuePreparationMode.HideNonStructures);
      PillageGoldReward = 650;
      PillageExperienceReward = 3000;
    }

    public override string RewardFlavour =>
      "The Darkspear Trolls have been brought to heel.";

    protected override string RewardDescription =>
      $"Gain control of Echo Isles, {GetObjectName(UNIT_O071_ORC_HEADHUNTER_WARSONG)}s are upgraded to {GetObjectName(UNIT_OTBK_AXE_THROWER_WARSONG)}s and unlock the ability to train powerful spellcasters like {GetObjectName(UNIT_NOGN_WARLOCK_WARSONG)}s. Alternatively, earn {PillageGoldReward} gold and up to {PillageExperienceReward} experience points, shared among all your heroes—the fewer heroes you control, the less experience each receives. Additionally, enhance both {GetObjectName(UNIT_O00G_BLADEMASTER_WARSONG)}s' and {GetObjectName(UNIT_N03F_KOR_KRON_ELITE_WARSONG_ELITE)}s' maximum mana by 250 and mana regeneration by 20%.";

    protected override void OnComplete(Faction completingFaction)
    {
      if (completingFaction == null || completingFaction.Player == null)
      {
        Console.WriteLine("Invalid faction or player; cannot complete the quest.");
        return;
      }

      PresentPillageDialogs(completingFaction);
    }

    private void PresentPillageDialogs(Faction completingFaction)
    {
      var gromUnit = _grom?.Unit;
      if (gromUnit == null)
      {
        Console.WriteLine("Without Grom's leadership, the Trolls are scattered in chaos and their riches lost.");
        return;
      }

      // Create dialog with Pillage and Subdue options
      var dialogPresenter = new WarsongPillageDialogPresenter(
        gromUnit,
        new WarsongPillageChoice(
          PillageChoiceType.Pillage,
          "Pillage Echo Isles",
          Regions.EchoUnlock,
          PillageGoldReward,
          PillageExperienceReward,
          PillageResearchReward
        ),
        new WarsongPillageChoice(
          PillageChoiceType.Subdue,
          "Subdue the Trolls",
          Regions.EchoUnlock,
          0,
          0,
          SubdueResearchReward
        )
      );

      // Subscribe to the OnChoiceMade event
      dialogPresenter.OnChoiceMade += (choiceType) =>
      {
        if (choiceType == PillageChoiceType.Subdue)
        {
          // Apply unit replacement logic when "Subdue" is chosen
          completingFaction.ModObjectLimit(UNIT_O071_ORC_HEADHUNTER_WARSONG, -Faction.UNLIMITED); // Disable Orc Headhunters
          completingFaction.ModObjectLimit(UNIT_OTBK_AXE_THROWER_WARSONG, Faction.UNLIMITED);    // Enable Axe Throwers
        }
        else if (choiceType == PillageChoiceType.Pillage)
        {
          // No changes to unit limits for the "Pillage" option
          Console.WriteLine("Pillage was chosen—no unit replacements performed.");
        }
      };

      // Run the dialog presenter
      dialogPresenter.Run(completingFaction.Player);
    }

    protected override void OnFail(Faction completingFaction)
    {
      var rescuer = completingFaction.ScoreStatus == ScoreStatus.Defeated
        ? Player(PLAYER_NEUTRAL_AGGRESSIVE)
        : completingFaction.Player;

      rescuer.RescueGroup(_rescueUnits);
    }
  }
}