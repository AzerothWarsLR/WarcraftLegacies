using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using MacroTools.Commands;
using MacroTools.DummyCasters;
using MacroTools.Extensions;
using MacroTools.Spells;
using MacroTools.Utils;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Cheats;

public sealed class CheatBenchmark : Command
{
  private const int MaximumTargets = 1000;
  private const int MaximumSamples = 5;
  private const int ReportChunkLength = 200;
  private const float TargetFieldRadius = 160;
  private const float TargetFieldRightOffset = 400;
  private const string ReportPath = @"WarcraftLegacies-benchmark-report.pld";

  private static readonly List<unit> Targets = new();
  private static readonly List<double> Times = new();
  private static Spell? _spell;
  private static unit? _caster;
  private static player? _owner;
  private static Point _targetCenter = new(0, 0);
  private static bool _friendlyTargets;
  private static bool _airTargets;
  private static bool _rightTargets;
  private static int _targetCount;
  private static int _sampleCount;
  private static int _sample;
  private static bool _running;

  public override string CommandText => "bench";
  public override ExpectedParameterCount ExpectedParameterCount => new(1, 4);
  public override CommandType Type => CommandType.Cheat;
  public override string Description => "Benchmark a spell. Use -bench help for usage.";

  public override string Execute(player commandUser, params string[] parameters)
  {
    if (parameters[0].Equals("help", StringComparison.OrdinalIgnoreCase))
    {
      return GetHelp();
    }
    if (parameters.Length is < 3 or > 4)
    {
      return GetUsage();
    }
    var targets = 0;
    var samples = 0;
    if (!int.TryParse(parameters[1], out targets) || targets < 1 || targets > MaximumTargets ||
        !int.TryParse(parameters[2], out samples) || samples < 1 || samples > MaximumSamples)
    {
      return $"Use 1-{MaximumTargets} targets and 1-{MaximumSamples} samples.";
    }
    if (_running)
    {
      return "A benchmark is already running.";
    }

    var key = NormalizeName(parameters[0]);
    Spell? spell = null;
    if (parameters[0].Length == 4)
    {
      SpellRegistry.TryGetSpellByAbilityId(FourCC(parameters[0]), out spell);
    }

    if (spell == null)
    {
      var matches = SpellRegistry.GetAllSpells()
        .Where(x => NormalizeName(GetObjectName(x.Id)) == key)
        .ToList();
      if (matches.Count > 1)
      {
        return $"'{parameters[0]}' matches several registered spells: " +
               $"{string.Join(", ", matches.Select(x => FourCc.GetString(x.Id)))}. Use a rawcode.";
      }
      spell = matches.FirstOrDefault();
    }

    if (spell == null)
    {
      return $"No registered scripted spell matches '{parameters[0]}'. " +
             "Try its 4-character rawcode. Faction spells require their faction to be in the match.";
    }

    var friendlyTargets = false;
    var airTargets = false;
    var rightTargets = false;
    if (parameters.Length == 4 &&
        !TryParseFixture(parameters[3], out friendlyTargets, out airTargets, out rightTargets))
    {
      return "Use enemy-ground, ally-ground, enemy-air, or ally-air, with an optional -right suffix.";
    }
    var anchor = GlobalGroup.EnumSelectedUnits(commandUser).FirstOrDefault();
    if (anchor == null)
    {
      return "Select a unit in an empty area to choose where the benchmark runs.";
    }

    _spell = spell;
    _owner = commandUser;
    var center = anchor.GetPosition();
    _targetCenter = rightTargets
      ? new Point(center.X + TargetFieldRightOffset, center.Y)
      : center;
    _friendlyTargets = friendlyTargets;
    _airTargets = airTargets;
    _rightTargets = rightTargets;
    _targetCount = targets;
    _sampleCount = samples;
    _sample = 0;
    Times.Clear();
    _caster = unit.Create(commandUser, DummyCasterManager.UnitTypeId, center.X, center.Y, 0);
    _caster.SetPathing(false);
    _caster.MaxLife = 10000;
    _caster.Life = 10000;
    _caster.MaxMana = 10000;
    _caster.Mana = 10000;
    _caster.AddAbility(spell.Id);
    _caster.SetAbilityLevel(spell.Id, 1);
    _running = true;
    if (!RunSample())
    {
      return $"{FourCc.GetString(spell.Id)} failed during the warm-up. See CustomMapData/{ReportPath}.";
    }
    return $"Running {FourCc.GetString(spell.Id)} (OnCast): {targets} {GetFixtureName()} targets, " +
           $"{samples} samples + 1 warm-up.";
  }

  private static string GetUsage() =>
    "Use -bench <spell> <targets> <samples> [fixture]. See -bench help.";

  private static string GetHelp()
  {
    return "-bench <spell> <targets> <samples> [fixture]\n" +
           "Select a unit in an empty area to set the caster position.\n" +
           "Use a case-sensitive rawcode or a unique spell name (quote names with spaces).\n" +
           "Examples: -bench A0WM 200 5; -bench A0GP 200 5 enemy-ground-right.\n" +
           $"Targets: 1-{MaximumTargets}; samples: 1-{MaximumSamples}.\n" +
           "Fixtures: enemy-ground (default), ally-ground, enemy-air, ally-air.\n" +
           $"Add -right to move the target group {TargetFieldRightOffset:0} units right of the caster.\n" +
           "Times the spell's OnCast call.\n" +
           "Work that runs after the call returns is not included.\n" +
           "Skips one warm-up, then reports the average and each sample.\n" +
           $"Saves the latest result to CustomMapData/{ReportPath}.";
  }

  private static string NormalizeName(string value) => value
    .Replace("-", string.Empty)
    .Replace(" ", string.Empty)
    .Replace("'", string.Empty)
    .ToLowerInvariant();

