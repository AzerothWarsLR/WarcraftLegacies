using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.Source.Quests.Warsong;
using AzerothWarsCSharp.Source.Setup.FactionSetup;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Setup.QuestSetup
{
  public class WarsongQuestSetup
  {
    public static void Setup()
    {
      var warsong = WarsongSetup.FACTION_WARSONG;

      //Setup
      warsong.StartingQuest = warsong.AddQuest(new QuestOrgrimmar(Regions.Orgrimmar));
      warsong.AddQuest(new QuestCrossroads(Regions.Crossroads.Rect));
      warsong.AddQuest(new QuestChenStormstout(PreplacedUnitSystem.GetUnitByUnitType(FourCC("Nsjs"))));
      warsong.AddQuest(new QuestFountainOfBlood());
      //Early duel
      warsong.AddQuest(new QuestWarsongKillDruids());
      warsong.AddQuest(new QuestMoreWyverns());
      //Misc
      warsong.AddQuest(new QuestWarsongHold());
    }
  }
}