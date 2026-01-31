using System;
using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.LegendSystem;
using MacroTools.Quests;
using WarcraftLegacies.Source.FactionMechanics.Warsong;
using WarcraftLegacies.Source.Objectives.ControlPointBased;
using WarcraftLegacies.Source.Objectives.FactionBased;
using WarcraftLegacies.Source.Objectives.LegendBased;
using WarcraftLegacies.Source.Setup.Legends;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Quests.Warsong;

public sealed class QuestSubdueTauren : QuestData
{
  private readonly List<unit> _rescueUnits;
  private readonly LegendaryHero _grom;
  private int PillageGoldReward { get; set; }
  private int PillageExperienceReward { get; set; }


  public QuestSubdueTauren(Rectangle rescueRect, LegendWarsong legendWarsong, LegendaryHero grom)
    : base(
      "Unyielding Bonds",
      "The Tauren of Thunder Bluff are noble warriors, but their allegiances are uncertain. Bring them into the fold or pillage their lands.",
      @"ReplaceableTextures\CommandButtons\BTNTauren.blp")
  {
    _grom = grom;
    AddObjective(new ObjectiveControlPoint(UNIT_N03M_THUNDERBLUFF));
    AddObjective(new ObjectiveControlLegend(legendWarsong.GromHellscream, true));
    AddObjective(new ObjectiveSelfExists());

    _rescueUnits = rescueRect.PrepareUnitsForRescue(RescuePreparationMode.HideNonStructures);
    PillageGoldReward = 500;
    PillageExperienceReward = 2500;
  }

  /// <inheritdoc/>
  protected override string RewardDescription =>
    $"Control of Thunder Bluff and the ability to train {GetObjectName(UNIT_OKOD_KODO_BEAST_WARSONG)}s' from {GetObjectName(UNIT_O02Q_BEASTIARY_WARSONG_SPECIALIST)} or gain the artifact {GetObjectName(ITEM_I00L_BLOODHOOF_TOTEM)}, {PillageGoldReward} gold and {PillageExperienceReward} experience points, shared across all your heroes—the fewer heroes you control, the less experience each receives.";

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
    var gromUnit = _grom.Unit;
    if (gromUnit == null)
    {
      Console.WriteLine("Without Grom's leadership to guide the Horde, the Tauren remain scattered and their riches lost.");
      return;
    }

    new WarsongPillageDialogPresenter(
      gromUnit,
      new WarsongPillageChoice(
        PillageChoiceType.Subdue,
        "Subdue the Tauren",
        Regions.ThunderBluff,
        0,
        0,
        UPGRADE_R00O_SUBDUE_THE_THUNDERBLUFF_TAUREN,
        artifactRewardItemType: null
      ),
      new WarsongPillageChoice(
        PillageChoiceType.Pillage,
        "Pillage Thunder Bluff",
        Regions.ThunderBluff,
        PillageGoldReward,
        PillageExperienceReward,
        0,
        ITEM_I00L_BLOODHOOF_TOTEM
      )
    ).Run(completingFaction.Player);
  }

  protected override void OnFail(Faction completingFaction)
  {
    var rescuer = completingFaction.ScoreStatus == ScoreStatus.Defeated
      ? player.NeutralAggressive
      : completingFaction.Player;

    rescuer.RescueGroup(_rescueUnits);
  }

}
