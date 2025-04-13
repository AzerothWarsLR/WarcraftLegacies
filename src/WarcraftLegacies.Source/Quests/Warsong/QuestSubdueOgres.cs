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
    private const int PillageResearchReward = UPGRADE_R017_QUEST_COMPLETED_BRUTE_ALLEGIANCE;

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
      PillageGoldReward = 600;
      PillageExperienceReward = 3000;
    }

    public override string RewardFlavour =>
      "The fate of the ogres has been decided, and the Horde's power grows.";

    protected override string RewardDescription =>
      $"Gain control of Stonemaul and unlock the ability to train {GetObjectName(UNIT_N07A_OGRE_WARRIOR_WARSONG)}s from the {GetObjectName(UNIT_O01S_WAR_CAMP_WARSONG_BARRACKS)} and {GetObjectName(UNIT_N08O_OGRE_MAGI_WARSONG)}s from the {GetObjectName(UNIT_O006_SPIRE_WARSONG_MAGIC)}. Alternatively, earn {PillageGoldReward} gold and {PillageExperienceReward} experience points, shared across all your heroes. Additionally, enhance both {GetObjectName(UNIT_O00G_BLADEMASTER_WARSONG)}s' and {GetObjectName(UNIT_N03F_KOR_KRON_ELITE_WARSONG_ELITE)}s' by increasing their attack damage by 10, movement speed by 20, and hit points by 300.";

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
          PillageChoiceType.Pillage,
          "Pillage Stonemaul",
          Regions.StonemaulKeep,
          PillageGoldReward,
          PillageExperienceReward,
          PillageResearchReward
        ),
        new WarsongPillageChoice(
          PillageChoiceType.Subdue,
          "Subdue the Ogres",
          Regions.StonemaulKeep,
          0,
          0,
          SubdueResearchReward
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