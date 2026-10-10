using System;
using System.Collections.Generic;
using System.Linq;
using MacroTools.Commands;
using MacroTools.ControlPoints;
using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.Paths;
using MacroTools.Utils;
using WarcraftLegacies.Source.Factions.OrcishHorde;
using WarcraftLegacies.Source.Factions.OrcishHorde.Quests;
using WarcraftLegacies.Source.GameLogic;
using WarcraftLegacies.Source.Shared;

namespace WarcraftLegacies.Source.Cheats;

/// <summary>Runs the Blood of Mannoroth and The Blood Fades paths back to back and writes what happened to a file.</summary>
public sealed class CheatTestChaos : Command
{
  private const string ReportPath = @"WarcraftLegacies-chaos-report.pld";
  private const int ReportChunkLength = 200;

  private static readonly int[] _trackedTypes =
  {
    UNIT_OPEO_PEON_ORCISH_HORDE_WORKER, UNIT_O00E_CHAOS_PEON_WARSONG_BLOODPACT,
    UNIT_OGRU_GRUNT_ORCISH_HORDE, UNIT_O00P_CHAOS_WARSONG_GRUNT_WARSONG,
    UNIT_ORAI_RAIDER_ORCISH_HORDE, UNIT_O00S_CHAOS_RAIDER_WARSONG,
    UNIT_OSHM_SHAMAN_ORCISH_HORDE, UNIT_O100_FEL_WARLOCK_WARSONG_BLOODPACT,
    UNIT_OGRH_CHIEFTAIN_OF_THE_WARSONG_CLAN_ORCISH_HORDE, UNIT_OPGH_CORRUPTOR_OF_THE_WARSONG_CLAN_WARSONG_BLOODPACT
  };

  private static readonly List<string> _report = new();

  /// <inheritdoc />
  public override string CommandText => "testchaos";

  /// <inheritdoc />
  public override ExpectedParameterCount ExpectedParameterCount => new(0);

  /// <inheritdoc />
  public override CommandType Type => CommandType.Cheat;

  /// <inheritdoc />
  public override string Description => "Takes The Blood of Mannoroth, kills Mannoroth, redeems the orcs, and writes a report to CustomMapData.";

  /// <inheritdoc />
  public override string Execute(player cheater, params string[] parameters)
  {
    var faction = cheater.GetPlayerData().Faction;
    if (faction is not OrcishHordeFaction || RoleplaySetting.OrcCorruption == null)
    {
      return "Play the Orcish Horde in Roleplay mode to run this.";
    }

    _report.Clear();
    Step(cheater, "start", () => Snapshot(cheater, faction));
    Step(cheater, "accept blood of mannoroth", () => AcceptPath(cheater, faction, "Blood of Mannoroth"));
    After(35, () =>
    {
      Step(cheater, "after blood of mannoroth", () => Snapshot(cheater, faction));
      Step(cheater, "kill mannoroth", () => AllLegends.Warsong.Mannoroth.PermanentlyKill());
      Step(cheater, "after killing mannoroth", () => Snapshot(cheater, faction));
      Step(cheater, "redeem", () => RoleplaySetting.OrcCorruption!.Redeem());
      After(2, () =>
      {
        Step(cheater, "after redeem", () => Snapshot(cheater, faction));
        WriteReport(cheater);
        cheater.DisplayTextTo($"Chaos test finished. Report in CustomMapData/{ReportPath}");
      });
    });

    return "Chaos test started, it takes about 40 seconds.";
  }

  private static void AcceptPath(player cheater, Faction faction, string name)
  {
    var path = faction.GetAllPaths().FirstOrDefault(x => x.Name.Contains(name));
    if (path == null)
    {
      Log($"  no path named {name}");
      return;
    }

    Log($"  {path.Name} state before: {path.State}");
    path.ForceAvailable();
    Log($"  state after unlock: {path.State}, blocked: {path.BlockedReason ?? "no"}");
    path.Accept(cheater);
    Log($"  state after accept: {path.State}");
  }

