using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.Source.Quests.Warsong;
using AzerothWarsCSharp.Source.Setup.FactionSetup;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Setup.QuestSetup
{
  public static class WarsongQuestSetup
  {
    public static void Setup()
    {
      var warsong = WarsongSetup.WarsongClan;
      warsong.StartingQuest = warsong.AddQuest(new QuestOrgrimmar(Regions.Orgrimmar));
      warsong.AddQuest(new QuestCrossroads(Regions.Crossroads));
      warsong.AddQuest(new QuestChenStormstout(PreplacedUnitSystem.GetUnit(FourCC("Nsjs"))));
      warsong.AddQuest(new QuestFountainOfBlood());
      warsong.AddQuest(new QuestWarsongKillDruids());
      warsong.AddQuest(new QuestMoreWyverns());
      warsong.AddQuest(new QuestWarsongHold());
    }
  }
}