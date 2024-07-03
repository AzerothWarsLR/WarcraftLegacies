using MacroTools;
using MacroTools.FactionSystem;
using WarcraftLegacies.Shared.FactionObjectLimits;
using WarcraftLegacies.Source.Quests.BlackEmpire;
using WarcraftLegacies.Source.Setup;


namespace WarcraftLegacies.Source.Factions
{
  public class BlackEmpire : Faction
  {

    private readonly AllLegendSetup _allLegendSetup;
    private readonly PreplacedUnitSystem _preplacedUnitSystem;

    /// <inheritdoc />
    public BlackEmpire(PreplacedUnitSystem preplacedUnitSystem, AllLegendSetup allLegendSetup) : base("BlackEmpire", PLAYER_COLOR_MAROON, "|cff800000",
      @"ReplaceableTextures\CommandButtons\BTNNzothIcon.blp")
    {
      _allLegendSetup = allLegendSetup;
      _preplacedUnitSystem = preplacedUnitSystem;
      ControlPointDefenderUnitTypeId = UNIT_N0DV_CONTROL_POINT_DEFENDER_BLACK_EMPIRE_TOWER;
      TraditionalTeam = TeamSetup.OldGods;
      StartingGold = 200;
    }
    
    /// <inheritdoc />
    public override void OnRegistered()
    {
      RegisterObjectLimits();
      RegisterQuests();
      SharedFactionConfigSetup.AddSharedFactionConfig(this);
    }

    private void RegisterQuests()
    {
      var QuestGorma = AddQuest(new QuestMawofGorma(Regions.BlackEmpireOutpost1));
      StartingQuest = QuestGorma;
 
      AddQuest(new QuestWakingCity(QuestGorma, Regions.Nyalotha));
      AddQuest(new QuestGiftofFlesh());
      AddQuest(new QuestWakingDream(_allLegendSetup.BlackEmpire.Xkorr, _preplacedUnitSystem));
      AddQuest(new QuestMawofShuma(_allLegendSetup.BlackEmpire.Yorsahj));
      AddQuest(new QuestMawofGorath(_allLegendSetup.BlackEmpire.Zonozz));
      AddQuest(new QuestBladeoftheBlackEmpire(Regions.TheAbyss));
    }

    private void RegisterObjectLimits()
    {
      foreach (var (objectTypeId, objectLimit) in BlackEmpireObjectLimitData.GetAllObjectLimits())
        ModObjectLimit(FourCC(objectTypeId), objectLimit);
    }
  }
}