  private static void Snapshot(player cheater, Faction faction)
  {
    var data = cheater.GetPlayerData();
    Log($"  name {faction.Name}, team {data.Team?.Name ?? "none"}, corrupted {YesNo(RoleplaySetting.OrcCorruption != null && RoleplaySetting.OrcCorruption.IsCorrupted)}");
    Log($"  R09O {GetPlayerTechCount(cheater, UPGRADE_R09O_DRINK_THE_BLOOD_OF_MANNOROTH, true)}, R09P {GetPlayerTechCount(cheater, UPGRADE_R09P_REVERT_BLOODPACT, true)}");
    foreach (var path in faction.GetAllPaths())
    {
      Log($"  path {path.Name}: {path.State}");
    }

    var counts = new Dictionary<int, int>();
    foreach (var whichUnit in GlobalGroup.EnumUnitsOfPlayer(cheater))
    {
      if (whichUnit.Alive)
      {
        counts[whichUnit.UnitType] = counts.GetValueOrDefault(whichUnit.UnitType) + 1;
      }
    }

    foreach (var unitType in _trackedTypes)
    {
      Log($"  {FourCc.GetString(unitType)}: units {counts.GetValueOrDefault(unitType)}, limit {GetPlayerTechMaxAllowed(cheater, unitType)} (faction {faction.GetObjectLimit(unitType)})");
    }

    var defenders = new Dictionary<int, int>();
    foreach (var controlPoint in ControlPointManager.Instance.GetAllControlPoints())
    {
      if (controlPoint.Owner == cheater && controlPoint.Defender != null)
      {
        defenders[controlPoint.Defender.UnitType] = defenders.GetValueOrDefault(controlPoint.Defender.UnitType) + 1;
      }
    }

    Log($"  defenders: {string.Join(", ", defenders.Select(x => $"{FourCc.GetString(x.Key)} x{x.Value}"))}");
    Log($"  thrall: {DescribeHero(AllLegends.Orc.Thrall)}");
    Log($"  voljin: {DescribeHero(AllLegends.Orc.Voljin)}");
    Log($"  grom: {DescribeHero(AllLegends.Orc.GromHellscream)}");
    Log($"  mannoroth: {DescribeHero(AllLegends.Warsong.Mannoroth)}");
    Log($"  saurfang: {DescribeHero(AllLegends.Warsong.Saurfang)}");
    Log($"  orgrimmar: owned by {AllLegends.Orc.Orgrimmar.Unit.Owner.Name}, quest {faction.GetQuestByType<QuestOrgrimmar>().Progress}");
  }

  private static string DescribeHero(MacroTools.Legends.LegendaryHero hero)
  {
    var heroUnit = hero.Unit;
    return heroUnit == null
      ? "no unit"
      : $"{FourCc.GetString(heroUnit.UnitType)} owned by {heroUnit.Owner.Name}, alive {YesNo(heroUnit.Alive)}";
  }

  private static void Step(player cheater, string name, Action action)
  {
    Log($"[{name}]");
    try
    {
      action();
    }
    catch (Exception ex)
    {
      Log($"  ERROR: {ex.Message}");
      cheater.DisplayTextTo($"|cffff0000Chaos test error|r in {name}: {ex.Message}");
    }
  }

  private static string YesNo(bool value) => value ? "yes" : "no";

  private static void Log(string line) => _report.Add(line);

  private static void WriteReport(player cheater)
  {
    if (player.LocalPlayer != cheater)
    {
      return;
    }

    var report = string.Join("\n", _report);
    PreloadGenClear();
    PreloadGenStart();
    for (var offset = 0; offset < report.Length; offset += ReportChunkLength)
    {
      Preload(report.Substring(offset, Math.Min(ReportChunkLength, report.Length - offset)));
    }

    PreloadGenEnd(ReportPath);
  }

  private static void After(float delay, Action action)
  {
    var delayTimer = timer.Create();
    delayTimer.Start(delay, false, () =>
    {
      delayTimer.Dispose();
      action();
    });
  }
}
