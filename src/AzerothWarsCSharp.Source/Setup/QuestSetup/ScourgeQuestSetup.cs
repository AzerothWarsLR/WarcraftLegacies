using System.Collections.Generic;
using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.MacroTools.Wrappers;
using AzerothWarsCSharp.Source.Mechanics.Scourge.Plague;
using AzerothWarsCSharp.Source.Quests.Scourge;
using AzerothWarsCSharp.Source.Setup.FactionSetup;
using WCSharp.Shared.Data;

namespace AzerothWarsCSharp.Source.Setup.QuestSetup
{
  public static class ScourgeQuestSetup
  {
    public static QuestData Setup()
    {
      QuestSpiderWar questSpiderWar = new(Regions.Ice_Crown,
        PreplacedUnitSystem.GetUnit(Constants.UNIT_N074_QUEEN_NEZAR_AZRET));
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
        new(1, Constants.UNIT_U01R_APOTHECARY_FORSAKEN),
        new(2, Constants.UNIT_UACO_ACOLYTE_SCOURGE, ScourgeSetup.Scourge),
        new(2, Constants.UNIT_U01K_ACOLYTE_FORSAKEN),
        new(4, Constants.UNIT_N07S_DEADEYE_FORSAKEN),
        new(4, Constants.UNIT_H08O_ROTGUARD_FORSAKEN),
      };
      plagueParameters.PlagueCauldronUnitTypeId = Constants.UNIT_H02W_PLAGUE_CAULDRON;
      plagueParameters.Duration = 360;

      QuestPlague questPlague = new(ForsakenSetup.Forsaken,
        PreplacedUnitSystem.GetUnit(Constants.UNIT_N0AG_LORD_BAROV),
        new GroupWrapper().EnumUnitsOfType(Constants.UNIT_U01U_CULTIST_OF_THE_DAMNED_FORSAKEN).EmptyToList(),
        plagueParameters
      );

      QuestSapphiron questSapphiron = new(PreplacedUnitSystem.GetUnit(Constants.UNIT_UBDR_SAPPHIRON_CREEP));
      QuestCorruptArthas questCorruptArthas = new();
      QuestNaxxramas questNaxxramas = new(Regions.NaxAmbient,
        PreplacedUnitSystem.GetUnit(Constants.UNIT_E013_NAXXRAMAS_SCOURGE));
      QuestCivilWar questCivilWar = new();
      QuestLichKingArthas questLichKingArthas =
        new(PreplacedUnitSystem.GetUnit(Constants.UNIT_H00O_UTGARDE_KEEP_SCOURGE));

      questNaxxramas.AddObjective(new ObjectiveCompleteQuest(questKelthuzad));

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