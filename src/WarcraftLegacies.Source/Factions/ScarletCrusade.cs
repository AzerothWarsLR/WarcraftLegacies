using System.Collections.Generic;
using MacroTools.FactionSystem;
using WarcraftLegacies.Shared.FactionObjectLimits;
using WarcraftLegacies.Source.Quests.Scarlet;
using WarcraftLegacies.Source.Setup;

namespace WarcraftLegacies.Source.Factions
{
  public sealed class ScarletCrusade : Faction
  {
    private readonly AllLegendSetup _allLegendSetup;

    /// <inheritdoc />
    public ScarletCrusade(AllLegendSetup allLegendSetup) : base("Scarlet Crusade", PLAYER_COLOR_LIGHT_BLUE,
      "ReplaceableTextures/CommandButtons/BTNScarletKnight.blp")
    {
      _allLegendSetup = allLegendSetup;
      StartingGold = 200;
      ControlPointDefenderUnitTypeId = UNIT_H09O_CONTROL_POINT_DEFENDER_CRUSADE;

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
      var questStratholme = new QuestRebuildStratholme(Regions.StratholmeUnlock, _allLegendSetup.Scarlet.Saiden);
      AddQuest(questStratholme);

      var questCapital = new QuestReconquerCapital(Regions.Terenas, _allLegendSetup.Lordaeron.CapitalPalace,
        _allLegendSetup.Scarlet.Saiden, _allLegendSetup.Scarlet.Renault, _allLegendSetup.Scarlet.Sally,
        _allLegendSetup.Scarlet.Brigitte);
      AddQuest(questCapital);

      var questHearthglen = new QuestRebuildHearthglen(Regions.Hearthglen, _allLegendSetup.Lordaeron.Monastery);
      AddQuest(questHearthglen);

      var questBrill = new QuestRebuildBrill(Regions.Brill, _allLegendSetup.Scarlet.Renault);
      AddQuest(questBrill);

      var questAndorhal = new QuestRebuildAndorhal(Regions.Andorhal);
      AddQuest(questAndorhal);

      var questReconquerLordaeron =
        new QuestReconquerLordaeron(questStratholme, questCapital, questHearthglen, questBrill, questAndorhal);
      AddQuest(questReconquerLordaeron);
      StartingQuest = questReconquerLordaeron;

      var questOnslaught = new QuestOnslaught(Regions.Central_Northrend);
      AddQuest(questOnslaught);

      AddQuest(new QuestCrimsonCathedral(questOnslaught, _allLegendSetup.Scarlet.CrimsonCathedral));
    }
  }
}