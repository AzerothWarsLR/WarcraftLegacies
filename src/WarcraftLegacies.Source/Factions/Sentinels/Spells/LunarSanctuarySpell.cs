using MacroTools.DummyCasters;
using MacroTools.Hazards;
using MacroTools.Spells;
using MacroTools.Utils;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions.Sentinels.Spells;

public sealed class LunarSanctuaryEffectSettings
{
  public string? GlowPath { get; init; }
  public float GlowScale { get; init; } = 1;
  public string? RingPath { get; init; }
  public float RingScale { get; init; } = 1;
  public (int Red, int Green, int Blue) RingColor { get; init; } = (255, 255, 255);
  public int RingAlpha { get; init; } = 255;
  public string? BurstPath { get; init; }
  public float BurstScale { get; init; } = 1;
  public string? HealPath { get; init; }
}

public sealed class LunarSanctuarySpell : Spell
{
  public required float Radius { get; init; }
  public required float Duration { get; init; }
  public required float PulsePeriod { get; init; }
  public required LeveledAbilityField<float> HealPerPulse { get; init; }
  public required LeveledAbilityField<float> ManaPerPulse { get; init; }
  public required int SlowAuraAbilityId { get; init; }
  public required int TrueSightAbilityId { get; init; }
  public required LunarSanctuaryEffectSettings Effects { get; init; }

  public LunarSanctuarySpell(int id) : base(id)
  {
  }

  public override void OnCast(unit caster, unit target, Point targetPoint)
  {
    var level = GetAbilityLevel(caster);
    HazardSystem.Add(new LunarSanctuaryHazard(caster, targetPoint.X, targetPoint.Y)
    {
      Radius = Radius,
      Heal = HealPerPulse.GetValue(level),
      Mana = ManaPerPulse.GetValue(level),
      AbilityLevel = level,
      SlowAuraAbilityId = SlowAuraAbilityId,
      TrueSightAbilityId = TrueSightAbilityId,
      Effects = Effects,
      Interval = PulsePeriod,
      Duration = Duration
    });
  }
}

public sealed class LunarSanctuaryHazard : Hazard
{
  private readonly unit _caster;
  private unit? _auraCarrier;
  private effect? _glowEffect;
  private effect? _ringEffect;

  public float Radius { get; init; }
  public float Heal { get; init; }
  public float Mana { get; init; }
  public int AbilityLevel { get; init; }
  public int SlowAuraAbilityId { get; init; }
  public int TrueSightAbilityId { get; init; }
  public required LunarSanctuaryEffectSettings Effects { get; init; }

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

    if (Effects.BurstPath != null)
    {
      var burst = effect.Create(Effects.BurstPath, Position.X, Position.Y);
      burst.Scale = Effects.BurstScale;
      burst.Dispose();
    }

    if (Effects.GlowPath != null)
    {
      _glowEffect = effect.Create(Effects.GlowPath, Position.X, Position.Y);
      _glowEffect.Scale = Effects.GlowScale;
    }

    if (Effects.RingPath != null)
    {
      _ringEffect = effect.Create(Effects.RingPath, Position.X, Position.Y);
      _ringEffect.Scale = Effects.RingScale;
      _ringEffect.SetColor(Effects.RingColor.Red, Effects.RingColor.Green, Effects.RingColor.Blue);
      _ringEffect.SetAlpha(Effects.RingAlpha);
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

      if (wasHurt && Effects.HealPath != null)
      {
        effect.Create(Effects.HealPath, target, "origin").Dispose();
      }
    }
  }

  protected override void OnDispose()
  {
    _glowEffect?.Dispose();
    _ringEffect?.Dispose();
    _auraCarrier?.Dispose();
  }
}
