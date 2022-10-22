using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.Source.Quests.Stormwind;
using AzerothWarsCSharp.Source.Setup.FactionSetup;

namespace AzerothWarsCSharp.Source.Setup.QuestSetup
{
  public static class StormwindQuestSetup
  {
    public static void Setup()
    {
      var stormwind = StormwindSetup.Stormwind;
      QuestData newQuest =
        stormwind.AddQuest(new QuestDarkshire(PreplacedUnitSystem.GetUnit(FourCC("ngnv"), Regions.DarkshireUnlock.Center)));
      stormwind.StartingQuest = newQuest;
      stormwind.AddQuest(new QuestLakeshire(Regions.LakeshireUnlock,
        PreplacedUnitSystem.GetUnit(FourCC("nogl"), Regions.LakeshireUnlock.Center)));
      stormwind.AddQuest(new QuestGoldshire(Regions.ElwinForestAmbient,
        PreplacedUnitSystem.GetUnit(Constants.UNIT_N021_HOGGER)));
      stormwind.AddQuest(new QuestStormwindCity(Regions.StormwindUnlock));
      stormwind.AddQuest(new QuestNethergarde());
      stormwind.AddQuest(new QuestStromgarde(Regions.Stromgarde));
      stormwind.AddQuest(new QuestHonorHold(Regions.HonorHold));
      stormwind.AddQuest(new QuestKhadgar());
      stormwind.AddQuest(new QuestClosePortal());
    }
  }
}