  private static bool TryParseFixture(string value, out bool friendly, out bool air, out bool right)
  {
    friendly = false;
    air = false;
    right = false;
    var key = NormalizeName(value);
    const string rightSuffix = "right";
    if (key.EndsWith(rightSuffix, StringComparison.Ordinal))
    {
      right = true;
      key = key.Substring(0, key.Length - rightSuffix.Length);
    }

    switch (key)
    {
      case "enemyground":
        return true;
      case "allyground":
        friendly = true;
        return true;
      case "enemyair":
        air = true;
        return true;
      case "allyair":
        friendly = true;
        air = true;
        return true;
      default:
        return false;
    }
  }

  private static string GetFixtureName() =>
    $"{(_friendlyTargets ? "ally" : "enemy")}-{(_airTargets ? "air" : "ground")}" +
    (_rightTargets ? "-right" : string.Empty);

  private static bool RunSample()
  {
    try
    {
      CreateTargets();
      _caster!.EndAbilityCooldown(_spell!.Id);
      var started = Now();
      _spell.OnCast(_caster, Targets[0], _targetCenter);
      var elapsed = (Now() - started) * 1000;
      var sampleName = _sample == 0 ? "warmup" : _sample.ToString(CultureInfo.InvariantCulture);
      Console.WriteLine($"BENCH spell={FourCc.GetString(_spell.Id)} sample={sampleName} scope=scripted-oncast " +
                        $"fixture={GetFixtureName()} spawnedTargets={_targetCount} " +
                        $"cpuMs={elapsed.ToString("0.###", CultureInfo.InvariantCulture)}");
      if (_sample > 0)
      {
        Times.Add(elapsed);
      }
      After(0.75f, CompleteSample);
      return true;
    }
    catch (Exception ex)
    {
      FailBenchmark(ex);
      return false;
    }
  }

  private static void FailBenchmark(Exception ex)
  {
    try
    {
      var spellName = _spell != null ? FourCc.GetString(_spell.Id) : "unknown";
      var result = $"BENCH_ERROR spell={spellName} fixture={GetFixtureName()} error={ex.Message}";
      Console.WriteLine(result);
      WriteLocalReport(result);
      if (_owner != null)
      {
        _owner.DisplayTextTo($"{spellName} benchmark failed: {ex.Message}. Report: CustomMapData/{ReportPath}.");
      }
    }
    finally
    {
      try
      {
        CleanupTargets();
      }
      finally
      {
        DisposeAndReset();
      }
    }
  }

  private static void DisposeAndReset()
  {
    var caster = _caster;
    _caster = null;
    _spell = null;
    _owner = null;
    _friendlyTargets = false;
    _airTargets = false;
    _rightTargets = false;
    _running = false;
    caster?.Dispose();
  }

  private static void CompleteSample()
  {
    try
    {
      CleanupTargets();
      _sample++;
      if (_sample <= _sampleCount)
      {
        After(0.2f, () => RunSample());
        return;
      }

      var average = Times.Average();
      var spellName = FourCc.GetString(_spell!.Id);
      var result = $"BENCH_RESULT spell={spellName} scope=scripted-oncast fixture={GetFixtureName()} " +
                   $"spawnedTargets={_targetCount} samples={_sampleCount} " +
                   $"avgCpuMs={average.ToString("0.###", CultureInfo.InvariantCulture)} " +
                   $"cpuMs=[{string.Join(",", Times.Select(x => x.ToString("0.###", CultureInfo.InvariantCulture)))}]";
      Console.WriteLine(result);
      WriteLocalReport(result);
      _owner!.DisplayTextTo($"{spellName} OnCast: {average.ToString("0.###", CultureInfo.InvariantCulture)}ms average. " +
                            $"Report: CustomMapData/{ReportPath}.");
      DisposeAndReset();
    }
    catch (Exception ex)
    {
      FailBenchmark(ex);
    }
  }

  private static void CreateTargets()
  {
    const double goldenAngle = 2.399963229728653;
    var owner = _friendlyTargets ? _owner! : player.NeutralAggressive;
    var unitTypeId = _airTargets ? UNIT_HGRY_GRYPHON_RIDER_IRONFORGE : UNIT_HFOO_FOOTMAN_LORDAERON;
    for (var i = 0; i < _targetCount; i++)
    {
      var distance = 15 + (TargetFieldRadius - 15) * Math.Sqrt((i + 0.5) / _targetCount);
      var angle = i * goldenAngle;
      var x = _targetCenter.X + (float)(distance * Math.Cos(angle));
      var y = _targetCenter.Y + (float)(distance * Math.Sin(angle));
      var target = unit.Create(owner, unitTypeId, x, y, 0);
      target.SetPathing(false);
      target.X = x;
      target.Y = y;
      target.MaxLife = 10000;
      target.Life = _friendlyTargets ? 5000 : 10000;
      target.MaxMana = 10000;
      target.Mana = 10000;
      target.SetPausedEx(true);
      Targets.Add(target);
    }
  }

  private static void CleanupTargets()
  {
    var targets = Targets.ToList();
    Targets.Clear();
    foreach (var target in targets)
    {
      target.SetPausedEx(false);
      target.Dispose();
    }
  }

  private static void WriteLocalReport(string report)
  {
    if (_owner == null || player.LocalPlayer != _owner)
    {
      return;
    }
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
    var timer = WCSharp.Api.timer.Create();
    timer.Start(delay, false, () =>
    {
      timer.Dispose();
      action();
    });
  }

#pragma warning disable CS0626
  /// @CSharpLua.Template = "os.clock()"
  private static extern double Now();
#pragma warning restore CS0626
}
