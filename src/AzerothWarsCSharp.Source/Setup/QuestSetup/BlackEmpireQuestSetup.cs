using System.Collections.Generic;
using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.Source.Quests.BlackEmpire;
using AzerothWarsCSharp.Source.Setup.FactionSetup;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Setup.QuestSetup
{
  public static class BlackEmpireQuestSetup
  {
    public static void Setup()
    {
      var blackempire = BlackEmpireSetup.FactionBlackempire;
      blackempire.StartingQuest = blackempire.AddQuest(new QuestFirstObelisk(Regions.NyalothaUnlock1.Rect, new[]
      {
        PreplacedUnitSystem.GetDestructable(FourCC("ATg1"), new Point(-23416, -3279)),
        PreplacedUnitSystem.GetDestructable(FourCC("ATg3"), new Point(-24911, 633))
      }));
      blackempire.AddQuest(new QuestSecondObelisk(new List<rect>
        {Regions.NyalothaUnlock2.Rect, Regions.NyalothaUnlock3.Rect}, new[]
      {
        PreplacedUnitSystem.GetDestructable(FourCC("ATg2"), new Point(-25747, -3442)),
        PreplacedUnitSystem.GetDestructable(FourCC("ATg3"), new Point(-25225, -6227))
      }));
      blackempire.AddQuest(new QuestThirdObelisk(new List<rect>
        {Regions.NyalothaUnlock1.Rect, Regions.NyalothaUnlock2.Rect, Regions.NyalothaUnlock3.Rect}, new[]
      {
        PreplacedUnitSystem.GetDestructable(FourCC("ATg1"), new Point(-23416, -3279)),
        PreplacedUnitSystem.GetDestructable(FourCC("ATg3"), new Point(-24911, 633)),
        PreplacedUnitSystem.GetDestructable(FourCC("ATg2"), new Point(-25747, -3442)),
        PreplacedUnitSystem.GetDestructable(FourCC("ATg3"), new Point(-25225, -6227))
      }));
      blackempire.AddQuest(new QuestYoggSaron());
      blackempire.AddQuest(new QuestBladeOfTheBlackEmpire(new QuestIntoTheVoid()));
    }
  }
}