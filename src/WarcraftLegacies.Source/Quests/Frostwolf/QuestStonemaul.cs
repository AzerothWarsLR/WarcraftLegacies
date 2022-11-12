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

    //Todo: bad flavour
    /// <inheritdoc />
    protected override string CompletionPopup =>
      "Korghal has been defeated, Rexxar has joined the Frostwolf!";

    /// <inheritdoc />
    protected override string RewardDescription => "Enable to train Rexxar at the Altar";
    
    /// <summary>
    /// Initializes a new instance of the <see cref="QuestStonemaul"/> class.
    /// </summary>
    public QuestStonemaul() : base("The Chieftain's Challenge",
      "Rexxar is having trouble with a beligerent Ogre Warlord, slay the Chieftain to gain the heroe's allegiance.",
      "ReplaceableTextures\\CommandButtons\\BTNOneHeadedOgre.blp")
    {
      AddObjective(new ObjectiveKillUnit(PreplacedUnitSystem.GetUnit(Constants.UNIT_NOGA_STONEMAUL_WARCHIEF_KOR_GALL)));
      AddObjective(new ObjectiveSelfExists());
      ResearchId = Constants.UPGRADE_R03S_QUEST_COMPLETED_THE_CHIEFTAIN_S_CHALLENGE_FROSTWOLF;

      Required = true;
    }
    
  }
}