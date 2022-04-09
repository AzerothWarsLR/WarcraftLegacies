using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Quests.Scourge;
using AzerothWarsCSharp.Source.Setup.FactionSetup;

namespace AzerothWarsCSharp.Source.Setup.QuestSetup
{
  public static class ScourgeQuestSetup{

    public static void Setup( ){
      QuestSpiderWar questSpiderWar = new QuestSpiderWar(PreplacedUnitSystem.GetUnitByUnitType(Constants.UNIT_QUEEN_NEZAR_AZRET));
      QuestKelthuzad questKelthuzad = new QuestKelthuzad();
      QuestDrakUnlock questDrakUnlock = new QuestDrakUnlock();
      QuestPlague questPlague = new QuestPlague();
      QuestSapphiron questSapphiron = new QuestSapphiron();
      QuestCorruptArthas questCorruptArthas = new QuestCorruptArthas();
      QuestNaxxramas questNaxxramas = new QuestNaxxramas();
      QuestCivilWar questCivilWar = new QuestCivilWar();
      QuestLichKingArthas questLichKingArthas = new QuestLichKingArthas();

      questNaxxramas.AddQuestItem(new QuestItemCompleteQuest(questKelthuzad));

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
