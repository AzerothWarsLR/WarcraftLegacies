using WarcraftLegacies.MacroTools.ControlPointSystem;
using WarcraftLegacies.MacroTools.QuestSystem;
using WarcraftLegacies.MacroTools.QuestSystem.UtilityStructs;
using WarcraftLegacies.Source.Setup;

namespace WarcraftLegacies.Source.Quests.Twilight
{
  public sealed class QuestFeludius : QuestData
  {
    public QuestFeludius() : base("Gift of the Windlord",
      "Bringing the Legendary Sword, Thunderfury, to Uldum will grant us the favors of Al'akir, the great Wind Elemental Lord",
      "ReplaceableTextures\\CommandButtons\\BTNfuryoftheair.blp")
    {
      AddObjective(
        new ObjectiveControlPoint(ControlPointManager.GetFromUnitType(Constants.UNIT_N0BD_ULDUM_10GOLD_MIN)));
      AddObjective(new ObjectiveArtifactInRect(ArtifactSetup.ArtifactThunderfury, Regions.UldumAmbiance, "Uldum"));
      ResearchId = Constants.UPGRADE_R07T_QUEST_COMPLETED_GIFT_OF_THE_WINDLORD;
    }

    protected override string CompletionPopup => "The great Al'akir has joined us!";

    protected override string RewardDescription => "You can summon Al'akir from the Altar";
  }
}