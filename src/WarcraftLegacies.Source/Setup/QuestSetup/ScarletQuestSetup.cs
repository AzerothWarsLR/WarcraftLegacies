using MacroTools;
using System.Linq;
using MacroTools.Extensions;
using static War3Api.Common;
using WarcraftLegacies.Source.Setup.FactionSetup;
using WarcraftLegacies.Source.Quests.Scarlet;

namespace WarcraftLegacies.Source.Setup.QuestSetup
{
  public static class ScarletQuestSetup
  {
    public static void Setup(PreplacedUnitSystem preplacedUnitSystem, AllLegendSetup allLegendSetup)
    {
      var scarlet = ScarletSetup.ScarletCrusade;
      if (scarlet == null) 
        return;
      var questStratholme = new QuestRebuildStratholme (Regions.StratholmeUnlock, allLegendSetup.Scarlet.Saiden);
      scarlet.AddQuest(questStratholme);
     
      var questCapital = new QuestReconquerCapital(Regions.Terenas, allLegendSetup.Lordaeron.CapitalPalace, allLegendSetup.Scarlet.Saiden, allLegendSetup.Scarlet.Renault, allLegendSetup.Scarlet.Sally, allLegendSetup.Scarlet.Brigitte);
      scarlet.AddQuest(questCapital);
     
      var questHearthglen = new QuestRebuildHearthglen(Regions.Hearthglen, allLegendSetup.Lordaeron.Monastery);
      scarlet.AddQuest(questHearthglen);
     
      var questBrill = new QuestRebuildBrill(Regions.Brill, allLegendSetup.Scarlet.Renault);
      scarlet.AddQuest(questBrill);
      
      var questAndorhal = new QuestRebuildAndorhal(Regions.Andorhal);
      scarlet.AddQuest(questAndorhal);

      var questReconquerLordaeron = new QuestReconquerLordaeron(questStratholme, questCapital, questHearthglen, questBrill, questAndorhal);
      scarlet.AddQuest(questReconquerLordaeron);
      scarlet.StartingQuest = questReconquerLordaeron;

      var questNewHearthglen = new QuestNewHearthglen(Regions.Central_Northrend);
      scarlet.AddQuest(questNewHearthglen);

      scarlet.AddQuest(new QuestOnslaughtHarbor(questNewHearthglen, allLegendSetup.Scarlet.CrimsonCathedral));
    }
  }
}