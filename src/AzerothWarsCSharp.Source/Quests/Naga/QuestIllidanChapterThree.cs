//Escapes Kalimdor, Find the Skull of Guldan

using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Libraries;

namespace AzerothWarsCSharp.Source.Quests.Naga
{
  public sealed class QuestIllidanChapterThree : QuestData{

   
    private const int RITUAL_ID = FourCC("A0KY");
  



    protected override string CompletionPopup => 
      return "Illidan must awaken the Naga from the depth of the ocean";
    }

    protected override string CompletionDescription => 
      return "Nazjatar && the NagaFourCC(s loyalty";
    }

    protected override void OnComplete(){
      GeneralHelpers.RescueNeutralUnitsInRect(gg_rct_NagaUnlock2, this.Holder.Player);
      GeneralHelpers.RescueNeutralUnitsInRect(gg_rct_NagaUnlock1, this.Holder.Player);
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
      this.AddQuestItem(new QuestItemLegendReachRect(LEGEND_ILLIDAN, gg_rct_StartQuest3, "the exit"));
      this.AddQuestItem(new QuestItemLegendReachRect(LEGEND_ILLIDAN, gg_rct_MaelstromAmbient, "the Maelstrom"));
      this.AddQuestItem(new QuestItemCastSpell(RITUAL_ID, true));
      ;;
    }


  }
}
