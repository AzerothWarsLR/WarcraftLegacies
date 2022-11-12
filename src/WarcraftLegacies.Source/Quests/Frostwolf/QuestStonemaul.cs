using System.Collections.Generic;
using MacroTools;
using MacroTools.ControlPointSystem;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.QuestSystem;
using MacroTools.QuestSystem.UtilityStructs;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Quests.Frostwolf
{
  /// <summary>
  /// Quest for capturing Stonemaul Keep.
  /// </summary>
  public sealed class QuestStonemaul : QuestData
  {
    private readonly List<unit> _rescueUnits;

    //Todo: bad flavour
    /// <inheritdoc />
    protected override string CompletionPopup =>
      "Stonemaul has been liberated, and its military is now free to assist the Frostwolf Clan.";

    /// <inheritdoc />
    protected override string RewardDescription => "Control of all units in Stonemaul and 3000 lumber";
    
    /// <summary>
    /// Initializes a new instance of the <see cref="QuestStonemaul"/> class.
    /// </summary>
    /// <param name="rescueRect">Units in this area will be made invulnerable, then rescued when the quest is completed.</param>
    public QuestStonemaul(Rectangle rescueRect) : base("The Chieftain's Challenge",
      "The Ogres of Stonemaul follow the strongest, slay the Chieftain to gain control of the base.",
      "ReplaceableTextures\\CommandButtons\\BTNOneHeadedOgre.blp")
    {
      AddObjective(new ObjectiveKillUnit(PreplacedUnitSystem.GetUnit(Constants.UNIT_NOGA_STONEMAUL_WARCHIEF_KOR_GALL)));
      AddObjective(new ObjectiveControlPoint(ControlPointManager.GetFromUnitType(Constants.UNIT_N022_STONEMAUL_20GOLD_MIN)));
      AddObjective(new ObjectiveExpire(1505));
      AddObjective(new ObjectiveSelfExists());
      ResearchId = Constants.UPGRADE_R03S_QUEST_COMPLETED_THE_CHIEFTAIN_S_CHALLENGE_FROSTWOLF;

      _rescueUnits = rescueRect.PrepareUnitsForRescue(Player(PLAYER_NEUTRAL_PASSIVE));

      Required = true;
    }
    
    /// <inheritdoc />
    protected override void OnFail(Faction completingFaction)
    {
      Player(PLAYER_NEUTRAL_AGGRESSIVE).RescueGroup(_rescueUnits);
    }

    /// <inheritdoc />
    protected override void OnComplete(Faction completingFaction)
    {
      completingFaction.Player?.RescueGroup(_rescueUnits);
      completingFaction.Player?.AdjustPlayerState(PLAYER_STATE_RESOURCE_LUMBER, 3000);
    }
  }
}