using System.Collections.Generic;
using MacroTools.ControlPointSystem;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.ObjectiveSystem.Objectives;
using MacroTools.QuestSystem;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Quests.Fel_Horde
{
  /// <summary>
  /// Drive the Draenai out of Outland, take control of various control points in outland and upgrade main to t3 in order to unlock Hellfire Citadel.
  /// </summary>
  public sealed class QuestHellfireCitadel : QuestData
  {
    private readonly List<unit> _demonGates;
    private readonly List<unit> _rescueUnits;

    /// <summary>
    /// Initializes a new instance of the <see cref="QuestHellfireCitadel"/> class.
    /// </summary>
    /// <param name="rescueRect">Units in this area start invulnerable then get rescued when the quest is complete.</param>
    /// <param name="demonGates">These units start invulnerable then get rescued when the quest is complete.</param>
    public QuestHellfireCitadel(Rectangle rescueRect, List<unit> demonGates) : base("The Citadel",
      "The clans holding Hellfire Citadel do not respect Magtheridon's authority yet, capture a large part of Outland to finally establish Magtheridon as the undisputable king of Outland",
      "ReplaceableTextures\\CommandButtons\\BTNFelOrcFortress.blp")
    {
      _demonGates = demonGates;
      AddObjective(new ObjectiveControlPoint(ControlPointManager.Instance.GetFromUnitType(Constants.UNIT_N01J_ZANGARMARSH_15GOLD_MIN)));
      AddObjective(new ObjectiveControlPoint(ControlPointManager.Instance.GetFromUnitType(Constants.UNIT_N02N_BLADE_S_EDGE_MOUNTAINS_15GOLD_MIN)));
      AddObjective(new ObjectiveControlPoint(ControlPointManager.Instance.GetFromUnitType(Constants.UNIT_N00B_NAGRAND_15GOLD_MIN)));
      AddObjective(new ObjectiveControlPoint(ControlPointManager.Instance.GetFromUnitType(Constants.UNIT_N0CV_HALAAR_10GOLD_MIN)));
      AddObjective(new ObjectiveUpgrade(Constants.UNIT_O030_FORTRESS_FEL_HORDE, Constants.UNIT_O02Y_GREAT_HALL_FEL_HORDE));
      AddObjective(new ObjectiveExpire(1450));
      AddObjective(new ObjectiveSelfExists());
      ResearchId = Constants.UPGRADE_R00P_QUEST_COMPLETED_THE_CITADEL;
      _rescueUnits = rescueRect.PrepareUnitsForRescue(RescuePreparationMode.Invulnerable);
      Required = true;
    }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    protected override string CompletionPopup =>
      "Hellfire Citadel has been subjugated, and its military is now free to assist the Fel Horde.";

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    protected override string RewardDescription =>
      "Control of all units in Hellfire Citadel and enable Kargath to be trained at the altar";

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    protected override void OnComplete(Faction completingFaction)
    {
      if(completingFaction.Player != null)
      {
        completingFaction.Player.RescueGroup(_rescueUnits);
        completingFaction.Player.RescueGroup(_demonGates);
      }
      if (GetLocalPlayer() == completingFaction.Player) PlayThematicMusic("war3mapImported\\FelTheme.mp3");
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