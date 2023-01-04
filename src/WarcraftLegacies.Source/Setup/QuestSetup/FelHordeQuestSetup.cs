using System.Collections.Generic;
using MacroTools;
using WarcraftLegacies.Source.Quests.Fel_Horde;
using WCSharp.Shared.Data;
using static WarcraftLegacies.Source.Setup.FactionSetup.FelHordeSetup;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Setup.QuestSetup
{
  public static class FelHordeQuestSetup
  {
    public static void Setup(PreplacedUnitSystem preplacedUnitSystem)
    {
      
      var questHellfireCitadel = FelHorde.AddQuest(new QuestHellfireCitadel(Regions.HellfireUnlock));
     
      //FelHorde.AddQuest(new QuestDarkPortalOpen(
      //  preplacedUnitSystem.GetUnit(Constants.UNIT_N05J_DARK_PORTAL_AURA_CONTROL_NEXUS, new Point(3703, -26045)),
      //  preplacedUnitSystem.GetUnit(Constants.UNIT_N036_DARK_PORTAL, Regions.Dark_Portal_Entrance_1.Center),
      //  preplacedUnitSystem.GetUnit(Constants.UNIT_N036_DARK_PORTAL, Regions.Dark_Portal_Entrance_2.Center),
      //  preplacedUnitSystem.GetUnit(Constants.UNIT_N036_DARK_PORTAL, Regions.Dark_Portal_Entrance_3.Center),
      //  preplacedUnitSystem.GetUnit(Constants.UNIT_N036_DARK_PORTAL, Regions.Dark_Portal_Exit_1.Center),
      //  preplacedUnitSystem.GetUnit(Constants.UNIT_N036_DARK_PORTAL, Regions.Dark_Portal_Exit_2.Center),
      //  preplacedUnitSystem.GetUnit(Constants.UNIT_N036_DARK_PORTAL, Regions.Dark_Portal_Exit_3.Center)));
      
    
      FelHorde.AddQuest(new QuestBlackrock(Regions.BlackrockUnlock, new[] { questHellfireCitadel }));
      FelHorde.AddQuest(new QuestFelHordeKillIronforge());
      FelHorde.AddQuest(new QuestFelHordeKillStormwind());
      FelHorde.AddQuest(new QuestGuldansLegacy());
    }
  }
}