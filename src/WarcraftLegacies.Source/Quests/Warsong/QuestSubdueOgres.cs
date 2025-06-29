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
  public sealed class QuestSubdueOgres : QuestData
  {
    private readonly List<unit> _rescueUnits;
    private readonly LegendaryHero _grom;

    private int PillageGoldReward { get; set; }
    private int PillageExperienceReward { get; set; }
    private const int SubdueResearchReward = UPGRADE_R012_SUBDUE_THE_STONEMAUL_OGRES;
    private const int PillageResearchReward = UPGRADE_R01U_PILLAGE_STONEMAUL;
    private const int SubdueRemoveUnit = UNIT_O02M_WARSONG_GRUNT_WARSONG;
    private const int SubdueAddUnit = UNIT_O073_MOK_NATHAL_WARRIOR_WARSONG;

    public QuestSubdueOgres(Rectangle rescueRect, LegendWarsong legendWarsong, LegendaryHero grom)
      : base(
        "Brute Allegiance",
        "Their brute strength is untamed, their loyalty unproven. Subdue the ogres and further strengthen the Horde.",
        @"ReplaceableTextures\CommandButtons\BTNOgre.blp")
    {
      AddObjective(new ObjectiveControlPoint(Constants.UNIT_N022_STONEMAUL));
      AddObjective(new ObjectiveSelfExists());
      AddObjective(new ObjectiveControlLegend(legendWarsong.GromHellscream, true));
      
      _rescueUnits = rescueRect.PrepareUnitsForRescue(RescuePreparationMode.HideNonStructures);
      _grom = grom;
      PillageGoldReward = 900;
      PillageExperienceReward = 3000;
    }

    public override string RewardFlavour =>
      "The fate of the ogres has been decided, and the Horde's power grows.";

    protected override string RewardDescription =>
      $"Gain control of Stonemaul, {GetObjectName(SubdueRemoveUnit)}s' are upgraded to {GetObjectName(SubdueAddUnit)}s' and unlock the ability to train {GetObjectName(UNIT_N08O_OGRE_MAGI_WARSONG)}s. Alternatively, earn {PillageGoldReward} gold and up to {PillageExperienceReward} experience points, shared among all your heroes—the fewer heroes you control, the less experience each receives. Additionally, enhance both {GetObjectName(Constants.UNIT_O00G_BLADEMASTER_WARSONG)}s' and {GetObjectName(Constants.UNIT_N03F_KOR_KRON_ELITE_WARSONG_ELITE)}s' attack damage by 10, movement speed by 20 and hit points by 300.";

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
      var gromUnit = _grom.Unit;
      if (gromUnit == null)
      {
        Console.WriteLine("Without Grom's leadership to restrain the Warband, the ogres are slaughtered.");
        return;
      }
      new WarsongPillageDialogPresenter(
        gromUnit,
        new WarsongPillageChoice(
          PillageChoiceType.Subdue,
          "Subdue the Ogres",
          Regions.StonemaulKeep,
          0,
          0,
          SubdueResearchReward,
          artifactRewardItemType: null,
          new UnitUpgrade(SubdueRemoveUnit, SubdueAddUnit)
        ),
        new WarsongPillageChoice(
          PillageChoiceType.Pillage,
          "Pillage Stonemaul",
          Regions.StonemaulKeep,
          PillageGoldReward,
          PillageExperienceReward,
          PillageResearchReward
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