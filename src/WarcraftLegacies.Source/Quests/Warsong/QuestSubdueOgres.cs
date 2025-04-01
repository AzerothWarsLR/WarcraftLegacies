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
  public sealed class QuestSubdueOgres : QuestData
  {
    private readonly List<unit> _rescueUnits;
    private readonly LegendaryHero _grom;
    private int PillageGoldReward { get; set; }
    private int PillageExperienceReward { get; set; }

    public QuestSubdueOgres(Rectangle rescueRect, LegendaryHero grom)
      : base(
        "Brute Allegiance",
        "Their brute strength is untamed, their loyalty unproven.Subdue the ogres and further strengthen the Horde.",
        @"ReplaceableTexturesCommandButtonsBTNBarracks.blp")
    {
      _grom = grom;
      AddObjective(new ObjectiveControlPoint(Constants.UNIT_N022_STONEMAUL));
      AddObjective(new ObjectiveSelfExists());

      _rescueUnits = rescueRect.PrepareUnitsForRescue(RescuePreparationMode.HideNonStructures);
      // default values for fallback
      PillageGoldReward = 300;
      PillageExperienceReward = 1000;
    }


    /// <inheritdoc/>
    public override string RewardFlavour =>
      "The fate of the ogres has been decided, the Hordes power grows.";

    /// <inheritdoc/>
    protected override string RewardDescription =>
      $"Control of Stonemaul and the ability to train {GetObjectName(UNIT_N07A_OGRE_WARRIOR_WARSONG)} from the {GetObjectName(UNIT_O01S_WAR_CAMP_WARSONG_BARRACKS)} and {GetObjectName(UNIT_N08O_OGRE_MAGI_WARSONG)} from the {GetObjectName(UNIT_O006_SPIRE_WARSONG_MAGIC)} or gain {PillageGoldReward} gold and {PillageExperienceReward} XP for Grom.";

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
        Console.WriteLine("Without Grom's leadership to restrain the Warband, the ogres are slaughtered.");
        return;
      }

      // Set custom rewards
      PillageGoldReward = 300;
      PillageExperienceReward = 1000;

      new WarsongPillageDialogPresenter(
        gromUnit,
        new WarsongPillageChoice(PillageChoiceType.Pillage, "Pillage Stonemaul", Regions.StonemaulKeep, PillageGoldReward, PillageExperienceReward),
        new WarsongPillageChoice(PillageChoiceType.Subdue, "Subdue the Ogres", Regions.StonemaulKeep, 0, 0)
      ).Run(completingFaction.Player);
    }



    /// inheritdoc />
    protected override void OnFail(Faction completingFaction)
    {
      completingFaction.Player.RescueGroup(_rescueUnits);
    }
  }
}
