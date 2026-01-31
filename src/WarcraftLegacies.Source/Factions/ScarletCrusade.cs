using System.Collections.Generic;
using MacroTools.Factions;
using WarcraftLegacies.Shared.FactionObjectLimits;
using WarcraftLegacies.Source.Quests.Scarlet;
using WarcraftLegacies.Source.Setup;

namespace WarcraftLegacies.Source.Factions;

public sealed class ScarletCrusade : Faction
{
  /// <inheritdoc />
  public ScarletCrusade() : base("Scarlet Crusade", playercolor.LightBlue,
    "ReplaceableTextures/CommandButtons/BTNScarletKnight.blp")
  {
    StartingGold = 200;
    ControlPointDefenderUnitTypeId = UNIT_H09O_CONTROL_POINT_DEFENDER_SCARLET;

    Nicknames = new List<string>
    {
      "sc",
      "scarlet",
      "scarletcrusade"
    };
    ProcessObjectInfo(ScarletCrusadeObjectInfo.GetAllObjectLimits());
  }

  /// <inheritdoc />
  public override void OnRegistered()
  {
    RegisterQuests();
    SharedFactionConfigSetup.AddSharedFactionConfig(this);
  }

  private void RegisterQuests()
  {
    var questStratholme = new QuestRebuildStratholme(Regions.StratholmeUnlock, AllLegends.Scarlet.Saiden);
    AddQuest(questStratholme);

    var questCapital = new QuestReconquerCapital(Regions.Terenas, AllLegends.Lordaeron.CapitalPalace,
      AllLegends.Scarlet.Saiden, AllLegends.Scarlet.Renault, AllLegends.Scarlet.Sally,
      AllLegends.Scarlet.Brigitte);
    AddQuest(questCapital);

    var questHearthglen = new QuestRebuildHearthglen(Regions.Hearthglen, AllLegends.Lordaeron.Monastery);
    AddQuest(questHearthglen);

    var questBrill = new QuestRebuildBrill(Regions.Brill, AllLegends.Scarlet.Renault);
    AddQuest(questBrill);

    var questAndorhal = new QuestRebuildAndorhal(Regions.Andorhal);
    AddQuest(questAndorhal);

    var questReconquerLordaeron =
      new QuestReconquerLordaeron(questStratholme, questCapital, questHearthglen, questBrill, questAndorhal);
    AddQuest(questReconquerLordaeron);
    StartingQuest = questReconquerLordaeron;

    var questOnslaught = new QuestOnslaught(Regions.Central_Northrend);
    AddQuest(questOnslaught);

    AddQuest(new QuestCrimsonCathedral(questOnslaught, AllLegends.Scarlet.CrimsonCathedral));
  }
}
