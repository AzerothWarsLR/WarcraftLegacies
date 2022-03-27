using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Quests.Scourge;

namespace AzerothWarsCSharp.Source.Setup.QuestSetup
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
      ScourgeSetup.FactionScourge.AddQuest(questSpiderWar);
      ScourgeSetup.FactionScourge.StartingQuest = questSpiderWar;
      ScourgeSetup.FactionScourge.AddQuest(questDrakUnlock);
      ScourgeSetup.FactionScourge.AddQuest(questPlague);
      ScourgeSetup.FactionScourge.AddQuest(questSapphiron);
      //Early duel
      ScourgeSetup.FactionScourge.AddQuest(questCorruptArthas);
      ScourgeSetup.FactionScourge.AddQuest(questKelthuzad);
      ScourgeSetup.FactionScourge.AddQuest(questNaxxramas);
      ScourgeSetup.FactionScourge.AddQuest(questCivilWar);
      //Misc
      ScourgeSetup.FactionScourge.AddQuest(questLichKingArthas);
    }

  }
}
