using MacroTools.DummyCasters;
using MacroTools.Hazards;
using MacroTools.Spells;
using MacroTools.Utils;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions.Sentinels.Spells;

public sealed class LunarSanctuarySpell : Spell
{
  public required float Radius { get; init; }
  public required float Duration { get; init; }
  public required float Period { get; init; }
  public required LeveledAbilityField<float> HealPerPeriod { get; init; }
  public required LeveledAbilityField<float> ManaPerPeriod { get; init; }
  public required int SlowAuraAbilityId { get; init; }
  public required int TrueSightAbilityId { get; init; }
  public string? SanctuaryEffectPath { get; init; }
  public string? HealEffectPath { get; init; }

  public LunarSanctuarySpell(int id) : base(id)
  {
  }

  public override void OnCast(unit caster, unit target, Point targetPoint)
  {
    var level = GetAbilityLevel(caster);
    HazardSystem.Add(new LunarSanctuaryHazard(caster, targetPoint.X, targetPoint.Y)
    {
      Radius = Radius,
      Heal = HealPerPeriod.GetValue(level),
      Mana = ManaPerPeriod.GetValue(level),
      AbilityLevel = level,
      SlowAuraAbilityId = SlowAuraAbilityId,
      TrueSightAbilityId = TrueSightAbilityId,
      SanctuaryEffectPath = SanctuaryEffectPath,
      HealEffectPath = HealEffectPath,
      Interval = Period,
      Duration = Duration
    });
  }
}

public sealed class LunarSanctuaryHazard : Hazard
{
  private readonly unit _caster;
  private unit? _auraCarrier;
  private effect? _sanctuaryEffect;

  public float Radius { get; init; }
  public float Heal { get; init; }
  public float Mana { get; init; }
  public int AbilityLevel { get; init; }
  public int SlowAuraAbilityId { get; init; }
  public int TrueSightAbilityId { get; init; }
  public string? SanctuaryEffectPath { get; init; }
  public string? HealEffectPath { get; init; }

  public LunarSanctuaryHazard(unit caster, float x, float y) : base(caster, x, y)
  {
    _caster = caster;
  }

  public override void OnCreate()
  {
    _auraCarrier = unit.Create(_caster.Owner, DummyCasterManager.UnitTypeId, Position.X, Position.Y, 0);
    _auraCarrier.AddAbility(SlowAuraAbilityId);
    _auraCarrier.SetAbilityLevel(SlowAuraAbilityId, AbilityLevel);
    _auraCarrier.AddAbility(TrueSightAbilityId);

    if (SanctuaryEffectPath != null)
    {
      _sanctuaryEffect = effect.Create(SanctuaryEffectPath, Position.X, Position.Y);
    }
  }

  protected override void OnPeriodic()
  {
    foreach (var target in GlobalGroup.EnumUnitsInRange(Position.X, Position.Y, Radius))
    {
      if (!CastFilters.IsTargetAllyAndAlive(_caster, target))
      {
        continue;
      }

      var wasHurt = target.Life < target.MaxLife;
      target.Life += Heal;
      target.Mana += Mana;

      if (wasHurt && HealEffectPath != null)
      {
        effect.Create(HealEffectPath, target, "origin").Dispose();
      }
    }
  }

  protected override void OnDispose()
  {
    _sanctuaryEffect?.Dispose();
    _auraCarrier?.Dispose();
  }
}
