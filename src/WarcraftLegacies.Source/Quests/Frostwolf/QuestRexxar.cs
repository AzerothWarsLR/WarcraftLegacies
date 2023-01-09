using MacroTools;
using MacroTools.ObjectiveSystem.Objectives.FactionBased;
using MacroTools.ObjectiveSystem.Objectives.UnitBased;
using MacroTools.QuestSystem;

namespace WarcraftLegacies.Source.Quests.Frostwolf
{
  /// <summary>
  /// Quest for capturing Stonemaul Keep.
  /// </summary>
  public sealed class QuestRexxar : QuestData
  {

    //Todo: bad flavour
    /// <inheritdoc />
    protected override string CompletionPopup =>
      "Korghal has been defeated, Rexxar has joined the Frostwolf!";

    /// <inheritdoc />
    protected override string RewardDescription => "Enable to train Rexxar at the Altar";
    
    /// <summary>
    /// Initializes a new instance of the <see cref="QuestRexxar"/> class.
    /// </summary>
    public QuestRexxar(PreplacedUnitSystem preplacedUnitSystem) : base("The Chieftain's Challenge",
      "Rexxar is having trouble with a beligerent Ogre Warlord, slay the Chieftain to gain the heroe's allegiance.",
      "ReplaceableTextures\\CommandButtons\\BTNOneHeadedOgre.blp")
    {
      AddObjective(new ObjectiveUnitIsDead(preplacedUnitSystem.GetUnit(Constants.UNIT_NOGA_STONEMAUL_WARCHIEF_KOR_GALL)));
      AddObjective(new ObjectiveSelfExists());
      ResearchId = Constants.UPGRADE_R03S_QUEST_COMPLETED_THE_CHIEFTAIN_S_CHALLENGE_FROSTWOLF;

      Required = true;
    }
    
  }
}