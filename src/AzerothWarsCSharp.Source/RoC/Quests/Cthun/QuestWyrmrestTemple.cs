public class QuestWyrmrestTemple{

  
    private const int RESEARCH_ID = FourCC(R07S);
  


    private string operator CompletionPopup( ){
      return "YorFourCC(sahj can now be trained at the altar";
    }

    private string operator CompletionDescription( ){
      return "The hero YorFourCC(sahj will join Ahn)Qiraj";
    }

    public  thistype ( ){
      //Todo: the flavour of this doesn)t add up. The description implies you need to do something to Wyrmrest Temple,
      //but actually you need to take the Demon Soul there and kill 3 dragons. What)s the connection to the Demon Soul in particular?
      thistype this = thistype.allocate("The Siege of Wyrmrest Temple", "YorFourCC(sahj the Unsleeping)s mission is to destroy the Wyrmrest temple, assist him && he will join the Black Empire", "ReplaceableTextures\\CommandButtons\\BTNHeroMastermind.blp");
      this.AddQuestItem(QuestItemAcquireArtifact.create(ARTIFACT_DEMONSOUL));
      this.AddQuestItem(QuestItemArtifactInRect.create(ARTIFACT_DEMONSOUL, gg_rct_WyrmrestTemple, "Wyrmrest Temple"));
      this.AddQuestItem(QuestItemLegendDead.create(LEGEND_SARAGOSA));
      this.AddQuestItem(QuestItemLegendDead.create(LEGEND_VAELASTRASZ));
      this.AddQuestItem(QuestItemLegendDead.create(LEGEND_OCCULUS));
      this.ResearchId = RESEARCH_ID;
      ;;
    }


}
