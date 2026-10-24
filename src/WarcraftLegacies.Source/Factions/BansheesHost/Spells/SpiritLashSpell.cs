using MacroTools.DummyCasters;
using MacroTools.Spells;
using MacroTools.Utils;
using WCSharp.Missiles;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions.BansheesHost.Spells;

/// <summary>Sends a spirit through a line of enemies, damaging and silencing each one it passes.</summary>
public sealed class SpiritLashSpell : Spell
{
  public required LeveledAbilityField<float> Damage { get; init; }
  public required float Range { get; init; }
  public required float Width { get; init; }
  public required float Speed { get; init; }
  public required int SilenceAbilityId { get; init; }
  public required int SilenceLevel { get; init; }
  public required string SpiritPath { get; init; }
  public required string HitEffectPath { get; init; }

  public SpiritLashSpell(int id) : base(id)
  {
  }

  public override void OnCast(unit caster, unit target, Point targetPoint)
  {
    var angle = MathEx.GetAngleBetweenPoints(caster.X, caster.Y, targetPoint.X, targetPoint.Y);
    var end = new Point(MathEx.GetPolarOffsetX(caster.X, Range, angle), MathEx.GetPolarOffsetY(caster.Y, Range, angle));
    MissileSystem.Add(new SpiritLashMissile(caster.Owner, caster.X, caster.Y, end.X, end.Y)
    {
      Caster = caster,
      EffectString = SpiritPath,
      Speed = Speed,
      CollisionRadius = Width,
      CasterLaunchZ = 60,
      TargetImpactZ = 60,
      Damage = Damage.GetValue(GetAbilityLevel(caster)),
      SilenceAbilityId = SilenceAbilityId,
      SilenceLevel = SilenceLevel,
      HitEffectPath = HitEffectPath,
      Active = true
    });
  }
}

/// <summary>The spirit sent out by <see cref="SpiritLashSpell"/>.</summary>
public sealed class SpiritLashMissile : BasicMissile
{
  public required float Damage { get; init; }
  public required int SilenceAbilityId { get; init; }
  public required int SilenceLevel { get; init; }
  public required string HitEffectPath { get; init; }

  public SpiritLashMissile(player castingPlayer, float casterX, float casterY, float targetX, float targetY) :
    base(castingPlayer, casterX, casterY, targetX, targetY)
  {
  }

  public override void OnCollision(unit unit)
  {
    if (!CastFilters.IsTargetEnemyAndAliveUnits(Caster, unit) || unit.UnitType == DummyCasterManager.UnitTypeId)
    {
      return;
    }

    effect.Create(HitEffectPath, unit, "chest").Dispose();
    Caster.DealDamage(unit, Damage, false, false, attacktype.Normal, damagetype.Magic, weapontype.WhoKnows);
    DummyCasterManager.GetGlobalDummyCaster()
      .CastPoint(Caster.Owner, SilenceAbilityId, ORDER_SILENCE, SilenceLevel, new Point(unit.X, unit.Y));
  }
}
