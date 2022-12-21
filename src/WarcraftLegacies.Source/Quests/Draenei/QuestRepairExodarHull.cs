using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.QuestSystem;
using System.Collections.Generic;
using MacroTools.ObjectiveSystem.Objectives;
using WarcraftLegacies.Source.Setup.Legends;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Quests.Draenei
{
  /// <summary>
  /// Bring the exodar to full health in order to unlock the base inside
  /// </summary>
  public class QuestRepairExodarHull : QuestData
  {
    /// <summary>
    /// 
    /// </summary>
    /// <param name="rescueRect"></param>
    public QuestRepairExodarHull(Rectangle rescueRect) : base("A New Home",
      "After the disastrous voyage through the Twisting Nether, the exodar crash-landed on the Azuremyst Isles. Its hull must be repaired in order to get inside.",
      "")
    {
      Required = true;
      AddObjective(new ObjectiveUnitReachesFullHealth(LegendDraenei.LegendExodar.Unit));
      AddObjective(new ObjectiveSelfExists());
      _rescueUnits = rescueRect.PrepareUnitsForRescue(RescuePreparationMode.HideNonStructures);
      ResearchId = Constants.UPGRADE_R099_QUEST_COMPLETED_A_NEW_HOME; // Change this to current quest;
    }

    private List<unit> _rescueUnits { get; }

    /// <inheritdoc/>
    protected override string CompletionPopup => "The Exodar's hull is repaired. It can now be entered again";

    /// <inheritdoc/>
    protected override string FailurePopup => "The Exodar is destroyed. It can never be repaired again.";

    /// <inheritdoc/>
    protected override string RewardDescription =>
      "You are now able to enter the Exodar and gain access to everything inside.";

    /// <inheritdoc/>
    protected override void OnComplete(Faction whichFaction)
    {
      if (whichFaction.Player != null)
        whichFaction.Player.RescueGroup(_rescueUnits);
      else
        Player(PLAYER_NEUTRAL_AGGRESSIVE).RescueGroup(_rescueUnits);
      // SetUnitInvulnerable(LegendDraenei.LegendExodar.Unit, false);

      //Open Portals to exodar inside
    }

    /// <inheritdoc/>
    protected override void OnFail(Faction whichFaction)
    {
      // Quest to repair the Exodar inside should be failed here too.
    }

    //  protected override void OnAdd(Faction whichFaction)
    //  {
    //    SetUnitInvulnerable(LegendDraenei.LegendExodar.Unit, true);
    //  }
  }
}