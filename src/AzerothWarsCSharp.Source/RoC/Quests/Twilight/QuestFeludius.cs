using AzerothWarsCSharp.Source.Main.Libraries.MacroTools;
using AzerothWarsCSharp.Source.Main.Libraries.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.RoC.Quests.Twilight
{
  public class QuestFeludius{

  
    private const int RESEARCH_ID = FourCC(R07T);
  


    private string operator CompletionPopup( ){
      return "The great AlFourCC(akir has joined us!";
    }

    private string operator CompletionDescription( ){
      return "You can summon Al-akir from the Altar";
    }


    public  thistype ( ){
      thistype this = thistype.allocate("Gift of the Windlord", "Bringing the Legendary Sword, Thunderfury, to Uldum will grant us the favors of AlFourCC(akir, the great Wind Elemental Lord", "ReplaceableTextures\\CommandButtons\\BTNfuryoftheair.blp");
      this.AddQuestItem(QuestItemControlPoint.create(ControlPoint.ByUnitType(FourCC(n0BD))));
      this.AddQuestItem(QuestItemArtifactInRect.create(ARTIFACT_THUNDERFURY, gg_rct_UldumAmbiance, "Uldum"));
      this.ResearchId = RESEARCH_ID;
      ;;
    }


  }
}
