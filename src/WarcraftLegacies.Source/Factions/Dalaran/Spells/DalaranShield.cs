using System;
using System.Collections.Generic;
using System.Linq;
using MacroTools.Extensions;
using MacroTools.Legends;
using MacroTools.Spells;
using MacroTools.Utils;
using WCSharp.Buffs;
using WCSharp.Effects;
using WCSharp.Events;
using WCSharp.Shared.Data;
using WCSharp.Shared.Extensions;

namespace WarcraftLegacies.Source.Factions.Dalaran.Spells;

public sealed class DalaranShield : Spell
{
  public Point Center { get; init; }

  public float MaxRadius { get; init; }

  public float MaxEffectScale { get; init; } = 1f;

  public float GrowthDuration { get; init; }

  public float TotalDuration { get; init; }

  public float TickInterval { get; init; }

  public float DamagePerTick { get; init; }

  public string DomeEffectPath { get; init; } = string.Empty;

  public string GroundEffectPath { get; init; } = string.Empty;

  public float GroundEffectScale { get; init; } = 1f;

  public float GroundEffectSpacing { get; init; } = 400f;

  public float GroundEffectEdgeMargin { get; init; } = 150f;

  public float ShrinkDuration { get; init; } = 3f;

  public required Legend RequiredHero { get; init; }

  public float RequiredHeroRange { get; init; } = 200f;

  private unit? _caster;
  private unit? _hero;
  private effect? _domeEffect;
  private readonly List<GroundEffectSlot> _groundEffectSlots = new();
  private float _elapsed;
  private float _sinceLastTick;
  private float _currentScale;
  private float _shrinkElapsed;
  private bool _isShrinking;

  public DalaranShield(int id) : base(id)
  {
    PeriodicEvents.AddPeriodicEvent(OnPeriodic);
  }

  public override void OnCast(unit caster, unit target, Point targetPoint)
  {
    var hero = RequiredHero.Unit;
    if (hero == null || !hero.Alive ||
        MathEx.GetDistanceBetweenPoints(caster.GetPosition(), hero.GetPosition()) > RequiredHeroRange)
    {
      caster.Owner.DisplayTextTo("|cffffcc00Antonidas must be next to the Power Generator to use this ability.|r");

      var cooldownResetTimer = CreateTimer();
      TimerStart(cooldownResetTimer, 0, false, () =>
      {
        BlzEndUnitAbilityCooldown(caster, Id);
        DestroyTimer(cooldownResetTimer);
      });
      return;
    }

    _caster = caster;
    _hero = hero;
    _elapsed = 0;
    _sinceLastTick = 0;
    _isShrinking = false;
    var casterPosition = caster.GetPosition();
    _domeEffect = effect.Create(DomeEffectPath, casterPosition.X, casterPosition.Y);
    BlzSetSpecialEffectScale(_domeEffect, 0.01f);

    _groundEffectSlots.Clear();
    var groundRadius = MaxRadius - GroundEffectEdgeMargin;
    for (var offsetX = -groundRadius; offsetX <= groundRadius; offsetX += GroundEffectSpacing)
    {
      for (var offsetY = -groundRadius; offsetY <= groundRadius; offsetY += GroundEffectSpacing)
      {
        var distance = MathF.Sqrt(offsetX * offsetX + offsetY * offsetY);
        if (distance <= groundRadius)
        {
          _groundEffectSlots.Add(new GroundEffectSlot
          {
            Position = new Point(casterPosition.X + offsetX, casterPosition.Y + offsetY),
            Distance = distance
          });
        }
      }
    }

    _hero.FacePosition(casterPosition);
    SetUnitAnimation(_hero, "channel");
    _hero.SetPausedEx(true);
    _hero.IsInvulnerable = true;
  }

  private bool OnPeriodic()
  {
    if (_isShrinking)
    {
      TickShrink();
      return true;
    }

    if (_caster == null || _domeEffect == null)
    {
      return true;
    }

    if (!_caster.Alive || _elapsed >= TotalDuration)
    {
      BeginShrink();
      return true;
    }

    _elapsed += PeriodicEvents.SYSTEM_INTERVAL;
    _sinceLastTick += PeriodicEvents.SYSTEM_INTERVAL;

    var growth = _elapsed >= GrowthDuration ? 1f : _elapsed / GrowthDuration;
    var currentRadius = MaxRadius * growth;
    _currentScale = MaxEffectScale * growth;
    BlzSetSpecialEffectScale(_domeEffect, _currentScale);

    foreach (var slot in _groundEffectSlots)
    {
      if (slot.Instance == null && slot.Distance <= currentRadius)
      {
        slot.Instance = effect.Create(GroundEffectPath, slot.Position.X, slot.Position.Y);
        BlzSetSpecialEffectScale(slot.Instance, GroundEffectScale);
      }
    }

    if (_sinceLastTick >= TickInterval)
    {
      _sinceLastTick -= TickInterval;
      DamageUndeadInside(currentRadius);
    }

    return true;
  }

  /// <summary>
  /// Ends the shield early, if it's currently active.
  /// </summary>
  public void Cancel()
  {
    if (_caster == null)
    {
      return;
    }

    BeginShrink();
  }

  private void BeginShrink()
  {
    _caster = null;

    if (_hero != null)
    {
      _hero.SetPausedEx(false);
      _hero.IsInvulnerable = false;
      IssueImmediateOrder(_hero, "stop");
      _hero = null;
    }

    if (_domeEffect == null)
    {
      return;
    }

    _shrinkElapsed = 0;
    _isShrinking = true;
  }

  private void TickShrink()
  {
    if (_domeEffect == null)
    {
      _isShrinking = false;
      return;
    }

    _shrinkElapsed += PeriodicEvents.SYSTEM_INTERVAL;

    if (_shrinkElapsed >= ShrinkDuration)
    {
      _domeEffect.Dispose();
      _domeEffect = null;

      foreach (var slot in _groundEffectSlots)
      {
        slot.Instance?.Dispose();
      }

      _groundEffectSlots.Clear();
      _isShrinking = false;
      return;
    }

    var remainingFraction = 1f - _shrinkElapsed / ShrinkDuration;
    BlzSetSpecialEffectScale(_domeEffect, _currentScale * remainingFraction);

    var shrinkRadius = MaxRadius * remainingFraction;
    foreach (var slot in _groundEffectSlots)
    {
      if (slot.Instance != null && slot.Distance > shrinkRadius)
      {
        slot.Instance.Dispose();
        slot.Instance = null;
      }
    }
  }

  private void DamageUndeadInside(float radius)
  {
    var targets = GlobalGroup
      .EnumUnitsInRange(Center, radius)
      .Where(x => x.Alive && x.IsUnitType(unittype.Undead));

    foreach (var target in targets)
    {
      target.Damage(_caster, DamagePerTick, attacktype.Normal);
      BuffSystem.Add(new DalaranShieldBuff(_caster, target)
      {
        Active = true,
        Duration = TickInterval + 1f,
        IsBeneficial = false
      });
    }
  }

  private sealed class GroundEffectSlot
  {
    public required Point Position { get; init; }
    public required float Distance { get; init; }
    public effect? Instance { get; set; }
  }
}
