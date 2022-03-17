//Escapes Kalimdor, Find the Skull of Guldan
public class QuestIllidanChapterThree{

   
    private const int RITUAL_ID = FourCC(A0KY);
  



    private string operator CompletionPopup( ){
      return "Illidan must awaken the Naga from the depth of the ocean";
    }

    private string operator CompletionDescription( ){
      return "Nazjatar && the NagaFourCC(s loyalty";
    }

    private void OnComplete( ){
      RescueNeutralUnitsInRect(gg_rct_NagaUnlock2, this.Holder.Player);
      RescueNeutralUnitsInRect(gg_rct_NagaUnlock1, this.Holder.Player);
      FACTION_NAGA.AddQuest(REDEMPTION_PATH);
      REDEMPTION_PATH.Progress = QUEST_PROGRESS_UNDISCOVERED;
      FACTION_NAGA.AddQuest(EXILE_PATH);
      EXILE_PATH.Progress = QUEST_PROGRESS_UNDISCOVERED;
      FACTION_NAGA.AddQuest(MADNESS_PATH);
      MADNESS_PATH.Progress = QUEST_PROGRESS_UNDISCOVERED;
      //call FACTION_NAGA.AddQuest(ALLIANCE_NAGA)
      //set ALLIANCE_NAGA.Progress = QUEST_PROGRESS_UNDISCOVERED
      FACTION_NAGA.AddQuest(CONQUER_BLACK_TEMPLE);
      CONQUER_BLACK_TEMPLE.Progress = QUEST_PROGRESS_UNDISCOVERED;
      FACTION_NAGA.AddQuest(KILL_FROZEN_THRONE);
      KILL_FROZEN_THRONE.Progress = QUEST_PROGRESS_UNDISCOVERED;
      SetUnitInvulnerable(gg_unit_n045_3377, true);
    }

    public  thistype ( ){
      thistype this = thistype.allocate("Chapter Three: Dwellers from the Deep", "Awakening the Naga will give Illidan the army he needs to achieve his goals.", "ReplaceableTextures\\CommandButtons\\BTNNagaMyrmidon.blp");
      this.AddQuestItem(QuestItemLegendReachRect.create(LEGEND_ILLIDAN, gg_rct_StartQuest3, "the exit"));
      this.AddQuestItem(QuestItemLegendReachRect.create(LEGEND_ILLIDAN, gg_rct_MaelstromAmbient, "the Maelstrom"));
      this.AddQuestItem(QuestItemCastSpell.create(RITUAL_ID, true));
      ;;
    }


}
