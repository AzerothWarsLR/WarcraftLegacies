using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.Quests.Twilight
{
  public sealed class QuestFeludius : QuestData{

  
    private const int RESEARCH_ID = FourCC("R07T");
  


    protected override string CompletionPopup => "The great AlFourCC(akir has joined us!";

    protected override string CompletionDescription => "You can summon Al-akir from the Altar";


    public  thistype ( ){
      thistype this = thistype.allocate("Gift of the Windlord", "Bringing the Legendary Sword, Thunderfury, to Uldum will grant us the favors of AlFourCC("akir, the great Wind Elemental Lord", "ReplaceableTextures\\CommandButtons\\BTNfuryoftheair.blp"");
      AddQuestItem(new QuestItemControlPoint(ControlPoint.GetFromUnitType(FourCC("n0BD"))));
      AddQuestItem(new QuestItemArtifactInRect(ARTIFACT_THUNDERFURY, Regions.UldumAmbiance.Rect, "Uldum"));
      ResearchId = RESEARCH_ID;
      ;;
    }


  }
}
