using MacroTools;
using MacroTools.FactionSystem;
using MacroTools.PassiveAbilities;
using MacroTools.PassiveAbilitySystem;
using WarcraftLegacies.Shared.FactionObjectLimits;
using WarcraftLegacies.Source.Quests.BlackEmpire;
using WarcraftLegacies.Source.Quests.Cthun;
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
      RegisterSpells();
      SharedFactionConfigSetup.AddSharedFactionConfig(this);
    }

    private void RegisterQuests()
    {
      var QuestGorma = AddQuest(new QuestMawofGorma(Regions.BlackEmpireOutpost1));
      StartingQuest = QuestGorma;

      AddQuest(new QuestWakingCity(QuestGorma, _allLegendSetup, Regions.Nyalotha));
      AddQuest(new QuestGiftofFlesh());
      AddQuest(new QuestWakingDream(_allLegendSetup.BlackEmpire.Xkorr, _preplacedUnitSystem));
      AddQuest(new QuestMawofShuma(_allLegendSetup.BlackEmpire.Yorsahj));
      AddQuest(new QuestMawofGorath(_allLegendSetup.BlackEmpire.Zonozz));
      AddQuest(new QuestBladeoftheBlackEmpire(Regions.TheAbyss));
      AddQuest(new QuestDestruction(_allLegendSetup.BlackEmpire.Nzoth));
      AddQuest(new QuestWorldStone(_allLegendSetup.BlackEmpire.Nzoth, _allLegendSetup.Frostwolf.ThunderBluff, _allLegendSetup.Warsong.Orgrimmar));
      AddQuest(new QuestAscension(_allLegendSetup.BlackEmpire.Nzoth));
      AddQuest(new QuestAlignement(_allLegendSetup.BlackEmpire.Nzoth));
    }

    private void RegisterObjectLimits()
    {
      foreach (var (objectTypeId, objectLimit) in BlackEmpireObjectLimitData.GetAllObjectLimits())
        ModObjectLimit(FourCC(objectTypeId), objectLimit);
    }

    private void RegisterSpells()
    {
      PassiveAbilityManager.Register(new HideousAppendages(UNIT_U01Z_OLD_GOD_NZOTH)
      {
        TentacleUnitTypeId = UNIT_N098_NZOTHTENTACLE_HIDEOUS_APPENDAGES_N_ZOTH,
        TentacleCount = 9,
        RadiusOffset = 520
      });

      PassiveAbilityManager.Register(new InfiniteInfluence(UNIT_U01Z_OLD_GOD_NZOTH)
      {
        Radius = 700
      });
    }
  }
};