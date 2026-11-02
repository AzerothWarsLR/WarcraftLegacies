using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.Legends;
using MacroTools.Paths;
using MacroTools.Utils;
using WarcraftLegacies.Source.Factions.Illidari;
using WarcraftLegacies.Source.Factions.OrcishHorde;
using WarcraftLegacies.Source.Objectives.LegendBased;
using WarcraftLegacies.Source.Shared;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions.FelHorde.Paths;

/// <summary>Lets the Fel Horde join the Horde once an enemy other than the Illidari kills Magtheridon for good.</summary>
public sealed class PathMaghar : FactionPath
{
  private const float GaradarX = -2912;
  private const float GaradarY = -31136;
  private const float HellfireX = 960;
  private const float HellfireY = -26688;

  public PathMaghar(LegendaryHero magtheridon)
  {
    Name = "The Mag'har";
    IconName = "GarroshHellscream";
    NameColorCode = ColorManager.GetColorHexCode(playercolor.Wheat);
    Description = "If Magtheridon falls, Greatmother Geyah will call the clans home to Garadar: \"Remember who you were before the demons' blood.\" Cast off the fel and join the Horde as the Mag'har, led by Garrosh Hellscream.";
    DeclineDescription = "Kazzak the Supreme takes Magtheridon's place and keeps the clans loyal to the Legion.";
    AddRequirement(new ObjectiveLegendKilledBy(magtheridon, "an enemy other than the Illidari", IsEnemyOtherThanIllidari, true) { ShowsInQuestLog = false });
  }

  /// <inheritdoc />
  public override bool ChangesTeam => true;

  /// <inheritdoc />
  protected override Team? GetDestinationTeam(Faction faction)
  {
    if (!FactionManager.TryGetFactionByType<OrcishHordeFaction>(out var orcishHorde))
    {
      return null;
    }

    var orcishHordePlayer = orcishHorde.Player;
    return orcishHordePlayer == null ? null : orcishHordePlayer.GetPlayerData().Team;
  }

  /// <inheritdoc />
  protected override void OnTaken(Faction faction)
  {
    var owner = faction.Player;
    if (owner == null)
    {
      return;
    }

    var maghar = new MagharFaction(faction);
    FactionTransition.AssignNewFaction(faction, maghar);
    PathBase.RemoveHero(AllLegends.FelHorde.Kargath);
    PathBase.RemoveHero(AllLegends.FelHorde.Teron);
    RemoveLeftBehind(owner);
    AbandonDemonGates(owner);
    PathBase.ConvertArmy(owner, MagharFaction.UnitEquivalents);
    PathBase.ConvertStructures(owner, MagharFaction.UnitEquivalents);
    BuildGaradar(owner);
    BuildGaradarBase(owner);
    BuildOrgrimmarBase(owner);
    LeaveHellfireRuins();
    var garrosh = new LegendaryHero("Garrosh Hellscream")
    {
      UnitType = UNIT_O20Q_CHIEFTAIN_OF_THE_MAG_HAR_MAGHAR
    };
    MagtheridonSuccession.Replace(maghar, garrosh, new Point(GaradarX, GaradarY - 500));
    MagharQuests.Setup(faction, maghar, garrosh);
    TakenOutcome = "The clans cast off the demons' blood and became the Mag'har, led by Garrosh Hellscream from Garadar.";
  }

  /// <inheritdoc />
  protected override void OnDeclined(Faction faction)
  {
    Point? spawnPosition = null;
    var owner = faction.Player;
    if (owner != null)
    {
      foreach (var demiKazzak in GlobalGroup.EnumUnitsOfPlayer(owner))
      {
        if (demiKazzak.UnitType != UNIT_N05T_KAZZAK_THE_SUPREME_FEL_DEMI || !demiKazzak.Alive)
        {
          continue;
        }

        spawnPosition = new Point(demiKazzak.X, demiKazzak.Y);
        demiKazzak.DropAllItems();
        demiKazzak.Dispose();
        break;
      }
    }

    faction.ModObjectLimit(UNIT_N05T_KAZZAK_THE_SUPREME_FEL_DEMI, -faction.GetObjectLimit(UNIT_N05T_KAZZAK_THE_SUPREME_FEL_DEMI));
    MagtheridonSuccession.Replace(faction, new LegendaryHero("Kazzak the Supreme")
    {
      UnitType = UNIT_N0Z1_DOOM_LORD_FEL
    }, spawnPosition);
  }

  private static void RemoveLeftBehind(player owner)
  {
    foreach (var whichUnit in GlobalGroup.EnumUnitsOfPlayer(owner))
    {
      if (!whichUnit.Alive || !whichUnit.IsRemovable() || whichUnit.IsUnitType(unittype.Hero) ||
          !MagharFaction.IsLeftBehind(whichUnit.UnitType))
      {
        continue;
      }

      owner.Gold += whichUnit.GoldCost;
      whichUnit.DropAllItems();
      whichUnit.Dispose();
    }
  }

