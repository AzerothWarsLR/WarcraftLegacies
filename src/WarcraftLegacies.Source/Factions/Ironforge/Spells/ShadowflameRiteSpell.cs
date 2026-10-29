using System.Collections.Generic;
using MacroTools.Channels;
using MacroTools.DummyCasters;
using MacroTools.Spells;
using MacroTools.Utils;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions.Ironforge.Spells;

/// <summary>Moira channels shadowflame around her, damaging enemies and healing friends each second.</summary>
public sealed class ShadowflameRiteSpell : Spell
{
  public required LeveledAbilityField<float> DamagePerSecond { get; init; }
  public required LeveledAbilityField<float> HealPerSecond { get; init; }
  public required float Radius { get; init; }
  public required string RingEffectPath { get; init; }
  public required int RingRed { get; init; }
  public required int RingGreen { get; init; }
  public required int RingBlue { get; init; }
  public required string DamageEffectPath { get; init; }
  public required string HealEffectPath { get; init; }

  public ShadowflameRiteSpell(int id) : base(id)
  {
  }

  /// <inheritdoc />
  public override void OnCast(unit caster, unit target, Point targetPoint)
  {
    var level = caster.GetAbilityLevel(Id);
    ChannelManager.Add(new ShadowflameRiteChannel(caster, Id)
    {
      Interval = 1,
      DamagePerSecond = DamagePerSecond.GetValue(level),
      HealPerSecond = HealPerSecond.GetValue(level),
      Radius = Radius,
      RingEffectPath = RingEffectPath,
      RingRed = RingRed,
      RingGreen = RingGreen,
      RingBlue = RingBlue,
      DamageEffectPath = DamageEffectPath,
      HealEffectPath = HealEffectPath
    });
  }
}

/// <summary>The channel behind <see cref="ShadowflameRiteSpell"/>.</summary>
public sealed class ShadowflameRiteChannel : Channel
{
  private const int RingEffectCount = 12;
  private readonly List<effect> _ring = new();

  public required float DamagePerSecond { get; init; }
  public required float HealPerSecond { get; init; }
  public required float Radius { get; init; }
  public required string RingEffectPath { get; init; }
  public required int RingRed { get; init; }
  public required int RingGreen { get; init; }
  public required int RingBlue { get; init; }
  public required string DamageEffectPath { get; init; }
  public required string HealEffectPath { get; init; }

  public ShadowflameRiteChannel(unit caster, int spellId) : base(caster, spellId)
  {
  }

  /// <inheritdoc />
  public override void OnCreate()
  {
    for (var i = 0; i < RingEffectCount; i++)
    {
      var angle = 2 * MathEx.Pi * i / RingEffectCount;
      var fx = effect.Create(RingEffectPath, Caster.X + Radius * Cos(angle), Caster.Y + Radius * Sin(angle));
      BlzSetSpecialEffectColor(fx, RingRed, RingGreen, RingBlue);
      _ring.Add(fx);
    }
  }

  /// <inheritdoc />
  protected override void OnPeriodic()
  {
    foreach (var other in GlobalGroup.EnumUnitsInRange(Caster.X, Caster.Y, Radius))
    {
      if (!other.Alive || other.IsUnitType(unittype.Structure) || other.UnitType == DummyCasterManager.UnitTypeId)
      {
        continue;
      }

      if (other.IsEnemyTo(Caster.Owner))
      {
        Caster.DealDamage(other, DamagePerSecond, false, false, attacktype.Magic, damagetype.Magic, weapontype.WhoKnows);
        AddSpecialEffectTarget(DamageEffectPath, other, "chest").Dispose();
      }
      else if (other.IsAllyTo(Caster.Owner))
      {
        other.Life += HealPerSecond;
        AddSpecialEffectTarget(HealEffectPath, other, "origin").Dispose();
      }
    }
  }

  /// <inheritdoc />
  protected override void OnDispose()
  {
    foreach (var fx in _ring)
    {
      fx.Dispose();
    }

    _ring.Clear();
  }
}
