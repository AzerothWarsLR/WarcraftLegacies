using System.Collections.Generic;
using AzerothWarsCSharp.Source.Quests.BlackEmpire;
using AzerothWarsCSharp.Source.Setup.FactionSetup;
using War3Api;

namespace AzerothWarsCSharp.Source.Setup.QuestSetup
{
  public static class BlackEmpireQuestSetup
  {
    public static void Setup()
    {
      var blackempire = BlackEmpireSetup.FactionBlackempire;
      blackempire.StartingQuest = blackempire.AddQuest(new QuestFirstObelisk(Regions.NyalothaUnlock1.Rect));
      blackempire.AddQuest(new QuestSecondObelisk(new List<Common.rect>
        {Regions.NyalothaUnlock2.Rect, Regions.NyalothaUnlock3.Rect}));
      blackempire.AddQuest(new QuestThirdObelisk(new List<Common.rect>
        {Regions.NyalothaUnlock1.Rect, Regions.NyalothaUnlock2.Rect, Regions.NyalothaUnlock3.Rect}));
      blackempire.AddQuest(new QuestYoggSaron());
      blackempire.AddQuest(new QuestBladeOfTheBlackEmpire(new QuestIntoTheVoid()));
    }
  }
}