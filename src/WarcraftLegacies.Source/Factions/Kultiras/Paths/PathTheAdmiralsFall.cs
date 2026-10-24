using MacroTools.Factions;
using MacroTools.Legends;
using MacroTools.Localization;
using MacroTools.Paths;
using WarcraftLegacies.Source.Objectives.MetaBased;
using WarcraftLegacies.Source.Shared;
using WarcraftLegacies.Source.Shared.Powers;

namespace WarcraftLegacies.Source.Factions.Kultiras.Paths;

/// <summary>With Boralus in ruins and Daelin dead, Katherine Proudmoore leads Kul Tiras out of the Alliance.</summary>
public sealed class PathTheAdmiralsFall : FactionPath
{
  private const int KatherineLevels = 2;
  private const int ExtraMusketeers = 4;
  private const float DamageBonus = 0.1f;
  private const float DamageReduction = 0.2f;
  private const float BaseX = 1344;
  private const float BaseY = -9280;

  private readonly ObjectiveTriggered _admiralFallen;
  private bool _boralusFallen;
  private bool _daelinFallen;
  private bool _katherineEmpowered;

  public PathTheAdmiralsFall()
  {
    Name = "The Admiral's Fall";
    IconName = "JainaFormal";
    Description = "Boralus burns and the Lord Admiral is dead, slain in a war the Alliance would not finish. Katherine Proudmoore takes up her husband's mantle and leads Kul Tiras alone, beholden to no king but its own.";
    _admiralFallen = new ObjectiveTriggered("Boralus Keep has fallen and Daelin Proudmoore is dead") { ShowsInQuestLog = false };
    AddRequirement(_admiralFallen);
    CanGoSolo = true;

    var boralusDeath = trigger.Create();
    boralusDeath.RegisterUnitEvent(AllLegends.Kultiras.LegendBoralus.Unit, unitevent.Death);
    boralusDeath.AddAction(OnBoralusFallen);
    AllLegends.Kultiras.LegendAdmiral.Died += OnDaelinDied;
  }

  /// <inheritdoc />
  public override bool ChangesTeam => true;

  /// <inheritdoc />
  protected override void OnTaken(Faction faction)
  {
    faction.ModObjectLimit(UNIT_N07G_MUSKETEER_KULTIRAS, ExtraMusketeers);
    faction.AddPower(new EmpoweredUnits(x => !x.IsUnitType(unittype.Structure), DamageBonus, DamageReduction)
    {
      Name = "Proudmoore's Legacy",
      IconName = "JainaFormal",
      DescriptionTemplate = "Kul Tiras stands alone, and every sailor fights as if Boralus itself were behind them. Your units deal {bonus}% more damage and take {reduction}% less damage."
    });

    var katherine = AllLegends.Kultiras.LegendKatherine;
    if (katherine.Unit != null)
    {
      EmpowerKatherine(katherine.Unit);
    }
    else
    {
      katherine.UnitChanged += _ =>
      {
        if (katherine.Unit != null)
        {
          EmpowerKatherine(katherine.Unit);
        }
      };
    }

    var owner = faction.Player;
    if (owner != null)
    {
      BuildDrustvarBase(owner);
    }
  }

  private void OnBoralusFallen()
  {
    _boralusFallen = true;
    var daelin = AllLegends.Kultiras.LegendAdmiral;
    Faction?.ModObjectLimit(UNIT_HAPM_LORD_ADMIRAL_OF_KUL_TIRAS_KULTIRAS, -1);
    var daelinUnit = daelin.Unit;
    if (daelinUnit == null)
    {
      _daelinFallen = true;
    }
    else if (daelinUnit.Alive)
    {
      daelin.PermaDies = true;
    }
    else
    {
      daelin.PermanentlyKill();
    }

    CheckFallen();
  }

  private void OnDaelinDied(LegendDiedEventArgs args)
  {
    if (!args.Permanent)
    {
      return;
    }

    _daelinFallen = true;
    CheckFallen();
  }

  private void CheckFallen()
  {
    if (_boralusFallen && _daelinFallen)
    {
      _admiralFallen.Trigger();
    }
  }

  private void EmpowerKatherine(unit katherine)
  {
    if (_katherineEmpowered)
    {
      return;
    }

    _katherineEmpowered = true;
    SetHeroLevel(katherine, GetHeroLevel(katherine) + KatherineLevels, true);
    katherine.Name = Loc.Get("Lord Admiral of Kul Tiras");
  }

  private static void BuildDrustvarBase(player owner)
  {
    PathBase.CreateStructure(owner, UNIT_H062_TOWN_HALL_KULTIRAS_T1, BaseX, BaseY);
    PathBase.CreateStructure(owner, UNIT_H06R_GARRISON_KULTIRAS_BARRACKS, BaseX + 448, BaseY - 128);
    PathBase.CreateStructure(owner, UNIT_H07N_HOMESTEAD_KULTIRAS_FARM, BaseX - 320, BaseY - 192);
    PathBase.CreateStructure(owner, UNIT_H07N_HOMESTEAD_KULTIRAS_FARM, BaseX - 320, BaseY - 448);
    PathBase.CreateStructure(owner, UNIT_H07S_GUARD_TOWER_KULTIRAS_TOWER, BaseX + 512, BaseY + 192);
    PathBase.CreateUnits(owner, UNIT_H01E_DECKHAND_KULTIRAS_WORKER, 4, BaseX, BaseY - 384);
  }
}
