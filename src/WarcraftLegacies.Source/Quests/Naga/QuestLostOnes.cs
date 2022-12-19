using System.Collections.Generic;
using MacroTools.ControlPointSystem;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.QuestSystem;
using MacroTools.QuestSystem.UtilityStructs;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Quests.Naga
{
  /// <summary>
  /// Drive the Draenai out of Outland, take control of various control points in outland and upgrade main to t3 in order to unlock Hellfire Citadel.
  /// </summary>
  public sealed class QuestLostOnes : QuestData
  {
    private readonly List<unit> _rescueUnits;

    /// <summary>
    /// Initializes a new instance of the <see cref="QuestLostOnes"/> class.
    /// </summary>
    /// <param name="rescueRect">Units in this area start invulnerable then get rescued when the quest is complete.</param>
    public QuestLostOnes(Rectangle rescueRect) : base("The Lost Ones",
      "The lost tribe of Draenei, forgotten on Outland, have need of a new master, and that master is Illidan",
      "ReplaceableTextures\\CommandButtons\\BTNDranaiAkama.blp")
    {
      AddObjective(new ObjectiveControlPoint(ControlPointManager.Instance.GetFromUnitType(Constants.UNIT_N01J_ZANGARMARSH_15GOLD_MIN)));
      AddObjective(new ObjectiveControlPoint(ControlPointManager.Instance.GetFromUnitType(Constants.UNIT_N02N_BLADE_S_EDGE_MOUNTAINS_15GOLD_MIN)));
      AddObjective(new ObjectiveControlPoint(ControlPointManager.Instance.GetFromUnitType(Constants.UNIT_N00B_NAGRAND_15GOLD_MIN)));
      AddObjective(new ObjectiveControlPoint(ControlPointManager.Instance.GetFromUnitType(Constants.UNIT_N0CW_FARAHLON_10GOLD_MIN)));
      AddObjective(new ObjectiveExpire(1450));
      AddObjective(new ObjectiveSelfExists());
      ResearchId = Constants.UPGRADE_R05H_QUEST_COMPLETED_THE_LOST_ONES;
      _rescueUnits = rescueRect.PrepareUnitsForRescue(RescuePreparationMode.Invulnerable);
      Required = true;
    }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    protected override string CompletionPopup =>
      "The Lost Ones tribe has joined our cause";

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    protected override string RewardDescription =>
      "Control of all units in the Draenei camp, Enable to Build the Draenei Hut and train Akama";

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    protected override void OnComplete(Faction completingFaction)
    {
      if(completingFaction.Player != null)
      {
        completingFaction.Player.RescueGroup(_rescueUnits);
      }
      if (completingFaction?.Player == GetLocalPlayer())
        PlayThematicMusic("IllidansTheme");
    }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    protected override void OnFail(Faction completingFaction)
    {
      if (completingFaction.Player != null)
      {
        Player(PLAYER_NEUTRAL_AGGRESSIVE).RescueGroup(_rescueUnits);
      }      
    }
  }
}