  private static void AbandonDemonGates(player owner)
  {
    foreach (var whichUnit in GlobalGroup.EnumUnitsOfPlayer(owner))
    {
      if (!whichUnit.Alive || !MagharFaction.IsDemonGate(whichUnit.UnitType))
      {
        continue;
      }

      whichUnit.RemoveAbility(ABILITY_A05V_TOGGLE_SUMMONING_FEL_HORDE_DEMON_GATE);
      whichUnit.SetOwner(player.NeutralAggressive);
    }
  }

  private static void LeaveHellfireRuins()
  {
    var hellfire = AllLegends.FelHorde.HellfireCitadel.Unit;
    if (hellfire != null && hellfire.Alive)
    {
      hellfire.Kill();
    }

    var ruins = unit.Create(player.NeutralPassive, UNIT_N0Z7_RUINS_OF_HELLFIRE_CITADEL_MAGHAR, HellfireX, HellfireY, 270);
    SetUnitAnimation(ruins, "decay");
    var freeze = timer.Create();
    freeze.Start(0.1f, false, () =>
    {
      freeze.Dispose();
      SetUnitTimeScale(ruins, 0);
    });
  }

  private static void BuildOrgrimmarBase(player owner)
  {
    BuildOver(owner, UNIT_O20F_FORTRESS_MAGHAR_T3, -6880, -480);
    BuildOver(owner, UNIT_O20K_BEASTIARY_MAGHAR_SPECIALIST, -7008, -224);
    BuildOver(owner, UNIT_O20H_BARRACKS_MAGHAR_BARRACKS, -6816, -864);
    BuildOver(owner, UNIT_O20G_ALTAR_OF_STORMS_MAGHAR_ALTAR, -7392, -864);
    BuildOver(owner, UNIT_O20M_WATCH_TOWER_MAGHAR_TOWER, -7104, -832);
    BuildOver(owner, UNIT_O20L_BURROW_MAGHAR_FARM, -7168, -192);
    BuildOver(owner, UNIT_O20L_BURROW_MAGHAR_FARM, -7104, -64);
    BuildOver(owner, UNIT_O20L_BURROW_MAGHAR_FARM, -7168, -960);
    BuildOver(owner, UNIT_O20L_BURROW_MAGHAR_FARM, -7232, -832);
  }

  private static void BuildOver(player owner, int unitTypeId, float x, float y)
  {
    RefundSystem.RefundOtherStructuresInRange(owner, x, y, 200);
    PathBase.CreateStructure(owner, unitTypeId, x, y);
  }

  private static void BuildGaradarBase(player owner)
  {
    PathBase.CreateStructure(owner, UNIT_O20G_ALTAR_OF_STORMS_MAGHAR_ALTAR, -3552, -30880);
    PathBase.CreateStructure(owner, UNIT_O20J_SPIRIT_LODGE_MAGHAR_MAGIC, -3424, -31840);
    PathBase.CreateStructure(owner, UNIT_O20H_BARRACKS_MAGHAR_BARRACKS, -2208, -31072);
    PathBase.CreateStructure(owner, UNIT_O20O_TREASURY_MAGHAR_SHOP, -2208, -30688);
    PathBase.CreateStructure(owner, UNIT_O20I_WAR_MILL_MAGHAR_RESEARCH, -2208, -30240);
    PathBase.CreateStructure(owner, UNIT_O20L_BURROW_MAGHAR_FARM, -3712, -30848);
    PathBase.CreateStructure(owner, UNIT_O20L_BURROW_MAGHAR_FARM, -1984, -31104);
    PathBase.CreateStructure(owner, UNIT_O20L_BURROW_MAGHAR_FARM, -2560, -30528);
    PathBase.CreateStructure(owner, UNIT_O20M_WATCH_TOWER_MAGHAR_TOWER, -2944, -31616);
    PathBase.CreateStructure(owner, UNIT_O20M_WATCH_TOWER_MAGHAR_TOWER, -1984, -30784);
    PathBase.CreateStructure(owner, UNIT_O20M_WATCH_TOWER_MAGHAR_TOWER, -2688, -30464);
    PathBase.CreateStructure(owner, UNIT_O20N_IMPROVED_WATCH_TOWER_MAGHAR_TOWER_2, -3328, -30400);
  }

  private static void BuildGaradar(player owner)
  {
    var garadar = PathBase.CreateStructure(owner, UNIT_O20T_GARADAR_MAGHAR, GaradarX, GaradarY);
    if (garadar == null || !garadar.Alive)
    {
      return;
    }

    CapitalManager.Register(new Capital
    {
      Unit = garadar,
      Essential = true,
      DeathMessage = "Garadar has been razed."
    });
  }

  private bool IsEnemyOtherThanIllidari(player killer) => OutlandSubmission.IsEnemyOtherThanIllidari(Faction, killer);
}
