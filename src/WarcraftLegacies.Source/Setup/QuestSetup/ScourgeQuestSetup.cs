using System.Collections.Generic;
using MacroTools;
using MacroTools.QuestSystem;
using WarcraftLegacies.Source.Mechanics.Scourge.Plague;
using WarcraftLegacies.Source.Quests.Scourge;
using WarcraftLegacies.Source.Setup.FactionSetup;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Setup.QuestSetup
{
  public static class ScourgeQuestSetup
  {
    public static QuestData Setup(PreplacedUnitSystem preplacedUnitSystem, ArtifactSetup artifactSetup)
    {
      QuestSpiderWar questSpiderWar = new(Regions.Ice_Crown,
        preplacedUnitSystem.GetUnit(Constants.UNIT_N074_QUEEN_NEZAR_AZRET));
      QuestKelthuzad questKelthuzad = new();
      QuestDrakUnlock questDrakUnlock = new(Regions.DrakUnlock);

      var plagueParameters = new PlagueParameters();
      plagueParameters.PlagueRects = new List<Rectangle>
      {
        Regions.Plague_1,
        Regions.Plague_2,
        Regions.Plague_3,
        Regions.Plague_4,
        Regions.Plague_5,
        Regions.Plague_6,
        Regions.Plague_7
      };
      plagueParameters.PlagueCauldronSummonParameters = new List<PlagueCauldronSummonParameter>
      {
        new(2, Constants.UNIT_UNEC_NECROMANCER_SCOURGE),
        new(2, Constants.UNIT_UACO_ACOLYTE_SCOURGE_WORKER, ScourgeSetup.Scourge),
        new(4, Constants.UNIT_UGHO_GHOUL_SCOURGE),
        new(4, Constants.UNIT_UCRY_CRYPT_FIEND_SCOURGE),
      };
      plagueParameters.PlagueCauldronUnitTypeId = Constants.UNIT_H02W_PLAGUE_CAULDRON;
      plagueParameters.Duration = 360;

      QuestPlague questPlague = new(plagueParameters);

      QuestSapphiron questSapphiron = new(preplacedUnitSystem.GetUnit(Constants.UNIT_UBDR_SAPPHIRON_CREEP));
      QuestCorruptArthas questCorruptArthas = new();
      QuestNaxxramas questNaxxramas = new(Regions.NaxAmbient,
        preplacedUnitSystem.GetUnit(Constants.UNIT_E013_NAXXRAMAS_SCOURGE));
      QuestCivilWar questCivilWar = new();
      QuestLichKingArthas questLichKingArthas =
        new(preplacedUnitSystem.GetUnit(Constants.UNIT_H00O_UTGARDE_KEEP_SCOURGE), artifactSetup.HelmOfDomination);

      //Setup
      ScourgeSetup.Scourge.AddQuest(questSpiderWar);
      ScourgeSetup.Scourge.StartingQuest = questSpiderWar;
      ScourgeSetup.Scourge.AddQuest(questDrakUnlock);
      ScourgeSetup.Scourge.AddQuest(questPlague);
      ScourgeSetup.Scourge.AddQuest(questSapphiron);
      //Early duel
      ScourgeSetup.Scourge.AddQuest(questCorruptArthas);
      ScourgeSetup.Scourge.AddQuest(questKelthuzad);
      ScourgeSetup.Scourge.AddQuest(questNaxxramas);
      ScourgeSetup.Scourge.AddQuest(questCivilWar);
      //Misc
      ScourgeSetup.Scourge.AddQuest(questLichKingArthas);

      return questPlague;
    }
  }
}