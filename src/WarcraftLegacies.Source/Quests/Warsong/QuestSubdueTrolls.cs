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
    private const int PillageResearchReward = Constants.UPGRADE_R01Z_PILLAGE_ECHO_ISLES;
    private const int SubdueRemoveUnit = Constants.UNIT_OTBK_AXE_THROWER_WARSONG;
    private const int SubdueAddUnit = Constants.UNIT_O071_DARKSPEAR_BERSERKER_WARSONG;

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
      PillageGoldReward = 850;
      PillageExperienceReward = 3500;
    }

    public override string RewardFlavour =>
      "The Darkspear Trolls have been brought to heel.";

    protected override string RewardDescription =>
      $"Gain control of Echo Isles, {GetObjectName(SubdueRemoveUnit)}s are upgraded to {GetObjectName(SubdueAddUnit)}s and learn to train {GetObjectName(Constants.UNIT_N08E_SHADOWPRIEST_WARSONG)}s. Alternatively, earn {PillageGoldReward} gold and up to {PillageExperienceReward} experience points, shared among all your heroes—the fewer heroes you control, the less experience each receives. Additionally, enhance both {GetObjectName(Constants.UNIT_O00G_BLADEMASTER_WARSONG)}s' and {GetObjectName(Constants.UNIT_N03F_KOR_KRON_ELITE_WARSONG_ELITE)}s' maximum mana by 250 and mana regeneration by 20%.";

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

      // Pass unit upgrade for Subdue to dynamically replace units
      new WarsongPillageDialogPresenter(
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
          SubdueResearchReward,
          artifactRewardItemType: null,
          unitUpgrade: new UnitUpgrade(SubdueRemoveUnit, SubdueAddUnit)
        )
      ).Run(completingFaction.Player);
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