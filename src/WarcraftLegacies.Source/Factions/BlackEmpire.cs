using MacroTools.FactionSystem;
using WarcraftLegacies.Shared.FactionObjectLimits;
using WarcraftLegacies.Source.Quests.BlackEmpire;
using WarcraftLegacies.Source.Setup;

namespace WarcraftLegacies.Source.Factions
{
  public class BlackEmpire : Faction
  {

    private readonly AllLegendSetup _allLegendSetup;

    /// <inheritdoc />
    public BlackEmpire(AllLegendSetup allLegendSetup) : base("BlackEmpire", PLAYER_COLOR_MAROON, "|cff800000",
      @"ReplaceableTextures\CommandButtons\BTNNzothIcon.blp")
    {
      _allLegendSetup = allLegendSetup;
      ControlPointDefenderUnitTypeId = UNIT_N0DV_CONTROL_POINT_DEFENDER_BLACK_EMPIRE_TOWER;
      TraditionalTeam = TeamSetup.OldGods;
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
      var newQuest = AddQuest(new QuestMawofGorma(Regions.BlackEmpireOutpost1));
      StartingQuest = newQuest;
 
      AddQuest(new QuestWakingCity(Regions.Nyalotha));
      AddQuest(new QuestGiftofFlesh());
      AddQuest(new QuestWakingDream(_allLegendSetup.BlackEmpire.Zaqul));
    }

    private void RegisterObjectLimits()
    {
      foreach (var (objectTypeId, objectLimit) in BlackEmpireObjectLimitData.GetAllObjectLimits())
        ModObjectLimit(FourCC(objectTypeId), objectLimit);
    }
  }
}