using AzerothWarsCSharp.Source.Main.Libraries.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.RoC.Quests.Scourge;

namespace AzerothWarsCSharp.Source.RoC.Setup.QuestSetup
{
  public class ScourgeQuestSetup{

    public static void Setup( ){
      QuestSpiderWar questSpiderWar = QuestSpiderWar.create();
      QuestKelthuzad questKelthuzad = QuestKelthuzad.create();
      QuestDrakUnlock questDrakUnlock = QuestDrakUnlock.create();
      QuestPlague questPlague = QuestPlague.create();
      QuestSapphiron questSapphiron = QuestSapphiron.create();
      QuestCorruptArthas questCorruptArthas = QuestCorruptArthas.create();
      QuestNaxxramas questNaxxramas = QuestNaxxramas.create();
      QuestCivilWar questCivilWar = QuestCivilWar.create();
      QuestLichKingArthas questLichKingArthas = QuestLichKingArthas.create();

      questNaxxramas.AddQuestItem(QuestItemCompleteQuest.create(questKelthuzad));

      //Setup
      FACTION_SCOURGE.AddQuest(questSpiderWar);
      FACTION_SCOURGE.StartingQuest = questSpiderWar;
      FACTION_SCOURGE.AddQuest(questDrakUnlock);
      FACTION_SCOURGE.AddQuest(questPlague);
      FACTION_SCOURGE.AddQuest(questSapphiron);
      //Early duel
      FACTION_SCOURGE.AddQuest(questCorruptArthas);
      FACTION_SCOURGE.AddQuest(questKelthuzad);
      FACTION_SCOURGE.AddQuest(questNaxxramas);
      FACTION_SCOURGE.AddQuest(questCivilWar);
      //Misc
      FACTION_SCOURGE.AddQuest(questLichKingArthas);
    }

  }
}
