using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.QuestSystem;
using MacroTools.QuestSystem.UtilityStructs;
using WarcraftLegacies.Source.Setup.Legends;
using WCSharp.Shared.Data;
using static War3Api.Common;
using static War3Api.Blizzard;
using WarcraftLegacies.Source.Setup.FactionSetup;
using WarcraftLegacies.Source.Setup;
using MacroTools.ControlPointSystem;

namespace WarcraftLegacies.Source.Quests.KulTiras
{
  /// <summary>
  /// Proudmoore captial ship starts locked. Take control of Kul Tiras to unlock it.
  /// </summary>
  public sealed class QuestUnlockShip : QuestData
  {
    private readonly unit _proudmooreCapitalShip;
    private readonly List<unit> _rescueUnits = new();
    /// <summary>
    /// Initializes a new instance of the <see cref="QuestUnlockShip"/> class.
    /// </summary>
    /// <param name="rescueRect">All units in this area will be made neutral, then rescued when the quest is completed.</param>
    /// <param name="proudmooreCapitalShip">starts invulnerable and unusable. Made usuable and vulnerable when the quest is completed.</param>
    public QuestUnlockShip(Rectangle rescueRect, unit proudmooreCapitalShip) : base("The Admiralty of Kul Tiras",
      "Kul Tiras has degenerated severely in contemporary times. Bandits and vile monsters threaten the islands and the noble houses have split apart. We must quell these threats and reunite the kingdom's various regions under Daelin Proudmoore's command.",
      "ReplaceableTextures\\CommandButtons\\BTNGalleonIcon.blp")
    {
      AddObjective(new ObjectiveControlCapital(LegendKultiras.LegendBoralus, false));
      AddObjective(new ObjectiveControlLegend(LegendKultiras.LegendAdmiral, false));
      AddObjective(new ObjectiveControlPoint(ControlPointManager.GetFromUnitType(Constants.UNIT_N0BX_TIRAGARDE_SOUND_10GOLD_MIN)));
      AddObjective(new ObjectiveControlPoint(ControlPointManager.GetFromUnitType(Constants.UNIT_N0BW_STORMSONG_VALLEY_10GOLD_MIN)));
      AddObjective(new ObjectiveControlPoint(ControlPointManager.GetFromUnitType(Constants.UNIT_N0BV_DRUSTVAR_10GOLD_MIN)));
      AddObjective(new ObjectiveExpire(900));
      AddObjective(new ObjectiveSelfExists());
      _proudmooreCapitalShip = proudmooreCapitalShip;
      _rescueUnits = rescueRect.PrepareUnitsForRescue(RescuePreparationMode.HideNonStructures);
      Required = true;
    }

    /// <inheritdoc/>
    protected override string FailurePopup =>
      "You failed to reunite the Kul'Tiran kingdom. It will never rise to its former glory again.";

    /// <inheritdoc/>
    protected override string PenaltyDescription =>
      "The Proudmoore Capital Ship is lost forever.";

    /// <inheritdoc/>
    protected override string CompletionPopup => "The Kul'Tiran kingdom has been united once more. The Proudmoore Capital Ship is now ready to set sail!";

    /// <inheritdoc/>
    protected override string RewardDescription =>
      "Unlock the Proudmoore capital ship and the buildings inside.";

    /// <inheritdoc/>
    protected override void OnComplete(Faction completingFaction)
    {
      if (completingFaction.Player != null)
      {
        completingFaction.Player.RescueGroup(_rescueUnits);
        _proudmooreCapitalShip.Rescue(completingFaction.Player);
      }
      else
      {
        Player(bj_PLAYER_NEUTRAL_VICTIM).RescueGroup(_rescueUnits);
        _proudmooreCapitalShip.Rescue(Player(PLAYER_NEUTRAL_AGGRESSIVE));
      }
      _proudmooreCapitalShip.Pause(false);
    }

    /// <inheritdoc/>
    protected override void OnFail(Faction completingFaction)
    {
      _proudmooreCapitalShip.Remove();
    }
  }
}