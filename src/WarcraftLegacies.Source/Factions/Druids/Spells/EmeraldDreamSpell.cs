using MacroTools.Hazards;
using MacroTools.Spells;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions.Druids.Spells;

public sealed class EmeraldDreamEffectSettings
{
  public string? DreamPath { get; init; }
  public string? FlashPath { get; init; }
  public string? SleepPath { get; init; }
  public string? BurstPath { get; init; }
  public string? SoundLabel { get; init; }
  public (int Red, int Green, int Blue, int Alpha) DreamTint { get; init; } = (255, 255, 255, 255);
}

public sealed class EmeraldDreamSpell : Spell
{
  public required LeveledAbilityField<float> DreamDuration { get; init; }
  public required LeveledAbilityField<float> HealFraction { get; init; }
  public required LeveledAbilityField<float> ManaFraction { get; init; }
  public required float TickPeriod { get; init; }
  public required EmeraldDreamEffectSettings Effects { get; init; }

  public EmeraldDreamSpell(int id) : base(id)
  {
  }

  public override void OnCast(unit caster, unit target, Point targetPoint)
  {
    var level = GetAbilityLevel(caster);
    var duration = DreamDuration.GetValue(level);
    HazardSystem.Add(new EmeraldDreamHazard(caster, target)
    {
      HealFraction = HealFraction.GetValue(level),
      ManaFraction = ManaFraction.GetValue(level),
      TotalDuration = duration,
      Effects = Effects,
      Interval = TickPeriod,
      Duration = duration
    });
  }
}

public sealed class EmeraldDreamHazard : Hazard
{
  private readonly unit _target;
  private effect? _dreamEffect;
  private effect? _sleepEffect;
  private sound? _dreamSound;
  private float _shareApplied;

  public float HealFraction { get; init; }
  public float ManaFraction { get; init; }
  public float TotalDuration { get; init; }
  public required EmeraldDreamEffectSettings Effects { get; init; }

  public EmeraldDreamHazard(unit caster, unit target) : base(caster, target.X, target.Y)
  {
    _target = target;
  }

  public override void OnCreate()
  {
    _target.IsInvulnerable = true;
    _target.SetPausedEx(true);
    _target.SetVertexColor(Effects.DreamTint.Red, Effects.DreamTint.Green, Effects.DreamTint.Blue,
      Effects.DreamTint.Alpha);

    if (Effects.DreamPath != null)
    {
      _dreamEffect = effect.Create(Effects.DreamPath, _target, "origin");
    }

    if (Effects.SleepPath != null)
    {
      _sleepEffect = effect.Create(Effects.SleepPath, _target, "overhead");
    }

    if (Effects.BurstPath != null)
    {
      effect.Create(Effects.BurstPath, _target, "origin").Dispose();
    }

    if (Effects.SoundLabel != null)
    {
      _dreamSound = sound.CreateFromLabel(Effects.SoundLabel, true, true, true, 10, 10);
      _dreamSound.AttachToUnit(_target);
      _dreamSound.Start();
    }

    PlayFlash();
  }

  protected override void OnPeriodic()
  {
    if (!_target.Alive)
    {
      Duration = 0;
      return;
    }

    Restore(Interval / TotalDuration);
  }

  protected override void OnDispose()
  {
    if (_target.Alive)
    {
      Restore(1 - _shareApplied);
    }

    _dreamEffect?.Dispose();
    _sleepEffect?.Dispose();
    _dreamSound?.Stop(true, true);
    _target.SetPausedEx(false);
    _target.IsInvulnerable = false;
    _target.SetVertexColor(255, 255, 255, 255);
    PlayFlash();
  }

  private void Restore(float share)
  {
    if (share <= 0)
    {
      return;
    }

    _shareApplied += share;
    _target.Life += _target.MaxLife * HealFraction * share;
    _target.Mana += _target.MaxMana * ManaFraction * share;
  }

  private void PlayFlash()
  {
    if (Effects.FlashPath != null)
    {
      effect.Create(Effects.FlashPath, _target, "origin").Dispose();
    }
  }
}
