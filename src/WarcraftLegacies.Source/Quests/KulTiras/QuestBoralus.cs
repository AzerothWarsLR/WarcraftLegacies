using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.QuestSystem;
using WCSharp.Shared.Data;
using static War3Api.Common;
using static War3Api.Blizzard;
using MacroTools;
using MacroTools.ObjectiveSystem.Objectives.FactionBased;
using MacroTools.ObjectiveSystem.Objectives.TimeBased;
using MacroTools.ObjectiveSystem.Objectives.UnitBased;

namespace WarcraftLegacies.Source.Quests.KulTiras
{
  /// <summary>
  /// Tier 4 must be researched to unlock all units in the Boralus area.
  /// </summary>
  public sealed class QuestBoralus : QuestData
  {
    private readonly List<unit> _rescueUnits;

    /// <summary>
    /// Initializes a new instance of the <see cref="QuestBoralus"/> class.
    /// </summary>
    /// <param name="preplacedUnitSystem">A system which can be used to find preplaced units.</param>
    /// <param name="rescueRect">All units in this area will be made neutral, then rescued when the quest is completed or made aggressive when the quest is failed.</param>
    public QuestBoralus(Rectangle rescueRect, PreplacedUnitSystem preplacedUnitSystem) : base("The City at Sea",
      "Proudmoore is stranded at sea. Rejoin Boralus to take control of the city.",
      "ReplaceableTextures\\CommandButtons\\BTNHumanShipyard.blp")
    {
      AddObjective(new ObjectiveResearch(Constants.UPGRADE_R04R_FORTIFIED_HULLS_UNIVERSAL_UPGRADE, Constants.UNIT_H06I_CASTLE_KUL_TIRAS_T3));
      AddObjective(new ObjectiveUpgrade(Constants.UNIT_H06I_CASTLE_KUL_TIRAS_T3, Constants.UNIT_H062_TOWN_HALL_KUL_TIRAS_T1));
      AddObjective(new ObjectiveExpire(900));
      AddObjective(new ObjectiveSelfExists());
      ResearchId = Constants.UPGRADE_R00L_QUEST_COMPLETED_THE_CITY_AT_SEA_KUL_TIRAS;
      _rescueUnits = rescueRect.PrepareUnitsForRescue(RescuePreparationMode.HideNonStructures);
      _rescueUnits.Remove(preplacedUnitSystem.GetUnit(Constants.UNIT_H05V_PROUDMOORE_FLAGSHIP_KUL_TIRAS)); // Proudmoore Capital Ship is not supposed to be rescued on this quest
      Required = true;
    }

    /// <inheritdoc/>
    protected override string RewardFlavour =>
      "Kul'tiras has joined the war and its military is now free to assist the Alliance.";

    /// <inheritdoc/>
    protected override string RewardDescription =>
      "Control of all units in Kul'tiras and enables Katherine Proodmoure to be trained at the altar";

    /// <inheritdoc/>
    protected override void OnFail(Faction completingFaction)
    {
      Player(PLAYER_NEUTRAL_AGGRESSIVE).RescueGroup(_rescueUnits);
    }

    /// <inheritdoc/>
    protected override void OnComplete(Faction completingFaction)
    {
      if (completingFaction.Player != null)
      {
        completingFaction.Player.RescueGroup(_rescueUnits);
      }
      else
      {
        Player(bj_PLAYER_NEUTRAL_VICTIM).RescueGroup(_rescueUnits);
      }
      if (GetLocalPlayer() == completingFaction.Player) PlayThematicMusic("war3mapImported\\KultirasTheme.mp3");
      
    }
  }
}