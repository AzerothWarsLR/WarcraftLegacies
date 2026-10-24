using MacroTools.DummyCasters;
using MacroTools.Spells;
using MacroTools.Utils;
using WCSharp.Missiles;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions.BansheesHost.Spells;

/// <summary>Fires an arrow that wails on impact, damaging and silencing enemies around it, then wails again.</summary>
public sealed class WailingArrowSpell : Spell
{
  public required LeveledAbilityField<float> ImpactDamage { get; init; }
  public required LeveledAbilityField<float> WailDamage { get; init; }
  public required float Radius { get; init; }
  public required float SecondWailDelay { get; init; }
  public required int SilenceAbilityId { get; init; }
  public required int SilenceLevel { get; init; }
  public required string ArrowPath { get; init; }
  public required string WailEffectPath { get; init; }

  public WailingArrowSpell(int id) : base(id)
  {
  }

  public override void OnCast(unit caster, unit target, Point targetPoint)
  {
    var level = GetAbilityLevel(caster);
    MissileSystem.Add(new WailingArrowMissile(caster, target)
    {
      EffectString = ArrowPath,
      Speed = 1400,
      Arc = 0.15f,
      CasterLaunchZ = 60,
      TargetImpactZ = 60,
      Spell = this,
      ImpactDamage = ImpactDamage.GetValue(level),
      WailDamage = WailDamage.GetValue(level),
      Active = true
    });
  }

  /// <summary>Damages enemies around the point, silencing them if <paramref name="silences"/> is true.</summary>
  public void Wail(unit caster, float x, float y, float damage, bool silences)
  {
    effect.Create(WailEffectPath, x, y).Dispose();
    foreach (var nearby in GlobalGroup.EnumUnitsInRange(x, y, Radius))
    {
      if (CastFilters.IsTargetEnemyAndAliveUnits(caster, nearby) && nearby.UnitType != DummyCasterManager.UnitTypeId)
      {
        caster.DealDamage(nearby, damage, false, false, attacktype.Normal, damagetype.Magic, weapontype.WhoKnows);
      }
    }

    if (silences)
    {
      DummyCasterManager.GetGlobalDummyCaster()
        .CastPoint(caster.Owner, SilenceAbilityId, ORDER_SILENCE, SilenceLevel, new Point(x, y));
    }
  }
}

/// <summary>The arrow fired by <see cref="WailingArrowSpell"/>.</summary>
public sealed class WailingArrowMissile : BasicMissile
{
  public required WailingArrowSpell Spell { get; init; }
  public required float ImpactDamage { get; init; }
  public required float WailDamage { get; init; }

  public WailingArrowMissile(unit caster, unit target) : base(caster, target)
  {
  }

  public override void OnImpact()
  {
    var x = MissileX;
    var y = MissileY;
    if (Target != null && Target.Alive)
    {
      Caster.DealDamage(Target, ImpactDamage, false, false, attacktype.Normal, damagetype.Magic, weapontype.WhoKnows);
    }

    Spell.Wail(Caster, x, y, WailDamage, true);
    var caster = Caster;
    var spell = Spell;
    var wailDamage = WailDamage;
    var echo = timer.Create();
    echo.Start(spell.SecondWailDelay, false, () =>
    {
      spell.Wail(caster, x, y, wailDamage, false);
      echo.Dispose();
    });
  }
}
