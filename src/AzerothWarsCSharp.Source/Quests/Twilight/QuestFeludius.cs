using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Setup;

namespace AzerothWarsCSharp.Source.Quests.Twilight
{
  public sealed class QuestFeludius : QuestData
  {
    public QuestFeludius() : base("Gift of the Windlord",
      "Bringing the Legendary Sword, Thunderfury, to Uldum will grant us the favors of Al'akir, the great Wind Elemental Lord",
      "ReplaceableTextures\\CommandButtons\\BTNfuryoftheair.blp")
    {
      AddQuestItem(new QuestItemControlPoint(ControlPoint.GetFromUnitType(FourCC("n0BD"))));
      AddQuestItem(new QuestItemArtifactInRect(ArtifactSetup.ArtifactThunderfury, Regions.UldumAmbiance.Rect, "Uldum"));
      ResearchId = FourCC("R07T");
    }
    
    protected override string CompletionPopup => "The great Al'akir has joined us!";

    protected override string RewardDescription => "You can summon Al'akir from the Altar";
  }
}